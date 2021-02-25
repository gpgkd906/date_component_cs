using System;

namespace dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            var date1 = new DateTime(2015, 4, 20, 0, 0, 0);
            var date2 = new DateTime(2015, 12, 19, 0, 0, 0);
            var diff1 = DateComponent.Calendar.calculate(date1, date2);
            Console.WriteLine(diff1);
        }
    }
}
