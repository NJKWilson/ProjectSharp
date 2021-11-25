﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectSharp.Gui.Database;

#nullable disable

namespace ProjectSharp.DataAccess.Migrations
{
    [DbContext(typeof(PSharpContext))]
    [Migration("20211125190948_UpdatedSeedData")]
    partial class UpdatedSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjectSharp.Gui.Database.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("UpdatedById")
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6f3fb42f-69ba-4b24-9b26-a43b5986db4a"),
                            CreatedOn = new DateTimeOffset(new DateTime(2021, 11, 25, 19, 9, 48, 363, DateTimeKind.Unspecified).AddTicks(7366), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "admin",
                            Password = "$2a$11$wavn.EqSjRjLzfaE9jsN6uRLgU51Uu6o39kZUOQld11HwF9En7imy",
                            Role = "Admin"
                        });
                });

            modelBuilder.Entity("ProjectSharp.Gui.Database.Entities.Users.User", b =>
                {
                    b.HasOne("ProjectSharp.Gui.Database.Entities.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("ProjectSharp.Gui.Database.Entities.Users.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("UpdatedBy");
                });
#pragma warning restore 612, 618
        }
    }
}
