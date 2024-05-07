using spendTrack.Invest.Domain;

namespace spendTrack.UnitTest
{
    public class WhenUpdatingInvestmentResult
    {
        [Test]
        public void MonthlyInvestementResultsAreUpdated()
        {
            var invests = new Invests(new List<Stock>(), new List<IndexFund>(), new List<CopyTrader>());
            var firstMonth = "02/2024";
            var secondMonth = "03/2024";
            var thirdMonth = "04/2024";
            var monthlyInvestment = 100.00M;
            var firstMonthResultStock1 = 150.00M;
            var firstMonthResultStock2 = 70.00M;
            var firstMonthResultIndexFund1 = 130.00M;
            var firstMonthResultIndexFund2 = 170.00M;
            var firstMonthResultCopyTrader1 = 90.00M;
            var firstMonthResultCopyTrader2 = 80.00M;
            var firstMonthTotalResult = firstMonthResultStock1 + firstMonthResultStock2 + firstMonthResultIndexFund1 + firstMonthResultIndexFund2 + firstMonthResultCopyTrader1 + firstMonthResultCopyTrader2;
            var secondMonthResultStock1 = 270.00M;
            var secondMonthResultStock2 = 210.00M;
            var secondMonthResultIndexFund1 = 260.00M;
            var secondMonthResultIndexFund2 = 280.00M;
            var secondMonthResultCopyTrader1 = 160.00M;
            var secondMonthResultCopyTrader2 = 210.00M;
            var secondMonthTotalResult = secondMonthResultStock1 + secondMonthResultStock2 + secondMonthResultIndexFund1 + secondMonthResultIndexFund2 + secondMonthResultCopyTrader1 + secondMonthResultCopyTrader2;
            var thirdMonthResultStock1 = 420.00M;
            var thirdMonthResultStock2 = 310.00M;
            var thirdMonthResultIndexFund1 = 460.00M;
            var thirdMonthResultIndexFund2 = 395.00M;
            var thirdMonthResultCopyTrader1 = 200.00M;
            var thirdMonthResultCopyTrader2 = 290.00M;
            var thirdMonthTotalResult = thirdMonthResultStock1 + thirdMonthResultStock2 + thirdMonthResultIndexFund1 + thirdMonthResultIndexFund2 + thirdMonthResultCopyTrader1 + thirdMonthResultCopyTrader2;
            var secondMonthTotalInvestment = firstMonthTotalResult + 6 * monthlyInvestment;
            var thirdMonthTotalInvestment = secondMonthTotalResult + 6 * monthlyInvestment;
            var firstMonthProfit = firstMonthTotalResult - 6 * monthlyInvestment;
            var secondMonthProfit = secondMonthTotalResult - secondMonthTotalInvestment;
            var thirdMonthProfit = thirdMonthTotalResult - thirdMonthTotalInvestment;
            var firstMonthProfitIndex = Math.Round(100 * firstMonthProfit / (6 * monthlyInvestment), 2);
            var secondMonthProfitIndex = Math.Round(100 * secondMonthProfit / secondMonthTotalInvestment, 2);
            var thirdMonthProfitIndex = Math.Round(100 * thirdMonthProfit / thirdMonthTotalInvestment, 2);
            var avarageMonthlyProfitIndex = Math.Round((firstMonthProfitIndex + secondMonthProfitIndex + thirdMonthProfitIndex) / 3, 2);

            invests.AddStockInvest(firstMonth, "stock1", monthlyInvestment);
            invests.AddStockInvest(firstMonth, "stock2", monthlyInvestment);
            invests.AddIndexFundInvest(firstMonth, "indexFund1", monthlyInvestment);
            invests.AddIndexFundInvest(firstMonth, "indexFund2", monthlyInvestment);
            invests.AddCopyTraderInvest(firstMonth, "copyTrader1", monthlyInvestment);
            invests.AddCopyTraderInvest(firstMonth, "copyTrader2", monthlyInvestment);
            invests.UpdateStockResult(firstMonth, "stock1", firstMonthResultStock1);
            invests.UpdateStockResult(firstMonth, "stock2", firstMonthResultStock2);
            invests.UpdateIndexFundResult(firstMonth, "indexFund1", firstMonthResultIndexFund1);
            invests.UpdateIndexFundResult(firstMonth, "indexFund2", firstMonthResultIndexFund2);
            invests.UpdateCopyTraderResult(firstMonth, "copyTrader1", firstMonthResultCopyTrader1);
            invests.UpdateCopyTraderResult(firstMonth, "copyTrader2", firstMonthResultCopyTrader2);
            invests.AddStockInvest(secondMonth, "stock1", monthlyInvestment);
            invests.AddStockInvest(secondMonth, "stock2", monthlyInvestment);
            invests.AddIndexFundInvest(secondMonth, "indexFund1", monthlyInvestment);
            invests.AddIndexFundInvest(secondMonth, "indexFund2", monthlyInvestment);
            invests.AddCopyTraderInvest(secondMonth, "copyTrader1", monthlyInvestment);
            invests.AddCopyTraderInvest(secondMonth, "copyTrader2", monthlyInvestment);
            invests.UpdateStockResult(secondMonth, "stock1", secondMonthResultStock1);
            invests.UpdateStockResult(secondMonth, "stock2", secondMonthResultStock2);
            invests.UpdateIndexFundResult(secondMonth, "indexFund1", secondMonthResultIndexFund1);
            invests.UpdateIndexFundResult(secondMonth, "indexFund2", secondMonthResultIndexFund2);
            invests.UpdateCopyTraderResult(secondMonth, "copyTrader1", secondMonthResultCopyTrader1);
            invests.UpdateCopyTraderResult(secondMonth, "copyTrader2", secondMonthResultCopyTrader2);
            invests.AddStockInvest(thirdMonth, "stock1", monthlyInvestment);
            invests.AddStockInvest(thirdMonth, "stock2", monthlyInvestment);
            invests.AddIndexFundInvest(thirdMonth, "indexFund1", monthlyInvestment);
            invests.AddIndexFundInvest(thirdMonth, "indexFund2", monthlyInvestment);
            invests.AddCopyTraderInvest(thirdMonth, "copyTrader1", monthlyInvestment);
            invests.AddCopyTraderInvest(thirdMonth, "copyTrader2", monthlyInvestment);
            invests.UpdateStockResult(thirdMonth, "stock1", thirdMonthResultStock1);
            invests.UpdateStockResult(thirdMonth, "stock2", thirdMonthResultStock2);
            invests.UpdateIndexFundResult(thirdMonth, "indexFund1", thirdMonthResultIndexFund1);
            invests.UpdateIndexFundResult(thirdMonth, "indexFund2", thirdMonthResultIndexFund2);
            invests.UpdateCopyTraderResult(thirdMonth, "copyTrader1", thirdMonthResultCopyTrader1);
            invests.UpdateCopyTraderResult(thirdMonth, "copyTrader2", thirdMonthResultCopyTrader2);

            Assert.That(invests.TotalInvest, Is.EqualTo(6 * 3 * monthlyInvestment));
            Assert.That(invests.AvarageMonthlyProfitIndex, Is.EqualTo(avarageMonthlyProfitIndex));
            Assert.That(invests.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(6 * monthlyInvestment));
            Assert.That(invests.MonthlyInvests[firstMonth].Invest, Is.EqualTo(6 * monthlyInvestment));
            Assert.That(invests.MonthlyInvests[firstMonth].Result, Is.EqualTo(firstMonthTotalResult));
            Assert.That(invests.MonthlyInvests[firstMonth].Profit, Is.EqualTo(firstMonthProfit));
            Assert.That(invests.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(firstMonthProfitIndex));
            Assert.That(invests.MonthlyInvests[secondMonth].TotalInvest, Is.EqualTo(secondMonthTotalInvestment));
            Assert.That(invests.MonthlyInvests[secondMonth].Invest, Is.EqualTo(6 * monthlyInvestment));
            Assert.That(invests.MonthlyInvests[secondMonth].Result, Is.EqualTo(secondMonthTotalResult));
            Assert.That(invests.MonthlyInvests[secondMonth].Profit, Is.EqualTo(secondMonthProfit));
            Assert.That(invests.MonthlyInvests[secondMonth].ProfitIndex, Is.EqualTo(secondMonthProfitIndex));
            Assert.That(invests.MonthlyInvests[thirdMonth].TotalInvest, Is.EqualTo(thirdMonthTotalInvestment));
            Assert.That(invests.MonthlyInvests[thirdMonth].Invest, Is.EqualTo(6 * monthlyInvestment));
            Assert.That(invests.MonthlyInvests[thirdMonth].Result, Is.EqualTo(thirdMonthTotalResult));
            Assert.That(invests.MonthlyInvests[thirdMonth].Profit, Is.EqualTo(thirdMonthProfit));
            Assert.That(invests.MonthlyInvests[thirdMonth].ProfitIndex, Is.EqualTo(thirdMonthProfitIndex));
        }
    }
}
