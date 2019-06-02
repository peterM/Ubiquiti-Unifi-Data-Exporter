// MIT License
//
// Copyright (c) 2018 Peter Malik. (MalikP.)
// 
// File: Program.cs 
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
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceProcess;
using System.Threading.Tasks;

using MalikP.Cryptography.Encryptors.Asymmetric;
using MalikP.Cryptography.Identifiers;
using MalikP.Cryptography.Obtainers;
using MalikP.IoC;
using MalikP.IoC.Strategies;
using MalikP.Ubiquiti.DatabaseExporter.Common;
using MalikP.Ubiquiti.DatabaseExporter.Core.Blacklists;
using MalikP.Ubiquiti.DatabaseExporter.Data.Core;
using MalikP.Ubiquiti.DatabaseExporter.Data.Core.Credentials;
using MalikP.Ubiquiti.DatabaseExporter.Data.Core.Factory;
using MalikP.Ubiquiti.DatabaseExporter.Datasource;
using MalikP.Ubiquiti.DatabaseExporter.IO;
using MalikP.Ubiquiti.DatabaseExporter.Service.Decisions;
using MalikP.Ubiquiti.DatabaseExporter.Service.Exporters;
using MalikP.Ubiquiti.DatabaseExporter.Service.Loggers;
using MalikP.Ubiquiti.DatabaseExporter.Service.Schedulers;
using MalikP.Ubiquiti.DatabaseExporter.SSHTuneling;

namespace MalikP.Ubiquiti.DatabaseExporter.Service
{
    static class Program
    {
        private static IIoC _ioc;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static async Task Main()
        {
            SetupInversionOfControl();

            DatabaseExporterWindowsService service = _ioc.Resolve<DatabaseExporterWindowsService>();

            if (Environment.UserInteractive)
            {
                await service.StartServiceAsync(Enumerable.Empty<string>().ToArray());

                Console.WriteLine("Press any key to exit...");

                Console.ReadKey();
            }
            else
            {
                ServiceBase.Run(service);
            }
        }

        private static void SetupInversionOfControl()
        {
            _ioc = Locator.GetContainer();

            _ioc.Register<IDirectoryWrapper, DirectoryWrapper>();

            _ioc.Register<IFileWrapper, FileWrapper>();

            if (bool.Parse(ConfigurationManager.AppSettings["Use-SSH-Tunel"]))
            {
                _ioc.Register<ISSHTunel, SSHTunel>()
                    .Extend()
                      .WithResolveStrategy(ConstructorResolveStrategy.Complex);
            }

            _ioc.Register<IMongoDataSource, MongoDatabaseDataSource>()
                .Extend()
                .WithSpecific<string>(ConfigurationManager.AppSettings["Mongo-Connection-String"])
                  .WithResolveStrategy(ConstructorResolveStrategy.Complex);

            _ioc.Register<IServiceExporter, ServiceMainExporter>();
            _ioc.Register<DatabaseExporterWindowsService>();

            if (Environment.UserInteractive)
            {
                _ioc.Register<IProcessInterupter, ConsoleProcessInterupter>();
                _ioc.Register<IExportScheduler, ConsoleScheduler>();
                _ioc.Register<IContinueDecision, ConsoleContinueDecision>();
                _ioc.Register<ICustomLogger, ConsoleLogger>();
            }
            else
            {
                _ioc.Register<IProcessInterupter, EmptyProcessInterupter>();
                _ioc.Register<IExportScheduler, ServiceScheduler>();
                _ioc.Register<IContinueDecision, ServiceContinueDecision>();
                _ioc.Register<ICustomLogger, EventLogLogger>();
            }

            if (bool.Parse(ConfigurationManager.AppSettings["Export-To-FS"]))
            {
                _ioc.Register<ISpecificUnifiExporter, UnifiToFileSystemExporter>()
                    .Extend()
                      .WithSpecific<string>(ConfigurationManager.AppSettings["Backup-Path"]);
            }

            if (bool.Parse(ConfigurationManager.AppSettings["Export-To-DB"]))
            {
                _ioc.Register<ISpecificUnifiExporter, UnifiToSqlDatabaseExporter>()
                    .Extend()
                      .WithSpecific<int>(int.Parse(ConfigurationManager.AppSettings["Sql-Batch-Size"]));
            }

            string connectionString = ConfigurationManager.AppSettings["Sql-Connection-String"];

            _ioc.Register<IDatabaseChecker, DatabaseChecker>()
                .Extend()
                  .WithSpecific<string>(connectionString);

            _ioc.Register<IDatabaseWriter, DatabaseWriter>()
               .Extend()
                 .WithSpecific<string>(connectionString);

            if (bool.Parse(ConfigurationManager.AppSettings["Use-Encrypted-Psswords"]))
            {
                _ioc.Register<ICertificateIdentifier, CertificateIdentifier>()
                    .Extend()
                      .WithSpecific<string>(ConfigurationManager.AppSettings["Encryption-Certificate-Identifier"]);

                _ioc.Register<CertificateObtainerSettings>()
                    .Extend()
                      .WithSpecific<StoreName>(StoreName.My)
                      .WithSpecific<StoreLocation>(StoreLocation.LocalMachine)
                      .WithSpecific<X509FindType>(X509FindType.FindBySerialNumber)
                      .WithResolveStrategy(ConstructorResolveStrategy.Complex);

                _ioc.Register<ICertificateObtainer, CertificationStoreExactCertificateObtainer>()
                    .Extend()
                      .WithResolveStrategy(ConstructorResolveStrategy.Complex);

                _ioc.Register<RsaCertificateEncryptor>(provider => new RsaCertificateEncryptor(provider.Resolve<ICertificateObtainer>(), RSAEncryptionPadding.OaepSHA1));

                _ioc.Register<ICustomCredential>(provider => new EncryptedCredential(ConfigurationManager.AppSettings["Sql-User-Id"],
                                                                                     ConfigurationManager.AppSettings["Sql-User-Password"],
                                                                                     provider.Resolve<RsaCertificateEncryptor>()));
            }
            else
            {
                _ioc.Register<ICustomCredential>(provider => new CustomCredential(ConfigurationManager.AppSettings["Sql-User-Id"],
                                                                                  ConfigurationManager.AppSettings["Sql-User-Password"]));
            }

            _ioc.Register<ICheckerCommandCreatorProvider, CheckerCommandCreatorProvider>();
            _ioc.Register<IWriterCommandCreatorProvider, WriterCommandCreatorProvider>();

            _ioc.Register<IBlacklistItemParser, BlacklistItemParser>();
            _ioc.Register<IBlacklist, SimpleTableBlacklist>()
                .Extend()
                  .WithSpecific<string>(ConfigurationManager.AppSettings["Blacklisted-Table-Names"]);
        }
    }
}
