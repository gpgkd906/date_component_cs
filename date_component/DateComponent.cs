using System;

namespace DateComponent {
    public struct dateComponent {
        public int year;
        public int month;
        public int day;
        public int interval_day;
        public bool invert;

        public dateComponent(int year, int month, int day, int interval_day, bool invert)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.interval_day = interval_day;
            this.invert = invert;
        }

        public override string ToString()
        {
            return String.Format(@"{0} 
[[
    year: {1},
    month: {2},
    day: {3},
    interval_day: {4},
    invert: {5}
]]", base.ToString(), this.year, this.month, this.day, this.interval_day, this.invert);
        }
    }


    public class Calendar {
        delegate int Abs(TimeSpan x);
        static Abs abs = delegate(TimeSpan x) {
            return Math.Abs(Convert.ToInt32(x.TotalDays));
        };

        public static dateComponent calculate(DateTime date1, DateTime date2) {

            var diff = date1.Subtract(date2);
            DateTime from, to;
            bool invert;
            if (diff.TotalSeconds <= 0) {
                (from, to, invert) = (date1, date2, false);
            } else {
                (from, to, invert) = (date2, date1, true);
            }
            var diff_year = to.Year - from.Year;
            var diff_month = to.Month - from.Month;
            int interval_year, interval_month, interval_day;
            if (diff_month < 0) {
                (interval_year, interval_month) = (diff_year -1, diff_month + 12);
            } else {
                (interval_year, interval_month) = (diff_year, diff_month);
            }
            var diff_day = to.Day - from.Day;
            if (diff_day < 0) {
                (interval_day, interval_month) = (abs(new DateTime(to.Year, to.Month - 1, from.Day, to.Hour, to.Minute, to.Second).Subtract(to)), interval_month - 1);
            } else {
                interval_day = abs(new DateTime(to.Year, to.Month, from.Day, to.Hour, to.Minute, to.Second).Subtract(to));
            }
            return new dateComponent(
                interval_year,
                interval_month,
                interval_day,
                abs(diff),
                invert
            );
        }
    }
}