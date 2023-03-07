using Data.Interfaces;
using Data.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(Application.Queries.GetAllStockQuery.GetAllStockQuery).Assembly);
builder.Services.AddScoped<IStockContext, StockContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // No Auth added in local dev mode to allow ease of local running
}
else
{
    // Looking to add Azure AD / Some form of JWT token authentication to lock down the api in the environment
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
