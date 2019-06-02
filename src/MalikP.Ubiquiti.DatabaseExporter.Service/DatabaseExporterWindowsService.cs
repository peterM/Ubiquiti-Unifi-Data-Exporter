// MIT License
//
// Copyright (c) 2018 Peter Malik. (MalikP.)
// 
// File: DatabaseExporterWindowsService.cs 
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
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using MalikP.Ubiquiti.DatabaseExporter.Service.Exporters;

namespace MalikP.Ubiquiti.DatabaseExporter.Service
{
    public partial class DatabaseExporterWindowsService : ServiceBase
    {
        private readonly CancellationTokenSource _tokenSource;

        private Task _exporterTask;
        private IServiceExporter _databaseExporter;

        public DatabaseExporterWindowsService(IServiceExporter databaseExporter)
        {
            InitializeComponent();
            _tokenSource = new CancellationTokenSource();
            _databaseExporter = databaseExporter;
        }

        public Task StartServiceAsync(string[] args)
        {
            OnStart(args);
            return Task.CompletedTask;
        }

        public Task StopServiceAsync()
        {
            Stop();
            return Task.CompletedTask;
        }

        protected override void OnStart(string[] args)
        {
            _exporterTask = _databaseExporter.ExportAsync(_tokenSource.Token);
        }

        protected override void OnStop()
        {
            try
            {
                _tokenSource.Cancel();
            }
            catch (Exception)
            {
                _tokenSource?.Dispose();
                Debug.Write("Waiting");
            }
        }
    }
}
