using spendTrack.Invest.Domain;

namespace spendTrack.App.Repositories
{
    public interface IInvestingRepository
    {
        Task<CopyTraderAggregator> GetCopyTraders();
        Task<IndexFundAggregator> GetIndexFunds();
        Task<StockAggregator> GetStocks();
        Stock GetStockByName(string name);
        void AddStockMonthlyInvest(string month, string name, decimal amount);
        void AddIndexFundMonthlyInvest(string month, string name, decimal amount);
        void AddCopyTraderMonthlyInvest(string month, string copyTraderName, decimal amount);
        void UpdateCopyTraderMonthlyResult(string month, string stockName, decimal result);
    }
}
