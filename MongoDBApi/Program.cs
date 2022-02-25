using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDBApi.Models;
using MongoDBApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<EmployeeDatabaseSettings>(
    builder.Configuration.GetSection(nameof(EmployeeDatabaseSettings)));

builder.Services.AddSingleton<IEmployeeDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<EmployeeDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(x => 
    new MongoClient(builder.Configuration.GetValue<string>("EmployeeDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(option=>option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
