using spendTrack.App.Repositories;
using spendTrack.Invest.Domain;

namespace spendTrack.Infrastructure
{
    public class CsvGenerator : IOutputGenerator
    {
        //public async Task GenerateOutput(Stocks stocks, IndexFunds indexFunds, CopyTraders copyTraders, string filePath)
        //{
        //    using StreamWriter writer = new(filePath);
        //    await writer.WriteLineAsync(",Stocks Total Invest,Stocks Average Monthly Index %,,,,S&P500 Total Invest,S&P500 Average Monthly Index %,,,,CT Total Invest,CT Average Monthly Index %,,");

        //    await writer.WriteLineAsync($",\"{stocks.TotalInvest}\",\"{stocks.AvarageMonthlyProfitIndex}\",,,,\"{indexFunds.TotalInvest}\",\"{indexFunds.AvarageMonthlyProfitIndex}\",,,,\"{copyTraders.TotalInvest}\",\"{copyTraders.AvarageMonthlyProfitIndex}\",,");
        //    await writer.WriteLineAsync("Month,Stocks Monthly Historic Invest,Stocks Monthly Invest,Stocks Monthly Invest index %,Stocks Profit,Stocks Result,S&P500 Monthly Historic Invest,S&P500 Monthly Invest,S&P500 Monthly Invest index %,S&P500 Profit,S&P500 Result,CT Monthly Historic Invest,CT Monthly Invest,CT Monthly Invest index %,CT Profit,CT Result");

        //    for (int month = 1; month <= copyTraders.MonthlyInvests.Count; month++)
        //    {
        //        await writer.WriteLineAsync($"" +
        //                            $"\"{month}\"," +
        //                            $"\"{stocks.MonthlyInvests[month].TotalInvest}\",\"{stocks.MonthlyInvests[month].Invest}\",\"{stocks.MonthlyInvests[month].ProfitIndex}\",\"{stocks.MonthlyInvests[month].Profit}\",\"{stocks.MonthlyInvests[month].Result}\"," +
        //                            $"\"{indexFunds.MonthlyInvests[month].TotalInvest}\",\"{indexFunds.MonthlyInvests[month].Invest}\",\"{indexFunds.MonthlyInvests[month].ProfitIndex}\",\"{indexFunds.MonthlyInvests[month].Profit}\",\"{indexFunds.MonthlyInvests[month].Result}\"," +
        //                            $"\"{copyTraders.MonthlyInvests[month].TotalInvest}\",\"{copyTraders.MonthlyInvests[month].Invest}\",\"{copyTraders.MonthlyInvests[month].ProfitIndex}\",\"{copyTraders.MonthlyInvests[month].Profit}\",\"{copyTraders.MonthlyInvests[month].Result}\"");
        //    }
        //}
    }
}
