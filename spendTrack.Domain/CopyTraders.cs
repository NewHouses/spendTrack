
namespace spendTrack.Invest.Domain
{
    public class CopyTraders : Invests
    {
        public CopyTraders(Dictionary<int, MonthlyInvest> monthlyInvests) : base(monthlyInvests)
        {
        }
    }
}
