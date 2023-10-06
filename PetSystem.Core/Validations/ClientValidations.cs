using FluentValidation;
using PetSystem.Core.Entities.Models;

namespace PetSystem.Core.Validations;

public class ClientValidations : AbstractValidator<Client>
{
    public ClientValidations()
    {
        RuleFor(e => e.Name)
            .NotEmpty()
            .NotNull();
    }
}