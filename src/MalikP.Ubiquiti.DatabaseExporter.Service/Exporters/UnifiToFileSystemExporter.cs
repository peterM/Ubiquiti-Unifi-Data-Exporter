// Copyright (c) 2018 Peter M.
// 
// File: UnifiToFileSystemExporter.cs 
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
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MalikP.Ubiquiti.DatabaseExporter.Datasource;
using MalikP.Ubiquiti.DatabaseExporter.IO;
using MalikP.Ubiquiti.DatabaseExporter.Service.Decisions;
using MalikP.Ubiquiti.DatabaseExporter.Service.Loggers;

namespace MalikP.Ubiquiti.DatabaseExporter.Service.Exporters
{
    public class UnifiToFileSystemExporter : ISpecificUnifiExporter
    {
        readonly IDirectoryWrapper _directoryWrapper;
        readonly IFileWrapper _fileWrapper;
        readonly ICustomLogger _customLogger;
        readonly string _rootPath;

        IMongoDataSource _mongoDataSource;

        public UnifiToFileSystemExporter(
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
        }

        public Task ExportAsync(string databaseName, string collectionName, CancellationToken cancellationToken)
        {
            string dataTime = DateTime.Now.ToString("dd_MM_yyyy_HH-mm-ss");

            cancellationToken.ThrowIfCancellationRequested();
            var jsonDocument = _mongoDataSource.GetCollectionJsonData(databaseName, collectionName);
            byte[] collectionData = Encoding.UTF8.GetBytes(jsonDocument);
            string path = CreateCollectionPath(_directoryWrapper, _rootPath, databaseName, dataTime);
            path = GetCollectionFilePath(collectionName, path);
            _fileWrapper.WriteAllBytes(path, collectionData);
            _customLogger.WriteMessage($"Collection Name {collectionName} saved to file system");

            return Task.CompletedTask;
        }

        public void SetUnifiDataSource(IMongoDataSource mongoDataSource)
        {
            _mongoDataSource = mongoDataSource;
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
    }
}
