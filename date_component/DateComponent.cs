using System;

namespace DateComponent {
    [Serializable]
    public struct dateComponent {
        public int year {get; set;}
        public int month {get; set;}
        public int day {get; set;}
        public int interval_day {get; set;}
        public bool invert {get; set;}

        public dateComponent(int year, int month, int day, int interval_day, bool invert)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.interval_day = interval_day;
            this.invert = invert;
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
            int to_year, to_month;

            if (diff.TotalSeconds <= 0) {
                (from, to, invert) = (date1, date2, false);
            } else {
                (from, to, invert) = (date2, date1, true);
            }

            var diff_year = to.Year - from.Year;
            var diff_month = to.Month - from.Month;
            int interval_year, interval_month, interval_day;
            var diff_day = to.Day - from.Day;

            if (to.Month > 1) {
                (to_year, to_month) = (to.Year, to.Month - 1);
            } else {
                (to_year, to_month) = (to.Year - 1, 12);
            }

            if (diff_day < 0) {
                (interval_day, interval_month) = (abs(new DateTime(to_year, to_month, from.Day, to.Hour, to.Minute, to.Second).Subtract(to)), diff_month - 1);
            } else {
                (interval_day, interval_month) = (abs(new DateTime(to.Year, to.Month, from.Day, to.Hour, to.Minute, to.Second).Subtract(to)), diff_month);
            }
            
            if (interval_month < 0) {
                (interval_year, interval_month) = (diff_year -1, interval_month + 12);
            } else {
                (interval_year, interval_month) = (diff_year, interval_month);
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