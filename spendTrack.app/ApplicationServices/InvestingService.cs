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

        public void AddStockInvest(string month, string name, decimal amount)
        {
            repository.AddStockMonthlyInvest(month, name, amount);
        }

        public void AddIndexFundInvest(string month, string name, decimal amount)
        {
            repository.AddIndexFundMonthlyInvest(month, name, amount);
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
