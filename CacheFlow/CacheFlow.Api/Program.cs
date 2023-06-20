using CashFlow.Api.Application.Services;
using CashFlow.Api.Application.Validations;
using CashFlow.Api.Domain.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => { o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename)); });

builder.Services.AddDbContext<CashFlowDbContext>(opt => opt.UseInMemoryDatabase("CashFlow"));
builder.Services.AddScoped<ICashFlowService, CashFlowService>();
builder.Services.AddScoped<IFinancialReportService, FinancialReportService>();

builder.Services.AddValidatorsFromAssemblyContaining<FinancialPostingValidatior>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();




