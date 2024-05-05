namespace spendTrack.App.ApplicationServices
{
    public interface IInvestingService
    {
        void AddStockInvest(string month, string stockName, decimal amount);
        void AddIndexFundInvest(string month, string indexFundName, decimal amount);
        void AddCopyTraderInvest(string month, string copyTraderName, decimal amount);
        void UpdateStockResult(string month, string stockName, decimal result);
        void UpdateIndexFundResult(string month, string indexfundName, decimal result); 
        void UpdateCopyTraderResult(string month, string copytraderName, decimal result);
        //Task GenerateCsv(string filePath);
    }
}
