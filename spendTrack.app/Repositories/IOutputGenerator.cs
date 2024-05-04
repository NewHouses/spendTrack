using spendTrack.Invest.Domain;

namespace spendTrack.App.Repositories
{
    public interface IOutputGenerator
    {
        Task GenerateOutput(IndexFunds indexFunds, CopyTraders copyTraders);
    }
}
