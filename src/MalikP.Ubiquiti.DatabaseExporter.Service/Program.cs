﻿// Copyright (c) 2018 Peter M.
// 
// File: Program.cs 
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
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceProcess;
using MalikP.Cryptography.Encryptors.Asymmetric;
using MalikP.Cryptography.Identifiers;
using MalikP.Cryptography.Obtainers;
using MalikP.IoC.Core;
using MalikP.IoC.Factory;
using MalikP.IoC.Locator;
using MalikP.IoC.Registrations;
using MalikP.IoC.Strategies;
using MalikP.Ubiquiti.DatabaseExporter.Common;
using MalikP.Ubiquiti.DatabaseExporter.Data.Core;
using MalikP.Ubiquiti.DatabaseExporter.Data.Core.Factory;
using MalikP.Ubiquiti.DatabaseExporter.Datasource;
using MalikP.Ubiquiti.DatabaseExporter.IO;
using MalikP.Ubiquiti.DatabaseExporter.Service.Exporters;
using MalikP.Ubiquiti.DatabaseExporter.Service.Decisions;
using MalikP.Ubiquiti.DatabaseExporter.Service.Schedulers;
using MalikP.Ubiquiti.DatabaseExporter.SSHTuneling;
using MalikP.Ubiquiti.DatabaseExporter.Service.Loggers;
using MalikP.Ubiquiti.DatabaseExporter.Data.Core.Credentials;
using System.Threading.Tasks;

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
                Console.ReadKey();
            }
            else
            {
                ServiceBase.Run(service);
            }
        }

        private static void SetupInversionOfControl()
        {
            _ioc = IocLocator.Container(new AdvancedContainerFactory());

            _ioc.Register<IDirectoryWrapper, DirectoryWrapper>();

            _ioc.Register<IFileWrapper, FileWrapper>();

            if (bool.Parse(ConfigurationManager.AppSettings["Use-SSH-Tunel"]))
            {
                _ioc.Register<ISSHTunel, SSHTunel>()
                    .RegistrationBuilder<IExtendedRegistrationBuilder>()
                    .WithConstructorResolvingStrategy(ConstructorResolveStrategy.Complex);
            }

            _ioc.Register<IMongoDataSource, MongoDatabaseDataSource>()
                .RegistrationBuilder<IExtendedRegistrationBuilder>()
                .WithPrimitiveParameter<string>(ConfigurationManager.AppSettings["Mongo-Connection-String"])
                .WithConstructorResolvingStrategy(ConstructorResolveStrategy.Complex);

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
                    .RegistrationBuilder<IExtendedRegistrationBuilder>()
                    .WithPrimitiveParameter<string>(ConfigurationManager.AppSettings["Backup-Path"]);
            }

            if (bool.Parse(ConfigurationManager.AppSettings["Export-To-DB"]))
            {
                _ioc.Register<ISpecificUnifiExporter, UnifiToSqlDatabaseExporter>();
            }

            var connectionString = ConfigurationManager.AppSettings["Sql-Connection-String"];

            _ioc.Register<IDatabaseChecker, RecordCecker>()
                .RegistrationBuilder<IExtendedRegistrationBuilder>()
                .WithPrimitiveParameter<string>(connectionString);

            _ioc.Register<IDatabaseWriter, RecordWriter>()
               .RegistrationBuilder<IExtendedRegistrationBuilder>()
               .WithPrimitiveParameter<string>(connectionString);

            _ioc.Register<ICertificateIdentifier, CertificateIdentifier>()
                .RegistrationBuilder<IExtendedRegistrationBuilder>()
                .WithPrimitiveParameter<string>(ConfigurationManager.AppSettings["Encryption-Certificate-Identifier"]);

            _ioc.Register<CertificateObtainerSettings>()
                .RegistrationBuilder<IExtendedRegistrationBuilder>()
                .WithPrimitiveParameter<StoreName>(StoreName.My)
                .WithPrimitiveParameter<StoreLocation>(StoreLocation.LocalMachine)
                .WithPrimitiveParameter<X509FindType>(X509FindType.FindBySerialNumber)
                .WithConstructorResolvingStrategy(ConstructorResolveStrategy.Complex);

            _ioc.RegisterByConstructor<ICustomCredential>(provider => new EncryptedCredential(ConfigurationManager.AppSettings["Sql-User-Id"],
                                                                                              ConfigurationManager.AppSettings["Sql-User-Password"],
                                                                                              provider.Resolve<RsaCertificateEncryptor>()));

            _ioc.Register<ICertificateObtainer, CertificationStoreExactCertificateObtainer>()
                .RegistrationBuilder<IExtendedRegistrationBuilder>()
                .WithConstructorResolvingStrategy(ConstructorResolveStrategy.Complex);

            _ioc.RegisterByConstructor<RsaCertificateEncryptor>(provider => new RsaCertificateEncryptor(provider.Resolve<ICertificateObtainer>(), RSAEncryptionPadding.OaepSHA1));

            _ioc.Register<ICheckerCommandCreatorProvider, CheckerCommandCreatorProvider>();
            _ioc.Register<IWriterCommandCreatorProvider, WriterCommandCreatorProvider>();
        }
    }
}