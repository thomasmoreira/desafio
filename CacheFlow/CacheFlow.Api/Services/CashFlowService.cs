using CashFlow.Api.Domain.Data;
using CashFlow.Api.Domain.Entities;
using CashFlow.Api.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Api.Services
{
    public class CashFlowService : ICashFlowService
    {
        private readonly CashFlowDbContext _dbContext;
        public CashFlowService(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<FinancialPosting> AddFinancialPosting(FinancialPostingDTO financialPostingDTO)
        {
            var amount = 
                financialPostingDTO.FinancialPostingType == Enums.FinancialPostingType.Debit ? 
                financialPostingDTO.Amount * -1 :
                financialPostingDTO.Amount;

            var financialPosting =
                new FinancialPosting
                (
                
                financialPostingDTO.FinancialPostingType,
                amount,
                financialPostingDTO.Description,
                financialPostingDTO.FinancialPostingDate

                );


            _dbContext.FinancialPostings.Add(financialPosting);
            await _dbContext.SaveChangesAsync();

            return financialPosting;
        }
        public async Task<IList<FinancialPostingDTO>> GetFinancialPostings()
        {
            var result = await _dbContext.FinancialPostings.Select(
                x => new FinancialPostingDTO
                {
                    FinancialPostingType = x.FinancialPostingType,
                    Amount = x.Amount,
                    Description = x.Description,
                    FinancialPostingDate = x.FinancialPostingDate
                }).ToListAsync();

            return result;
        }
    }
}
