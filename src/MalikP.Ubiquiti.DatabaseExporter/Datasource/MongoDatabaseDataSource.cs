// Copyright (c) 2018 Peter M.
// 
// File: MongoDatabaseDataSource.cs 
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
using System.Collections.Generic;
using System.IO;
using System.Linq;

using MalikP.Ubiquiti.DatabaseExporter.SSHTuneling;

using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;

namespace MalikP.Ubiquiti.DatabaseExporter.Datasource
{
    public class MongoDatabaseDataSource : IMongoDataSource
    {
        private readonly string _connectionString;
        private readonly ISSHTunel _tunel;
        private IMongoClient _client;

        public MongoDatabaseDataSource(string connectionString)
            : this(connectionString, null)
        {
        }

        public MongoDatabaseDataSource(string connectionString, ISSHTunel tunelProvider)
        {
            _connectionString = connectionString;
            _tunel = tunelProvider;
        }

        public IDisposable Connect()
        {
            IDisposable openedTunel = _tunel?.OpenTunel();
            _client = _client ?? new MongoClient(_connectionString);

            return openedTunel ?? new MemoryStream();
        }

        public IEnumerable<string> GetDatabases()
        {
            return _client.ListDatabases()
                          .ToList()
                          .Select(d => d.GetValue(0).ToString())
                          .ToList();
        }

        public IEnumerable<String> GetCollections(string database)
        {
            IMongoDatabase databaseObject = GetDatabase(database);
            return databaseObject.ListCollections()
                                 .ToList()
                                 .Select(d => d.GetValue(0).ToString())
                                 .ToList();
        }

        private IMongoDatabase GetDatabase(string database)
        {
            return _client.GetDatabase(database);
        }

        public IEnumerable<string> GetJsonDocuments(string database, string collectionName)
        {
            IMongoDatabase databaseObject = GetDatabase(database);
            IMongoCollection<BsonDocument> collectionObject = GetCollection(collectionName, databaseObject);

            IAsyncCursor<BsonDocument> cursor = collectionObject.Find(new BsonDocument())
                                                                .ToCursor();

            var data = cursor.ToEnumerable()
                .Select(d => d.ToJson(new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }))
                .ToList();
            return data;
        }

        private IMongoCollection<BsonDocument> GetCollection(string collectionName, IMongoDatabase databaseObject)
        {
            return databaseObject.GetCollection<BsonDocument>(collectionName);
        }
    }
}
