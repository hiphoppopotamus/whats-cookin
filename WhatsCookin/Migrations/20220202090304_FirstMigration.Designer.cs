﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhatsCookin.Data;

#nullable disable

namespace WhatsCookin.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220202090304_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WhatsCookin.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = new byte[] { 32, 32, 32, 32, 32, 32, 32 },
                            PasswordSalt = new byte[] { 32, 32, 32, 32, 32, 32, 32 },
                            Username = "User1"
                        },
                        new
                        {
                            Id = 2,
                            PasswordHash = new byte[] { 32, 32, 32, 32, 32, 32, 32 },
                            PasswordSalt = new byte[] { 32, 32, 32, 32, 32, 32, 32 },
                            Username = "User2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
