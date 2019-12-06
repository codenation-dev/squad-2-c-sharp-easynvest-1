﻿// <auto-generated />
using System;
using CentralDeErros.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CentralDeErros.Api.Migrations
{
    [DbContext(typeof(ErrorDbContext))]
    [Migration("20191130200742_PROJETO")]
    partial class PROJETO
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CentralDeErros.Api.Models.Environment", b =>
                {
                    b.Property<int>("Environment_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EnvironmentName")
                        .IsRequired()
                        .HasColumnName("ENVIRONMENT")
                        .HasMaxLength(30);

                    b.HasKey("Environment_Id");

                    b.ToTable("ENVIRONMENT");
                });

            modelBuilder.Entity("CentralDeErros.Api.Models.Error", b =>
                {
                    b.Property<int>("SituationId");

                    b.Property<int>("EnvironmentId");

                    b.Property<int>("LevelId");

                    b.Property<int>("Code")
                        .HasColumnName("CODE");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(200);

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("TITLE")
                        .HasMaxLength(200);

                    b.HasKey("SituationId", "EnvironmentId", "LevelId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("EnvironmentId");

                    b.HasIndex("LevelId");

                    b.ToTable("ERROR");
                });

            modelBuilder.Entity("CentralDeErros.Api.Models.ErrorOccurrence", b =>
                {
                    b.Property<int>("ErrorOccurrenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnName("DATE_TIME");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnName("DETAILS")
                        .HasMaxLength(2000);

                    b.Property<int>("ErrorEnvironmentId");

                    b.Property<int>("ErrorId");

                    b.Property<int>("ErrorLevelId");

                    b.Property<int>("ErrorSituationId");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnName("ORIGIN")
                        .HasMaxLength(200);

                    b.Property<int>("UserId");

                    b.HasKey("ErrorOccurrenceId");

                    b.HasIndex("UserId");

                    b.HasIndex("ErrorSituationId", "ErrorEnvironmentId", "ErrorLevelId");

                    b.ToTable("ERROR_OCCURRENCE");
                });

            modelBuilder.Entity("CentralDeErros.Api.Models.Level", b =>
                {
                    b.Property<int>("LevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LevelName")
                        .IsRequired()
                        .HasColumnName("LEVEL")
                        .HasMaxLength(30);

                    b.HasKey("LevelId");

                    b.ToTable("LEVEL");
                });

            modelBuilder.Entity("CentralDeErros.Api.Models.Situation", b =>
                {
                    b.Property<int>("SituationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SituationName")
                        .IsRequired()
                        .HasColumnName("SITUATION")
                        .HasMaxLength(30);

                    b.HasKey("SituationId");

                    b.ToTable("SITUATION");
                });

            modelBuilder.Entity("CentralDeErros.Api.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(200);

                    b.Property<DateTime>("Expiration")
                        .HasColumnName("EXPIRATION");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(200);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("PASSWORD")
                        .HasMaxLength(50);

                    b.Property<string>("Token")
                        .HasColumnName("TOKEN")
                        .HasMaxLength(200);

                    b.HasKey("UserId");

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("CentralDeErros.Api.Models.Error", b =>
                {
                    b.HasOne("CentralDeErros.Api.Models.Environment", "Environment")
                        .WithMany("Errors")
                        .HasForeignKey("EnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CentralDeErros.Api.Models.Level", "Level")
                        .WithMany("Errors")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CentralDeErros.Api.Models.Situation", "Situation")
                        .WithMany("Errors")
                        .HasForeignKey("SituationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CentralDeErros.Api.Models.ErrorOccurrence", b =>
                {
                    b.HasOne("CentralDeErros.Api.Models.Users", "User")
                        .WithMany("ErrorOccurrences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CentralDeErros.Api.Models.Error", "Error")
                        .WithMany()
                        .HasForeignKey("ErrorSituationId", "ErrorEnvironmentId", "ErrorLevelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
