using spendTrack.Invest.Domain.ValueObjects;

namespace spendTrack.Invest.Domain
{
    public class CopyTraderAggregator : Invest
    {
        public Dictionary<string, CopyTrader> CopyTraders;

        public CopyTraderAggregator(List<CopyTrader> copyTraders) : base(new Dictionary<string, MonthlyInvest>())
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
            AddMonthlyInvest(month, invest);
        }

        public void UpdateMonthlyResult(string month, string copyTraderName, decimal result)
        {
            var copyTrader = GetCopyTrader(copyTraderName);

            if (copyTrader is null)
                throw new ArgumentException($"Copy Trader {copyTraderName} does not exist");

            copyTrader.UpdateMonthlyResult(month, result);

            var newResult = CopyTraders.Where(s => s.Value.MonthlyInvests.ContainsKey(month)).Sum(s => s.Value.MonthlyInvests[month].Result);
            UpdateMonthlyResult(month, newResult);
        }
    }
}
