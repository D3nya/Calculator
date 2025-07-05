using Calculator.Domain.UseCases.CalculateSum;
using Services.CalculateSum;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<ICalculateSumService, CalculateSumService>();
builder.Services.AddScoped<ICalculateSumUseCase, CalculateSumUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
