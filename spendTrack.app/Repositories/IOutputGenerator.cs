using spendTrack.Invest.Domain;

namespace spendTrack.App.Repositories
{
    public interface IOutputGenerator
    {
        Task GenerateOutput(Stocks stocks, IndexFunds indexFunds, CopyTraders copyTraders);
    }
}
