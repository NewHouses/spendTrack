
namespace spendTrack.Invest.Domain
{
    public class IndexFundAggregator
    {
        public Dictionary<string, IndexFund> IndexFunds;

        public IndexFundAggregator(List<IndexFund> indexFunds)
        {
            IndexFunds = new Dictionary<string, IndexFund>();
            indexFunds.ForEach(i => IndexFunds.Add(i.Name, i));
        }

        public IndexFund? GetIndexFund(string name)
        {
            return IndexFunds.GetValueOrDefault(name);
        }

        public void AddMonthlyInvest(string month, string indexFundName, decimal invest)
        {
            var indexFund = GetIndexFund(indexFundName);

            if (indexFund is null)
            {
                indexFund = new IndexFund(indexFundName);
                IndexFunds.Add(indexFundName, indexFund);
            }

            indexFund.AddMonthlyInvest(month, invest);
        }

        public void UpdateMonthlyResult(string month, string indexFundName, decimal result)
        {
            var stock = GetIndexFund(indexFundName);

            if (stock is null)
                throw new ArgumentException($"Index Fund {indexFundName} does not exist");

            stock.UpdateMonthlyResult(month, result);
        }
    }
}
