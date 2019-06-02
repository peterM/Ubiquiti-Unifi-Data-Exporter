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
using System.Windows.Forms;

using MalikP.Cryptography.Encryptors.Asymmetric;
using MalikP.Cryptography.Identifiers;
using MalikP.Cryptography.Obtainers;
using MalikP.IoC;
using MalikP.IoC.Strategies;

namespace MalikP.Ubiquiti.DatabaseExporter.EncryptPasswordTool
{
    public class Program
    {
        private static IIoC _ioc;

        [STAThread]
        static void Main(string[] args)
        {
            SetupInversionOfControl();
            var encryptor = _ioc.Resolve<RsaCertificateEncryptor>();

            var arg = args.FirstOrDefault();
            if (arg == null)
            {
                return;
            }

            var encrypted = encryptor.Encrypt(arg);
            Clipboard.SetText(encrypted);

            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(encrypted);

            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Code copied to clipboard !!!");
            Console.ResetColor();

            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
        }

        private static void SetupInversionOfControl()
        {
            _ioc = Locator.GetContainer();
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
        }
    }
}
