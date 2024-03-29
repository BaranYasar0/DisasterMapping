using DisasterMapping.Api.Application.Extensions;
using DisasterMapping.Api.WebAPI.Extensions;
using DisasterMapping.Infrastructure.Persistance;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.ModelValidatorProviders.Clear();
});
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddApplicationServices();

SqlColumn sqlColumn = new SqlColumn();
sqlColumn.ColumnName = "UserName";
sqlColumn.DataType = System.Data.SqlDbType.NVarChar;
sqlColumn.PropertyName = "UserName";
sqlColumn.DataLength = 50;
sqlColumn.AllowNull = true;

ColumnOptions columnOptions = new ColumnOptions();
columnOptions.Store.Remove(StandardColumn.Properties);
columnOptions.Store.Add(StandardColumn.LogEvent);
columnOptions.AdditionalColumns = new Collection<SqlColumn> { sqlColumn };

Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("DisasterConnectionString"), "logs", autoCreateSqlTable: true,
    columnOptions: columnOptions)
    //.WriteTo.Seq("http://localhost:1111/#/events") logları seq ile görselleştirmek için gerekli konfigurasyon docker da ayaga kaldırılmalı!
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(log);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    //logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;

});

builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345.54321\""
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
                { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
            new string[] { }
        }
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseSerilogRequestLogging();
app.UseHttpLogging();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    var userName = context.User?.Identity?.IsAuthenticated != null || true ?context.User.Identity.Name : null;
    LogContext.PushProperty("UserName", userName);
    await next();
});

app.MapControllers();

app.Run();
