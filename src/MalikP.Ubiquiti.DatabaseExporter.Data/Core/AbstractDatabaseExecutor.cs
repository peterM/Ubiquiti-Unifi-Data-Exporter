﻿// MIT License
//
// Copyright (c) 2019 Peter Malik. (MalikP.)
// 
// File: AbstractDatabaseExecutor.cs 
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
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MalikP.Ubiquiti.DatabaseExporter.Data.Core
{
    public abstract class AbstractDatabaseExecutor
    {
        protected AbstractDatabaseExecutor(string connectionString, ICustomCredential credential)
        {
            ConnectionString = connectionString;
            CustomCredentialInstance = credential;
        }

        protected string ConnectionString { get; }
        protected ICustomCredential CustomCredentialInstance { get; }

        protected virtual IDbConnection CreateConnection(string connectionString = null)
        {
            SqlCredential sqlCredential = CreateSqlCredential(CustomCredentialInstance);
            var connection = new SqlConnection(connectionString ?? ConnectionString, sqlCredential);
            connection.Open();
            return connection;
        }

        protected virtual SqlCredential CreateSqlCredential(ICustomCredential customCredentialInstance)
        {
            return new SqlCredential(customCredentialInstance.UserName, customCredentialInstance.Password);
        }

        protected virtual IDbCommand GetCommand(AbstractCommandCreator abstractCommandCreator)
        {
            var connection = CreateConnection();
            return abstractCommandCreator?.CreateCommand(connection);
        }

        protected void ExecuteNonQuery(IEnumerable<IDbCommand> commands, IDbTransaction transaction)
        {
            if (commands == null || !commands.Any())
            {
                return;
            }

            foreach (IDbCommand command in commands)
            {
                command.ExecuteNonQuery();
            }

            transaction.Commit();

            foreach (IDbCommand command in commands)
            {
                command.Dispose();
            }
        }

        protected int ExecuteNonQuery(IDbCommand command)
        {
            if (command == null)
            {
                return 0;
            }

            using (command?.Connection)
            using (command)
            {
                return command.ExecuteNonQuery();
            }
        }

        protected IEnumerable<T> ExecuteReaderWithManyResults<T>(IDbCommand command)
            where T : class, IMapable, new()
        {
            using (command?.Connection)
            using (command)
            using (var reader = command.ExecuteReader())
            {
                while (!reader.IsClosed && reader.Read())
                {
                    yield return MapEntity<T>(reader);
                }
            }
        }

        protected T ExecuteReaderWithSingleResult<T>(IDbCommand command, T entity = null)
           where T : class, IMapable, new()
        {
            using (command?.Connection)
            using (command)
            using (var reader = command.ExecuteReader())
            {
                if (!reader.IsClosed && reader.Read())
                {
                    entity = MapEntity<T>(reader, entity);
                }
            }

            return entity;
        }

        protected T MapEntity<T>(IDataReader reader, T entity = null)
             where T : class, IMapable, new()
        {
            if (!reader.IsClosed)
            {
                if (entity == null)
                {
                    entity = new T();
                }

                entity.MapFrom(reader);
            }

            return entity;
        }
    }
}
