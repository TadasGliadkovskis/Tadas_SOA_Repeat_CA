using Microsoft.EntityFrameworkCore;
using Serilog;
using Tadas_SOA_Repeat_CA.Data;

var builder = WebApplication.CreateBuilder(args);

// Added NewtonSoftJson, gives ability to use HTTP Patch Requests
// Return HttpNotAccept is for when some makes a request
// that isn't `application/json` or `/xml` they will receive an error
Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("logs/APILogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();
builder.Host.UseSerilog(); //Uses Framework seriLog to write to file \logs\**.txt
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddControllers(option =>
{
    //option.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
