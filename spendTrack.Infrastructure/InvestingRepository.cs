using spendTrack.App.Repositories;
using spendTrack.Invest.Domain;

namespace spendTrack.Infrastructure
{
    public class InvestingRepository : IInvestingRepository
    {
        private readonly CopyTraders copyTraders;
        private readonly IndexFunds indexFunds;

        public InvestingRepository()
        {
            copyTraders = new CopyTraders(new Dictionary<int, MonthlyInvest>());
            indexFunds = new IndexFunds(new Dictionary<int, MonthlyInvest>());
        }

        public Task<CopyTraders> GetCopyTraders()
        {
            return Task.FromResult(copyTraders);
        }

        public Task<IndexFunds> GetIndexFunds()
        {
            return Task.FromResult(indexFunds);
        }
    }
}
