using spendTrack.App.Repositories;
using spendTrack.Invest.Domain;

namespace spendTrack.Infrastructure
{
    public class CsvGenerator : IOutputGenerator
    {
        public async Task GenerateOutput(CopyTraders copyTraders)
        {
            string filePath = "invests.csv";

            using (StreamWriter writer = new(filePath))
            {
                await writer.WriteLineAsync(",CT Total Invest,CT Average Monthly Index,,");

                await writer.WriteLineAsync($",\"{copyTraders.TotalInvest}\",\"{copyTraders.AvarageMonthlyProfitIndex}\",,");
                await writer.WriteLineAsync("Month,CT Monthly Historic Invest,CT Monthly Invest,CT Monthly Invest index %,CT Profit,CT Result");


                foreach (var monthlyInvest in copyTraders.MonthlyInvests)
                {
                    await writer.WriteLineAsync($"{monthlyInvest.Key}, {monthlyInvest.Value.TotalInvest},{monthlyInvest.Value.Invest},{monthlyInvest.Value.ProfitIndex},{monthlyInvest.Value.Profit},{monthlyInvest.Value.Result}");
                }
            }
        }
    }
}
