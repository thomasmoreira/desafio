using CashFlow.Api.Domain.Enums;

namespace CashFlow.Api.Domain.Entities
{
    public class FinancialPosting
    {
        protected FinancialPosting() { }
        public FinancialPosting
            (
            FinancialPostingType financialPostingtype,
            decimal amount,
            string? description,
            DateTime financialPostingDate
            )
        {
            Id = Guid.NewGuid();
            FinancialPostingType = financialPostingtype;
            Amount = amount;
            Description = description;
            FinancialPostingDate = financialPostingDate;
        }
        public Guid Id { get; private set; }
        public FinancialPostingType FinancialPostingType { get; private set; }
        public decimal Amount { get; private set; }
        public string? Description { get; private set; }
        public DateTime FinancialPostingDate { get; private set; }

    }
}
