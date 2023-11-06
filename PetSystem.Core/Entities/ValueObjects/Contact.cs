namespace PetSystem.Core.Entities.ValueObjects;

public class Contact
{
    public string MainPhoneNumber { get; set; } = string.Empty;
    public string OptionalPhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    #region Update

    public void UpdateContact(Contact contact)
    {
        MainPhoneNumber = contact.MainPhoneNumber;
        OptionalPhoneNumber = contact.OptionalPhoneNumber;
        Email = contact.Email;
    }

    #endregion
}