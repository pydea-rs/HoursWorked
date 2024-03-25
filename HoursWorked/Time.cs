using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLogger
{
    public struct Time
    {
        public byte hour, minute, second;

        public Time(byte hour, byte minute, byte second = 0)
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

        public int ToMinutes { get => this.hour * 60 + this.minute; }

        public Time(int seconds)
        {
            this.second = (byte)(seconds % 60);
            int minutes = (byte)((float)seconds / 60.0);
            this.minute = (byte)(minutes % 60);
            try
            {
                this.hour = (byte)((float)minutes / 60.0);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("این مقدار قابل تبدیل به واحد زمانی برنامه نیست. برای سبک ساختن برنامه صرفا می تواند حداکثر 255 ساعت را ثبت کند. با توجه به اینکه این دستگاه ساعت زنی روزانه است عدد ورودی شما غیرمنطقی است. ");
            }

        }
    }
}
