using System;
using System.Collections.Generic;
using System.Globalization;

namespace WorkLogger
{
    

    public class Staff
    {
        private readonly Dictionary<string, WorkLog> logs;
        public string Name { get; set; }
        public ushort Id { get; set; }

        public List<WorkLog> Logs { get; }
        public Staff(ushort id, string name)
        {
            this.logs = new Dictionary<string, WorkLog>();
            this.Id = id;
            this.Name = name;
        }

        public WorkLog GetCorrespondingWorkLog(string date)
        {
            try
            {
                return this.logs[date];
            }
            catch (KeyNotFoundException) { }
            return null;
        }
    }
}
