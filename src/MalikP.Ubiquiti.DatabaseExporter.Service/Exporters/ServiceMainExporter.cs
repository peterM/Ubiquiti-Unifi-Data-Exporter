﻿// MIT License
//
// Copyright (c) 2019 Peter Malik. (MalikP.)
// 
// File: ServiceMainExporter.cs 
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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MalikP.Ubiquiti.DatabaseExporter.Common;
using MalikP.Ubiquiti.DatabaseExporter.Core.Extensions;
using MalikP.Ubiquiti.DatabaseExporter.Datasource;
using MalikP.Ubiquiti.DatabaseExporter.Service.Decisions;
using MalikP.Ubiquiti.DatabaseExporter.Service.Loggers;
using MalikP.Ubiquiti.DatabaseExporter.Service.Schedulers;

namespace MalikP.Ubiquiti.DatabaseExporter.Service.Exporters
{
    public class ServiceMainExporter : IServiceExporter
    {
        private readonly IExportScheduler _exportScheduler;
        private readonly IProcessInterupter _processInterupter;
        private readonly IContinueDecision _continueDecision;
        private readonly IMongoDataSource _mongoDataSource;
        private readonly ICustomLogger _customLogger;
        private readonly IReadOnlyCollection<ISpecificUnifiExporter> _specificExporters;

        public ServiceMainExporter(
            IExportScheduler exportScheduler,
            IProcessInterupter processInterupter,
            IContinueDecision continueDecision,
            IMongoDataSource mongoDataSource,
            ICustomLogger customLogger,
            IEnumerable<ISpecificUnifiExporter> specificExporters)
        {
            _exportScheduler = exportScheduler;
            _processInterupter = processInterupter;
            _continueDecision = continueDecision;
            _mongoDataSource = mongoDataSource;
            _customLogger = customLogger;
            _specificExporters = specificExporters.ToList();

            WriteLog();
        }

        private void WriteLog()
        {
            _customLogger.WriteMessage($"There are [{_specificExporters.Count}] resolved exporters.");

            foreach (ISpecificUnifiExporter exporter in _specificExporters)
            {
                _customLogger.WriteMessage($"\tThere is [{exporter.GetType().Name}] exporter resolved.");
            }

            _customLogger.WriteMessage("\n");
        }

        public async Task ExportAsync(CancellationToken cancellationToken)
        {
            while (_continueDecision.CanContinue && !cancellationToken.IsCancellationRequested)
            {
                if (_exportScheduler.IsSignal())
                {
                    await DoAsync(cancellationToken).ConfigureAwait(false);
                    await Task.Delay(5000).ConfigureAwait(false);
                }

                await Task.Delay(1000).ConfigureAwait(false);
            }
        }

        private async Task DoAsync(CancellationToken cancellationToken)
        {
            using (IDisposable disposableTunel = _mongoDataSource.Connect())
            {
                string dataTimeStamp = DateTime.Now.ToString("dd_MM_yyyy_HH-mm-ss");
                foreach (string databaseName in _mongoDataSource.GetDatabases())
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    IEnumerable<string> collectionNames = _mongoDataSource.GetCollections(databaseName);
                    foreach (string collectionName in collectionNames)
                    {
                        _customLogger.WriteMessage($"Current collection name: {collectionName}");
                        cancellationToken.ThrowIfCancellationRequested();

                        IEnumerable<string> documents = _mongoDataSource.GetJsonDocuments(databaseName, collectionName);
                        foreach (ISpecificUnifiExporter specificExporter in _specificExporters)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            specificExporter.TryInitialize(dataTimeStamp);
                            await specificExporter.ExportAsync(databaseName, collectionName, documents, cancellationToken)
                                .ConfigureAwait(false);
                        }
                    }
                }
            }

            _processInterupter.Interupt();
        }
    }
}
