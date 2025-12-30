using Microsoft.AspNetCore.Mvc;
using ProjectCenturion.Leads.Libraries.Application.Interfaces;
using ProjectCenturion.Models.DomainModels;

namespace ProjectCenturion.Leads.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LeadIngestionController(ILeadIngestionApplication application) : ControllerBase
{
    [HttpPost]
    public async Task<IResult> IngestLead([FromBody] Lead lead, [FromQuery] Guid leadSource)
    {
        await application.IngestLeadAsync(lead, leadSource);
        return Results.Ok(lead);
    }
}