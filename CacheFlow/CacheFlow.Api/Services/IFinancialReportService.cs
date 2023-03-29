using CashFlow.Api.DTOs;

namespace CashFlow.Api.Services
{
    public interface IFinancialReportService
    {
        Task<IList<FinancialReport>> GetFinancialReport();
    }
}
