using spendTrack.App.Repositories;
using spendTrack.Invest.Domain;

namespace spendTrack.Infrastructure
{
    public class InvestingRepository : IInvestingRepository
    {
        private readonly Invests invests;

        public InvestingRepository()
        {
            invests = new Invests(new List<Stock>(), new List<IndexFund>(), new List<CopyTrader>());
        }

        public Task<Invests> GetInvests()
        {
            return Task.FromResult(invests);
        }

        public Task<StockAggregator> GetStocks()
        {
            return Task.FromResult(invests.Stocks);
        }

        public Task<IndexFundAggregator> GetIndexFunds()
        {
            return Task.FromResult(invests.IndexFunds);
        }

        public Task<CopyTraderAggregator> GetCopyTraders()
        {
            return Task.FromResult(invests.CopyTraders);
        }

        public Stock GetStockByName(string name)
        {
            return invests.Stocks.GetStock(name);
        }

        public void AddStockMonthlyInvest(string month, string stockName, decimal amount)
        {
            invests.AddStockInvest(month, stockName, amount);
        }

        public void AddIndexFundMonthlyInvest(string month, string indexFundName, decimal amount)
        {
            invests.AddIndexFundInvest(month, indexFundName, amount);
        }

        public void AddCopyTraderMonthlyInvest(string month, string copyTraderName, decimal amount)
        {
            invests.AddCopyTraderInvest(month, copyTraderName, amount);
        }

        public void UpdateStockMonthlyResult(string month, string stockName, decimal result)
        {
            invests.UpdateStockResult(month, stockName, result);
        }

        public void UpdateIndexFundMonthlyResult(string month, string indexfundName, decimal result)
        {
            invests.UpdateIndexFundResult(month, indexfundName, result);
        }

        public void UpdateCopyTraderMonthlyResult(string month, string copyTraderName, decimal result)
        {
            invests.UpdateCopyTraderResult(month, copyTraderName, result);
        }
    }
}
