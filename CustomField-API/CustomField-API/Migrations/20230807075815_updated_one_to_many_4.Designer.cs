﻿// <auto-generated />
using System;
using CustomField_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomField_API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230807075815_updated_one_to_many_4")]
    partial class updated_one_to_many_4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CustomField_API.CustomFormField", b =>
                {
                    b.Property<Guid>("CustomFormFieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FormName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomFormFieldId");

                    b.ToTable("CustomFormFields");
                });

            modelBuilder.Entity("CustomField_API.CustomFormFieldItem", b =>
                {
                    b.Property<Guid>("CustomFormFieldItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ControlName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CustomFormFieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomFormFieldItemId");

                    b.HasIndex("CustomFormFieldId");

                    b.ToTable("CustomFormFieldItems");
                });

            modelBuilder.Entity("CustomField_API.CustomFormFieldItem", b =>
                {
                    b.HasOne("CustomField_API.CustomFormField", "CustomFormField")
                        .WithMany("CustomFormFieldItems")
                        .HasForeignKey("CustomFormFieldId");

                    b.Navigation("CustomFormField");
                });

            modelBuilder.Entity("CustomField_API.CustomFormField", b =>
                {
                    b.Navigation("CustomFormFieldItems");
                });
#pragma warning restore 612, 618
        }
    }
}
