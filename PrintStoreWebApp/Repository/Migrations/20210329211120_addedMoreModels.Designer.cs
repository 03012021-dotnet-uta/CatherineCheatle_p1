﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace Repository.Migrations
{
    [DbContext(typeof(PrintStoreContext))]
    [Migration("20210329211120_addedMoreModels")]
    partial class addedMoreModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Abstracts.APrint", b =>
                {
                    b.Property<int>("PrintID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArtistFName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArtistLName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrintDecription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrintImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrintPrice")
                        .HasColumnType("float");

                    b.Property<string>("PrintTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrintID");

                    b.ToTable("Prints");
                });

            modelBuilder.Entity("Models.Abstracts.AStore", b =>
                {
                    b.Property<int>("StoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StoreCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoreZip")
                        .HasColumnType("int");

                    b.HasKey("StoreID");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerFName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerLName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("CustomerPasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("CustomerPasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("CustomerPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerZip")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Models.Inventory", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("PrintId")
                        .HasColumnType("int");

                    b.Property<int>("PrintQty")
                        .HasColumnType("int");

                    b.HasKey("StoreId", "PrintId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.Property<int>("OrdersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AStoreStoreID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("OrderSubtotal")
                        .HasColumnType("float");

                    b.Property<double>("OrderTax")
                        .HasColumnType("float");

                    b.Property<double>("OrderTotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("OrdersId");

                    b.HasIndex("AStoreStoreID");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Models.Orderline", b =>
                {
                    b.Property<int>("OrderNumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PrintId")
                        .HasColumnType("int");

                    b.Property<int>("PrintQty")
                        .HasColumnType("int");

                    b.HasKey("OrderNumId");

                    b.ToTable("Orderline");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.HasOne("Models.Abstracts.AStore", null)
                        .WithMany("Orders")
                        .HasForeignKey("AStoreStoreID");

                    b.HasOne("Models.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Abstracts.AStore", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
