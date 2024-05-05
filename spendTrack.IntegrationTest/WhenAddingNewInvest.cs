using spendTrack.App.ApplicationServices;
using spendTrack.Infrastructure;

namespace spendTrack.IntegrationTest
{
    public class WhenAddingNewInvest
    {
        private InvestingRepository repository;
        private InvestingService service;

        [SetUp]
        public void Setup()
        {
            repository = new InvestingRepository();
            var outputGenerator = new CsvGenerator();
            service = new InvestingService(repository, outputGenerator);
        }

        [Test]
        public async Task ExistingStockIsUpdatedInTheAggregator()
        {
            var stockName = "stockTest";
            var existingMonth = "03/2024";
            var existingInvest = 100.00M;
            var existingResult = 150.00M;
            var newMonth = "05/2024";
            var stockInvest = 200.00M;
            var stocks = await repository.GetStocks();

            service.AddStockInvest(existingMonth, stockName, existingInvest);
            service.UpdateStockResult(existingMonth, stockName, existingResult);
            service.AddStockInvest(newMonth, stockName, stockInvest);

            var stock = stocks.GetStock(stockName);
            Assert.That(stock.Name, Is.EqualTo(stockName));
            Assert.That(stock.TotalInvest, Is.EqualTo(existingInvest + stockInvest));
            Assert.That(stock.MonthlyInvests.Count, Is.EqualTo(2));
            Assert.That(stock.MonthlyInvests[existingMonth].Month, Is.EqualTo(existingMonth));
            Assert.That(stock.MonthlyInvests[existingMonth].TotalInvest, Is.EqualTo(existingInvest));
            Assert.That(stock.MonthlyInvests[existingMonth].Invest, Is.EqualTo(existingInvest));
            Assert.That(stock.MonthlyInvests[newMonth].Month, Is.EqualTo(newMonth));
            Assert.That(stock.MonthlyInvests[newMonth].TotalInvest, Is.EqualTo(stockInvest + existingResult));
            Assert.That(stock.MonthlyInvests[newMonth].Invest, Is.EqualTo(stockInvest));
            Assert.That(stock.MonthlyInvests[newMonth].Profit, Is.EqualTo(0));
            Assert.That(stock.MonthlyInvests[newMonth].ProfitIndex, Is.EqualTo(0));
            Assert.That(stock.MonthlyInvests[newMonth].Result, Is.EqualTo(0));
        }

        [Test]
        public async Task ExistingIndexFundIsUpdatedInTheAggregator()
        {
            var indexFundName = "indexFundTest";
            var existingMonth = "03/2024";
            var existingInvest = 100.00M;
            var existingResult = 150.00M;
            var newMonth = "05/2024";
            var indexFundInvest = 200.00M;
            var indexFunds = await repository.GetIndexFunds();

            service.AddIndexFundInvest(existingMonth, indexFundName, existingInvest);
            service.UpdateIndexFundResult(existingMonth, indexFundName, existingResult);
            service.AddIndexFundInvest(newMonth, indexFundName, indexFundInvest);

            var indexFund = indexFunds.GetIndexFund(indexFundName);
            Assert.That(indexFund.Name, Is.EqualTo(indexFundName));
            Assert.That(indexFund.TotalInvest, Is.EqualTo(existingInvest));
            Assert.That(indexFund.MonthlyInvests.Count, Is.EqualTo(1));
            Assert.That(indexFund.MonthlyInvests[existingMonth].Month, Is.EqualTo(existingMonth));
            Assert.That(indexFund.MonthlyInvests[existingMonth].TotalInvest, Is.EqualTo(existingInvest));
            Assert.That(indexFund.MonthlyInvests[existingMonth].Invest, Is.EqualTo(existingInvest));
            Assert.That(indexFund.MonthlyInvests[newMonth].Month, Is.EqualTo(newMonth));
            Assert.That(indexFund.MonthlyInvests[newMonth].TotalInvest, Is.EqualTo(indexFundInvest + existingResult));
            Assert.That(indexFund.MonthlyInvests[newMonth].Invest, Is.EqualTo(indexFundInvest));
            Assert.That(indexFund.MonthlyInvests[newMonth].Profit, Is.EqualTo(0));
            Assert.That(indexFund.MonthlyInvests[newMonth].ProfitIndex, Is.EqualTo(0));
            Assert.That(indexFund.MonthlyInvests[newMonth].Result, Is.EqualTo(0));
        }

        [Test]
        public async Task ExistingCopyTraderIsUpdatedInTheAggregator()
        {
            var copyTraderName = "copyTraderTest";
            var existingMonth = "03/2024";
            var existingInvest = 100.00M;
            var existingResult = 150.00M;
            var newMonth = "05/2024";
            var copyTraderInvest = 200.00M;
            var copyTraders = await repository.GetCopyTraders();

            service.AddCopyTraderInvest(existingMonth, copyTraderName, existingInvest);
            service.UpdateCopyTraderResult(existingMonth, copyTraderName, existingResult);
            service.AddCopyTraderInvest(newMonth, copyTraderName, copyTraderInvest);

            var copyTrader = copyTraders.GetCopyTrader(copyTraderName);
            Assert.That(copyTrader.Name, Is.EqualTo(copyTraderName));
            Assert.That(copyTrader.TotalInvest, Is.EqualTo(existingInvest));
            Assert.That(copyTrader.MonthlyInvests.Count, Is.EqualTo(1));
            Assert.That(copyTrader.MonthlyInvests[existingMonth].Month, Is.EqualTo(existingMonth));
            Assert.That(copyTrader.MonthlyInvests[existingMonth].TotalInvest, Is.EqualTo(existingInvest));
            Assert.That(copyTrader.MonthlyInvests[existingMonth].Invest, Is.EqualTo(existingInvest));
            Assert.That(copyTrader.MonthlyInvests[newMonth].Month, Is.EqualTo(newMonth));
            Assert.That(copyTrader.MonthlyInvests[newMonth].TotalInvest, Is.EqualTo(copyTraderInvest));
            Assert.That(copyTrader.MonthlyInvests[newMonth].Invest, Is.EqualTo(copyTraderInvest));
            Assert.That(copyTrader.MonthlyInvests[newMonth].Profit, Is.EqualTo(0));
            Assert.That(copyTrader.MonthlyInvests[newMonth].ProfitIndex, Is.EqualTo(0));
            Assert.That(copyTrader.MonthlyInvests[newMonth].Result, Is.EqualTo(0));
        }

        //[Test]
        //public async Task GeneratesTheCsv()
        //{
        //    var stocks = await repository.GetStocks();
        //    stocks.AddMonthlyInvest((decimal)745.49);
        //    stocks.AddMonthlyResult((decimal)706.02);
        //    stocks.AddMonthlyInvest((decimal)723.97);
        //    stocks.AddMonthlyResult((decimal)1394.27);
        //    stocks.AddMonthlyInvest((decimal)249.47);
        //    var indexFunds = await repository.GetIndexFunds();
        //    indexFunds.AddMonthlyInvest((decimal)242.44);
        //    indexFunds.AddMonthlyResult((decimal)284.64);
        //    indexFunds.AddMonthlyInvest((decimal)250.96);
        //    indexFunds.AddMonthlyResult((decimal)581.2);
        //    indexFunds.AddMonthlyInvest((decimal)255.12);
        //    var copyTraders = await repository.GetCopyTraders();
        //    copyTraders.AddMonthlyInvest((decimal)235.55);
        //    copyTraders.AddMonthlyResult((decimal)245.44);
        //    copyTraders.AddMonthlyInvest((decimal)250.95);
        //    copyTraders.AddMonthlyResult((decimal)529.25);
        //    copyTraders.AddMonthlyInvest((decimal)255.12);

        //    await service.GenerateCsv();

        //    AssertCsv();
        //}

        //private static void AssertCsv()
        //{
        //    string filePath = "invests.csv";
        //    List<string[]> csvData = new List<string[]>();
        //    using (TextFieldParser parser = new TextFieldParser(filePath))
        //    {
        //        parser.TextFieldType = FieldType.Delimited;
        //        parser.SetDelimiters(",");

        //        while (!parser.EndOfData)
        //        {
        //            string[] row = parser.ReadFields();
        //            csvData.Add(row);
        //        }
        //    }

        //    var csv = csvData.ToArray();

        //    Assume.That(csv[0][0], Is.EqualTo(""));
        //    Assume.That(csv[0][1], Is.EqualTo("Stocks Total Invest"));
        //    Assume.That(csv[0][2], Is.EqualTo("Stocks Average Monthly Index %"));
        //    Assume.That(csv[0][3], Is.EqualTo(""));
        //    Assume.That(csv[0][4], Is.EqualTo(""));
        //    Assume.That(csv[0][5], Is.EqualTo(""));
        //    Assume.That(csv[0][6], Is.EqualTo("S&P500 Total Invest"));
        //    Assume.That(csv[0][7], Is.EqualTo("S&P500 Average Monthly Index %"));
        //    Assume.That(csv[0][8], Is.EqualTo(""));
        //    Assume.That(csv[0][9], Is.EqualTo(""));
        //    Assume.That(csv[0][10], Is.EqualTo(""));
        //    Assume.That(csv[0][11], Is.EqualTo("CT Total Invest"));
        //    Assume.That(csv[0][12], Is.EqualTo("CT Average Monthly Index %"));
        //    Assume.That(csv[0][13], Is.EqualTo(""));

        //    Assume.That(csv[1][0], Is.EqualTo(""));
        //    Assume.That(csv[1][1], Is.EqualTo("1718.93"));
        //    Assume.That(csv[1][2], Is.EqualTo("-2.60"));
        //    Assume.That(csv[1][3], Is.EqualTo(""));
        //    Assume.That(csv[1][4], Is.EqualTo(""));
        //    Assume.That(csv[1][5], Is.EqualTo(""));
        //    Assume.That(csv[1][6], Is.EqualTo("748.52"));
        //    Assume.That(csv[1][7], Is.EqualTo("8.64"));
        //    Assume.That(csv[1][8], Is.EqualTo(""));
        //    Assume.That(csv[1][9], Is.EqualTo(""));
        //    Assume.That(csv[1][10], Is.EqualTo(""));
        //    Assume.That(csv[1][11], Is.EqualTo("741.62"));
        //    Assume.That(csv[1][12], Is.EqualTo("3.61"));
        //    Assume.That(csv[1][13], Is.EqualTo(""));

        //    Assume.That(csv[2][0], Is.EqualTo("Month"));
        //    Assume.That(csv[2][1], Is.EqualTo("Stocks Monthly Historic Invest"));
        //    Assume.That(csv[2][2], Is.EqualTo("Stocks Monthly Invest"));
        //    Assume.That(csv[2][3], Is.EqualTo("Stocks Monthly Invest index %"));
        //    Assume.That(csv[2][4], Is.EqualTo("Stocks Profit"));
        //    Assume.That(csv[2][5], Is.EqualTo("Stocks Result"));
        //    Assume.That(csv[2][6], Is.EqualTo("S&P500 Monthly Historic Invest"));
        //    Assume.That(csv[2][7], Is.EqualTo("S&P500 Monthly Invest"));
        //    Assume.That(csv[2][8], Is.EqualTo("S&P500 Monthly Invest index %"));
        //    Assume.That(csv[2][9], Is.EqualTo("S&P500 Profit"));
        //    Assume.That(csv[2][10], Is.EqualTo("S&P500 Result"));
        //    Assume.That(csv[2][11], Is.EqualTo("CT Monthly Historic Invest"));
        //    Assume.That(csv[2][12], Is.EqualTo("CT Monthly Invest"));
        //    Assume.That(csv[2][13], Is.EqualTo("CT Monthly Invest index %"));
        //    Assume.That(csv[2][14], Is.EqualTo("CT Profit"));
        //    Assume.That(csv[2][15], Is.EqualTo("CT Result"));

        //    Assume.That(csv[3][0], Is.EqualTo("1"));
        //    Assume.That(csv[3][1], Is.EqualTo("745.49"));
        //    Assume.That(csv[3][2], Is.EqualTo("745.49"));
        //    Assume.That(csv[3][3], Is.EqualTo("-5.29"));
        //    Assume.That(csv[3][4], Is.EqualTo("-39.47"));
        //    Assume.That(csv[3][5], Is.EqualTo("706.02"));

        //    Assume.That(csv[3][6], Is.EqualTo("242.44"));
        //    Assume.That(csv[3][7], Is.EqualTo("242.44"));
        //    Assume.That(csv[3][8], Is.EqualTo("17.41"));
        //    Assume.That(csv[3][9], Is.EqualTo("42.20"));
        //    Assume.That(csv[3][10], Is.EqualTo("284.64"));

        //    Assume.That(csv[3][11], Is.EqualTo("235.55"));
        //    Assume.That(csv[3][12], Is.EqualTo("235.55"));
        //    Assume.That(csv[3][13], Is.EqualTo("4.20"));
        //    Assume.That(csv[3][14], Is.EqualTo("9.89"));
        //    Assume.That(csv[3][15], Is.EqualTo("245.44"));

        //    Assume.That(csv[4][0], Is.EqualTo("2"));
        //    Assume.That(csv[4][1], Is.EqualTo("1429.99"));
        //    Assume.That(csv[4][2], Is.EqualTo("723.97"));
        //    Assume.That(csv[4][3], Is.EqualTo("-2.50"));
        //    Assume.That(csv[4][4], Is.EqualTo("-35.72"));
        //    Assume.That(csv[4][5], Is.EqualTo("1394.27"));

        //    Assume.That(csv[4][6], Is.EqualTo("535.60"));
        //    Assume.That(csv[4][7], Is.EqualTo("250.96"));
        //    Assume.That(csv[4][8], Is.EqualTo("8.51"));
        //    Assume.That(csv[4][9], Is.EqualTo("45.60"));
        //    Assume.That(csv[4][10], Is.EqualTo("581.2"));

        //    Assume.That(csv[4][11], Is.EqualTo("496.39"));
        //    Assume.That(csv[4][12], Is.EqualTo("250.95"));
        //    Assume.That(csv[4][13], Is.EqualTo("6.62"));
        //    Assume.That(csv[4][14], Is.EqualTo("32.86"));
        //    Assume.That(csv[4][15], Is.EqualTo("529.25"));

        //    Assume.That(csv[5][0], Is.EqualTo("3"));
        //    Assume.That(csv[5][1], Is.EqualTo("1643.74"));
        //    Assume.That(csv[5][2], Is.EqualTo("249.47"));
        //    Assume.That(csv[5][3], Is.EqualTo("0"));
        //    Assume.That(csv[5][4], Is.EqualTo("0"));
        //    Assume.That(csv[5][5], Is.EqualTo("0"));

        //    Assume.That(csv[5][6], Is.EqualTo("836.32"));
        //    Assume.That(csv[5][7], Is.EqualTo("255.12"));
        //    Assume.That(csv[5][8], Is.EqualTo("0"));
        //    Assume.That(csv[5][9], Is.EqualTo("0"));
        //    Assume.That(csv[5][10], Is.EqualTo("0"));

        //    Assume.That(csv[5][11], Is.EqualTo("784.37"));
        //    Assume.That(csv[5][12], Is.EqualTo("255.12"));
        //    Assume.That(csv[5][13], Is.EqualTo("0"));
        //    Assume.That(csv[5][14], Is.EqualTo("0"));
        //    Assume.That(csv[5][15], Is.EqualTo("0"));

        //    foreach (string[] row in csvData)
        //    {
        //        foreach (string cell in row)
        //        {
        //            Console.Write(cell + "\t");
        //        }
        //        Console.WriteLine();
        //    }
        //}
    }
}