using CashFlow.Api.Application.DTOs;
using FluentValidation;

namespace CashFlow.Api.Application.Validations
{
    public class FinancialPostingValidatior : AbstractValidator<FinancialPostingDTO>
    {
        public FinancialPostingValidatior()
        {
            RuleFor(fp => fp.Amount)
                .GreaterThan(0).WithMessage("Valor deve ser maior que zero");
        }
    }
}
