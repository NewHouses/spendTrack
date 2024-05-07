using spendTrack.Invest.Domain;

namespace spendTrack.UnitTest.IndexFunds
{
    public class WhenUpdatingCopyTraderInvestmentResult
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
        public void ZeroMonthlyInvestementIsAddedIfThereWasNotInvestmentInThatMonth()
        {
            var indexfund = new IndexFund("indexfund1");
            var firstMonth = "02/2024";
            var secondMonth = "04/2024";
            var monthlyInvestment = 100.00M;
            var firstMonthResult = 150.00M;
            var secondMonthResult = 270.00M;
            var secondMonthTotalInvestment = firstMonthResult;
            var firstMonthProfit = firstMonthResult - monthlyInvestment;
            var secondMonthProfit = secondMonthResult - secondMonthTotalInvestment;
            var firstMonthProfitIndex = Math.Round(100 * firstMonthProfit / monthlyInvestment, 2);
            var secondMonthProfitIndex = Math.Round(100 * secondMonthProfit / secondMonthTotalInvestment, 2);
            var avarageMonthlyProfitIndex = Math.Round((firstMonthProfitIndex + secondMonthProfitIndex) / 2, 2);

            indexfund.AddMonthlyInvest(firstMonth, monthlyInvestment);
            indexfund.UpdateMonthlyResult(firstMonth, firstMonthResult);
            indexfund.UpdateMonthlyResult(secondMonth, secondMonthResult);

            Assert.That(indexfund.TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(indexfund.AvarageMonthlyProfitIndex, Is.EqualTo(avarageMonthlyProfitIndex));
            Assert.That(indexfund.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(indexfund.MonthlyInvests[firstMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(indexfund.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(firstMonthProfitIndex));
            Assert.That(indexfund.MonthlyInvests[firstMonth].Profit, Is.EqualTo(firstMonthProfit));
            Assert.That(indexfund.MonthlyInvests[firstMonth].Result, Is.EqualTo(firstMonthResult));
            Assert.That(indexfund.MonthlyInvests[secondMonth].TotalInvest, Is.EqualTo(secondMonthTotalInvestment));
            Assert.That(indexfund.MonthlyInvests[secondMonth].Invest, Is.EqualTo(0));
            Assert.That(indexfund.MonthlyInvests[secondMonth].ProfitIndex, Is.EqualTo(secondMonthProfitIndex));
            Assert.That(indexfund.MonthlyInvests[secondMonth].Profit, Is.EqualTo(secondMonthProfit));
            Assert.That(indexfund.MonthlyInvests[secondMonth].Result, Is.EqualTo(secondMonthResult));
        }

        [Test]
        public void IndexFundAggregatorMonthlyInvestementResultsAreUpdated()
        {
            var indexFunds = new IndexFundAggregator(new List<IndexFund>());
            var firstMonth = "02/2024";
            var secondMonth = "03/2024";
            var thirdMonth = "04/2024";
            var monthlyInvestment = 100.00M;
            var firstMonthResultIndexFund1 = 150.00M;
            var firstMonthResultIndexFund2 = 70.00M;
            var secondMonthResultIndexFund1 = 270.00M;
            var secondMonthResultIndexFund2 = 210.00M;
            var thirdMonthResultIndexFund1 = 420.00M;
            var thirdMonthResultIndexFund2 = 310.00M;
            var secondMonthTotalInvestment = firstMonthResultIndexFund1 + firstMonthResultIndexFund2 + 2 * monthlyInvestment;
            var thirdMonthTotalInvestment = secondMonthResultIndexFund1 + secondMonthResultIndexFund2 + 2 * monthlyInvestment;
            var firstMonthProfit = firstMonthResultIndexFund1 + firstMonthResultIndexFund2 - 2 * monthlyInvestment;
            var secondMonthProfit = secondMonthResultIndexFund1 + secondMonthResultIndexFund2 - secondMonthTotalInvestment;
            var thirdMonthProfit = thirdMonthResultIndexFund1 + thirdMonthResultIndexFund2 - thirdMonthTotalInvestment;
            var firstMonthProfitIndex = Math.Round(100 * firstMonthProfit / (2 * monthlyInvestment), 2);
            var secondMonthProfitIndex = Math.Round(100 * secondMonthProfit / secondMonthTotalInvestment, 2);
            var thirdMonthProfitIndex = Math.Round(100 * thirdMonthProfit / thirdMonthTotalInvestment, 2);
            var avarageMonthlyProfitIndex = Math.Round((firstMonthProfitIndex + secondMonthProfitIndex + thirdMonthProfitIndex) / 3, 2);

            indexFunds.AddMonthlyInvest(firstMonth, "indexFund1", monthlyInvestment);
            indexFunds.AddMonthlyInvest(firstMonth, "indexFund2", monthlyInvestment);
            indexFunds.UpdateMonthlyResult(firstMonth, "indexFund1", firstMonthResultIndexFund1);
            indexFunds.UpdateMonthlyResult(firstMonth, "indexFund2", firstMonthResultIndexFund2);
            indexFunds.AddMonthlyInvest(secondMonth, "indexFund1", monthlyInvestment);
            indexFunds.AddMonthlyInvest(secondMonth, "indexFund2", monthlyInvestment);
            indexFunds.UpdateMonthlyResult(secondMonth, "indexFund1", secondMonthResultIndexFund1);
            indexFunds.UpdateMonthlyResult(secondMonth, "indexFund2", secondMonthResultIndexFund2);
            indexFunds.AddMonthlyInvest(thirdMonth, "indexFund1", monthlyInvestment);
            indexFunds.AddMonthlyInvest(thirdMonth, "indexFund2", monthlyInvestment);
            indexFunds.UpdateMonthlyResult(thirdMonth, "indexFund1", thirdMonthResultIndexFund1);
            indexFunds.UpdateMonthlyResult(thirdMonth, "indexFund2", thirdMonthResultIndexFund2);

            Assert.That(indexFunds.TotalInvest, Is.EqualTo(2 * 3 * monthlyInvestment));
            Assert.That(indexFunds.AvarageMonthlyProfitIndex, Is.EqualTo(avarageMonthlyProfitIndex));
            Assert.That(indexFunds.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(2 * monthlyInvestment));
            Assert.That(indexFunds.MonthlyInvests[firstMonth].Invest, Is.EqualTo(2 * monthlyInvestment));
            Assert.That(indexFunds.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(firstMonthProfitIndex));
            Assert.That(indexFunds.MonthlyInvests[firstMonth].Profit, Is.EqualTo(firstMonthProfit));
            Assert.That(indexFunds.MonthlyInvests[firstMonth].Result, Is.EqualTo(firstMonthResultIndexFund1 + firstMonthResultIndexFund2));
            Assert.That(indexFunds.MonthlyInvests[secondMonth].TotalInvest, Is.EqualTo(secondMonthTotalInvestment));
            Assert.That(indexFunds.MonthlyInvests[secondMonth].Invest, Is.EqualTo(2 * monthlyInvestment));
            Assert.That(indexFunds.MonthlyInvests[secondMonth].ProfitIndex, Is.EqualTo(secondMonthProfitIndex));
            Assert.That(indexFunds.MonthlyInvests[secondMonth].Profit, Is.EqualTo(secondMonthProfit));
            Assert.That(indexFunds.MonthlyInvests[secondMonth].Result, Is.EqualTo(secondMonthResultIndexFund1 + secondMonthResultIndexFund2));
            Assert.That(indexFunds.MonthlyInvests[thirdMonth].TotalInvest, Is.EqualTo(thirdMonthTotalInvestment));
            Assert.That(indexFunds.MonthlyInvests[thirdMonth].Invest, Is.EqualTo(2 * monthlyInvestment));
            Assert.That(indexFunds.MonthlyInvests[thirdMonth].ProfitIndex, Is.EqualTo(thirdMonthProfitIndex));
            Assert.That(indexFunds.MonthlyInvests[thirdMonth].Profit, Is.EqualTo(thirdMonthProfit));
            Assert.That(indexFunds.MonthlyInvests[thirdMonth].Result, Is.EqualTo(thirdMonthResultIndexFund1 + thirdMonthResultIndexFund2));
        }
    }
}
