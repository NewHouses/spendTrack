
using spendTrack.Invest.Domain.ValueObjects;

namespace spendTrack.Invest.Domain
{
    public class Stock : Invest
    {
        public string Name { get; set; }
        public Stock(string name) : base(new Dictionary<string, MonthlyInvest>())
        {
            Name = name;
        }
    }
}
