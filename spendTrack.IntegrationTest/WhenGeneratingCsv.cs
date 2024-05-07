using Microsoft.VisualBasic.FileIO;
using spendTrack.App.ApplicationServices;
using spendTrack.Infrastructure;
using System.Reflection;

namespace spendTrack.IntegrationTest
{
    internal class WhenGeneratingCsv
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
        public async Task GeneratesTheCsv()
        {
            var firstMonth = "03/2024";
            var secondMonth = "04/2024";
            var thirdMonth = "05/2024";
            var fourthMonth = "06/2024";
            var monthlyInvest = 100.00M;

            service.AddStockInvest(firstMonth, "stock-1", monthlyInvest);
            service.AddStockInvest(firstMonth, "stock-2", monthlyInvest);
            service.AddStockInvest(firstMonth, "stock-3", monthlyInvest);
            service.AddStockInvest(firstMonth, "stock-4", monthlyInvest);
            service.UpdateStockResult(firstMonth, "stock-1", 150.00M);
            service.UpdateStockResult(firstMonth, "stock-2", 120.00M);
            service.UpdateStockResult(firstMonth, "stock-3", 50.00M);
            service.UpdateStockResult(firstMonth, "stock-4", 100.00M);
            service.AddStockInvest(secondMonth, "stock-1", monthlyInvest);
            service.AddStockInvest(secondMonth, "stock-2", monthlyInvest);
            service.AddStockInvest(secondMonth, "stock-3", monthlyInvest);
            service.AddStockInvest(secondMonth, "stock-4", monthlyInvest);
            service.UpdateStockResult(secondMonth, "stock-1", 230.00M);
            service.UpdateStockResult(secondMonth, "stock-2", 270.00M);
            service.UpdateStockResult(secondMonth, "stock-3", 130.00M);
            service.UpdateStockResult(secondMonth, "stock-4", 210.00M);
            service.AddStockInvest(thirdMonth, "stock-1", monthlyInvest);
            service.AddStockInvest(thirdMonth, "stock-2", monthlyInvest);
            service.AddStockInvest(thirdMonth, "stock-4", monthlyInvest);
            service.UpdateStockResult(thirdMonth, "stock-1", 370.00M);
            service.UpdateStockResult(thirdMonth, "stock-2", 400.00M);
            service.UpdateStockResult(thirdMonth, "stock-3", 280.00M);
            service.UpdateStockResult(thirdMonth, "stock-4", 330.00M);
            service.AddStockInvest(fourthMonth, "stock-1", monthlyInvest);
            service.AddStockInvest(fourthMonth, "stock-2", monthlyInvest);
            service.AddStockInvest(fourthMonth, "stock-3", monthlyInvest);
            service.AddStockInvest(fourthMonth, "stock-4", monthlyInvest);
            service.AddIndexFundInvest(secondMonth, "indexFund-1", monthlyInvest);
            service.UpdateIndexFundResult(secondMonth, "indexFund-1", 150.00M);
            service.AddIndexFundInvest(thirdMonth, "indexFund-1", monthlyInvest);
            service.UpdateIndexFundResult(thirdMonth, "indexFund-1", 280.00M);
            service.AddIndexFundInvest(fourthMonth, "indexFund-1", monthlyInvest);
            service.AddCopyTraderInvest(thirdMonth, "copyTrader-1", monthlyInvest);
            service.AddCopyTraderInvest(thirdMonth, "copyTrader-2", monthlyInvest);
            service.UpdateCopyTraderResult(thirdMonth, "copyTrader-1", 120.00M);
            service.UpdateCopyTraderResult(thirdMonth, "copyTrader-2", 90.00M);
            service.AddCopyTraderInvest(fourthMonth, "copyTrader-1", monthlyInvest);
            service.AddCopyTraderInvest(fourthMonth, "copyTrader-2", monthlyInvest);

            await service.GenerateCsv("invests.csv");

            AssertCsv();
        }

        private static void AssertCsv()
        {
            var relativePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("bin\\Debug\\net8.0", "");
            string filePath = Path.Combine(relativePath, @"ExpectedInvest.csv");

            List<string[]> expectedCsvData = new List<string[]>();
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    string[] row = parser.ReadFields();
                    expectedCsvData.Add(row);
                }
            }

            var expectedCsv = expectedCsvData.ToArray();

            filePath = "invests.csv";
            List<string[]> csvData = new List<string[]>();
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    string[] row = parser.ReadFields();
                    csvData.Add(row);
                }
            }

            var csv = csvData.ToArray();

            for (int rowIndex = 0; rowIndex < csv.Length; rowIndex++)
            {
                for (int columIndex = 0; columIndex < csv[rowIndex].Length; columIndex++)
                {
                    Console.Write(csv[rowIndex][columIndex] + "\t");
                    Assert.That(csv[rowIndex][columIndex], Is.EqualTo(expectedCsv[rowIndex][columIndex]));
                }
                Console.WriteLine();
            }
        }
    }
}
