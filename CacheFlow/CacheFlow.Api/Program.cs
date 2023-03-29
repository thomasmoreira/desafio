using CashFlow.Api.Domain.Data;
using CashFlow.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CashFlowDbContext>(opt => opt.UseInMemoryDatabase("CashFlow"));
builder.Services.AddScoped<ICashFlowService, CashFlowService>();
builder.Services.AddScoped<IFinancialReportService, FinancialReportService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
