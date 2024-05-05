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

            UpdateTotalInvest();
        }

        public void UpdateMonthlyResult(string month, decimal result)
        {
            var monthlyInvest = MonthlyInvests.GetValueOrDefault(month);
            if (monthlyInvest is null)
                throw new ArgumentException($"There was not investment in the month of {month}");

            monthlyInvest.AddResult(result);

            UpdateTotalInvest();
        }

        private void UpdateTotalInvest()
        {
            TotalInvest = MonthlyInvests.Sum(mi => mi.Value.Invest);
            AvarageMonthlyProfitIndex = Math.Round(MonthlyInvests.Sum(mi => mi.Value.ProfitIndex) / MonthlyInvests.Count, 2);
        }
    }
}
