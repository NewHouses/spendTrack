namespace spendTrack.Invest.Domain
{
    public class CopyTraders
    {
        public decimal TotalInvest { get; set; }
        public decimal AvarageMonthlyProfitIndex { get; set; }
        public Dictionary<int, MonthlyInvest> MonthlyInvests { get; set; }

        public CopyTraders(Dictionary<int, MonthlyInvest> monthlyInvests)
        {
            MonthlyInvests = monthlyInvests;
            if(MonthlyInvests.Count > 0)
            {
                TotalInvest = monthlyInvests.Sum(mi => mi.Value.Invest);
                AvarageMonthlyProfitIndex = monthlyInvests.Sum(mi => mi.Value.ProfitIndex) / monthlyInvests.Count;
            }
        }

        public void AddMonthlyInvest(decimal invest)
        {
            decimal newMonthlyTotalInvest = invest;

            if (MonthlyInvests.Count > 0)
            {
                newMonthlyTotalInvest = MonthlyInvests.Last().Value.Result + invest;
            }
            var newMonthlyInvest = new MonthlyInvest(invest, newMonthlyTotalInvest);
            MonthlyInvests.Add(MonthlyInvests.Count + 1, newMonthlyInvest);

            TotalInvest = MonthlyInvests.Sum(mi => mi.Value.Invest);
            AvarageMonthlyProfitIndex = Math.Round(MonthlyInvests.Sum(mi => mi.Value.ProfitIndex) / MonthlyInvests.Count,2);
        }

        public void AddMonthlyResult(decimal result)
        {
            var lastMonth = MonthlyInvests.Last().Value;
            lastMonth.AddResult(result);
        }
    }
}
