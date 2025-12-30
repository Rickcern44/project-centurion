using MassTransit;
using ProjectCenturion.Leads.Libraries.Application;
using ProjectCenturion.Leads.Libraries.Application.Interfaces;
using ProjectCenturion.Models.DomainModels;
using ProjectCenturion.Shared.Messaging.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var queueSettings = builder.Configuration.GetSection("AppSettings:QueueSettings");

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("queue.internal", "/", host =>
        {
            host.Username(queueSettings["Username"]);
            host.Password(queueSettings["Password"]);
        });

        cfg.Message<LeadIngested>(config => { config.SetEntityName("lead.ingested"); });
    });
});


builder.Services.AddScoped<ILeadIngestionApplication, LeadIngestionApplication>();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();