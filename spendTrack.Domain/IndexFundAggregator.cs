
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
    }
}
