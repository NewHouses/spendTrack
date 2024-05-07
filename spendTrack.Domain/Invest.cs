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
                UpdateTotalInvest();
            }
        }

        public void AddMonthlyInvest(string month, decimal invest)
        {
            var monthlyInvest = MonthlyInvests.GetValueOrDefault(month);
            if (monthlyInvest is not null)
            {
                monthlyInvest.Invest += invest;
                monthlyInvest.TotalInvest += invest;
            }
            else
            {
                decimal newMonthlyTotalInvest = invest;

                if (MonthlyInvests.Count > 0)
                {
                    var lastMonth = MonthlyInvests.Last().Value;
                    if (lastMonth.resultUpdated is false)
                        throw new Exception("Last month result is not updated");

                    newMonthlyTotalInvest = MonthlyInvests.Last().Value.Result + invest;
                }

                var newMonthlyInvest = new MonthlyInvest(month, invest, newMonthlyTotalInvest);
                MonthlyInvests.Add(newMonthlyInvest.Month, newMonthlyInvest);
            }

            UpdateTotalInvest();
        }

        public void UpdateMonthlyResult(string month, decimal result)
        {
            var monthlyInvest = MonthlyInvests.GetValueOrDefault(month);
            if (monthlyInvest is null)
            {
                AddMonthlyInvest(month, 0);
                monthlyInvest = MonthlyInvests[month];

            }

            monthlyInvest.AddResult(result);

            UpdateTotalInvest();
        }

        private void UpdateTotalInvest()
        {
            TotalInvest = MonthlyInvests.Sum(mi => mi.Value.Invest);
            var monthlyResults = MonthlyInvests.Where(mi => mi.Value.resultUpdated).Select(mi => mi.Value).ToList();
            var numMonthlyResults = monthlyResults.Count();
            if(numMonthlyResults > 0)
                AvarageMonthlyProfitIndex = Math.Round(monthlyResults.Sum(mr => mr.ProfitIndex) / numMonthlyResults, 2);
        }
    }
}
