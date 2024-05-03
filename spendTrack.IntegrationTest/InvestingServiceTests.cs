using spendTrack.App.ApplicationServices;
using spendTrack.App.Repositories;
using spendTrack.Infrastructure;

namespace spendTrack.IntegrationTest
{
    public class InvestingServiceTests
    {
        private IInvestingRepository repository;
        private IInvestingService service;

        [SetUp]
        public void Setup()
        {

            repository = new InvestingRepository();
            var outputGenerator = new CsvGenerator();
            service = new InvestingService(repository, outputGenerator);
        }

        [Test]
        public async Task GeneratesTheCsv()
        {
            var copyTraders = await repository.GetCopyTraders();
            copyTraders.AddMonthlyInvest((decimal)235.55);
            copyTraders.AddMonthlyInvest((decimal)250.95);
            copyTraders.AddMonthlyInvest((decimal)255.12);
            copyTraders.AddMonthlyInvest((decimal)249.71);
            copyTraders.AddMonthlyInvest((decimal)249.25);
            copyTraders.AddMonthlyInvest((decimal)249.33);
            copyTraders.AddMonthlyInvest((decimal)278.22);

            await service.GenerateCsv();
        }
    }
}