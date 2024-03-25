using System.Globalization;
using System;

namespace WorkLogger
{
    struct PersianDate
    {
        private static readonly PersianCalendar calendar = new PersianCalendar();
        private readonly int year;
        private readonly byte month, day;
        private readonly byte dayOfWeek, currentMonthDays;
        private readonly ushort daysInYear;

        private readonly DateTime christianDate;
        public byte DayOfWeek { get => this.dayOfWeek; }

        public int Year { get => this.year; }
        public byte Month { get => this.month; }
        public byte Day { get => this.day; }

        public PersianDate(string christianDateString)
        {
            this.christianDate = DateTime.Parse(christianDateString);
            this.year = calendar.GetYear(this.christianDate);
            this.month = (byte)calendar.GetMonth(this.christianDate);
            this.day = (byte)calendar.GetDayOfMonth(this.christianDate);
            this.dayOfWeek = (byte)calendar.GetDayOfWeek(this.christianDate);
            this.currentMonthDays = (byte)calendar.GetDaysInMonth(this.year, this.month);
            this.daysInYear = (ushort)calendar.GetDaysInYear(this.year);
        }

        public byte CurrentMonthDays { get => this.currentMonthDays; }

        public ushort CurrentYearDays { get => this.daysInYear; }


        public byte GetDaysInMonth(int year, int month)
        {
            return (byte)calendar.GetDaysInMonth(year, month);
        }

        public ushort GetDaysInYear(int year)
        {
            return (ushort)calendar.GetDaysInYear(year);
        }

        public DateTime ChristianDateTime { get => this.christianDate; }
        public string ChristianDateString { get => this.christianDate.ToString("yyyy-MM-dd"); }

        public string AsString { get => $"{this.year:0000}-{this.month:00}-{this.day:00}"; }

        public override string ToString() => this.AsString;

    }
}
