using Calculator.Domain.DependencyInjection;
using Calculator.Services.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCalculatorDomain()
    .AddCalculatorServices();

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
