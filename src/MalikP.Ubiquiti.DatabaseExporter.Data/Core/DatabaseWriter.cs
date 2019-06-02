// MIT License
//
// Copyright (c) 2019 Peter Malik. (MalikP.)
// 
// File: DatabaseWriter.cs 
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

using MalikP.Ubiquiti.DatabaseExporter.Data.Core.CommandCreators;
using MalikP.Ubiquiti.DatabaseExporter.Data.Core.Credentials;
using System.Linq;

namespace MalikP.Ubiquiti.DatabaseExporter.Data.Core
{
    public class DatabaseWriter : AbstractDatabaseExecutor, IDatabaseWriter
    {
        public DatabaseWriter(string connectionString, ICustomCredential customCredential)
            : base(connectionString, customCredential)
        {
        }

        public bool Write(Abstract_CommandCreator_WriteId commandCreator)
        {
            bool result = false;
            using (var command = GetCommand(commandCreator))
            {
                var commands = commandCreator.Commands;
                if (commands.Any())
                {
                    ExecuteNonQuery(commands, commands.First().Transaction);
                    result = true;
                }
            }

            return result;
        }
    }
}
