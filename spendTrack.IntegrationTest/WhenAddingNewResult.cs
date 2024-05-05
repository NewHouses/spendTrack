using spendTrack.App.ApplicationServices;
using spendTrack.Infrastructure;

namespace spendTrack.IntegrationTest
{
    internal class WhenAddingNewResult
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
        public async Task ExistingStockUpdatesResult()
        {
            var stockName = "stockTest";
            var month = "03/2024";
            var existingInvest = 100.00M;
            var result = 50.00M;
            var expectingProfit = result - existingInvest;
            var expectingProfitIndex = Math.Round(100 * expectingProfit / existingInvest);
            var stocks = await repository.GetStocks();
            service.AddStockInvest(month, stockName, existingInvest);

            service.UpdateStockResult(month, stockName, result);

            var stock = stocks.GetStock(stockName);
            Assert.That(stock.Name, Is.EqualTo(stockName));
            Assert.That(stock.MonthlyInvests.Count, Is.EqualTo(1));
            Assert.That(stock.MonthlyInvests[month].Month, Is.EqualTo(month));
            Assert.That(stock.MonthlyInvests[month].TotalInvest, Is.EqualTo(existingInvest));
            Assert.That(stock.MonthlyInvests[month].Invest, Is.EqualTo(existingInvest));
            Assert.That(stock.MonthlyInvests[month].Profit, Is.EqualTo(expectingProfit));
            Assert.That(stock.MonthlyInvests[month].ProfitIndex, Is.EqualTo(expectingProfitIndex));
            Assert.That(stock.MonthlyInvests[month].Result, Is.EqualTo(result));
        }

        [Test]
        public async Task ExistingIndexFundUpdatesResult()
        {
            var indexfundName = "indexFundTest";
            var month = "03/2024";
            var existingInvest = 100.00M;
            var result = 50.00M;
            var expectingProfit = result - existingInvest;
            var expectingProfitIndex = Math.Round(100 * expectingProfit / existingInvest);
            var indexfunds = await repository.GetIndexFunds();
            service.AddIndexFundInvest(month, indexfundName, existingInvest);

            service.UpdateIndexFundResult(month, indexfundName, result);

            var indexfund = indexfunds.GetIndexFund(indexfundName);
            Assert.That(indexfund.Name, Is.EqualTo(indexfundName));
            Assert.That(indexfund.MonthlyInvests.Count, Is.EqualTo(1));
            Assert.That(indexfund.MonthlyInvests[month].Month, Is.EqualTo(month));
            Assert.That(indexfund.MonthlyInvests[month].TotalInvest, Is.EqualTo(existingInvest));
            Assert.That(indexfund.MonthlyInvests[month].Invest, Is.EqualTo(existingInvest));
            Assert.That(indexfund.MonthlyInvests[month].Profit, Is.EqualTo(expectingProfit));
            Assert.That(indexfund.MonthlyInvests[month].ProfitIndex, Is.EqualTo(expectingProfitIndex));
            Assert.That(indexfund.MonthlyInvests[month].Result, Is.EqualTo(result));
        }
    }
}
