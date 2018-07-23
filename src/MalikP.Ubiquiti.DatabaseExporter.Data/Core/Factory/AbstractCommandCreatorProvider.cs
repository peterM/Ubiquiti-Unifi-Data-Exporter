// Copyright (c) 2018 Peter M.
// 
// File: AbstractCommandCreatorProvider.cs 
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MalikP.Ubiquiti.DatabaseExporter.Data.Core.Factory
{
    public abstract class AbstractCommandCreatorProvider<TAbstractCommandCreator>
        where TAbstractCommandCreator : AbstractCommandCreator
    {
        List<Type> _types = new List<Type>();
        protected AbstractCommandCreatorProvider()
        {
            var location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var files = Directory.GetFiles(location, "*.dll", SearchOption.AllDirectories)
                                 .Concat(Directory.GetFiles(location, "*.exe", SearchOption.AllDirectories));

            foreach (var file in files)
            {
                var foundTypes = Assembly.LoadFrom(file)
                                         .GetTypes()
                                         .Where(d => !d.IsAbstract)
                                         .Where(d => !d.IsInterface)
                                         .Where(d => typeof(TAbstractCommandCreator).IsAssignableFrom(d))
                                         .Where(d => d.IsClass)
                                         .ToList();
                _types.AddRange(foundTypes);
            }
        }

        protected abstract string ClassPrefix { get; }

        protected TAbstractCommandCreator GetCreator(string schemaName, string tableName, params object[] data)
        {
            var type = _types.Where(d => typeof(TAbstractCommandCreator).IsAssignableFrom(d))
                             .Where(d => d.Namespace.EndsWith(schemaName, StringComparison.InvariantCultureIgnoreCase))
                             .Single(d => String.Equals(d.Name, $"{ClassPrefix}{tableName}", StringComparison.InvariantCultureIgnoreCase));
            return (TAbstractCommandCreator)Activator.CreateInstance(type, data);
        }
    }
}
