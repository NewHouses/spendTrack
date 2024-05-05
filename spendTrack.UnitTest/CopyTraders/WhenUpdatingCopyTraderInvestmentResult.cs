using spendTrack.Invest.Domain;

namespace spendTrack.UnitTest.CopyTraders
{
    public class WhenUpdatingCopyTraderInvestmentResult
    {
        [Test]
        public void MonthlyInvestementResultsAreUpdated()
        {
            var copytrader = new CopyTrader("copytrader1");
            var firstMonth = "02/2024";
            var secondMonth = "03/2024";
            var thirdMonth = "04/2024";
            var monthlyInvestment = 100.00M;
            var firstMonthResult = 150.00M;
            var secondMonthResult = 270.00M;
            var thirdMonthResult = 420.00M;
            var secondMonthTotalInvestment = firstMonthResult + monthlyInvestment;
            var thirdMonthTotalInvestment = secondMonthResult + monthlyInvestment;
            var firstMonthProfit = firstMonthResult - monthlyInvestment;
            var secondMonthProfit = secondMonthResult - secondMonthTotalInvestment;
            var thirdMonthProfit = thirdMonthResult - thirdMonthTotalInvestment;
            var firstMonthProfitIndex = Math.Round(100 * firstMonthProfit / monthlyInvestment, 2);
            var secondMonthProfitIndex = Math.Round(100 * secondMonthProfit / secondMonthTotalInvestment, 2);
            var thirdMonthProfitIndex = Math.Round(100 * thirdMonthProfit / thirdMonthTotalInvestment, 2);
            var avarageMonthlyProfitIndex = Math.Round((firstMonthProfitIndex + secondMonthProfitIndex + thirdMonthProfitIndex) / 3, 2);

            copytrader.AddMonthlyInvest(firstMonth, monthlyInvestment);
            copytrader.UpdateMonthlyResult(firstMonth, firstMonthResult);
            copytrader.AddMonthlyInvest(secondMonth, monthlyInvestment);
            copytrader.UpdateMonthlyResult(secondMonth, secondMonthResult);
            copytrader.AddMonthlyInvest(thirdMonth, monthlyInvestment);
            copytrader.UpdateMonthlyResult(thirdMonth, thirdMonthResult);

            Assert.That(copytrader.TotalInvest, Is.EqualTo(3 * monthlyInvestment));
            Assert.That(copytrader.AvarageMonthlyProfitIndex, Is.EqualTo(avarageMonthlyProfitIndex));
            Assert.That(copytrader.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(copytrader.MonthlyInvests[firstMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(copytrader.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(firstMonthProfitIndex));
            Assert.That(copytrader.MonthlyInvests[firstMonth].Profit, Is.EqualTo(firstMonthProfit));
            Assert.That(copytrader.MonthlyInvests[firstMonth].Result, Is.EqualTo(firstMonthResult));
            Assert.That(copytrader.MonthlyInvests[secondMonth].TotalInvest, Is.EqualTo(secondMonthTotalInvestment));
            Assert.That(copytrader.MonthlyInvests[secondMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(copytrader.MonthlyInvests[secondMonth].ProfitIndex, Is.EqualTo(secondMonthProfitIndex));
            Assert.That(copytrader.MonthlyInvests[secondMonth].Profit, Is.EqualTo(secondMonthProfit));
            Assert.That(copytrader.MonthlyInvests[secondMonth].Result, Is.EqualTo(secondMonthResult));
            Assert.That(copytrader.MonthlyInvests[thirdMonth].TotalInvest, Is.EqualTo(thirdMonthTotalInvestment));
            Assert.That(copytrader.MonthlyInvests[thirdMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(copytrader.MonthlyInvests[thirdMonth].ProfitIndex, Is.EqualTo(thirdMonthProfitIndex));
            Assert.That(copytrader.MonthlyInvests[thirdMonth].Profit, Is.EqualTo(thirdMonthProfit));
            Assert.That(copytrader.MonthlyInvests[thirdMonth].Result, Is.EqualTo(thirdMonthResult));
        }

        [Test]
        public void SeparatedMonthlyInvestementResultsAreUpdated()
        {
            var copytrader = new CopyTrader("copytrader1");
            var firstMonth = "02/2024";
            var secondMonth = "04/2024";
            var thirdMonth = "10/2025";
            var monthlyInvestment = 100.00M;
            var firstMonthResult = 150.00M;
            var secondMonthResult = 270.00M;
            var thirdMonthResult = 420.00M;
            var secondMonthTotalInvestment = firstMonthResult + monthlyInvestment;
            var thirdMonthTotalInvestment = secondMonthResult + monthlyInvestment;
            var firstMonthProfit = firstMonthResult - monthlyInvestment;
            var secondMonthProfit = secondMonthResult - secondMonthTotalInvestment;
            var thirdMonthProfit = thirdMonthResult - thirdMonthTotalInvestment;
            var firstMonthProfitIndex = Math.Round(100 * firstMonthProfit / monthlyInvestment, 2);
            var secondMonthProfitIndex = Math.Round(100 * secondMonthProfit / secondMonthTotalInvestment, 2);
            var thirdMonthProfitIndex = Math.Round(100 * thirdMonthProfit / thirdMonthTotalInvestment, 2);
            var avarageMonthlyProfitIndex = Math.Round((firstMonthProfitIndex + secondMonthProfitIndex + thirdMonthProfitIndex) / 3, 2);

            copytrader.AddMonthlyInvest(firstMonth, monthlyInvestment);
            copytrader.UpdateMonthlyResult(firstMonth, firstMonthResult);
            copytrader.AddMonthlyInvest(secondMonth, monthlyInvestment);
            copytrader.UpdateMonthlyResult(secondMonth, secondMonthResult);
            copytrader.AddMonthlyInvest(thirdMonth, monthlyInvestment);
            copytrader.UpdateMonthlyResult(thirdMonth, thirdMonthResult);

            Assert.That(copytrader.TotalInvest, Is.EqualTo(3 * monthlyInvestment));
            Assert.That(copytrader.AvarageMonthlyProfitIndex, Is.EqualTo(avarageMonthlyProfitIndex));
            Assert.That(copytrader.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(copytrader.MonthlyInvests[firstMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(copytrader.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(firstMonthProfitIndex));
            Assert.That(copytrader.MonthlyInvests[firstMonth].Profit, Is.EqualTo(firstMonthProfit));
            Assert.That(copytrader.MonthlyInvests[firstMonth].Result, Is.EqualTo(firstMonthResult));
            Assert.That(copytrader.MonthlyInvests[secondMonth].TotalInvest, Is.EqualTo(secondMonthTotalInvestment));
            Assert.That(copytrader.MonthlyInvests[secondMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(copytrader.MonthlyInvests[secondMonth].ProfitIndex, Is.EqualTo(secondMonthProfitIndex));
            Assert.That(copytrader.MonthlyInvests[secondMonth].Profit, Is.EqualTo(secondMonthProfit));
            Assert.That(copytrader.MonthlyInvests[secondMonth].Result, Is.EqualTo(secondMonthResult));
            Assert.That(copytrader.MonthlyInvests[thirdMonth].TotalInvest, Is.EqualTo(thirdMonthTotalInvestment));
            Assert.That(copytrader.MonthlyInvests[thirdMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(copytrader.MonthlyInvests[thirdMonth].ProfitIndex, Is.EqualTo(thirdMonthProfitIndex));
            Assert.That(copytrader.MonthlyInvests[thirdMonth].Profit, Is.EqualTo(thirdMonthProfit));
            Assert.That(copytrader.MonthlyInvests[thirdMonth].Result, Is.EqualTo(thirdMonthResult));
        }

        [Test]
        public void ThrowsArgumentExeceptionIfThereWasNotInvestmentInThatMonth()
        {
            var copytrader = new CopyTrader("copytrader1");
            var month = "02/2024";

            var exception = Assert.Throws<ArgumentException>(() => copytrader.UpdateMonthlyResult(month, 100.00M));
            Assert.That(exception.Message, Is.EqualTo($"There was not investment in the month of {month}"));
        }
    }
}
