using System;
using System.Collections.Generic;
using System.Text;

namespace HoursWorked
{
    public struct Time
    {
        public byte hour, minute, second;

        public Time(byte hour, byte minute, byte second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public Time(string time)
        {
            string[] sections = time.Split(':');
            if (sections.Length != 2 && sections.Length != 3)
                throw new Exception("ورودی زمان موردنظر طبق استاندارد نیست.");
            this.hour = byte.Parse(sections[0]);
            this.minute = byte.Parse(sections[1]);
            this.second = sections.Length == 3 ? byte.Parse(sections[2]) : (byte)0;
        }
    }

    public class Staff
    {

        public string Name { get; set; }
        public ushort Id { get; set; }

        public Time TimeIn { get; set; }
        
        public Time TimeOut { get; set; }

        // these two methods are from setting in and out times from string inputs.
        public void SetTimeOut(string timeOut)
        {
            this.TimeOut = new Time(timeOut);
        }

        public void SetTimeIn(string timeIn)
        {
            this.TimeIn = new Time(timeIn);
        }

        public Staff(ushort id, string name, string timeIn)
        {
            this.Id = id;
            this.Name = name;
            this.TimeIn = new Time(timeIn);
        }
    }
}
