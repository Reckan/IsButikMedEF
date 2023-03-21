﻿// <auto-generated />
using IsButikMedEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IsButikMedEF.Migrations
{
    [DbContext(typeof(Model))]
    [Migration("20230321102914_First2")]
    partial class First2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IsButikMedEF.Bestilling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Antal")
                        .HasColumnType("int");

                    b.Property<int>("VareId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VareId");

                    b.ToTable("Bestillinger");
                });

            modelBuilder.Entity("IsButikMedEF.Vare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Pris")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Varer");
                });

            modelBuilder.Entity("IsButikMedEF.Bestilling", b =>
                {
                    b.HasOne("IsButikMedEF.Vare", "Vare")
                        .WithMany("Bestillinger")
                        .HasForeignKey("VareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vare");
                });

            modelBuilder.Entity("IsButikMedEF.Vare", b =>
                {
                    b.Navigation("Bestillinger");
                });
#pragma warning restore 612, 618
        }
    }
}