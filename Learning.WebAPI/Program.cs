using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddHttpLogging(logging =>
//{
//    // Customize HTTP logging here.
//    logging.LoggingFields = HttpLoggingFields.All;
//    logging.RequestHeaders.Add("My-Request-Header");
//    logging.ResponseHeaders.Add("My-Response-Header");
//    logging.MediaTypeOptions.AddText("application/javascript");
//    logging.RequestBodyLogLimit = 4096;
//    logging.ResponseBodyLogLimit = 4096;
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
