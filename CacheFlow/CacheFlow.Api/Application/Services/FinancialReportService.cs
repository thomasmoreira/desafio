using CashFlow.Api.Application.DTOs;
using CashFlow.Api.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Api.Application.Services
{
    public class FinancialReportService : IFinancialReportService
    {
        private readonly CashFlowDbContext _dbContext;

        public FinancialReportService(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<FinancialReport>> GetFinancialReport()
        {
            var financialReport = new List<FinancialReport>();


            var groupedList = from f in await _dbContext.FinancialPostings.ToListAsync()
                              group f by f.FinancialPostingDate.Date into g
                              orderby g.Key descending
                              select g;


            foreach (var f in groupedList)
            {
                decimal sumAmount = 0;

                foreach (var a in f)
                {
                    sumAmount += a.Amount;
                }

                financialReport.Add(new FinancialReport { Date = f.Key, Amount = sumAmount });
            }

            return financialReport;
        }
    }
}
