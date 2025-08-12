using CleanJson.Application.UseCases;
using CleanJson.Domain.Abstractions;
using CleanJson.Infrastructure.Cleaning;
using CleanJson.Infrastructure.Http;
using CleanJson.Infrastructure.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// MVC + Newtonsoft for JToken formatting
builder.Services.AddControllers()
    .AddNewtonsoftJson();

// Swagger/SwaggerUI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CleanJson API",
        Version = "v1",
        Description = "Fetches a remote JSON document and cleans it based on domain rules."
    });
});

// Options
builder.Services.Configure<RemoteJsonOptions>(
    builder.Configuration.GetSection(RemoteJsonOptions.SectionName));

// DI (DDD)
builder.Services.AddHttpClient<IRemoteJsonSource, RemoteJsonSource>();
builder.Services.AddSingleton<IJsonCleaner, NewtonsoftJsonCleaner>();
builder.Services.AddScoped<CleanRemoteJsonHandler>();

System.Console.WriteLine("sdfsdfsdfsdfsdf");

// CORS for React dev
builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(policy => policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanJson API v1");
});

app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();

app.Run();
