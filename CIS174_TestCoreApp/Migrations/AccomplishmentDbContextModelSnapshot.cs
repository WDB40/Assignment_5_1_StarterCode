﻿// <auto-generated />
using System;
using CIS174_TestCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CIS174_TestCoreApp.Migrations
{
    [DbContext(typeof(AccomplishmentDbContext))]
    partial class AccomplishmentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CIS174_TestCoreApp.Models.Accomplishment", b =>
                {
                    b.Property<int>("AccomplishmentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfAccomplishment");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("PersonID");

                    b.HasKey("AccomplishmentID");

                    b.HasIndex("PersonID");

                    b.ToTable("Accomplishment");
                });

            modelBuilder.Entity("CIS174_TestCoreApp.Models.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("State")
                        .HasMaxLength(25);

                    b.HasKey("PersonID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("CIS174_TestCoreApp.Models.Accomplishment", b =>
                {
                    b.HasOne("CIS174_TestCoreApp.Models.Person")
                        .WithMany("Accomplishments")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}