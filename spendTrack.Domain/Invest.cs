using spendTrack.Invest.Domain.ValueObjects;

namespace spendTrack.Invest.Domain
{
    public abstract class Invest
    {
        public decimal TotalInvest { get; set; }
        public decimal AvarageMonthlyProfitIndex { get; set; }
        public Dictionary<string, MonthlyInvest> MonthlyInvests { get; set; }

        public Invest(Dictionary<string, MonthlyInvest> monthlyInvests)
        {
            MonthlyInvests = monthlyInvests;
            if (MonthlyInvests.Count > 0)
            {
                TotalInvest = monthlyInvests.Sum(mi => mi.Value.Invest);
                AvarageMonthlyProfitIndex = monthlyInvests.Sum(mi => mi.Value.ProfitIndex) / monthlyInvests.Count;
            }
        }

        public void AddMonthlyInvest(string month, decimal invest)
        {
            decimal newMonthlyTotalInvest = invest;

            if (MonthlyInvests.Count > 0)
            {
                newMonthlyTotalInvest = MonthlyInvests.Last().Value.Result + invest;
            }
            var newMonthlyInvest = new MonthlyInvest(month, invest, newMonthlyTotalInvest);
            MonthlyInvests.Add(newMonthlyInvest.Month, newMonthlyInvest);

            TotalInvest = MonthlyInvests.Sum(mi => mi.Value.Invest);
            AvarageMonthlyProfitIndex = Math.Round(MonthlyInvests.Sum(mi => mi.Value.ProfitIndex) / MonthlyInvests.Count, 2);
        }

        public void AddMonthlyResult(decimal result)
        {
            var lastMonth = MonthlyInvests.Last().Value;
            lastMonth.AddResult(result);
        }
    }
}
