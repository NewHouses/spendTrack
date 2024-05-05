using spendTrack.Invest.Domain;

namespace spendTrack.UnitTest.IndexFunds
{
    public class WhenUpdatingIndexFundInvestmentResult
    {
        [Test]
        public void MonthlyInvestementResultsAreUpdated()
        {
            var indexfund = new IndexFund("indexfund1");
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

            indexfund.AddMonthlyInvest(firstMonth, monthlyInvestment);
            indexfund.UpdateMonthlyResult(firstMonth, firstMonthResult);
            indexfund.AddMonthlyInvest(secondMonth, monthlyInvestment);
            indexfund.UpdateMonthlyResult(secondMonth, secondMonthResult);
            indexfund.AddMonthlyInvest(thirdMonth, monthlyInvestment);
            indexfund.UpdateMonthlyResult(thirdMonth, thirdMonthResult);

            Assert.That(indexfund.TotalInvest, Is.EqualTo(3 * monthlyInvestment));
            Assert.That(indexfund.AvarageMonthlyProfitIndex, Is.EqualTo(avarageMonthlyProfitIndex));
            Assert.That(indexfund.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(indexfund.MonthlyInvests[firstMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(indexfund.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(firstMonthProfitIndex));
            Assert.That(indexfund.MonthlyInvests[firstMonth].Profit, Is.EqualTo(firstMonthProfit));
            Assert.That(indexfund.MonthlyInvests[firstMonth].Result, Is.EqualTo(firstMonthResult));
            Assert.That(indexfund.MonthlyInvests[secondMonth].TotalInvest, Is.EqualTo(secondMonthTotalInvestment));
            Assert.That(indexfund.MonthlyInvests[secondMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(indexfund.MonthlyInvests[secondMonth].ProfitIndex, Is.EqualTo(secondMonthProfitIndex));
            Assert.That(indexfund.MonthlyInvests[secondMonth].Profit, Is.EqualTo(secondMonthProfit));
            Assert.That(indexfund.MonthlyInvests[secondMonth].Result, Is.EqualTo(secondMonthResult));
            Assert.That(indexfund.MonthlyInvests[thirdMonth].TotalInvest, Is.EqualTo(thirdMonthTotalInvestment));
            Assert.That(indexfund.MonthlyInvests[thirdMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(indexfund.MonthlyInvests[thirdMonth].ProfitIndex, Is.EqualTo(thirdMonthProfitIndex));
            Assert.That(indexfund.MonthlyInvests[thirdMonth].Profit, Is.EqualTo(thirdMonthProfit));
            Assert.That(indexfund.MonthlyInvests[thirdMonth].Result, Is.EqualTo(thirdMonthResult));
        }

        [Test]
        public void SeparatedMonthlyInvestementResultsAreUpdated()
        {
            var indexfund = new IndexFund("indexfund1");
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

            indexfund.AddMonthlyInvest(firstMonth, monthlyInvestment);
            indexfund.UpdateMonthlyResult(firstMonth, firstMonthResult);
            indexfund.AddMonthlyInvest(secondMonth, monthlyInvestment);
            indexfund.UpdateMonthlyResult(secondMonth, secondMonthResult);
            indexfund.AddMonthlyInvest(thirdMonth, monthlyInvestment);
            indexfund.UpdateMonthlyResult(thirdMonth, thirdMonthResult);

            Assert.That(indexfund.TotalInvest, Is.EqualTo(3 * monthlyInvestment));
            Assert.That(indexfund.AvarageMonthlyProfitIndex, Is.EqualTo(avarageMonthlyProfitIndex));
            Assert.That(indexfund.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(indexfund.MonthlyInvests[firstMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(indexfund.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(firstMonthProfitIndex));
            Assert.That(indexfund.MonthlyInvests[firstMonth].Profit, Is.EqualTo(firstMonthProfit));
            Assert.That(indexfund.MonthlyInvests[firstMonth].Result, Is.EqualTo(firstMonthResult));
            Assert.That(indexfund.MonthlyInvests[secondMonth].TotalInvest, Is.EqualTo(secondMonthTotalInvestment));
            Assert.That(indexfund.MonthlyInvests[secondMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(indexfund.MonthlyInvests[secondMonth].ProfitIndex, Is.EqualTo(secondMonthProfitIndex));
            Assert.That(indexfund.MonthlyInvests[secondMonth].Profit, Is.EqualTo(secondMonthProfit));
            Assert.That(indexfund.MonthlyInvests[secondMonth].Result, Is.EqualTo(secondMonthResult));
            Assert.That(indexfund.MonthlyInvests[thirdMonth].TotalInvest, Is.EqualTo(thirdMonthTotalInvestment));
            Assert.That(indexfund.MonthlyInvests[thirdMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(indexfund.MonthlyInvests[thirdMonth].ProfitIndex, Is.EqualTo(thirdMonthProfitIndex));
            Assert.That(indexfund.MonthlyInvests[thirdMonth].Profit, Is.EqualTo(thirdMonthProfit));
            Assert.That(indexfund.MonthlyInvests[thirdMonth].Result, Is.EqualTo(thirdMonthResult));
        }

        [Test]
        public void ThrowsArgumentExeceptionIfThereWasNotInvestmentInThatMonth()
        {
            var indexfund = new IndexFund("indexfund1");
            var month = "02/2024";

            var exception = Assert.Throws<ArgumentException>(() => indexfund.UpdateMonthlyResult(month, 100.00M));
            Assert.That(exception.Message, Is.EqualTo($"There was not investment in the month of {month}"));
        }
    }
}
