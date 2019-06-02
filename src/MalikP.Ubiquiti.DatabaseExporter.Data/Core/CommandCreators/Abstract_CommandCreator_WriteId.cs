// MIT License
//
// Copyright (c) 2018 Peter Malik. (MalikP.)
// 
// File: Abstract_CommandCreator_WriteId.cs 
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

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MalikP.Ubiquiti.DatabaseExporter.Data.Core.CommandCreators
{
    public abstract class Abstract_CommandCreator_WriteId : AbstractCommandCreator
    {
        private readonly Dictionary<string, string> _documentDictionary;

        protected Abstract_CommandCreator_WriteId(string schema, string tableName, Dictionary<string, string> documentDictionary)
        {
            TableName = $"[{schema}].[{tableName}]";
            _documentDictionary = documentDictionary;
            Commands = new List<IDbCommand>();
        }

        protected string TableName { get; }

        public List<IDbCommand> Commands { get; }

        protected override string CreateCommandText()
        {
            //INSERT INTO table_name(column1, column2, column3, ...)
            //VALUES(value1, value2, value3, ...);

            return $@"insert into {TableName} ({TableName}.JsonData, {TableName}.JsonDataId)
                      values(@jsonData, @jsonDataId )";
        }

        protected override void SetupCommand(SqlCommand command)
        {
            var connection = command.Connection;
            var transaction = connection.BeginTransaction();

            foreach (var item in _documentDictionary)
            {
                var newCommand = new SqlCommand(CreateCommandText(), connection);
                Commands.Add(newCommand);
                newCommand.Parameters.AddWithValue("@jsonData", item.Value);
                newCommand.Parameters.AddWithValue("@jsonDataId", item.Key);
                newCommand.CommandType = CommandType.Text;
                newCommand.Transaction = transaction;
            }
        }
    }
}
