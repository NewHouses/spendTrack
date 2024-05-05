using spendTrack.Invest.Domain.ValueObjects;

namespace spendTrack.UnitTest
{
    public class Tests
    {

        [TestCase("01/1999")]
        [TestCase("12/2025")]
        public void ValidMonthDoesNotThrowArgumentException(string month)
        {
            Assert.DoesNotThrow(() => new MonthlyInvest(month, 10.00M, 10.00M));
        }

        [TestCase("aaaa")]
        [TestCase("2024/12")]
        [TestCase("13/2024")]
        [TestCase("00/2024")]
        [TestCase("3/2024")]
        public void InvalidMonthThrowsArgumentException(string month)
        {
            Assert.Throws<ArgumentException>(() => new MonthlyInvest(month, 10.00M, 10.00M));
        }
    }
}