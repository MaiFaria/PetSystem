namespace PetSystem.Core.Entities.ValueObjects;

public class Address
{
    public string PublicPlace { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;

    #region Update

    public void UpdateAddress(Address address)
    {
        PublicPlace = address.PublicPlace;
        District = address.District;
        City = address.City;
        State = address.State;
    }

    #endregion
}