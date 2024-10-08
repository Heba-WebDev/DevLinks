﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Link", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PlatformId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.HasIndex("UserId");

                    b.ToTable("Links");

                    b.HasData(
                        new
                        {
                            Id = new Guid("21e32ac1-a80b-4769-99f0-ee48671a07d7"),
                            CreatedAt = new DateTime(2024, 8, 28, 12, 21, 17, 373, DateTimeKind.Utc).AddTicks(2850),
                            PlatformId = new Guid("33333333-3333-3333-3333-333333333333"),
                            UpdatedAt = new DateTime(2024, 8, 28, 12, 21, 17, 373, DateTimeKind.Utc).AddTicks(2850),
                            Url = "https://github.com/Heba-WebDev",
                            UserId = new Guid("22222222-2222-2222-2222-222222222222")
                        });
                });

            modelBuilder.Entity("Core.Entities.Platform", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BaseUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsSupported")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            BaseUrl = "https://www.youtube.com",
                            Color = "#EE3939",
                            CreatedAt = new DateTime(2024, 8, 28, 12, 21, 17, 373, DateTimeKind.Utc).AddTicks(2790),
                            Image = "/images/platforms/youtube.svg",
                            IsSupported = true,
                            Name = "Youtube",
                            UpdatedAt = new DateTime(2024, 8, 28, 12, 21, 17, 373, DateTimeKind.Utc).AddTicks(2790)
                        },
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            BaseUrl = "http://linkedin.com",
                            Color = "#2D68FF",
                            CreatedAt = new DateTime(2024, 8, 28, 12, 21, 17, 373, DateTimeKind.Utc).AddTicks(2810),
                            Image = "/images/platforms/linkedin.svg",
                            IsSupported = true,
                            Name = "Linkedin",
                            UpdatedAt = new DateTime(2024, 8, 28, 12, 21, 17, 373, DateTimeKind.Utc).AddTicks(2810)
                        },
                        new
                        {
                            Id = new Guid("33333333-3333-3333-3333-333333333333"),
                            BaseUrl = "https://github.com",
                            Color = "#1A1A1A",
                            CreatedAt = new DateTime(2024, 8, 28, 12, 21, 17, 373, DateTimeKind.Utc).AddTicks(2810),
                            Image = "/images/platforms/github.svg",
                            IsSupported = true,
                            Name = "Github",
                            UpdatedAt = new DateTime(2024, 8, 28, 12, 21, 17, 373, DateTimeKind.Utc).AddTicks(2810)
                        });
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            CreatedAt = new DateTime(2024, 8, 28, 12, 21, 16, 910, DateTimeKind.Utc).AddTicks(3330),
                            Email = "john@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Password = "$2a$11$lWKtrkGZayyS8X7YPEKve.ZHH0fEgQMBw7kfWgQmolxFRDPSf6DtW",
                            Role = 0,
                            UpdatedAt = new DateTime(2024, 8, 28, 12, 21, 16, 910, DateTimeKind.Utc).AddTicks(3330),
                            Username = "john23"
                        },
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            CreatedAt = new DateTime(2024, 8, 28, 12, 21, 17, 138, DateTimeKind.Utc).AddTicks(4950),
                            Email = "susi@example.com",
                            FirstName = "Susi",
                            LastName = "Jr",
                            Password = "$2a$11$iByeG04Vdb4oJQiD9jlIou3ENz9tipxgMPhu/00FYyU3dlR8ZXAha",
                            Role = 1,
                            UpdatedAt = new DateTime(2024, 8, 28, 12, 21, 17, 138, DateTimeKind.Utc).AddTicks(4950),
                            Username = "susi11"
                        });
                });

            modelBuilder.Entity("Core.Entities.Link", b =>
                {
                    b.HasOne("Core.Entities.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("Links")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
