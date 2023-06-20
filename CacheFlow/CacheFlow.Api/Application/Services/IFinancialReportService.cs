using CashFlow.Api.Application.DTOs;

namespace CashFlow.Api.Application.Services
{
    public interface IFinancialReportService
    {
        Task<IList<FinancialReport>> GetFinancialReport();
    }
}
