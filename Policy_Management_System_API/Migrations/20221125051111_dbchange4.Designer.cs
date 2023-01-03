﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Policy_Management_System_API;

#nullable disable

namespace Policy_Management_System_API.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20221125051111_dbchange4")]
    partial class dbchange4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Policy_Management_System_API.Coverage", b =>
                {
                    b.Property<int>("CoverageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoverageId"), 1L, 1);

                    b.Property<string>("CoverageType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("CoverageId");

                    b.ToTable("coverage");
                });

            modelBuilder.Entity("Policy_Management_System_API.HouseDetail", b =>
                {
                    b.Property<int>("HouseDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HouseDetailId"), 1L, 1);

                    b.Property<float?>("AssetValue")
                        .HasColumnType("real");

                    b.Property<string>("HouseAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("HouseDetailId");

                    b.ToTable("housedetail");
                });

            modelBuilder.Entity("Policy_Management_System_API.Policy", b =>
                {
                    b.Property<int>("PolicyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PolicyId"), 1L, 1);

                    b.Property<int>("CoverageId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Duration")
                        .HasColumnType("real");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HouseDetailId")
                        .HasColumnType("int");

                    b.Property<float>("InsuredAmount")
                        .HasColumnType("real");

                    b.Property<int>("InsuredHolderAge")
                        .HasColumnType("int");

                    b.Property<string>("InsuredName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PolicyTypeId")
                        .HasColumnType("int");

                    b.Property<float?>("Premium")
                        .HasColumnType("real");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("VehicleDetailId")
                        .HasColumnType("int");

                    b.HasKey("PolicyId");

                    b.HasIndex("CoverageId");

                    b.HasIndex("HouseDetailId")
                        .IsUnique()
                        .HasFilter("[HouseDetailId] IS NOT NULL");

                    b.HasIndex("PolicyTypeId");

                    b.HasIndex("VehicleDetailId")
                        .IsUnique()
                        .HasFilter("[VehicleDetailId] IS NOT NULL");

                    b.ToTable("policy");
                });

            modelBuilder.Entity("Policy_Management_System_API.PolicyType", b =>
                {
                    b.Property<int>("PolicyTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PolicyTypeId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Policytype")
                        .HasColumnType("int");

                    b.HasKey("PolicyTypeId");

                    b.ToTable("policytype");
                });

            modelBuilder.Entity("Policy_Management_System_API.VehicleDetail", b =>
                {
                    b.Property<int>("VehicleDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleDetailId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("VehicleModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleDetailId");

                    b.ToTable("vehicledetail");
                });

            modelBuilder.Entity("Policy_Management_System_API.Policy", b =>
                {
                    b.HasOne("Policy_Management_System_API.Coverage", "coverage")
                        .WithMany("policy")
                        .HasForeignKey("CoverageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Policy_Management_System_API.HouseDetail", "houseDetail")
                        .WithOne("policy")
                        .HasForeignKey("Policy_Management_System_API.Policy", "HouseDetailId");

                    b.HasOne("Policy_Management_System_API.PolicyType", "policytype")
                        .WithMany("policy")
                        .HasForeignKey("PolicyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Policy_Management_System_API.VehicleDetail", "vehicleDetail")
                        .WithOne("policy")
                        .HasForeignKey("Policy_Management_System_API.Policy", "VehicleDetailId");

                    b.Navigation("coverage");

                    b.Navigation("houseDetail");

                    b.Navigation("policytype");

                    b.Navigation("vehicleDetail");
                });

            modelBuilder.Entity("Policy_Management_System_API.Coverage", b =>
                {
                    b.Navigation("policy");
                });

            modelBuilder.Entity("Policy_Management_System_API.HouseDetail", b =>
                {
                    b.Navigation("policy");
                });

            modelBuilder.Entity("Policy_Management_System_API.PolicyType", b =>
                {
                    b.Navigation("policy");
                });

            modelBuilder.Entity("Policy_Management_System_API.VehicleDetail", b =>
                {
                    b.Navigation("policy");
                });
#pragma warning restore 612, 618
        }
    }
}