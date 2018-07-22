// Copyright (c) 2018 Peter M.
// 
// File: HowPrepareInstallScript.cs 
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

using System.Collections.Generic;
using System.IO;

namespace MalikP.Ubiquiti.DatabaseExporter.Scripts
{
    public class HowPrepareInstallScript
    {
        public HowPrepareInstallScript()
        {
            string path = @"C:\Temp\s";
            string template = Path.Combine(path, "template.txt");

            string resultfile = Path.Combine(path, "result.txt");

            var folders = new KeyValuePair<string, string>[]
            {
               new KeyValuePair<string, string>("ace", @"C:\Temp\UnifiBackup\ace\21_07_2018_04-39-15"),
               new KeyValuePair<string, string>("ace_stat", @"C:\Temp\UnifiBackup\ace_stat\21_07_2018_04-39-15"),
               new KeyValuePair<string, string>("local", @"C:\Temp\UnifiBackup\local\21_07_2018_04-39-15")
            };
            foreach (var folder in folders)
            {
                foreach (var file in Directory.GetFiles(folder.Value))
                //foreach (var file in Directory.GetFiles(@"C:\Temp\UnifiBackup\ace_stat\21_07_2018_04-39-15"))
                //foreach (var file in Directory.GetFiles(@"C:\Temp\UnifiBackup\local\21_07_2018_04-39-15"))
                {
                    var token = Path.GetFileNameWithoutExtension(file);
                    var templateText = File.ReadAllText(template);
                    var resultText = templateText.Replace("TOKENIZATION", token);
                    var tablename = token;
                    resultText = templateText.Replace("TABLENAME", tablename);
                    resultText = resultText.Replace("SCHEMA", folder.Key);
                    resultText = resultText.Replace("TOKEN-FULLTABLENAME", $"{folder.Key}.{token}");
                    //resultText = resultText.Replace("TOKEN-FULLTABLENAME", $"ace.{token}");

                    File.AppendAllText(resultfile, "\r\n\r\n");
                    File.AppendAllText(resultfile, resultText);
                }
            }
        }
    }
}
