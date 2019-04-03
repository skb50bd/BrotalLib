using System;

using Brotal.Extensions;

using Xunit;

namespace BrotalExtensions.Tests
{
    public class DateTimeExtensionsTests
    {
        public static object[][] NaturalTestData = 
        {
            new object[] { DateTime.Now, "just now"},
            new object[] { DateTime.Now.AddSeconds(3), "in a bit"},
            new object[] { DateTime.Now.AddMinutes(-1), "1 minute ago"},
            new object[] { DateTime.Now.AddMinutes(-20), "20 minutes ago"},
            new object[] { DateTime.Now.AddMinutes(25 + 1), "in 25 minutes"},
            new object[] { DateTime.Now.AddSeconds(23), "in 20 seconds"},
            new object[] { DateTime.Now.AddYears(2), "in 2 years"},
            new object[] { DateTime.Now.AddYears(-2), "2 years ago"},
            new object[] { DateTime.Now.AddYears(-1), "1 year ago"},
            new object[] { DateTime.Now.AddYears(1), "in 1 year"},
            new object[] { DateTime.Now.AddDays(24), "in 3 weeks"},
            new object[] { DateTime.Now.AddDays(-24), "3 weeks ago"},
            new object[] { DateTime.Now.AddMonths(3), "in 3 months"},
            new object[] { DateTime.Now.AddMonths(-3), "3 months ago"},
            new object[] { DateTime.Now.AddHours(-3), "3 hours ago"},
            new object[] { DateTime.Now.AddMinutes(3 * 60 + 1), "in 3 hours"}
        };

        [Theory, MemberData(nameof(NaturalTestData))]
        public void Natural(DateTime dt, string expected)
        {
            Assert.Equal(expected, dt.Natural());
        }


        public static object[][] StartOfWeekTestData =
        {
            new object[]
            {
                new DateTime(2019, 1, 9),
                DayOfWeek.Sunday,
                new DateTime(2019, 1, 6)
            },

            new object[]
            {
                new DateTime(2019, 3, 9),
                DayOfWeek.Sunday,
                new DateTime(2019, 3, 3)
            },

            new object[]
            {
                new DateTime(2019, 1, 1),
                DayOfWeek.Monday,
                new DateTime(2018, 12, 31)
            },
            new object[]
            {
                new DateTime(2019, 1, 9),
                DayOfWeek.Sunday,
                new DateTime(2019, 1, 6)
            }
        };

        [Theory, MemberData(nameof(StartOfWeekTestData))]
        public void StartOfWeekShouldWork(
            DateTime dt, 
            DayOfWeek startOfWeek,
            DateTime expected)
        {
            Assert.Equal(expected, dt.StartOfWeek(startOfWeek));
        }

        public static object[][] FirstDayOfMonthTestData =
        {
            new object[]{ new DateTime(2019, 2, 28), new DateTime(2019, 2, 1), }, 
            new object[]{ new DateTime(2019, 12, 28), new DateTime(2019, 12, 1), }, 
            new object[]{ new DateTime(2019, 10, 1), new DateTime(2019, 10, 1), }, 
        };

        [Theory, MemberData(nameof(FirstDayOfMonthTestData))]
        public void FirstDayOfMonthShouldWork(DateTime dt, DateTime expected)
        {
            Assert.Equal(expected, dt.FirstDayOfMonth());
        }

        public static object[][] LastDayOfMonthTestData =
        {
            new object[]{ new DateTime(2019, 2, 28), new DateTime(2019, 2, 28), },
            new object[]{ new DateTime(2016, 2, 2), new DateTime(2016, 2, 29), },
            new object[]{ new DateTime(2019, 4, 1), new DateTime(2019, 4, 30), },
            new object[]{ new DateTime(2019, 12, 28), new DateTime(2019, 12, 31), },
            new object[]{ new DateTime(2019, 10, 1), new DateTime(2019, 10, 31), },
        };

        [Theory, MemberData(nameof(LastDayOfMonthTestData))]
        public void LastDayOfMonthShouldWork(DateTime dt, DateTime expected)
        {
            Assert.Equal(expected, dt.LastDayOfMonth());
        }
    }
}
