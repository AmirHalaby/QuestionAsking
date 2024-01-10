using Microsoft.EntityFrameworkCore;
using QuestionAsking.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Use sql server get connection string from appsettings.
builder.Services.AddDbContext<QuestionAskingContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("QuestionAsking")));



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
