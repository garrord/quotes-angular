using Data.Contracts;
using Data.DbContexts;
using Data.Managers;
using Data.QueryRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("AllowSpecificOrigin",
    builder => builder.WithOrigins("*")
    .AllowAnyMethod()
    .AllowAnyHeader()
));
builder.Services.AddDbContext<QuoteContext>(dbContextOptions => dbContextOptions
    .UseSqlServer("Server=localhost\\MSSQLSERVER06;Database=Quotes;Trusted_Connection=true;TrustServerCertificate=true;"));
builder.Services.AddScoped<IQuoteQueryRepository, QuoteQueryRepository>();
builder.Services.AddScoped<IQuoteManager, QuoteManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
