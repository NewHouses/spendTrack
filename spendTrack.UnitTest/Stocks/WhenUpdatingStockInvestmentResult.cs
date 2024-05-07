using spendTrack.Invest.Domain;

namespace spendTrack.UnitTest.Stocks
{
    public class WhenUpdatingInvestmentResult
    {
        [Test]
        public void MonthlyInvestementResultsAreUpdated()
        {
            var stock = new Stock("stock1");
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

            stock.AddMonthlyInvest(firstMonth, monthlyInvestment);
            stock.UpdateMonthlyResult(firstMonth, firstMonthResult);
            stock.AddMonthlyInvest(secondMonth, monthlyInvestment);
            stock.UpdateMonthlyResult(secondMonth, secondMonthResult);
            stock.AddMonthlyInvest(thirdMonth, monthlyInvestment);
            stock.UpdateMonthlyResult(thirdMonth, thirdMonthResult);

            Assert.That(stock.TotalInvest, Is.EqualTo(3 * monthlyInvestment));
            Assert.That(stock.AvarageMonthlyProfitIndex, Is.EqualTo(avarageMonthlyProfitIndex));
            Assert.That(stock.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(stock.MonthlyInvests[firstMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(stock.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(firstMonthProfitIndex));
            Assert.That(stock.MonthlyInvests[firstMonth].Profit, Is.EqualTo(firstMonthProfit));
            Assert.That(stock.MonthlyInvests[firstMonth].Result, Is.EqualTo(firstMonthResult));
            Assert.That(stock.MonthlyInvests[secondMonth].TotalInvest, Is.EqualTo(secondMonthTotalInvestment));
            Assert.That(stock.MonthlyInvests[secondMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(stock.MonthlyInvests[secondMonth].ProfitIndex, Is.EqualTo(secondMonthProfitIndex));
            Assert.That(stock.MonthlyInvests[secondMonth].Profit, Is.EqualTo(secondMonthProfit));
            Assert.That(stock.MonthlyInvests[secondMonth].Result, Is.EqualTo(secondMonthResult));
            Assert.That(stock.MonthlyInvests[thirdMonth].TotalInvest, Is.EqualTo(thirdMonthTotalInvestment));
            Assert.That(stock.MonthlyInvests[thirdMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(stock.MonthlyInvests[thirdMonth].ProfitIndex, Is.EqualTo(thirdMonthProfitIndex));
            Assert.That(stock.MonthlyInvests[thirdMonth].Profit, Is.EqualTo(thirdMonthProfit));
            Assert.That(stock.MonthlyInvests[thirdMonth].Result, Is.EqualTo(thirdMonthResult));
        }

        [Test]
        public void SeparatedMonthlyInvestementResultsAreUpdated()
        {
            var stock = new Stock("stock1");
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

            stock.AddMonthlyInvest(firstMonth, monthlyInvestment);
            stock.UpdateMonthlyResult(firstMonth, firstMonthResult);
            stock.AddMonthlyInvest(secondMonth, monthlyInvestment);
            stock.UpdateMonthlyResult(secondMonth, secondMonthResult);
            stock.AddMonthlyInvest(thirdMonth, monthlyInvestment);
            stock.UpdateMonthlyResult(thirdMonth, thirdMonthResult);

            Assert.That(stock.TotalInvest, Is.EqualTo(3 * monthlyInvestment));
            Assert.That(stock.AvarageMonthlyProfitIndex, Is.EqualTo(avarageMonthlyProfitIndex));
            Assert.That(stock.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(stock.MonthlyInvests[firstMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(stock.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(firstMonthProfitIndex));
            Assert.That(stock.MonthlyInvests[firstMonth].Profit, Is.EqualTo(firstMonthProfit));
            Assert.That(stock.MonthlyInvests[firstMonth].Result, Is.EqualTo(firstMonthResult));
            Assert.That(stock.MonthlyInvests[secondMonth].TotalInvest, Is.EqualTo(secondMonthTotalInvestment));
            Assert.That(stock.MonthlyInvests[secondMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(stock.MonthlyInvests[secondMonth].ProfitIndex, Is.EqualTo(secondMonthProfitIndex));
            Assert.That(stock.MonthlyInvests[secondMonth].Profit, Is.EqualTo(secondMonthProfit));
            Assert.That(stock.MonthlyInvests[secondMonth].Result, Is.EqualTo(secondMonthResult));
            Assert.That(stock.MonthlyInvests[thirdMonth].TotalInvest, Is.EqualTo(thirdMonthTotalInvestment));
            Assert.That(stock.MonthlyInvests[thirdMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(stock.MonthlyInvests[thirdMonth].ProfitIndex, Is.EqualTo(thirdMonthProfitIndex));
            Assert.That(stock.MonthlyInvests[thirdMonth].Profit, Is.EqualTo(thirdMonthProfit));
            Assert.That(stock.MonthlyInvests[thirdMonth].Result, Is.EqualTo(thirdMonthResult));
        }

        [Test]
        public void ZeroMonthlyInvestementIsAddedIfThereWasNotInvestmentInThatMonth()
        {
            var stock = new Stock("stock1");
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

            stock.AddMonthlyInvest(firstMonth, monthlyInvestment);
            stock.UpdateMonthlyResult(firstMonth, firstMonthResult);
            stock.UpdateMonthlyResult(secondMonth, secondMonthResult);

            Assert.That(stock.TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(stock.AvarageMonthlyProfitIndex, Is.EqualTo(avarageMonthlyProfitIndex));
            Assert.That(stock.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(stock.MonthlyInvests[firstMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(stock.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(firstMonthProfitIndex));
            Assert.That(stock.MonthlyInvests[firstMonth].Profit, Is.EqualTo(firstMonthProfit));
            Assert.That(stock.MonthlyInvests[firstMonth].Result, Is.EqualTo(firstMonthResult));
            Assert.That(stock.MonthlyInvests[secondMonth].TotalInvest, Is.EqualTo(secondMonthTotalInvestment));
            Assert.That(stock.MonthlyInvests[secondMonth].Invest, Is.EqualTo(0));
            Assert.That(stock.MonthlyInvests[secondMonth].ProfitIndex, Is.EqualTo(secondMonthProfitIndex));
            Assert.That(stock.MonthlyInvests[secondMonth].Profit, Is.EqualTo(secondMonthProfit));
            Assert.That(stock.MonthlyInvests[secondMonth].Result, Is.EqualTo(secondMonthResult));
        }

        [Test]
        public void StockAggregatorMonthlyInvestementResultsAreUpdated()
        {
            var stocks = new StockAggregator(new List<Stock>());
            var firstMonth = "02/2024";
            var secondMonth = "03/2024";
            var thirdMonth = "04/2024";
            var monthlyInvestment = 100.00M;
            var firstMonthResultStock1 = 150.00M;
            var firstMonthResultStock2 = 70.00M;
            var secondMonthResultStock1 = 270.00M;
            var secondMonthResultStock2 = 210.00M;
            var thirdMonthResultStock1 = 420.00M;
            var thirdMonthResultStock2 = 310.00M;
            var secondMonthTotalInvestment = firstMonthResultStock1 + firstMonthResultStock2 + 2 * monthlyInvestment;
            var thirdMonthTotalInvestment = secondMonthResultStock1 + secondMonthResultStock2 + 2 * monthlyInvestment;
            var firstMonthProfit = firstMonthResultStock1 + firstMonthResultStock2 - 2 * monthlyInvestment;
            var secondMonthProfit = secondMonthResultStock1 + secondMonthResultStock2 - secondMonthTotalInvestment;
            var thirdMonthProfit = thirdMonthResultStock1 + thirdMonthResultStock2 - thirdMonthTotalInvestment;
            var firstMonthProfitIndex = Math.Round(100 * firstMonthProfit / (2 * monthlyInvestment), 2);
            var secondMonthProfitIndex = Math.Round(100 * secondMonthProfit / secondMonthTotalInvestment, 2);
            var thirdMonthProfitIndex = Math.Round(100 * thirdMonthProfit / thirdMonthTotalInvestment, 2);
            var avarageMonthlyProfitIndex = Math.Round((firstMonthProfitIndex + secondMonthProfitIndex + thirdMonthProfitIndex) / 3, 2);

            stocks.AddMonthlyInvest(firstMonth, "stock1", monthlyInvestment);
            stocks.AddMonthlyInvest(firstMonth, "stock2", monthlyInvestment);
            stocks.UpdateMonthlyResult(firstMonth, "stock1", firstMonthResultStock1);
            stocks.UpdateMonthlyResult(firstMonth, "stock2", firstMonthResultStock2);
            stocks.AddMonthlyInvest(secondMonth, "stock1", monthlyInvestment);
            stocks.AddMonthlyInvest(secondMonth, "stock2", monthlyInvestment);
            stocks.UpdateMonthlyResult(secondMonth, "stock1", secondMonthResultStock1);
            stocks.UpdateMonthlyResult(secondMonth, "stock2", secondMonthResultStock2);
            stocks.AddMonthlyInvest(thirdMonth, "stock1", monthlyInvestment);
            stocks.AddMonthlyInvest(thirdMonth, "stock2", monthlyInvestment);
            stocks.UpdateMonthlyResult(thirdMonth, "stock1", thirdMonthResultStock1);
            stocks.UpdateMonthlyResult(thirdMonth, "stock2", thirdMonthResultStock2);

            Assert.That(stocks.TotalInvest, Is.EqualTo(2* 3 * monthlyInvestment));
            Assert.That(stocks.AvarageMonthlyProfitIndex, Is.EqualTo(avarageMonthlyProfitIndex));
            Assert.That(stocks.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(2 * monthlyInvestment));
            Assert.That(stocks.MonthlyInvests[firstMonth].Invest, Is.EqualTo(2 * monthlyInvestment));
            Assert.That(stocks.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(firstMonthProfitIndex));
            Assert.That(stocks.MonthlyInvests[firstMonth].Profit, Is.EqualTo(firstMonthProfit));
            Assert.That(stocks.MonthlyInvests[firstMonth].Result, Is.EqualTo(firstMonthResultStock1 + firstMonthResultStock2));
            Assert.That(stocks.MonthlyInvests[secondMonth].TotalInvest, Is.EqualTo(secondMonthTotalInvestment));
            Assert.That(stocks.MonthlyInvests[secondMonth].Invest, Is.EqualTo(2 * monthlyInvestment));
            Assert.That(stocks.MonthlyInvests[secondMonth].ProfitIndex, Is.EqualTo(secondMonthProfitIndex));
            Assert.That(stocks.MonthlyInvests[secondMonth].Profit, Is.EqualTo(secondMonthProfit));
            Assert.That(stocks.MonthlyInvests[secondMonth].Result, Is.EqualTo(secondMonthResultStock1 + secondMonthResultStock2));
            Assert.That(stocks.MonthlyInvests[thirdMonth].TotalInvest, Is.EqualTo(thirdMonthTotalInvestment));
            Assert.That(stocks.MonthlyInvests[thirdMonth].Invest, Is.EqualTo(2 * monthlyInvestment));
            Assert.That(stocks.MonthlyInvests[thirdMonth].ProfitIndex, Is.EqualTo(thirdMonthProfitIndex));
            Assert.That(stocks.MonthlyInvests[thirdMonth].Profit, Is.EqualTo(thirdMonthProfit));
            Assert.That(stocks.MonthlyInvests[thirdMonth].Result, Is.EqualTo(thirdMonthResultStock1 + thirdMonthResultStock2));
        }
    }
}
