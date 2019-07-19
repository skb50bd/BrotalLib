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
            new object[] { "A", "A" },
            new object[] { "this is a line", "This Is A Line" },
            new object[] { "This is a Line", "This Is A Line" },
            new object[] { "sHe Je KoThA dIyE rAkHlO nA", "She Je Kotha Diye Rakhlo Na" },
            new object[] { "aZ", "Az" },
            new object[] { "  a Z a", "  A Z A" },
        };
        [Theory, MemberData(nameof(ToTitleCaseTestData))]
        public void ToTitleCaseTest(
            string str,
            string expected) =>
            Equal(expected, str.ToTitleCase());


        public static object[][] ToCurrencyTestData =
        {
            new object[] { 12M, "$12.00" },
            new object[] { 12.011M, "$12.01" },
            new object[] { 12.001M, "$12.00" },
            new object[] { 0M,      "$0.00"  },
            new object[] { 0.111M,  "$0.11"  },
            new object[] { 12.11M,  "$12.11" }
        };
        [Theory, MemberData(nameof(ToCurrencyTestData))]
        public void ToCurrencyTest(
            decimal money,
            string expected) =>
            Equal(expected, money.ToCurrency());

        public static object[][] ToCurrencyTestData_OneDigit =
        {
            new object[] { 12M,     "$12.0" },
            new object[] { 12.011M, "$12.0" },
            new object[] { 0M,      "$0.0"  },
            new object[] { 0.111M,  "$0.1"  },
            new object[] { 12.11M,  "$12.1" }
        };
        [Theory, MemberData(nameof(ToCurrencyTestData_OneDigit))]
        public void ToCurrencyTest_OneDigit(
            decimal money,
            string expected) =>
            Equal(expected, money.ToCurrency(1));

        public static object[][] ToInitialsTestData =
        {
            new object[] { "AbD Harm K k", "AdHK" },
            new object[] { "aDD Ckk", "ddC" },
            new object[] { "BlazorOnThe Server", "BotS" },
            new object[] { "BlazorOnThe Client", "BotC" },
            new object[] { "Ku Klux Klan", "KKK" }
        };

        [Theory, MemberData(nameof(ToInitialsTestData))]
        public void ToInitialsTest(
            string actual,
            string expected) =>
            Equal(expected, actual.ToInitials());
    }
}
