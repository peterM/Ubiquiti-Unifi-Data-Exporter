// Copyright (c) 2018 Peter M.
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

using MalikP.Cryptography.Encryptors.Asymmetric;
using MalikP.Cryptography.Identifiers;
using MalikP.Cryptography.Obtainers;
using MalikP.IoC.Core;
using MalikP.IoC.Factory;
using MalikP.IoC.Locator;
using MalikP.IoC.Registrations;
using MalikP.IoC.Strategies;
using System;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MalikP.Ubiquiti.DatabaseExporter.EncryptPasswordTool
{
    public class Program
    {
        private static IIoC _ioc;

        static async Task Main(string[] args)
        {
            SetupInversionOfControl();
            var encryptor = _ioc.Resolve<RsaCertificateEncryptor>();

            Console.WriteLine(encryptor.Encrypt(args.First()));
        }

        private static void SetupInversionOfControl()
        {
            _ioc = IocLocator.Container(new AdvancedContainerFactory());
            _ioc.Register<ICertificateIdentifier, CertificateIdentifier>()
              .RegistrationBuilder<IExtendedRegistrationBuilder>()
              .WithPrimitiveParameter<string>(ConfigurationManager.AppSettings["Encryption-Certificate-Identifier"]);

            _ioc.Register<CertificateObtainerSettings>()
                .RegistrationBuilder<IExtendedRegistrationBuilder>()
                .WithPrimitiveParameter<StoreName>(StoreName.My)
                .WithPrimitiveParameter<StoreLocation>(StoreLocation.LocalMachine)
                .WithPrimitiveParameter<X509FindType>(X509FindType.FindBySerialNumber)
                .WithConstructorResolvingStrategy(ConstructorResolveStrategy.Complex);

            _ioc.Register<ICertificateObtainer, CertificationStoreExactCertificateObtainer>()
                .RegistrationBuilder<IExtendedRegistrationBuilder>()
                .WithConstructorResolvingStrategy(ConstructorResolveStrategy.Complex);

            _ioc.RegisterByConstructor<RsaCertificateEncryptor>(provider => new RsaCertificateEncryptor(provider.Resolve<ICertificateObtainer>(), RSAEncryptionPadding.OaepSHA1));
        }
    }
}
