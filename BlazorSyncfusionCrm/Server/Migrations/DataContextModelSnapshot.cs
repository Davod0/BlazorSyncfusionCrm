﻿// <auto-generated />
using System;
using BlazorSyncfusionCrm.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorSyncfusionCrm.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("BlazorSyncfusionCrm.Shared.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2024, 6, 7, 0, 5, 23, 395, DateTimeKind.Local).AddTicks(9773),
                            DateOfBirth = new DateTime(2001, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Peter",
                            IsDeleted = false,
                            LastName = "Parker",
                            NickName = "Spider-man",
                            Place = "New York City"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2024, 6, 7, 0, 5, 23, 395, DateTimeKind.Local).AddTicks(9826),
                            DateOfBirth = new DateTime(1990, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Tony",
                            IsDeleted = false,
                            LastName = "Stark",
                            NickName = "Iron-man",
                            Place = "Malibu"
                        },
                        new
                        {
                            Id = 3,
                            DateCreated = new DateTime(2024, 6, 7, 0, 5, 23, 395, DateTimeKind.Local).AddTicks(9829),
                            DateOfBirth = new DateTime(1990, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bruce",
                            IsDeleted = false,
                            LastName = "Wayne",
                            NickName = "Batman",
                            Place = "Gotham City"
                        });
                });

            modelBuilder.Entity("BlazorSyncfusionCrm.Shared.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContactId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Notes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContactId = 1,
                            DateCreated = new DateTime(2024, 6, 7, 0, 5, 23, 395, DateTimeKind.Local).AddTicks(9977),
                            IsDeleted = false,
                            Text = "With great power comes great responsibility"
                        },
                        new
                        {
                            Id = 2,
                            ContactId = 2,
                            DateCreated = new DateTime(2024, 6, 7, 0, 5, 23, 395, DateTimeKind.Local).AddTicks(9980),
                            IsDeleted = false,
                            Text = "The magic you are searching for is in the work you avoiding"
                        },
                        new
                        {
                            Id = 3,
                            ContactId = 3,
                            DateCreated = new DateTime(2024, 6, 7, 0, 5, 23, 395, DateTimeKind.Local).AddTicks(9983),
                            IsDeleted = false,
                            Text = "do not care about people"
                        });
                });

            modelBuilder.Entity("BlazorSyncfusionCrm.Shared.Note", b =>
                {
                    b.HasOne("BlazorSyncfusionCrm.Shared.Contact", "Contact")
                        .WithMany("Notes")
                        .HasForeignKey("ContactId");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("BlazorSyncfusionCrm.Shared.Contact", b =>
                {
                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
