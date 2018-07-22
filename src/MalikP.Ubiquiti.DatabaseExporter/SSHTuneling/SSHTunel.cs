// Copyright (c) 2018 Peter M.
// 
// File: SSHTunel.cs 
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
using Renci.SshNet;
using System.Configuration;

namespace MalikP.Ubiquiti.DatabaseExporter.SSHTuneling
{
    public class SSHTunel : ISSHTunel
    {
        private readonly RsaCertificateEncryptor _passwordEncryptor;

        public SSHTunel(RsaCertificateEncryptor passwordEncryptor)
        {
            _passwordEncryptor = passwordEncryptor;
        }

        // in case encrypted mode is disabled
        public SSHTunel()
        {
        }

        public SshClient OpenTunel()
        {
            var encryptedPassword = ConfigurationManager.AppSettings["SSH-Tunel-Password"];

            // in case encrypted mode is disabled
            var password = _passwordEncryptor?.Decrypt(encryptedPassword) ?? encryptedPassword;

            var tunel = new SshClient(ConfigurationManager.AppSettings["SSH-Tunel-Host"],
                                      ConfigurationManager.AppSettings["SSH-Tunel-UserName"],
                                      password);
            tunel.Connect();
            var forwardedPort = new ForwardedPortLocal(ConfigurationManager.AppSettings["SSH-Forward-Host-From"],
                                                       uint.Parse(ConfigurationManager.AppSettings["SSH-Forward-Port-From"]),
                                                       ConfigurationManager.AppSettings["SSH-Forward-Host-To"],
                                                       uint.Parse(ConfigurationManager.AppSettings["SSH-Forward-Port-To"]));

            tunel.AddForwardedPort(forwardedPort);
            forwardedPort.Start();

            return tunel;
        }
    }
}
