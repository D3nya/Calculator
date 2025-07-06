using Calculator.API.Filters;
using Calculator.API.Middlewares;
using Calculator.Domain.DependencyInjection;
using Calculator.Services.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCalculatorDomain()
    .AddCalculatorServices();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<LoggingFilter>();
    options.Filters.Add<TimingFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
