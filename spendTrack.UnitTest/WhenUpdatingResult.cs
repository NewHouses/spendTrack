using spendTrack.Invest.Domain;

namespace spendTrack.UnitTest
{
    public class WhenUpdatingResult
    {
        [Test]
        public void StockMonthlyInvestementResultsAreUpdated()
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
        public void SeparatedStockMonthlyInvestementResultsAreUpdated()
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
        public void ThrowsArgumentExeceptionIfThereWasNotInvestmentInThatMonth()
        {
            var stock = new Stock("stock1");
            var month = "02/2024";

            var exception = Assert.Throws<ArgumentException>(() => stock.UpdateMonthlyResult(month, 100.00M));
            Assert.That(exception.Message, Is.EqualTo($"There was not investment in the month of {month}"));
        }
    }
}
