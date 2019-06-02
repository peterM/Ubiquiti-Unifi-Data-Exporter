// MIT License
//
// Copyright (c) 2019 Peter Malik. (MalikP.)
// 
// File: UnifiToFileSystemExporter.cs 
// Company: MalikP.
//
// Repository: https://github.com/peterM/Ubiquiti-Unifi-Data-Exporter
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MalikP.Ubiquiti.DatabaseExporter.Core.Blacklists;
using MalikP.Ubiquiti.DatabaseExporter.Core.Interfaces;
using MalikP.Ubiquiti.DatabaseExporter.IO;
using MalikP.Ubiquiti.DatabaseExporter.Service.Loggers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MalikP.Ubiquiti.DatabaseExporter.Service.Exporters
{
    public class UnifiToFileSystemExporter : ISpecificUnifiExporter, IInitializable
    {
        readonly IBlacklist _blacklist;
        readonly IDirectoryWrapper _directoryWrapper;
        readonly IFileWrapper _fileWrapper;
        readonly ICustomLogger _customLogger;
        readonly string _rootPath;

        string _dateTimeStamp;

        public UnifiToFileSystemExporter(
            IBlacklist blacklist,
            IDirectoryWrapper directoryWrapperInstance,
            IFileWrapper fileWrapper,
            ICustomLogger customLogger,
            string rootPath)
        {
            _directoryWrapper = directoryWrapperInstance;
            _fileWrapper = fileWrapper;
            _customLogger = customLogger;
            _rootPath = rootPath;

            CheckRootPath(directoryWrapperInstance);
            _dateTimeStamp = DateTime.Now.ToString("dd_MM_yyyy_HH-mm-ss");
            _blacklist = blacklist;
        }

        public Task ExportAsync(string databaseName, string collectionName, IEnumerable<String> jsonDocuments, CancellationToken cancellationToken)
        {
            if (!_blacklist.IsBlacklisted($"{databaseName}.{collectionName}"))
            {
                cancellationToken.ThrowIfCancellationRequested();
                var jsonDocument = MergeDocumentsToCollectionJson(jsonDocuments, collectionName);
                byte[] collectionData = Encoding.UTF8.GetBytes(jsonDocument);
                string path = CreateCollectionPath(_directoryWrapper, _rootPath, databaseName, _dateTimeStamp);
                path = GetCollectionFilePath(collectionName, path);
                _fileWrapper.WriteAllBytes(path, collectionData);
                _customLogger.WriteMessage($"Collection Name {collectionName} saved to file system");
            }
            else
            {
                _customLogger.WriteMessage($"FS: Blacklisted table: [{databaseName}.{collectionName}]", EventLogEntryType.Warning);
            }

            return Task.CompletedTask;
        }

        private string MergeDocumentsToCollectionJson(IEnumerable<string> jsonDocuments, string collectionName)
        {
            byte[] result = default(byte[]);

            Dictionary<string, IEnumerable<JObject>> documents = new Dictionary<string, IEnumerable<JObject>>();
            documents.Add(collectionName, jsonDocuments.Select(JObject.Parse));

            return JsonConvert.SerializeObject(documents, Formatting.None);
        }

        private void CheckRootPath(IDirectoryWrapper directoryWrapper)
        {
            directoryWrapper.CreateWhenNonExists(_rootPath);
        }

        private string GetCollectionFilePath(string collectionName, string path)
        {
            return Path.Combine(path, $"{collectionName}.json");
        }

        private string CreateCollectionPath(IDirectoryWrapper directoryWrapper, params String[] pathChunks)
        {
            string pathResult = Path.Combine(pathChunks);
            directoryWrapper.CreateWhenNonExists(pathResult);
            return pathResult;
        }

        public IInitializable Initialize<T>(T initializationInstance)
        {
            if (typeof(T) == typeof(string))
            {
                _dateTimeStamp = initializationInstance as string;
            }

            return this;
        }
    }
}
