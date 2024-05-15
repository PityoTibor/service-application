﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using service_data.Models;

#nullable disable

namespace service_data.Migrations
{
    [DbContext(typeof(ServiceAppDbContext))]
    partial class ServiceAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("service_data.Models.EntityModels.Admin", b =>
                {
                    b.Property<Guid>("Admin_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("User_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Admin_id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Costumer", b =>
                {
                    b.Property<Guid>("Costumer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("User_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Costumer_id");

                    b.ToTable("Costumer");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Message", b =>
                {
                    b.Property<Guid>("Message_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<Guid>("CostumerId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("HandymanId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("char(36)");

                    b.HasKey("Message_id");

                    b.HasIndex("CostumerId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Ticket", b =>
                {
                    b.Property<Guid>("Ticket_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("CostumerId")
                        .HasColumnType("int");

                    b.Property<Guid?>("Costumer_id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<Guid>("HandymanId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("Severity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<int?>("statusEnum")
                        .HasColumnType("int");

                    b.HasKey("Ticket_id");

                    b.HasIndex("Costumer_id");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.User", b =>
                {
                    b.Property<Guid>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Admin_id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Costumer_id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<Guid>("Handyman_id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("User_id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Message", b =>
                {
                    b.HasOne("service_data.Models.EntityModels.Costumer", null)
                        .WithMany("Messages")
                        .HasForeignKey("CostumerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Ticket", b =>
                {
                    b.HasOne("service_data.Models.EntityModels.Costumer", null)
                        .WithMany("Tickets")
                        .HasForeignKey("Costumer_id");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Costumer", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
