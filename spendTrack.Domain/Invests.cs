using spendTrack.Invest.Domain.ValueObjects;

namespace spendTrack.Invest.Domain
{
    public class Invests : Invest
    {
        public StockAggregator Stocks { get; set; }
        public IndexFundAggregator IndexFunds { get; set; }
        public CopyTraderAggregator CopyTraders { get; set; }


        public Invests(List<Stock> stocks, List<IndexFund> indexFunds, List<CopyTrader> copyTraders) : base(new Dictionary<string, MonthlyInvest>())
        {
            Stocks = new StockAggregator(stocks);
            IndexFunds = new IndexFundAggregator(indexFunds);
            CopyTraders = new CopyTraderAggregator(copyTraders);
        }

        public void AddStockInvest(string month, string stockName, decimal amount)
        { 
            Stocks.AddMonthlyInvest(month, stockName, amount);
            AddMonthlyInvest(month, amount);
        }

        public void AddIndexFundInvest(string month, string indexFundName, decimal amount)
        {
            IndexFunds.AddMonthlyInvest(month, indexFundName, amount);
            AddMonthlyInvest(month, amount);
        }

        public void AddCopyTraderInvest(string month, string copyTraderName, decimal amount)
        {
            CopyTraders.AddMonthlyInvest(month, copyTraderName, amount);
            AddMonthlyInvest(month, amount);
        }

        public void UpdateStockResult(string month, string stockName, decimal result)
        {
            Stocks.UpdateMonthlyResult(month, stockName, result);

            var newResult = GetTotalResultByMonth(month);
            UpdateMonthlyResult(month, newResult);
        }

        public void UpdateIndexFundResult(string month, string indexFundName, decimal result)
        {
            IndexFunds.UpdateMonthlyResult(month, indexFundName, result);
            
            var newResult = GetTotalResultByMonth(month);
            UpdateMonthlyResult(month, newResult);
        }

        public void UpdateCopyTraderResult(string month, string copyTraderName, decimal result)
        {
            CopyTraders.UpdateMonthlyResult(month, copyTraderName, result);

            var newResult = GetTotalResultByMonth(month);
            UpdateMonthlyResult(month, newResult);
        }

        private decimal GetTotalResultByMonth(string month)
        {
            var stockResult = Stocks.MonthlyInvests.GetValueOrDefault(month)?.Result ?? 0;
            var indexFundResult = IndexFunds.MonthlyInvests.GetValueOrDefault(month)?.Result ?? 0;
            var copyTraderResult = CopyTraders.MonthlyInvests.GetValueOrDefault(month)?.Result ?? 0;
            return stockResult + indexFundResult + copyTraderResult;
        }
    }
}
