using spendTrack.Invest.Domain.ValueObjects;

namespace spendTrack.Invest.Domain
{
    public class Invests
    {
        public StockAggregator Stocks { get; set; }
        public IndexFundAggregator IndexFunds { get; set; }
        public CopyTraderAggregator CopyTraders { get; set; }
        public Dictionary<int, MonthlyInvest> MonthlyInvests { get; set; }


        public Invests(List<Stock> stocks, List<IndexFund> indexFunds, List<CopyTrader> copyTraders)
        {
            Stocks = new StockAggregator(stocks);
            IndexFunds = new IndexFundAggregator(indexFunds);
            CopyTraders = new CopyTraderAggregator(copyTraders);
        }
    }
}
