using Brotal.Extensions;

using Xunit;

using static Xunit.Assert;

namespace BrotalExtensions.Tests
{
    public class StringExtensionsTests
    {
        public static object[][] CapitalizeTestData =
        {
            new object[] { "letter", "Letter" },
            new object[] { "A word", "A word" },
            new object[] { "a word", "A word" },
            new object[] { "a", "A" },
            new object[] { "ZZZZZ", "ZZZZZ" },
            new object[] { "zZZZZ", "ZZZZZ" },
            new object[] { "   ", "   " }
        };
        [Theory, MemberData(nameof(CapitalizeTestData))]
        public void CapitalizeTest(
            string str, 
            string expected) => 
            Equal(expected, str.Capitalize());


        public static object[][] ToTitleCaseTestData =
        {
            new object[] { "this is a line", "This Is A Line" }, 
            new object[] { "This is a Line", "This Is A Line" }, 
            new object[] { "A", "A" }, 
            new object[] { "aZ", "AZ" }, 
            new object[] { "  a Z a", "  A Z A" }, 
        };
        [Theory, MemberData(nameof(ToTitleCaseTestData))]
        public void ToTitleCaseTest(
            string str, 
            string expected) =>
            Equal(expected, str.ToTitleCase());
    }
}
