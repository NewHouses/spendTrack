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

        public async Task GenerateCsv()
        {
            var copyTraders = await repository.GetCopyTraders();

            await outputGenerator.GenerateOutput(copyTraders);
        }
    }
}
