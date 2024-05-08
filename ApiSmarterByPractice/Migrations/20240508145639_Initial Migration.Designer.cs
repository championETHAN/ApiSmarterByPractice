﻿// <auto-generated />
using System;
using ApiSmarterByPractice.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiSmarterByPractice.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240508145639_Initial Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiSmarterByPractice.Models.UserScores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AimTrainer")
                        .HasColumnType("int");

                    b.Property<int>("ChimpTest")
                        .HasColumnType("int");

                    b.Property<DateTime>("InputDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberMemory")
                        .HasColumnType("int");

                    b.Property<int>("ReactionTime")
                        .HasColumnType("int");

                    b.Property<int>("SequenceMemory")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<int>("TypingTest")
                        .HasColumnType("int");

                    b.Property<int>("VerbalMemory")
                        .HasColumnType("int");

                    b.Property<int>("VisualMemory")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserScoress");
                });
#pragma warning restore 612, 618
        }
    }
}