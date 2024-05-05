
namespace spendTrack.Invest.Domain
{
    public class CopyTraderAggregator
    {
        public Dictionary<string, CopyTrader> CopyTraders;

        public CopyTraderAggregator(List<CopyTrader> copyTraders)
        {
            CopyTraders = new Dictionary<string, CopyTrader>();
            copyTraders.ForEach(ct =>  CopyTraders.Add(ct.Name, ct));
        }
    }
}
