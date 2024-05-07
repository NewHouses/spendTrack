using spendTrack.App.Repositories;
using spendTrack.Invest.Domain;
using System.Text;

namespace spendTrack.Infrastructure
{
    public class CsvGenerator : IOutputGenerator
    {
        public async Task GenerateOutput(Invests invests, string filePath)
        {
            using StreamWriter writer = new(filePath);

            await writer.WriteLineAsync(",,Total Invest, Average Monthly Index %");
            await writer.WriteLineAsync($",,\"{invests.TotalInvest}\",\"{invests.AvarageMonthlyProfitIndex}\"");
            await writer.WriteLineAsync("Month,Monthly Historic Invest,Monthly Invest,Monthly Profit index %,Monthly Profit,Monthly Result,");
            foreach (var monthlyInvest in invests.MonthlyInvests.Values)
            {
                await writer.WriteLineAsync($"" +
                                      $"\"{monthlyInvest.Month}\"," +
                                      $"\"{monthlyInvest.TotalInvest}\",\"{monthlyInvest.Invest}\",\"{monthlyInvest.ProfitIndex}\",\"{monthlyInvest.Profit}\",\"{monthlyInvest.Result}\"");

            }

            await writer.WriteLineAsync(",,Stocks Total Invest,Stocks Average Monthly Index %,,,,S&P500 Total Invest,S&P500 Average Monthly Index %,,,,CT Total Invest,CT Average Monthly Index %");

            await writer.WriteLineAsync($",,\"{invests.Stocks.TotalInvest}\",\"{invests.Stocks.AvarageMonthlyProfitIndex}\",,,,\"{invests.IndexFunds.TotalInvest}\",\"{invests.IndexFunds.AvarageMonthlyProfitIndex}\",,,,\"{invests.CopyTraders.TotalInvest}\",\"{invests.CopyTraders.AvarageMonthlyProfitIndex}\"");
            await writer.WriteLineAsync("Month,Stocks Monthly Historic Invest,Stocks Monthly Invest,Stocks Monthly Invest index %,Stocks Profit,Stocks Result,S&P500 Monthly Historic Invest,S&P500 Monthly Invest,S&P500 Monthly Invest index %,S&P500 Profit,S&P500 Result,CT Monthly Historic Invest,CT Monthly Invest,CT Monthly Invest index %,CT Profit,CT Result");
            foreach (var month in invests.MonthlyInvests.Keys)
            {
                await writer.WriteLineAsync($"" +
                                   $"\"{month}\"," +
                                   $"\"{invests.Stocks.MonthlyInvests.GetValueOrDefault(month)?.TotalInvest}\",\"{invests.Stocks.MonthlyInvests.GetValueOrDefault(month)?.Invest}\",\"{invests.Stocks.MonthlyInvests.GetValueOrDefault(month)?.ProfitIndex}\",\"{invests.Stocks.MonthlyInvests.GetValueOrDefault(month)?.Profit}\",\"{invests.Stocks.MonthlyInvests.GetValueOrDefault(month)?.Result}\"," +
                                   $"\"{invests.IndexFunds.MonthlyInvests.GetValueOrDefault(month)?.TotalInvest}\",\"{invests.IndexFunds.MonthlyInvests.GetValueOrDefault(month)?.Invest}\",\"{invests.IndexFunds.MonthlyInvests.GetValueOrDefault(month)?.ProfitIndex}\",\"{invests.IndexFunds.MonthlyInvests.GetValueOrDefault(month)?.Profit}\",\"{invests.IndexFunds.MonthlyInvests.GetValueOrDefault(month)?.Result}\"," +
                                   $"\"{invests.CopyTraders.MonthlyInvests.GetValueOrDefault(month)?.TotalInvest}\",\"{invests.CopyTraders.MonthlyInvests.GetValueOrDefault(month)?.Invest}\",\"{invests.CopyTraders.MonthlyInvests.GetValueOrDefault(month)?.ProfitIndex}\",\"{invests.CopyTraders.MonthlyInvests.GetValueOrDefault(month)?.Profit}\",\"{invests.CopyTraders.MonthlyInvests.GetValueOrDefault(month)?.Result}\"");

            }
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($",,");
            foreach (var stockName in invests.Stocks.Stocks.Keys)
            {
                stringBuilder.Append($"{stockName} Total Invest, {stockName} Average Monthly Index %,,,,");
            }
            foreach (var indexFundName in invests.IndexFunds.IndexFunds.Keys)
            {
                stringBuilder.Append($"{indexFundName} Total Invest, {indexFundName} Average Monthly Index %,,,,");
            }
            foreach (var copyTraderName in invests.CopyTraders.CopyTraders.Keys)
            {
                stringBuilder.Append($"{copyTraderName} Total Invest, {copyTraderName} Average Monthly Index %,,,,");
            }

            await writer.WriteLineAsync(stringBuilder.ToString());
            stringBuilder.Clear();
            stringBuilder.Append($",,");
            foreach (var stock in invests.Stocks.Stocks.Values)
            {
                stringBuilder.Append($"\"{stock.TotalInvest}\",\"{stock.AvarageMonthlyProfitIndex}\",,,,");
            }
            foreach (var indexFund in invests.IndexFunds.IndexFunds.Values)
            {
                stringBuilder.Append($"\"{indexFund.TotalInvest}\",\"{indexFund.AvarageMonthlyProfitIndex}\",,,,");
            }
            foreach (var copyTrader in invests.CopyTraders.CopyTraders.Values)
            {
                stringBuilder.Append($"\"{copyTrader.TotalInvest}\",\"{copyTrader.AvarageMonthlyProfitIndex}\",,,,");
            }
            await writer.WriteLineAsync(stringBuilder.ToString());

            stringBuilder.Clear();
            stringBuilder.Append($"Month,");
            foreach (var stockName in invests.Stocks.Stocks.Keys)
            {
                stringBuilder.Append($"{stockName} Monthly Historic Invest,{stockName} Monthly Invest,{stockName} Monthly Invest index %,{stockName} Profit,{stockName} Result,");
            }
            foreach (var indexFundName in invests.IndexFunds.IndexFunds.Keys)
            {
                stringBuilder.Append($"{indexFundName} Monthly Historic Invest,{indexFundName} Monthly Invest,{indexFundName} Monthly Invest index %,{indexFundName} Profit,{indexFundName} Result,");
            }
            foreach (var copyTraderName in invests.CopyTraders.CopyTraders.Keys)
            {
                stringBuilder.Append($"{copyTraderName} Monthly Historic Invest,{copyTraderName} Monthly Invest,{copyTraderName} Monthly Invest index %,{copyTraderName} Profit,{copyTraderName} Result,");
            }
            await writer.WriteLineAsync(stringBuilder.ToString());

            foreach (var month in invests.MonthlyInvests.Keys)
            {
                stringBuilder.Clear();
                stringBuilder.Append($"{month},");
                foreach (var stock in invests.Stocks.Stocks.Values)
                {
                    stringBuilder.Append($"\"{stock.MonthlyInvests.GetValueOrDefault(month)?.TotalInvest}\",\"{stock.MonthlyInvests.GetValueOrDefault(month)?.Invest}\",\"{stock.MonthlyInvests.GetValueOrDefault(month)?.ProfitIndex}\",\"{stock.MonthlyInvests.GetValueOrDefault(month)?.Profit}\",\"{stock.MonthlyInvests.GetValueOrDefault(month)?.Result}\",");
                }
                foreach (var indexFund in invests.IndexFunds.IndexFunds.Values)
                {
                    stringBuilder.Append($"\"{indexFund.MonthlyInvests.GetValueOrDefault(month)?.TotalInvest}\",\"{indexFund.MonthlyInvests.GetValueOrDefault(month)?.Invest}\",\"{indexFund.MonthlyInvests.GetValueOrDefault(month)?.ProfitIndex}\",\"{indexFund.MonthlyInvests.GetValueOrDefault(month)?.Profit}\",\"{indexFund.MonthlyInvests.GetValueOrDefault(month)?.Result}\",");
                }
                foreach (var copyTrader in invests.CopyTraders.CopyTraders.Values)
                {
                    stringBuilder.Append($"\"{copyTrader.MonthlyInvests.GetValueOrDefault(month)?.TotalInvest}\",\"{copyTrader.MonthlyInvests.GetValueOrDefault(month)?.Invest}\",\"{copyTrader.MonthlyInvests.GetValueOrDefault(month)?.ProfitIndex}\",\"{copyTrader.MonthlyInvests.GetValueOrDefault(month)?.Profit}\",\"{copyTrader.MonthlyInvests.GetValueOrDefault(month)?.Result}\",");
                }

                await writer.WriteLineAsync(stringBuilder.ToString());
            }
        }
    }
}
