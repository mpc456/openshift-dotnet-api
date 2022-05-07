using Serilog;
using Serilog.Formatting.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Logging
builder.Logging.ClearProviders();
var loggerConfig = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext();
if (builder.Environment.IsDevelopment())
{
    loggerConfig.WriteTo.Console();
}
else
{
    loggerConfig.WriteTo.Console(new ElasticsearchJsonFormatter());
}

var logger = loggerConfig.CreateLogger();
builder.Host.UseSerilog(logger);
builder.Logging.AddSerilog(logger);


var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseSerilogRequestLogging();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run("http://0.0.0.0:5000");
