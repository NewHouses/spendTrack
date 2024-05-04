namespace spendTrack.Invest.Domain
{
    public class Stocks : Invests
    {
        public Stocks(Dictionary<int, MonthlyInvest> monthlyInvests) : base(monthlyInvests)
        {
        }
    }
}
