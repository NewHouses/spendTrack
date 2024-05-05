using spendTrack.Invest.Domain;

namespace spendTrack.UnitTest
{
    public class WhenAddingMonthlyInvest
    {
        [Test]
        public void StockMonthlyInvestementIsAdded()
        {
            var stock = new Stock("stock1");
            var firstMonth = "02/2024";
            var monthlyInvestment = 100.00M;

            stock.AddMonthlyInvest(firstMonth, monthlyInvestment);

            Assert.That(stock.TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(stock.AvarageMonthlyProfitIndex, Is.EqualTo(0));
            Assert.That(stock.MonthlyInvests[firstMonth].TotalInvest, Is.EqualTo(monthlyInvestment));
            Assert.That(stock.MonthlyInvests[firstMonth].Invest, Is.EqualTo(monthlyInvestment));
            Assert.That(stock.MonthlyInvests[firstMonth].ProfitIndex, Is.EqualTo(0));
            Assert.That(stock.MonthlyInvests[firstMonth].Profit, Is.EqualTo(0));
            Assert.That(stock.MonthlyInvests[firstMonth].Result, Is.EqualTo(0));
        }

        [Test]
        public void ThrowsExeceptionIfLastMonthResultWasNotUpdated()
        {
            var stock = new Stock("stock1");
            var firstMonth = "02/2024";
            var secondMonth = "02/2024";
            var monthlyInvestment = 100.00M;

            stock.AddMonthlyInvest(firstMonth, monthlyInvestment);
            var exception = Assert.Throws<Exception>(() => stock.AddMonthlyInvest(secondMonth, monthlyInvestment));

            Assert.That(exception.Message, Is.EqualTo($"Last month result is not updated"));
        }

        [TestCase("aaaa")]
        [TestCase("2024/12")]
        [TestCase("13/2024")]
        [TestCase("00/2024")]
        [TestCase("3/2024")]
        public void ThrowsExeceptionIfMonthIsNotValid(string month)
        {
            var stock = new Stock("stock1");

            var exception = Assert.Throws<ArgumentException>(() => stock.AddMonthlyInvest(month, 100.00M));

            Assert.That(exception.Message, Is.EqualTo($"The month must follow the format: MM/YYYY"));
        }
    }
}