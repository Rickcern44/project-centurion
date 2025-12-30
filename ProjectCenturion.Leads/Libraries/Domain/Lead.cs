using ProjectCenturion.Shared.Messaging.Contracts;

namespace ProjectCenturion.Models.DomainModels;

public class Lead
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public static LeadIngested MapToLeadIngestedMessage(Lead lead)
    {
        var message = new LeadIngested
        {
            FirstName = lead.FirstName,
            LastName = lead.LastName
        };
        
        return message;
    }
}