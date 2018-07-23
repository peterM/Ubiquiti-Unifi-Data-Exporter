// Copyright (c) 2018 Peter M.
// 
// File: UnifiToSqlDatabaseExporter.cs 
// Company: MalikP.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MalikP.Ubiquiti.DatabaseExporter.Data.Core;
using MalikP.Ubiquiti.DatabaseExporter.Data.Core.Factory;
using MalikP.Ubiquiti.DatabaseExporter.Datasource;
using MalikP.Ubiquiti.DatabaseExporter.Service.Loggers;
using Newtonsoft.Json.Linq;

namespace MalikP.Ubiquiti.DatabaseExporter.Service.Exporters
{
    public class UnifiToSqlDatabaseExporter : ISpecificUnifiExporter
    {
        readonly ICustomLogger _customLogger;
        readonly ICheckerCommandCreatorProvider _checkerCommandCreatorProvider;
        readonly IWriterCommandCreatorProvider _writerCommandCreatorProvider;
        readonly IDatabaseChecker _checker;
        readonly IDatabaseWriter _writer;
        readonly int _batchSize;

        IMongoDataSource _mongoDataSource;

        public UnifiToSqlDatabaseExporter(
            ICheckerCommandCreatorProvider checkerCommandCreatorProvider,
            IWriterCommandCreatorProvider writerCommandCreatorProvider,
            IDatabaseChecker checker,
            IDatabaseWriter writer,
            ICustomLogger customLogger,
            int batchSize)
        {
            _checkerCommandCreatorProvider = checkerCommandCreatorProvider;
            _writerCommandCreatorProvider = writerCommandCreatorProvider;
            _checker = checker;
            _writer = writer;
            _customLogger = customLogger;
            _batchSize = batchSize;
        }

        public void SetUnifiDataSource(IMongoDataSource mongoDataSource)
        {
            _mongoDataSource = mongoDataSource;
        }

        public Task ExportAsync(string databaseName, string collectionName, CancellationToken cancellationToken)
        {
            if (!string.Equals(collectionName, "system.indexes"))
            {
                var documents = _mongoDataSource.GetCollectionJsonDocuments(databaseName, collectionName).ToList();
                var totalCount = documents.Count;

                int logCounter1 = 0;
                int counter = 0;
                while ((counter = documents.Count) > 0)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    var documentsToProcess = documents.Take(_batchSize).ToList();

                    Dictionary<string, string> documentDictionary = new Dictionary<string, string>();
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine($"Collection Name: {collectionName} | Going to check {documentsToProcess.Count} / {totalCount} these ids:");
                    foreach (var jsonDocument in documentsToProcess)
                    {
                        documents.Remove(jsonDocument);
                        string id = GetId(jsonDocument);

                        logCounter1++;
                        stringBuilder.AppendLine($"{id} -> {logCounter1} / {totalCount}");
                        documentDictionary.Add(id, jsonDocument);
                    }

                    string concatenatedIds = string.Join(", ", documentDictionary.Keys.Select(d => $"'{d}'"));
                    var checkCommand = _checkerCommandCreatorProvider.GetCommandCreator(databaseName, collectionName, concatenatedIds);
                    if (checkCommand != null)
                    {
                        var ids = _checker.Check(checkCommand).ToList();

                        AddLines(stringBuilder, 3);
                        var documentsToProcessPairs = documentDictionary.Where(d => !ids.Any(d2 => string.Equals(d2.Value, d.Key, StringComparison.CurrentCultureIgnoreCase))).Select(d => d).ToList();

                        documentDictionary.Clear();
                        documentsToProcessPairs.ForEach(d => documentDictionary.Add(d.Key, d.Value));
                    }

                    stringBuilder.AppendLine("Going to write these ids:");
                    if (documentDictionary.Any())
                    {
                        foreach (var item in documentDictionary)
                        {
                            stringBuilder.AppendLine(item.Key);
                        }

                        AddLines(stringBuilder, 3);
                        var writeCommand = _writerCommandCreatorProvider.GetCommandCreator(databaseName, collectionName, documentDictionary);
                        if (writeCommand != null && _writer.Write(writeCommand))
                        {
                            stringBuilder.AppendLine("Ids were written");
                        }
                        else
                        {
                            stringBuilder.AppendLine("Ids were NOT written");
                        }
                    }

                    _customLogger.WriteMessage(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }

            return Task.CompletedTask;
        }

        private void AddLines(StringBuilder stringBuilder, int count)
        {
            for (int i = 0; i < count; i++)
            {
                stringBuilder.AppendLine();
            }
        }

        private string GetId(string jsonDocument)
        {
            JObject jsonDoc = JObject.Parse(jsonDocument);
            string id = null;
            try
            {
                id = jsonDoc["_id"]["$oid"].ToString();
            }
            catch (Exception)
            {
                id = jsonDoc["_id"].ToString();
            }

            return id;
        }
    }
}
