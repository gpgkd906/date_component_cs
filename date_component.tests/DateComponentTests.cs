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
                var date1 = new DateTime(9999, 99, 99, 0, 0, 0);
                var date2 = new DateTime(9999, 99, 99, 0, 0, 0);
                Calendar.calculate(date1, date2);
            });
        }
    }
}