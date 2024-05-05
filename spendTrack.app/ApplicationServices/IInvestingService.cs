namespace spendTrack.App.ApplicationServices
{
    public interface IInvestingService
    {
        void AddStockInvest(string month, string name, decimal amount);
        //Task GenerateCsv(string filePath);
    }
}
