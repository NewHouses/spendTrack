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
            repository.UpdateStockMonthlyResult(month, stockName, result);
        }

        public void UpdateIndexFundResult(string month, string indexfundName, decimal result)
        {
            repository.UpdateIndexFundMonthlyResult(month, indexfundName, result);
        }

        public void UpdateCopyTraderResult(string month, string copytraderName, decimal result)
        {
            repository.UpdateCopyTraderMonthlyResult(month, copytraderName, result);
        }

        public async Task GenerateCsv(string filePath)
        {
            var invests = await repository.GetInvests();

            await outputGenerator.GenerateOutput(invests, filePath);
        } 
    }
}
