using CashFlow.Api.Application.DTOs;
using CashFlow.Api.Application.Services;
using CashFlow.Api.Application.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace CashFlow.Api.Api.Controllers
{
    /// <summary>
    /// Esse controller e os recursos que ele utliza, representam um contexto bem definido.
    /// Dessa forma, num cenário real, deveria ser transformado em um microsserviço.
    /// Por se tratar de uma demonstração didatica, não foram feitas aqui validações de negócio, tratamentos de exceção, etc.
    /// </summary>
    [ApiController]
    [Route("api/cash-flow")]
    public class CashFlowController
    {
        private readonly ICashFlowService _cashFlowService;
        private readonly IValidator<FinancialPostingDTO> _validator;

        public CashFlowController(ICashFlowService cashFlowService, IValidator<FinancialPostingDTO> validator)
        {
            _cashFlowService = cashFlowService;
            _validator = validator;
        }


        /// <summary>
        /// Enpoint para cadastro de lançamentos financeiros diários
        /// </summary>
        /// <remarks>
        /// <b>Financial Posting Types:</b> <br/>
        /// <br/>
        /// <b> 1 - Crédito </b><br/>
        /// <b> 2 - Débito </b>
        /// </remarks>
        /// <param name="financialPosting"></param>
        /// <returns></returns>
        [HttpPost("financial-posting")]        
        public async Task<IActionResult> AddFinancialPosting(FinancialPostingDTO financialPosting)
        {
            var validationResult = _validator.Validate(financialPosting);
            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.ToDictionary());
            }

            var result = await _cashFlowService.AddFinancialPosting(financialPosting);
            return new OkObjectResult(result);
        }

        /// <summary>
        /// Enpoint para listagem de lançamentos financeiros
        /// </summary>
        /// <returns></returns>
        [HttpGet("financial-postings")]
        public async Task<IActionResult> GetFinancialPostings()
        {
            var result = await _cashFlowService.GetFinancialPostings();
            return new OkObjectResult(result);
        }

    }
}
