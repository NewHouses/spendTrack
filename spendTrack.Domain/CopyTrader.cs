using spendTrack.Invest.Domain.ValueObjects;

namespace spendTrack.Invest.Domain
{
    public class CopyTrader : Invest
    {
        public string Name { get; set; }
        public CopyTrader(string name, Dictionary<string, MonthlyInvest> monthlyInvests) : base(monthlyInvests)
        {
            Name = name;
        }
    }
}
