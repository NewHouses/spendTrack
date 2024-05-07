
using spendTrack.Invest.Domain.ValueObjects;

namespace spendTrack.Invest.Domain
{
    public class IndexFundAggregator : Invest
    {
        public Dictionary<string, IndexFund> IndexFunds;

        public IndexFundAggregator(List<IndexFund> indexFunds) : base(new Dictionary<string, MonthlyInvest>())
        {
            IndexFunds = new Dictionary<string, IndexFund>();
            indexFunds.ForEach(i => IndexFunds.Add(i.Name, i));
        }

        public IndexFund? GetIndexFund(string name)
        {
            return IndexFunds.GetValueOrDefault(name);
        }

        public void AddMonthlyInvest(string month, string indexFundName, decimal invest)
        {
            var indexFund = GetIndexFund(indexFundName);

            if (indexFund is null)
            {
                indexFund = new IndexFund(indexFundName);
                IndexFunds.Add(indexFundName, indexFund);
            }

            indexFund.AddMonthlyInvest(month, invest);
            AddMonthlyInvest(month, invest);
        }

        public void UpdateMonthlyResult(string month, string indexFundName, decimal result)
        {
            var stock = GetIndexFund(indexFundName);

            if (stock is null)
                throw new ArgumentException($"Index Fund {indexFundName} does not exist");

            stock.UpdateMonthlyResult(month, result);

            var newResult = IndexFunds.Where(s => s.Value.MonthlyInvests.ContainsKey(month)).Sum(s => s.Value.MonthlyInvests[month].Result);
            UpdateMonthlyResult(month, newResult);
        }
    }
}
