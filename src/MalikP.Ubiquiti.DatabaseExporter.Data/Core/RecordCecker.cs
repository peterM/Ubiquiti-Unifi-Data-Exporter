// Copyright (c) 2018 Peter M.
// 
// File: RecordCecker.cs 
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

using MalikP.Ubiquiti.DatabaseExporter.Data.Core.CommandCreators;
using MalikP.Ubiquiti.DatabaseExporter.Data.Core.Credentials;
using MalikP.Ubiquiti.DatabaseExporter.Data.Core.Mapables;

namespace MalikP.Ubiquiti.DatabaseExporter.Data.Core
{
    public class RecordCecker : AbstractDatabaseExecutor, IDatabaseChecker
    {
        public RecordCecker(string connectionString, ICustomCredential customCredential)
            : base(connectionString, customCredential)
        {
        }

        public bool Check(AbstractCommandCreator commandCreator)
        {
            bool result = false;
            using (var command = GetCommand(commandCreator))
            {
                MapableBool resultObject = ExecuteReaderWithSingleResult<MapableBool>(command);
                result = resultObject?.Value ?? false;
            }

            return result;
        }
    }
}
