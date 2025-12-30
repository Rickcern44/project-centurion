using MassTransit;
using ProjectCenturion.Leads.Libraries.Application.Interfaces;
using ProjectCenturion.Models.DomainModels;

namespace ProjectCenturion.Leads.Libraries.Application;

public class LeadIngestionApplication(IBus bus) : ILeadIngestionApplication
{
    public async Task IngestLeadAsync(Lead lead, Guid leadSourceId)
    {
        var message = Lead.MapToLeadIngestedMessage(lead);
        await bus.Publish(message);
    }
}