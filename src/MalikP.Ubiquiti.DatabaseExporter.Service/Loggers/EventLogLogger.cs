// MIT License
//
// Copyright (c) 2019 Peter Malik. (MalikP.)
// 
// File: EventLogLogger.cs 
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

using System.Diagnostics;
using System.Security;

namespace MalikP.Ubiquiti.DatabaseExporter.Service.Loggers
{
    public class EventLogLogger : ICustomLogger
    {
        private const string EventLogName = "Application";
        private const string EventLogSourceName = "MalikP. Ubiquiti Database Exporter";

        protected EventLog EvenLogInstance { get; private set; }
        public EventLogLogger()
        {
            TryCreateEventSource();
            CreateEventLogInstance();
        }

        private void CreateEventLogInstance()
        {
            EvenLogInstance = new EventLog(EventLogName)
            {
                Source = EventLogSourceName
            };
        }

        public void WriteMessage(string message, object otherData = null)
        {
            var entryType = EventLogEntryType.Information;
            if (otherData != null && otherData is EventLogEntryType)
            {
                entryType = (EventLogEntryType)otherData;
            }

            EvenLogInstance.WriteEntry(message, entryType);
        }

        // You have to have elevated permission or execute from powershell
        // New-EventLog -LogName Application -Source "MalikP. Ubiquiti Database Exporter"
        private bool TryCreateEventSource()
        {
            var result = false;
            try
            {
                bool sourceExists = EventLog.SourceExists(EventLogSourceName);
                if (!sourceExists)
                {
                    EventLog.CreateEventSource(EventLogSourceName, EventLogName);
                }

                result = true;
            }
            catch (SecurityException)
            {
                result = false;
            }

            return result;
        }
    }
}
