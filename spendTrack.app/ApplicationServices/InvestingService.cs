using spendTrack.App.Repositories;

namespace spendTrack.App.ApplicationServices
{
    public class InvestingService : IInvestingService
    {
        private readonly IInvestingRepository repository;
        private readonly IOutputGenerator outputGenerator;

        public InvestingService(IInvestingRepository repository, IOutputGenerator outputGenerator) 
        { 
            this.repository = repository;
            this.outputGenerator = outputGenerator;
        }

        public void AddStockInvest(string month, string stockName, decimal amount)
        {
            repository.AddStockMonthlyInvest(month, stockName, amount);
        }

        public void AddIndexFundInvest(string month, string indexFundName, decimal amount)
        {
            repository.AddIndexFundMonthlyInvest(month, indexFundName, amount);
        }

        public void AddCopyTraderInvest(string month, string copyTraderName, decimal amount)
        {
            repository.AddCopyTraderMonthlyInvest(month, copyTraderName, amount);
        }

        public void UpdateStockResult(string month, string stockName, decimal result)
        {
            repository.UpdateCopyTraderMonthlyResult(month, stockName, result);
        }

        //public async Task GenerateCsv(string filePath)
        //{
        //    var stocks = await repository.GetStocks();
        //    var indexFunds = await repository.GetIndexFunds();
        //    var copyTraders = await repository.GetCopyTraders();

        //    await outputGenerator.GenerateOutput(stocks, indexFunds, copyTraders, filePath);
        //}
    }
}
