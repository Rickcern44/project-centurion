using MassTransit;
using ProjectCenturion.Shared.Messaging.Contracts;
using ProjectCenturion.WorkerFunctions;
using ProjectCenturion.WorkerFunctions.Workers.Consumers;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();


builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<LeadIngestedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("queue.internal", "/", host =>
        {
            host.Username("admin");
            host.Password("Password123");
        });

        // Match exchange name from API
        cfg.Message<LeadIngested>(m => { m.SetEntityName("lead.ingested"); });

        cfg.ReceiveEndpoint("lead.ingested.worker", e => { e.ConfigureConsumer<LeadIngestedConsumer>(context); });
    });
});

var host = builder.Build();
host.Run();