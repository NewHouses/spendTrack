using spendTrack.App.ApplicationServices;
using spendTrack.Infrastructure;

namespace spendTrack.IntegrationTest
{
    public class WhenAddingNewInvest
    {
        private InvestingRepository repository;
        private InvestingService service;

        [SetUp]
        public void Setup()
        {
            repository = new InvestingRepository();
            var outputGenerator = new CsvGenerator();
            service = new InvestingService(repository, outputGenerator);
        }

        [Test]
        public async Task ExistingStockIsUpdatedInTheAggregator()
        {
            var stockName = "stockTest";
            var existingMonth = "03/2024";
            var existingInvest = 100.00M;
            var existingResult = 150.00M;
            var existingProfit = existingResult - existingInvest;
            var existingProfitIndex = Math.Round(100 * existingProfit / existingInvest, 2);
            var newMonth = "05/2024";
            var stockInvest = 200.00M;
            var stocks = await repository.GetStocks();

            service.AddStockInvest(existingMonth, stockName, existingInvest);
            service.UpdateStockResult(existingMonth, stockName, existingResult);
            service.AddStockInvest(newMonth, stockName, stockInvest);

            Assert.That(stocks.TotalInvest, Is.EqualTo(existingInvest + stockInvest));
            Assert.That(stocks.AvarageMonthlyProfitIndex, Is.EqualTo(existingProfitIndex));
            Assert.That(stocks.MonthlyInvests.Count, Is.EqualTo(2));
            Assert.That(stocks.MonthlyInvests[existingMonth].Month, Is.EqualTo(existingMonth));
            Assert.That(stocks.MonthlyInvests[existingMonth].TotalInvest, Is.EqualTo(existingInvest));
            Assert.That(stocks.MonthlyInvests[existingMonth].Invest, Is.EqualTo(existingInvest));
            Assert.That(stocks.MonthlyInvests[newMonth].Month, Is.EqualTo(newMonth));
            Assert.That(stocks.MonthlyInvests[newMonth].TotalInvest, Is.EqualTo(stockInvest + existingResult));
            Assert.That(stocks.MonthlyInvests[newMonth].Invest, Is.EqualTo(stockInvest));
            Assert.That(stocks.MonthlyInvests[newMonth].Profit, Is.EqualTo(0));
            Assert.That(stocks.MonthlyInvests[newMonth].ProfitIndex, Is.EqualTo(0));
            Assert.That(stocks.MonthlyInvests[newMonth].Result, Is.EqualTo(0));
            var stock = stocks.GetStock(stockName);
            Assert.That(stock.Name, Is.EqualTo(stockName));
            Assert.That(stock.TotalInvest, Is.EqualTo(existingInvest + stockInvest));
            Assert.That(stock.AvarageMonthlyProfitIndex, Is.EqualTo(existingProfitIndex));
            Assert.That(stock.MonthlyInvests.Count, Is.EqualTo(2));
            Assert.That(stock.MonthlyInvests[existingMonth].Month, Is.EqualTo(existingMonth));
            Assert.That(stock.MonthlyInvests[existingMonth].TotalInvest, Is.EqualTo(existingInvest));
            Assert.That(stock.MonthlyInvests[existingMonth].Invest, Is.EqualTo(existingInvest));
            Assert.That(stock.MonthlyInvests[newMonth].Month, Is.EqualTo(newMonth));
            Assert.That(stock.MonthlyInvests[newMonth].TotalInvest, Is.EqualTo(stockInvest + existingResult));
            Assert.That(stock.MonthlyInvests[newMonth].Invest, Is.EqualTo(stockInvest));
            Assert.That(stock.MonthlyInvests[newMonth].Profit, Is.EqualTo(0));
            Assert.That(stock.MonthlyInvests[newMonth].ProfitIndex, Is.EqualTo(0));
            Assert.That(stock.MonthlyInvests[newMonth].Result, Is.EqualTo(0));
        }

        [Test]
        public async Task ExistingIndexFundIsUpdatedInTheAggregator()
        {
            var indexFundName = "indexFundTest";
            var existingMonth = "03/2024";
            var existingInvest = 100.00M;
            var existingResult = 150.00M;
            var existingProfit = existingResult - existingInvest;
            var existingProfitIndex = Math.Round(100 * existingProfit / existingInvest, 2);
            var newMonth = "05/2024";
            var indexFundInvest = 200.00M;
            var indexFunds = await repository.GetIndexFunds();

            service.AddIndexFundInvest(existingMonth, indexFundName, existingInvest);
            service.UpdateIndexFundResult(existingMonth, indexFundName, existingResult);
            service.AddIndexFundInvest(newMonth, indexFundName, indexFundInvest);

            var indexFund = indexFunds.GetIndexFund(indexFundName);
            Assert.That(indexFund.Name, Is.EqualTo(indexFundName));
            Assert.That(indexFund.TotalInvest, Is.EqualTo(existingInvest + indexFundInvest));
            Assert.That(indexFund.AvarageMonthlyProfitIndex, Is.EqualTo(existingProfitIndex));
            Assert.That(indexFund.MonthlyInvests.Count, Is.EqualTo(2));
            Assert.That(indexFund.MonthlyInvests[existingMonth].Month, Is.EqualTo(existingMonth));
            Assert.That(indexFund.MonthlyInvests[existingMonth].TotalInvest, Is.EqualTo(existingInvest));
            Assert.That(indexFund.MonthlyInvests[existingMonth].Invest, Is.EqualTo(existingInvest));
            Assert.That(indexFund.MonthlyInvests[newMonth].Month, Is.EqualTo(newMonth));
            Assert.That(indexFund.MonthlyInvests[newMonth].TotalInvest, Is.EqualTo(indexFundInvest + existingResult));
            Assert.That(indexFund.MonthlyInvests[newMonth].Invest, Is.EqualTo(indexFundInvest));
            Assert.That(indexFund.MonthlyInvests[newMonth].Profit, Is.EqualTo(0));
            Assert.That(indexFund.MonthlyInvests[newMonth].ProfitIndex, Is.EqualTo(0));
            Assert.That(indexFund.MonthlyInvests[newMonth].Result, Is.EqualTo(0));
        }

        [Test]
        public async Task ExistingCopyTraderIsUpdatedInTheAggregator()
        {
            var copyTraderName = "copyTraderTest";
            var existingMonth = "03/2024";
            var existingInvest = 100.00M;
            var existingResult = 150.00M;
            var existingProfit = existingResult - existingInvest;
            var existingProfitIndex = Math.Round(100 * existingProfit / existingInvest, 2);
            var newMonth = "05/2024";
            var copyTraderInvest = 200.00M;
            var copyTraders = await repository.GetCopyTraders();

            service.AddCopyTraderInvest(existingMonth, copyTraderName, existingInvest);
            service.UpdateCopyTraderResult(existingMonth, copyTraderName, existingResult);
            service.AddCopyTraderInvest(newMonth, copyTraderName, copyTraderInvest);

            var copyTrader = copyTraders.GetCopyTrader(copyTraderName);
            Assert.That(copyTrader.Name, Is.EqualTo(copyTraderName));
            Assert.That(copyTrader.TotalInvest, Is.EqualTo(existingInvest + copyTraderInvest));
            Assert.That(copyTrader.AvarageMonthlyProfitIndex, Is.EqualTo(existingProfitIndex));
            Assert.That(copyTrader.MonthlyInvests.Count, Is.EqualTo(2));
            Assert.That(copyTrader.MonthlyInvests[existingMonth].Month, Is.EqualTo(existingMonth));
            Assert.That(copyTrader.MonthlyInvests[existingMonth].TotalInvest, Is.EqualTo(existingInvest));
            Assert.That(copyTrader.MonthlyInvests[existingMonth].Invest, Is.EqualTo(existingInvest));
            Assert.That(copyTrader.MonthlyInvests[newMonth].Month, Is.EqualTo(newMonth));
            Assert.That(copyTrader.MonthlyInvests[newMonth].TotalInvest, Is.EqualTo(existingResult + copyTraderInvest));
            Assert.That(copyTrader.MonthlyInvests[newMonth].Invest, Is.EqualTo(copyTraderInvest));
            Assert.That(copyTrader.MonthlyInvests[newMonth].Profit, Is.EqualTo(0));
            Assert.That(copyTrader.MonthlyInvests[newMonth].ProfitIndex, Is.EqualTo(0));
            Assert.That(copyTrader.MonthlyInvests[newMonth].Result, Is.EqualTo(0));
        }
    }
}