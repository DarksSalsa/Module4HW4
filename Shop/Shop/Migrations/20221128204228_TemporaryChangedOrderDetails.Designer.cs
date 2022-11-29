﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Shop.Data;

#nullable disable

namespace Shop.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20221128204228_TemporaryChangedOrderDetails")]
    partial class TemporaryChangedOrderDetails
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseHiLo(modelBuilder, "EntityFrameworkHiLoSequence");

            modelBuilder.HasSequence("EntityFrameworkHiLoSequence")
                .IncrementsBy(10);

            modelBuilder.Entity("Shop.Data.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Shop.Data.Entities.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"));

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Address2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BillingAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BillingCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BillingCountry")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BillingPostalCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BillingRegion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Building")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardExpMo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardExpYr")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreditCard")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CreditCardTypeID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateEntered")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShipAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShipCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShipCountry")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShipPostalCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShipRegion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VoiceMail")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Shop.Data.Entities.OrderDetailsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"));

                    b.Property<DateTime>("BillDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Discount")
                        .HasColumnType("numeric");

                    b.Property<bool>("Fulfilled")
                        .HasColumnType("boolean");

                    b.Property<string>("IDSKU")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OrderID")
                        .HasColumnType("integer");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ShipDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Shop.Data.Entities.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("integer");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("ErrLoc")
                        .HasColumnType("text");

                    b.Property<string>("ErrMsg")
                        .HasColumnType("text");

                    b.Property<string>("Freight")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Fulfilled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OrderDetailsID")
                        .HasColumnType("integer");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Paid")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PaymentID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("SalesTax")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("ShipDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ShipperID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("TransactStatus")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("CustomerID");

                    b.HasIndex("PaymentID");

                    b.HasIndex("ShipperID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shop.Data.Entities.PaymentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"));

                    b.Property<bool>("Allowed")
                        .HasColumnType("boolean");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Shop.Data.Entities.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"));

                    b.Property<string>("AvailableColors")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AvailableSize")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CategoryID")
                        .HasColumnType("integer");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CurrentOrder")
                        .HasColumnType("integer");

                    b.Property<decimal>("Discount")
                        .HasColumnType("numeric");

                    b.Property<bool>("DiscountAvailable")
                        .HasColumnType("boolean");

                    b.Property<string>("IDSKU")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MSRP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("ProductAvailable")
                        .HasColumnType("boolean");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("QuantityPerUnit")
                        .HasColumnType("integer");

                    b.Property<int>("Ranking")
                        .HasColumnType("integer");

                    b.Property<string>("ReorderLevel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SupplierID")
                        .HasColumnType("integer");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("UnitWeight")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("integer");

                    b.Property<int>("UnitsOnOrder")
                        .HasColumnType("integer");

                    b.Property<int>("VendorProductID")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Shop.Data.Entities.ShipperEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Shippers");
                });

            modelBuilder.Entity("Shop.Data.Entities.SupplierEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"));

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Address2")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContactFName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContactLName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContactTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CurrentOrder")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomerID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("DiscountAvailable")
                        .HasColumnType("boolean");

                    b.Property<string>("DiscountType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaymentMethods")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SizeURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Shop.Data.Entities.OrderDetailsEntity", b =>
                {
                    b.HasOne("Shop.Data.Entities.OrderEntity", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Entities.ProductEntity", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shop.Data.Entities.OrderEntity", b =>
                {
                    b.HasOne("Shop.Data.Entities.CustomerEntity", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Entities.PaymentEntity", "Payment")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Entities.ShipperEntity", "Shipper")
                        .WithMany("Orders")
                        .HasForeignKey("ShipperID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Payment");

                    b.Navigation("Shipper");
                });

            modelBuilder.Entity("Shop.Data.Entities.ProductEntity", b =>
                {
                    b.HasOne("Shop.Data.Entities.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Entities.SupplierEntity", "Supplier")
                        .WithMany("TypeGoods")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Shop.Data.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Shop.Data.Entities.CustomerEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Shop.Data.Entities.OrderEntity", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Shop.Data.Entities.PaymentEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Shop.Data.Entities.ProductEntity", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Shop.Data.Entities.ShipperEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Shop.Data.Entities.SupplierEntity", b =>
                {
                    b.Navigation("TypeGoods");
                });
#pragma warning restore 612, 618
        }
    }
}
