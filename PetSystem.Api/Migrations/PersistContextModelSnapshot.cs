﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetSystem.Infra.Data;

#nullable disable

namespace PetSystem.Api.Migrations
{
    [DbContext(typeof(PersistContext))]
    partial class PersistContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PetSystem.Core.Entities.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("RegistrationDate");

                    b.HasKey("Id");

                    b.ToTable("Client", "dbo");
                });

            modelBuilder.Entity("PetSystem.Core.Entities.Models.Client", b =>
                {
                    b.OwnsOne("PetSystem.Core.Entities.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("ClientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("City");

                            b1.Property<string>("District")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("District");

                            b1.Property<string>("PublicPlace")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PublicPlace");

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("State");

                            b1.HasKey("ClientId");

                            b1.ToTable("Client", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.OwnsOne("PetSystem.Core.Entities.ValueObjects.Contact", "Contact", b1 =>
                        {
                            b1.Property<Guid>("ClientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Email")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Email");

                            b1.Property<string>("MainPhoneNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("MainPhoneNumber");

                            b1.Property<string>("OptionalPhoneNumber")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("OptionalPhoneNumber");

                            b1.HasKey("ClientId");

                            b1.ToTable("Client", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Contact")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
