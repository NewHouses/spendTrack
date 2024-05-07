using spendTrack.Invest.Domain;

namespace spendTrack.UnitTest
{
    public class WhenAddingMonthlyInvest
    {
        [Test]
        public void MonthlyInvestementIsAdded()
        {
            var invests = new Invests(new List<Stock>(), new List<IndexFund>(), new List<CopyTrader>());
            var firstMonth = "02/2024";
            var monthlyInvestment = 100.00M;

            invests.AddStockInvest(firstMonth, "stock1", monthlyInvestment);
            invests.AddStockInvest(firstMonth, "stock2", monthlyInvestment);
            invests.AddIndexFundInvest(firstMonth, "indexFund1", monthlyInvestment);
            invests.AddIndexFundInvest(firstMonth, "indexFund2", monthlyInvestment);
            invests.AddCopyTraderInvest(firstMonth, "copyTrader1", monthlyInvestment);
            invests.AddCopyTraderInvest(firstMonth, "copyTrader2", monthlyInvestment);

            Assert.That(invests.TotalInvest, Is.EqualTo(6 * monthlyInvestment));
            Assert.That(invests.AvarageMonthlyProfitIndex, Is.EqualTo(0));
            Assert.That(invests.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(6 * monthlyInvestment));
            Assert.That(invests.MonthlyInvests[firstMonth].Invest, Is.EqualTo(6 * monthlyInvestment));
            Assert.That(invests.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(0));
            Assert.That(invests.MonthlyInvests[firstMonth].Profit, Is.EqualTo(0));
            Assert.That(invests.MonthlyInvests[firstMonth].Result, Is.EqualTo(0));
        }
    }
}