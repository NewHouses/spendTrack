using spendTrack.Invest.Domain;

namespace spendTrack.UnitTest.CopyTraders
{
    public class WhenAddingMonthlyInvestCopyTrader
    {
        [Test]
        public void CopyTraderMonthlyInvestementIsAdded()
        {
            var copytrader = new CopyTrader("copytrader1");
            var firstMonth = "02/2024";
            var monthlyInvestment = 100.00M;

            copytrader.AddMonthlyInvest(firstMonth, monthlyInvestment);

            Assert.That(copytrader.TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(copytrader.AvarageMonthlyProfitIndex, Is.EqualTo(0));
            Assert.That(copytrader.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(copytrader.MonthlyInvests[firstMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(copytrader.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(0));
            Assert.That(copytrader.MonthlyInvests[firstMonth].Profit, Is.EqualTo(0));
            Assert.That(copytrader.MonthlyInvests[firstMonth].Result, Is.EqualTo(0));
        }

        [Test]
        public void ThrowsExeceptionIfLastMonthResultWasNotUpdated()
        {
            var copytrader = new CopyTrader("copytrader1");
            var firstMonth = "02/2024";
            var secondMonth = "02/2024";
            var monthlyInvestment = 100.00M;

            copytrader.AddMonthlyInvest(firstMonth, monthlyInvestment);
            var exception = Assert.Throws<Exception>(() => copytrader.AddMonthlyInvest(secondMonth, monthlyInvestment));

            Assert.That(exception.Message, Is.EqualTo($"Last month result is not updated"));
        }

        [TestCase("aaaa")]
        [TestCase("2024/12")]
        [TestCase("13/2024")]
        [TestCase("00/2024")]
        [TestCase("3/2024")]
        public void ThrowsExeceptionIfMonthIsNotValid(string month)
        {
            var copytrader = new CopyTrader("copytrader1");

            var exception = Assert.Throws<ArgumentException>(() => copytrader.AddMonthlyInvest(month, 100.00M));

            Assert.That(exception.Message, Is.EqualTo($"The month must follow the format: MM/YYYY"));
        }
    }
}