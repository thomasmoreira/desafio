using CashFlow.Api.Application.DTOs;
using CashFlow.Api.Domain.Entities;

namespace CashFlow.Api.Application.Services
{
    public interface ICashFlowService
    {
        Task<FinancialPosting> AddFinancialPosting(FinancialPostingDTO financialPosting);
        Task<IList<FinancialPostingDTO>> GetFinancialPostings();
    }
}
