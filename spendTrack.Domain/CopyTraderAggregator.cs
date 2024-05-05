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

        public CopyTrader? GetCopyTrader(string name)
        {
            return CopyTraders.GetValueOrDefault(name);
        }

        public void AddMonthlyInvest(string month, string copyTraderName, decimal invest)
        {
            var copyTrader = GetCopyTrader(copyTraderName);

            if (copyTrader is null)
            {
                copyTrader = new CopyTrader(copyTraderName);
                CopyTraders.Add(copyTraderName, copyTrader);
            }

            copyTrader.AddMonthlyInvest(month, invest);
        }
    }
}
