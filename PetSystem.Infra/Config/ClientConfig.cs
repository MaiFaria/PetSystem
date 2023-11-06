using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetSystem.Core.Entities.Models;

namespace PetSystem.Infra.Config;

public class ClientConfig : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client", "dbo");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("UNIQUEIDENTIFIER")
                .ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
             .HasColumnName("Name")
             .HasColumnType("NVARCHAR")
             .HasMaxLength(120)
             .IsRequired(true);

        builder.Property(e => e.RegistrationDate)
            .HasColumnName("RegistrationDate")
            .HasColumnType("SMALLDATETIME")
            .IsRequired(true);

        #region Contact

        builder.OwnsOne(e => e.Contact)
            .Property(e => e.MainPhoneNumber)
            .HasColumnName("MainPhoneNumber")
            .IsRequired(true);

        builder.OwnsOne(e => e.Contact)
            .Property(e => e.OptionalPhoneNumber)
            .HasColumnName("OptionalPhoneNumber")
            .IsRequired(false);

        builder.OwnsOne(e => e.Contact)
            .Property(e => e.Email)
            .HasColumnName("Email")
            .IsRequired(false);

        #endregion

        #region Address

        builder.OwnsOne(e => e.Address)
            .Property(e => e.PublicPlace)
            .HasColumnName("PublicPlace")
            .IsRequired(false);

        builder.OwnsOne(e => e.Address)
            .Property(e => e.District)
            .HasColumnName("District")
            .IsRequired(false);

        builder.OwnsOne(e => e.Address)
            .Property(e => e.City)
            .HasColumnName("City")
            .IsRequired(false);

        builder.OwnsOne(e => e.Address)
            .Property(e => e.State)
            .HasColumnName("State")
            .IsRequired(false);

        builder.OwnsOne(e => e.Address)
            .Property(e => e.PublicPlace)
            .HasColumnName("PublicPlace")
            .IsRequired(false);

        #endregion
    }
}