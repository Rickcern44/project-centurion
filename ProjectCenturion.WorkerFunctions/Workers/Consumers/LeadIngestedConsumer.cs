using MassTransit;
using ProjectCenturion.Shared.Messaging.Contracts;

namespace ProjectCenturion.WorkerFunctions.Workers.Consumers;

public class LeadIngestedConsumer(ILogger<LeadIngestedConsumer> logger) : IConsumer<LeadIngested>
{
    public Task Consume(ConsumeContext<LeadIngested> context)
    {
        var message = context.Message;
        logger.LogInformation("Ingested lead: {Message}", message.FirstName);

        return Task.CompletedTask;
    }
}