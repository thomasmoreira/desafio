using CashFlow.Api.Domain.Entities;
using CashFlow.Api.DTOs;

namespace CashFlow.Api.Services
{
    public interface ICashFlowService
    {
        Task<FinancialPosting> AddFinancialPosting(FinancialPostingDTO financialPosting);
        Task<IList<FinancialPostingDTO>> GetFinancialPostings();
    }
}
