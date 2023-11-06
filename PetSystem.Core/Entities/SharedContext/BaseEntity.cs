using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using FluentValidation.Results;

namespace PetSystem.Core.Entities.SharedContext;

[NotMapped]
public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public bool Equals(Guid id)
         => Id.Equals(id);

    public override int GetHashCode()
         => Id.GetHashCode();

    [NotMapped]
    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; } = new();

    [JsonIgnore]
    [NotMapped]
    public bool IsValid
        => ValidationResult.IsValid;

    public object Clone()
    {
        return MemberwiseClone();
    }
}