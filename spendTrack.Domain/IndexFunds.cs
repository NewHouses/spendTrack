
namespace spendTrack.Invest.Domain
{
    public class IndexFunds : Invests
    {
        public IndexFunds(Dictionary<int, MonthlyInvest> monthlyInvests) : base(monthlyInvests)
        {
        }
    }
}
