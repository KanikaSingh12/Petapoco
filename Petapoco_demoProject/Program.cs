using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Petapoco_demoProject.Models;
using Petapoco_demoProject.Controllers;
using PetaPoco;
using PetaPoco.Providers;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

builder.Services.AddControllers();
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("OpenCorsPolicy", opt =>
    opt.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    );
    //json serializer

});

/*
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
    = new DefaultContractResolver());
*/


string connectionString = configuration.GetValue<string>("Database:ConnectionString");
string providerName = configuration.GetValue<string>("Database:ProviderName");

var db = DatabaseConfiguration.Build()
         .UsingConnectionString(connectionString)
         .UsingProvider<PostgreSQLDatabaseProvider>()
         .Create();

builder.Services.AddTransient<IDatabase>(s => db);

builder.Services.AddTransient<Iuser_detail, user_service>();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Petapoco_demoProject", Version = "v1" });
});

var app = builder.Build();
app.UseCors("OpenCorsPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Petapoco_demoProject v1"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();
