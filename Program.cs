using CarInsuranceApi.Data;
using CarInsuranceApi.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Car Insurance API", Version = "v1" });
});

var creditScoreData = CreditScoreCsvLoader.LoadFromCsv("./wwwroot/Car_Insurance_Claim.csv");
builder.Services.AddSingleton(new CreditScoreService(creditScoreData));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Car Insurance API v1"));

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); 

app.Run();
