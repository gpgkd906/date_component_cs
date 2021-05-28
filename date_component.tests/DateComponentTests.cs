using Xunit;
using System;
using DateComponent;

namespace DateComponent_UnitTests
{
    public class DateComponent_Tests {

        [Fact]
        public void case1()
        {
            var date1 = new DateTime(2015, 4, 20, 0, 0, 0);
            var date2 = new DateTime(2015, 12, 19, 0, 0, 0);
            var date_component = Calendar.calculate(date1, date2);
            Assert.True(date_component.Equals(new dateComponent(0, 7, 29, 243, false)));
        }

        [Fact]
        public void case2()
        {
            var date1 = new DateTime(2015, 12, 21, 0, 0, 0);
            var date2 = new DateTime(2015, 4, 20, 0, 0, 0);
            var date_component = Calendar.calculate(date1, date2);
            Assert.True(date_component.Equals(new dateComponent(0, 8, 1, 245, true)));
        }

        [Fact]
        public void case3()
        {
            var date1 = new DateTime(2016, 2, 19, 0, 0, 0);
            var date2 = new DateTime(2015, 4, 20, 0, 0, 0);
            var date_component = Calendar.calculate(date1, date2);
            Assert.True(date_component.Equals(new dateComponent(0, 9, 30, 305, true)));
        }

        [Fact]
        public void case4()
        {
            var date1 = new DateTime(2015, 4, 20, 0, 0, 0);
            var date2 = new DateTime(2016, 2, 21, 0, 0, 0);
            var date_component = Calendar.calculate(date1, date2);
            Assert.True(date_component.Equals(new dateComponent(0, 10, 1, 307, false)));
        }

        [Fact]
        public void case5()
        {
            var date1 = new DateTime(2016, 3, 20, 0, 0, 0);
            var date2 = new DateTime(2016, 3, 20, 0, 0, 0);
            var date_component = Calendar.calculate(date1, date2);
            Assert.True(date_component.Equals(new dateComponent(0, 0, 0, 0, false)));
        }

        [Fact]
        public void case6()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                var date1 = new DateTime(0, 0, 0, 0, 0, 0);
                DateTime date2 = new DateTime(9999, 9999, 9999, 9999, 9999, 9999);
                var date_component = Calendar.calculate(date1, date2);
                Console.WriteLine(DateTime.MinValue.ToString("yyyy-MM-dd hh:mm:ss"));
                Console.WriteLine(DateTime.MaxValue.ToString("yyyy-MM-dd hh:mm:ss"));
            });
        }

        [Fact]
        public void case7()
        {
            var date1 = new DateTime(2015, 12, 30, 0, 0, 0);
            var date2 = new DateTime(2016, 1, 1, 0, 0, 0);
            var date_component = Calendar.calculate(date1, date2);
            Assert.True(date_component.Equals(new dateComponent(0, 0, 2, 2, false)));
        }


        [Fact]
        public void case8()
        {
            var date1 = new DateTime(2020, 2, 29, 0, 0, 0);
            var date2 = new DateTime(2021, 2, 1, 0, 0, 0);
            var date_component = Calendar.calculate(date1, date2);
            Console.WriteLine(date_component);
            Assert.True(date_component.Equals(new dateComponent(0, 11, 3, 338, false)));
        }
    }
}