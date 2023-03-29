using CashFlow.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{

    /// <summary>
    /// Esse controller e os recursos que ele utliza, representam um contexto bem definido.
    /// Dessa forma, num cenário real, deveria ser transformado em um microsserviço.
    /// Por se tratar de um relatorio, poderíamos isolar sua base de dados, para uma estrutura NOSQL ou desnormalizada,
    /// para garantir disponibilidade, performance e escalabilidade.
    /// Essa base de dados poderia ser sincronizada por uma fila, atraves de disparos de eventos ou por um job.
    /// </summary>
    [ApiController]
    [Route("api/financial-report")]
    public class FinancialReportController
    {
        private readonly IFinancialReportService _financialReportService;
        public FinancialReportController(IFinancialReportService financialReportService)
        {
            _financialReportService = financialReportService;
        }

        [HttpGet("process")]
        public async Task<IActionResult> GetFinancialReport()
        {
            var result = await _financialReportService.GetFinancialReport();
            return new OkObjectResult(result);
        }
    }
}
