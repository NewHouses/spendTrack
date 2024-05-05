namespace spendTrack.Invest.Domain
{
    public class StockAggregator
    {
        public Dictionary<string, Stock> Stocks;

        public StockAggregator(List<Stock> stocks)
        {
            Stocks = new Dictionary<string, Stock>();
            stocks.ForEach(s => Stocks.Add(s.Name, s));
        }

        public Stock? GetStock(string name)
        {
            return Stocks.GetValueOrDefault(name);
        }

        public void AddMonthlyInvest(string month, string stockName, decimal invest)
        {
            var stock = GetStock(stockName);

            if (stock is null)
            {
                stock = new Stock(stockName);
                Stocks.Add(stockName, stock);
            }

            stock.AddMonthlyInvest(month, invest);
        }
    }
}
