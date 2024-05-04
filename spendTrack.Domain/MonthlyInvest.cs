namespace spendTrack.Invest.Domain
{
    public class MonthlyInvest
    {
        public decimal TotalInvest { get; set; }
        public decimal Invest { get; set; }
        public decimal ProfitIndex { get; set; }
        public decimal Profit { get; set; }
        public decimal Result { get; set; }

        public MonthlyInvest(decimal invest, decimal totalInvest)
        {
            Invest = invest;
            TotalInvest = totalInvest;
        }

        public void AddResult(decimal result)
        {
            Result = result;
            Profit = Result - TotalInvest;
            ProfitIndex = Math.Round(100 * Profit / TotalInvest,2);
        }
    }
}
