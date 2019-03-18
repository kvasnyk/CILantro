﻿// <auto-generated />
using System;
using CILantroToolsWebAPI.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CILantroToolsWebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190318191215_RunEntityIntIdAndStatus")]
    partial class RunEntityIntIdAndStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CILantroToolsWebAPI.DbModels.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CILantroToolsWebAPI.DbModels.Run", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("IntId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Runs");
                });

            modelBuilder.Entity("CILantroToolsWebAPI.DbModels.Subcategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategories");
                });

            modelBuilder.Entity("CILantroToolsWebAPI.DbModels.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoryId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("HasEmptyInput");

                    b.Property<int>("IntId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Output");

                    b.Property<string>("Path");

                    b.Property<Guid?>("SubcategoryId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("CILantroToolsWebAPI.DbModels.TestInputOutputExample", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Input");

                    b.Property<string>("Name");

                    b.Property<string>("Output");

                    b.Property<Guid>("TestId");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("TestInputOutputExamples");
                });

            modelBuilder.Entity("CILantroToolsWebAPI.DbModels.Subcategory", b =>
                {
                    b.HasOne("CILantroToolsWebAPI.DbModels.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CILantroToolsWebAPI.DbModels.Test", b =>
                {
                    b.HasOne("CILantroToolsWebAPI.DbModels.Category", "Category")
                        .WithMany("Tests")
                        .HasForeignKey("CategoryId");

                    b.HasOne("CILantroToolsWebAPI.DbModels.Subcategory", "Subcategory")
                        .WithMany("Tests")
                        .HasForeignKey("SubcategoryId");
                });

            modelBuilder.Entity("CILantroToolsWebAPI.DbModels.TestInputOutputExample", b =>
                {
                    b.HasOne("CILantroToolsWebAPI.DbModels.Test", "Test")
                        .WithMany("IoExamples")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
