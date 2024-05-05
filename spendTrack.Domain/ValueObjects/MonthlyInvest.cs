using System.Text.RegularExpressions;

namespace spendTrack.Invest.Domain.ValueObjects
{
    public class MonthlyInvest
    {
        public string Month {  get; set; }
        public decimal TotalInvest { get; set; }
        public decimal Invest { get; set; }
        public decimal ProfitIndex { get; set; }
        public decimal Profit { get; set; }
        public decimal Result { get; set; }
        public bool resultUpdated = false;

        public MonthlyInvest(string month, decimal invest, decimal totalInvest)
        {
            Regex regex = new Regex("^(0[1-9]|1[0-2])\\/\\d{4}$");
            if (!regex.IsMatch(month))
                throw new ArgumentException("The month must follow the format: MM/YYYY");
            Month = month;
            Invest = invest;
            TotalInvest = totalInvest;
        }

        public void AddResult(decimal result)
        {
            Result = result;
            Profit = Result - TotalInvest;
            ProfitIndex = Math.Round(100 * Profit / TotalInvest, 2);
            resultUpdated = true;
        }
    }
}
