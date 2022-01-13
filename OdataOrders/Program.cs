using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using OdataOrders.Data;

/*
 * https://github.com/rstropek/htl-leo-csharp-4/tree/master/live-coding/2021-03-18
 * https://dev.to/berviantoleo/odata-with-net-6-5e1p
 */

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<Customer>("Customers");
    return builder.GetEdmModel();
}

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<OdataOrdersContext>(options =>
    options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddControllers().AddOData(options =>
    options.AddRouteComponents("odata", GetEdmModel()).Filter().Expand().Select().OrderBy());
//builder.Services.AddControllers().AddOData(options => 
//    options.Filter().Expand().Select().OrderBy());
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
