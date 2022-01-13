using Microsoft.EntityFrameworkCore;
using VideoGameManagerV6.DataAccess;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
/*
 * https://github.com/rstropek/htl-leo-csharp-4/blob/master/slides/ef-aspnet-cheat-sheet.md
 */

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<VideoGameDataContext>(options => 
    options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
