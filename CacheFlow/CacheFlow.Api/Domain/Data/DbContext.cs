using CashFlow.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Api.Domain.Data
{
    public class CashFlowDbContext : DbContext
    {
        public CashFlowDbContext(DbContextOptions<CashFlowDbContext> options) : base(options)
        {
        }

        public DbSet<FinancialPosting> FinancialPostings { get; set; }
    }
}
