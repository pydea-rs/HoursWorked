using System.Globalization;
using System.Collections.Generic;


namespace WorkLogger
{

    public class WorkLog
    {
        private readonly List<TrafficLog> traffix;

        public PersianCalendar Date { get; set; }
        
        public WorkLog(PersianCalendar date, Time? timeIn = null)
        {
            this.traffix = new List<TrafficLog>();
            this.Date = date;
            if(timeIn != null)
            {
                this.traffix.Add(new TrafficLog(timeIn));
            }
        }

        public TrafficLog GetCorrespondingTrafficLog()
        {
            return null;
        }
    }
}
