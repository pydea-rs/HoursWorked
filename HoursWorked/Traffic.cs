using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLogger
{
    public class TrafficLog
    {
        public Time? TimeIn { get; set; }

        public Time? TimeOut { get; set; }

        // these two methods are from setting in and out times from string inputs.
        public void SetTimeOut(string timeOut)
        {
            this.TimeOut = new Time(timeOut);
        }

        public void SetTimeIn(string timeIn)
        {
            this.TimeIn = new Time(timeIn);
        }

        public TrafficLog(Time? timeIn, Time? timeOut = null)
        {
            this.TimeOut = timeOut;
            this.TimeIn = timeIn;
        }
    }
}
