namespace PetSystem.Core.Entities.Requests.ClienteRequests;

public class UpdateClientRequest : InsertClientRequest
{
    public Guid Id { get; set; }
    public DateTime RegistrationDate { get; set; }
}