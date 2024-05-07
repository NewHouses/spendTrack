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
        public void ZeroMonthlyInvestementIsAddedIfThereWasNotInvestmentInThatMonth()
        {
            var copytrader = new CopyTrader("copytrader1");
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

            copytrader.AddMonthlyInvest(firstMonth, monthlyInvestment);
            copytrader.UpdateMonthlyResult(firstMonth, firstMonthResult);
            copytrader.UpdateMonthlyResult(secondMonth, secondMonthResult);

            Assert.That(copytrader.TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(copytrader.AvarageMonthlyProfitIndex, Is.EqualTo(avarageMonthlyProfitIndex));
            Assert.That(copytrader.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(copytrader.MonthlyInvests[firstMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(copytrader.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(firstMonthProfitIndex));
            Assert.That(copytrader.MonthlyInvests[firstMonth].Profit, Is.EqualTo(firstMonthProfit));
            Assert.That(copytrader.MonthlyInvests[firstMonth].Result, Is.EqualTo(firstMonthResult));
            Assert.That(copytrader.MonthlyInvests[secondMonth].TotalInvest, Is.EqualTo(secondMonthTotalInvestment));
            Assert.That(copytrader.MonthlyInvests[secondMonth].Invest, Is.EqualTo(0));
            Assert.That(copytrader.MonthlyInvests[secondMonth].ProfitIndex, Is.EqualTo(secondMonthProfitIndex));
            Assert.That(copytrader.MonthlyInvests[secondMonth].Profit, Is.EqualTo(secondMonthProfit));
            Assert.That(copytrader.MonthlyInvests[secondMonth].Result, Is.EqualTo(secondMonthResult));
        }

        [Test]
        public void CopyTraderAggregatorMonthlyInvestementResultsAreUpdated()
        {
            var copytraders = new CopyTraderAggregator(new List<CopyTrader>());
            var firstMonth = "02/2024";
            var secondMonth = "03/2024";
            var thirdMonth = "04/2024";
            var monthlyInvestment = 100.00M;
            var firstMonthResultCopyTrader1 = 150.00M;
            var firstMonthResultCopyTrader2 = 70.00M;
            var secondMonthResultCopyTrader1 = 270.00M;
            var secondMonthResultCopyTrader2 = 210.00M;
            var thirdMonthResultCopyTrader1 = 420.00M;
            var thirdMonthResultCopyTrader2 = 310.00M;
            var secondMonthTotalInvestment = firstMonthResultCopyTrader1 + firstMonthResultCopyTrader2 + 2 * monthlyInvestment;
            var thirdMonthTotalInvestment = secondMonthResultCopyTrader1 + secondMonthResultCopyTrader2 + 2 * monthlyInvestment;
            var firstMonthProfit = firstMonthResultCopyTrader1 + firstMonthResultCopyTrader2 - 2 * monthlyInvestment;
            var secondMonthProfit = secondMonthResultCopyTrader1 + secondMonthResultCopyTrader2 - secondMonthTotalInvestment;
            var thirdMonthProfit = thirdMonthResultCopyTrader1 + thirdMonthResultCopyTrader2 - thirdMonthTotalInvestment;
            var firstMonthProfitIndex = Math.Round(100 * firstMonthProfit / (2 * monthlyInvestment), 2);
            var secondMonthProfitIndex = Math.Round(100 * secondMonthProfit / secondMonthTotalInvestment, 2);
            var thirdMonthProfitIndex = Math.Round(100 * thirdMonthProfit / thirdMonthTotalInvestment, 2);
            var avarageMonthlyProfitIndex = Math.Round((firstMonthProfitIndex + secondMonthProfitIndex + thirdMonthProfitIndex) / 3, 2);

            copytraders.AddMonthlyInvest(firstMonth, "copytrader1", monthlyInvestment);
            copytraders.AddMonthlyInvest(firstMonth, "copytrader2", monthlyInvestment);
            copytraders.UpdateMonthlyResult(firstMonth, "copytrader1", firstMonthResultCopyTrader1);
            copytraders.UpdateMonthlyResult(firstMonth, "copytrader2", firstMonthResultCopyTrader2);
            copytraders.AddMonthlyInvest(secondMonth, "copytrader1", monthlyInvestment);
            copytraders.AddMonthlyInvest(secondMonth, "copytrader2", monthlyInvestment);
            copytraders.UpdateMonthlyResult(secondMonth, "copytrader1", secondMonthResultCopyTrader1);
            copytraders.UpdateMonthlyResult(secondMonth, "copytrader2", secondMonthResultCopyTrader2);
            copytraders.AddMonthlyInvest(thirdMonth, "copytrader1", monthlyInvestment);
            copytraders.AddMonthlyInvest(thirdMonth, "copytrader2", monthlyInvestment);
            copytraders.UpdateMonthlyResult(thirdMonth, "copytrader1", thirdMonthResultCopyTrader1);
            copytraders.UpdateMonthlyResult(thirdMonth, "copytrader2", thirdMonthResultCopyTrader2);

            Assert.That(copytraders.TotalInvest, Is.EqualTo(2 * 3 * monthlyInvestment));
            Assert.That(copytraders.AvarageMonthlyProfitIndex, Is.EqualTo(avarageMonthlyProfitIndex));
            Assert.That(copytraders.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(2 * monthlyInvestment));
            Assert.That(copytraders.MonthlyInvests[firstMonth].Invest, Is.EqualTo(2 * monthlyInvestment));
            Assert.That(copytraders.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(firstMonthProfitIndex));
            Assert.That(copytraders.MonthlyInvests[firstMonth].Profit, Is.EqualTo(firstMonthProfit));
            Assert.That(copytraders.MonthlyInvests[firstMonth].Result, Is.EqualTo(firstMonthResultCopyTrader1 + firstMonthResultCopyTrader2));
            Assert.That(copytraders.MonthlyInvests[secondMonth].TotalInvest, Is.EqualTo(secondMonthTotalInvestment));
            Assert.That(copytraders.MonthlyInvests[secondMonth].Invest, Is.EqualTo(2 * monthlyInvestment));
            Assert.That(copytraders.MonthlyInvests[secondMonth].ProfitIndex, Is.EqualTo(secondMonthProfitIndex));
            Assert.That(copytraders.MonthlyInvests[secondMonth].Profit, Is.EqualTo(secondMonthProfit));
            Assert.That(copytraders.MonthlyInvests[secondMonth].Result, Is.EqualTo(secondMonthResultCopyTrader1 + secondMonthResultCopyTrader2));
            Assert.That(copytraders.MonthlyInvests[thirdMonth].TotalInvest, Is.EqualTo(thirdMonthTotalInvestment));
            Assert.That(copytraders.MonthlyInvests[thirdMonth].Invest, Is.EqualTo(2 * monthlyInvestment));
            Assert.That(copytraders.MonthlyInvests[thirdMonth].ProfitIndex, Is.EqualTo(thirdMonthProfitIndex));
            Assert.That(copytraders.MonthlyInvests[thirdMonth].Profit, Is.EqualTo(thirdMonthProfit));
            Assert.That(copytraders.MonthlyInvests[thirdMonth].Result, Is.EqualTo(thirdMonthResultCopyTrader1 + thirdMonthResultCopyTrader2));
        }
    }
}
