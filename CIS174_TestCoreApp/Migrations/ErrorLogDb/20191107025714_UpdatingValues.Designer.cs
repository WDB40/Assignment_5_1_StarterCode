﻿// <auto-generated />
using System;
using CIS174_TestCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CIS174_TestCoreApp.Migrations.ErrorLogDb
{
    [DbContext(typeof(ErrorLogDbContext))]
    [Migration("20191107025714_UpdatingValues")]
    partial class UpdatingValues
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CIS174_TestCoreApp.Models.ErrorLog", b =>
                {
                    b.Property<int>("ErrorLogID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ErrorDateTime");

                    b.Property<string>("ExceptionMessage");

                    b.Property<string>("ResponseId");

                    b.Property<int>("StatusCode");

                    b.Property<string>("StrackTrace");

                    b.HasKey("ErrorLogID");

                    b.ToTable("ErrorLogs");
                });
#pragma warning restore 612, 618
        }
    }
}