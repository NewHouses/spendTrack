using spendTrack.Invest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spendTrack.App.Repositories
{
    public interface IInvestingRepository
    {
        Task<CopyTraders> GetCopyTraders();
        Task<IndexFunds> GetIndexFunds();
        Task<Stocks> GetStocks();
    }
}
