﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test_back.Models;

namespace test_back.Migrations
{
    [DbContext(typeof(AppDBContent))]
    partial class AppDBContentModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("test_back.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("test_back.Models.DocType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DocCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DocTypes");
                });

            modelBuilder.Entity("test_back.Models.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<long?>("BoughtTicketId")
                        .HasColumnType("bigint");

                    b.Property<string>("Citizenship")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DocTypeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRefund")
                        .HasColumnType("bit");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BoughtTicketId");

                    b.HasIndex("DocTypeId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("test_back.Models.Ticket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("ArrDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<DateTime>("DepDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FromCityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRefundable")
                        .HasColumnType("bit");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int?>("ToCityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromCityId");

                    b.HasIndex("ToCityId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("test_back.Models.Passenger", b =>
                {
                    b.HasOne("test_back.Models.Ticket", "BoughtTicket")
                        .WithMany()
                        .HasForeignKey("BoughtTicketId");

                    b.HasOne("test_back.Models.DocType", "DocType")
                        .WithMany()
                        .HasForeignKey("DocTypeId");

                    b.Navigation("BoughtTicket");

                    b.Navigation("DocType");
                });

            modelBuilder.Entity("test_back.Models.Ticket", b =>
                {
                    b.HasOne("test_back.Models.City", "FromCity")
                        .WithMany()
                        .HasForeignKey("FromCityId");

                    b.HasOne("test_back.Models.City", "ToCity")
                        .WithMany()
                        .HasForeignKey("ToCityId");

                    b.Navigation("FromCity");

                    b.Navigation("ToCity");
                });
#pragma warning restore 612, 618
        }
    }
}