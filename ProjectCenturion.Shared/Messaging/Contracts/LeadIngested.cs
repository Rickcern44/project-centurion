namespace ProjectCenturion.Shared.Messaging.Contracts;

public class LeadIngested
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}