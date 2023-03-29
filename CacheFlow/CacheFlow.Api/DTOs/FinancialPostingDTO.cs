using CashFlow.Api.Enums;

namespace CashFlow.Api.DTOs
{
    public class FinancialPostingDTO
    {
        public FinancialPostingType FinancialPostingType { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime FinancialPostingDate { get; set; }
    }
}
