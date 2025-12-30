using ProjectCenturion.Models.DomainModels;

namespace ProjectCenturion.Leads.Libraries.Application.Interfaces;

public interface ILeadIngestionApplication
{
    Task IngestLeadAsync(Lead lead, Guid leadSourceId);
}