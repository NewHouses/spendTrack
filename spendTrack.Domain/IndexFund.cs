using spendTrack.Invest.Domain.ValueObjects;

namespace spendTrack.Invest.Domain
{
    public class IndexFund : Invest
    {
        public string Name { get; set; }
        public IndexFund(string name) : base(new Dictionary<string, MonthlyInvest>())
        {
            Name = name;
        }
    }
}
