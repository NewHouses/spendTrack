
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

        public void AddMonthlyInvest(string month, string name, decimal invest)
        {
            var indexFund = GetIndexFund(name);

            if (indexFund is null)
            {
                indexFund = new IndexFund(name);
                IndexFunds.Add(name, indexFund);
            }

            indexFund.AddMonthlyInvest(month, invest);
        }
    }
}
