﻿using spendTrack.App.Repositories;
using spendTrack.Invest.Domain;

namespace spendTrack.Infrastructure
{
    public class InvestingRepository : IInvestingRepository
    {
        private readonly Invests invests;

        public InvestingRepository()
        {
            invests = new Invests(new List<Stock>(), new List<IndexFund>(), new List<CopyTrader>());
        }
        public Task<StockAggregator> GetStocks()
        {
            return Task.FromResult(invests.Stocks);
        }

        public Task<IndexFundAggregator> GetIndexFunds()
        {
            return Task.FromResult(invests.IndexFunds);
        }

        public Task<CopyTraderAggregator> GetCopyTraders()
        {
            return Task.FromResult(invests.CopyTraders);
        }

        public Stock GetStockByName(string name)
        {
            return invests.Stocks.GetStock(name);
        }

        public void AddStockMonthlyInvest(string month, string stockName, decimal amount)
        {
            invests.Stocks.AddMonthlyInvest(month, stockName, amount);
        }

        public void AddIndexFundMonthlyInvest(string month, string indexFundName, decimal amount)
        {
            invests.IndexFunds.AddMonthlyInvest(month, indexFundName, amount);

        }

        public void AddCopyTraderMonthlyInvest(string month, string copyTraderName, decimal amount)
        {
            invests.CopyTraders.AddMonthlyInvest(month, copyTraderName, amount);
        }

        public void UpdateStockMonthlyResult(string month, string stockName, decimal result)
        {
            invests.Stocks.UpdateMonthlyResult(month, stockName, result);
        }

        public void UpdateIndexFundMonthlyResult(string month, string indexfundName, decimal result)
        {
            invests.IndexFunds.UpdateMonthlyResult(month, indexfundName, result);
        }

        public void UpdateCopyTraderMonthlyResult(string month, string copyTraderName, decimal result)
        {
            invests.CopyTraders.UpdateMonthlyResult(month, copyTraderName, result);
        }
    }
}
