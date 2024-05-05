using spendTrack.Invest.Domain;

namespace spendTrack.UnitTest.IndexFunds
{
    public class WhenAddingMonthlyInvestIndexFund
    {
        [Test]
        public void IndexFundMonthlyInvestementIsAdded()
        {
            var indexfund = new IndexFund("indexfund1");
            var firstMonth = "02/2024";
            var monthlyInvestment = 100.00M;

            indexfund.AddMonthlyInvest(firstMonth, monthlyInvestment);

            Assert.That(indexfund.TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(indexfund.AvarageMonthlyProfitIndex, Is.EqualTo(0));
            Assert.That(indexfund.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(indexfund.MonthlyInvests[firstMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(indexfund.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(0));
            Assert.That(indexfund.MonthlyInvests[firstMonth].Profit, Is.EqualTo(0));
            Assert.That(indexfund.MonthlyInvests[firstMonth].Result, Is.EqualTo(0));
        }

        [Test]
        public void ThrowsExeceptionIfLastMonthResultWasNotUpdated()
        {
            var indexfund = new IndexFund("indexfund1");
            var firstMonth = "02/2024";
            var secondMonth = "02/2024";
            var monthlyInvestment = 100.00M;

            indexfund.AddMonthlyInvest(firstMonth, monthlyInvestment);
            var exception = Assert.Throws<Exception>(() => indexfund.AddMonthlyInvest(secondMonth, monthlyInvestment));

            Assert.That(exception.Message, Is.EqualTo($"Last month result is not updated"));
        }

        [TestCase("aaaa")]
        [TestCase("2024/12")]
        [TestCase("13/2024")]
        [TestCase("00/2024")]
        [TestCase("3/2024")]
        public void ThrowsExeceptionIfMonthIsNotValid(string month)
        {
            var indexfund = new IndexFund("indexfund1");

            var exception = Assert.Throws<ArgumentException>(() => indexfund.AddMonthlyInvest(month, 100.00M));

            Assert.That(exception.Message, Is.EqualTo($"The month must follow the format: MM/YYYY"));
        }
    }
}