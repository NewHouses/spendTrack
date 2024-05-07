using spendTrack.Invest.Domain;

namespace spendTrack.App.Repositories
{
    public interface IInvestingRepository
    {
        Task<Invests> GetInvests();
        Task<StockAggregator> GetStocks();
        Task<IndexFundAggregator> GetIndexFunds();
        Task<CopyTraderAggregator> GetCopyTraders();
        Stock GetStockByName(string name);
        void AddStockMonthlyInvest(string month, string name, decimal amount);
        void AddIndexFundMonthlyInvest(string month, string name, decimal amount);
        void AddCopyTraderMonthlyInvest(string month, string copyTraderName, decimal amount);
        void UpdateStockMonthlyResult(string month, string stockName, decimal result);
        void UpdateIndexFundMonthlyResult(string month, string indexfundName, decimal result);
        void UpdateCopyTraderMonthlyResult(string month, string copyTraderName, decimal result);
    }
}
