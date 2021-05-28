using System;

namespace dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            var date1 = new DateTime(2020, 2, 29, 0, 0, 0);
            var date2 = new DateTime(2021, 2, 1, 0, 0, 0);
            var diff1 = DateComponent.Calendar.calculate(date1, date2);
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", diff1.year, diff1.month, diff1.day, diff1.interval_day, diff1.invert);
        }
    }
}
