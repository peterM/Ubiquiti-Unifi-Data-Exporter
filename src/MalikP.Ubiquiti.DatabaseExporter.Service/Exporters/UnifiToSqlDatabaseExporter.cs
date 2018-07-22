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
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MalikP.Ubiquiti.DatabaseExporter.Data.Core;
using MalikP.Ubiquiti.DatabaseExporter.Data.Core.Factory;
using MalikP.Ubiquiti.DatabaseExporter.Datasource;
using MalikP.Ubiquiti.DatabaseExporter.Service.Decisions;
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

        IMongoDataSource _mongoDataSource;

        public UnifiToSqlDatabaseExporter(
            ICheckerCommandCreatorProvider checkerCommandCreatorProvider,
            IWriterCommandCreatorProvider writerCommandCreatorProvider,
            IDatabaseChecker checker,
            IDatabaseWriter writer,
            ICustomLogger customLogger)
        {
            _checkerCommandCreatorProvider = checkerCommandCreatorProvider;
            _writerCommandCreatorProvider = writerCommandCreatorProvider;
            _checker = checker;
            _writer = writer;
            _customLogger = customLogger;
        }

        public void SetUnifiDataSource(IMongoDataSource mongoDataSource)
        {
            _mongoDataSource = mongoDataSource;
        }

        public Task ExportAsync(string databaseName, string collectionName, CancellationToken cancellationToken)
        {
            if (!string.Equals(collectionName, "system.indexes"))
            {
                var documents = _mongoDataSource.GetCollectionJsonDocuments(databaseName, collectionName);
                var itemNumber = 0;
                foreach (string jsonDocument in documents)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    var count = documents.Count();
                    itemNumber++;

                    string id = GetId(jsonDocument);

                    _customLogger.WriteMessage($"Collection Name: {collectionName} | Check: {itemNumber} / {count}");
                    var checkCommand = _checkerCommandCreatorProvider.GetCommandCreator(databaseName, collectionName, id);
                    if (checkCommand != null && !_checker.Check(checkCommand))
                    {
                        var writeCommand = _writerCommandCreatorProvider.GetCommandCreator(databaseName, collectionName, id, jsonDocument);
                        if (writeCommand != null)
                        {
                            _customLogger.WriteMessage($"Collection Name: {collectionName} | Write {itemNumber} / {count}", EventLogEntryType.Warning);
                            if (_writer.Write(writeCommand))
                            {
                                _customLogger.WriteMessage($"Collection Name: {collectionName} | Write {itemNumber} / {count} was written into database.", EventLogEntryType.Warning);
                            }
                            else
                            {
                                _customLogger.WriteMessage($"Collection Name: {collectionName} | Write {itemNumber} / {count} was NOT written into database.", EventLogEntryType.Error);
                            }
                        }
                    }
                }
            }

            return Task.CompletedTask;
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
