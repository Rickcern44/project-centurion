using MassTransit;
using ProjectCenturion.Models.DomainModels;
using ProjectCenturion.WorkerFunctions;
using ProjectCenturion.WorkerFunctions.Workers.Consumers;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();


builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<Lead>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});

var host = builder.Build();
host.Run();