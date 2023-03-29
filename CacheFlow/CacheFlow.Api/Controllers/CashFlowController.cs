using CashFlow.Api.DTOs;
using CashFlow.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
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
        public CashFlowController(ICashFlowService cashFlowService)
        {
            _cashFlowService = cashFlowService;
        }

        [HttpPost("financial-posting")]
        public async Task<IActionResult> AddAccountingEntry(FinancialPostingDTO financialPosting)
        {
            var result =  await _cashFlowService.AddFinancialPosting(financialPosting);
            return new OkObjectResult(result);
        }

        [HttpGet("financial-postings")]
        public async Task<IActionResult> GetAccountingEntries()
        {
            var result = await _cashFlowService.GetFinancialPostings();
            return new OkObjectResult(result);
        }
        
    }
}
