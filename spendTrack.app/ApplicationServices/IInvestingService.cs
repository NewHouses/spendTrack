namespace spendTrack.App.ApplicationServices
{
    public interface IInvestingService
    {
        void AddStockInvest(string month, string stockName, decimal amount);
        void AddIndexFundInvest(string month, string indexFundName, decimal amount);
        void AddCopyTraderInvest(string month, string copyTraderName, decimal amount);
        //Task GenerateCsv(string filePath);
    }
}
