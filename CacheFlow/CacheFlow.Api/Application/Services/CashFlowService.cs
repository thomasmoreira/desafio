using CashFlow.Api.Application.DTOs;
using CashFlow.Api.Domain.Data;
using CashFlow.Api.Domain.Entities;
using CashFlow.Api.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Api.Application.Services
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
                financialPostingDTO.FinancialPostingType == FinancialPostingType.Debit ?
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
                    Amount = x.FinancialPostingType == FinancialPostingType.Debit ? x.Amount*-1 : x.Amount,
                    Description = x.Description,
                    FinancialPostingDate = x.FinancialPostingDate
                }).ToListAsync();

            return result;
        }
    }
}
