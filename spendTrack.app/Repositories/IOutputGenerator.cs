using spendTrack.Invest.Domain;

namespace spendTrack.App.Repositories
{
    public interface IOutputGenerator
    {
        Task GenerateOutput(Invests invests, string filePath);
    }
}
