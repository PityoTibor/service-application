﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using service_data.Models;

#nullable disable

namespace service_data.Migrations
{
    [DbContext(typeof(ServiceAppDbContext))]
    [Migration("20240930125301_DeleteTicketSkill")]
    partial class DeleteTicketSkill
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("service_data.Models.EntityModels.Admin", b =>
                {
                    b.Property<Guid>("Admin_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("User_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Admin_id");

                    b.HasIndex("User_id")
                        .IsUnique();

                    b.ToTable("tbl_admin");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Costumer", b =>
                {
                    b.Property<Guid>("Costumer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("User_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Costumer_id");

                    b.HasIndex("User_id")
                        .IsUnique();

                    b.ToTable("tbl_costumer");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Handyman", b =>
                {
                    b.Property<Guid>("Handyman_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<double?>("Latitude")
                        .HasColumnType("double");

                    b.Property<double?>("Longitude")
                        .HasColumnType("double");

                    b.Property<Guid>("User_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Handyman_id");

                    b.HasIndex("User_id")
                        .IsUnique();

                    b.ToTable("tbl_handyman");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.HandymanSkill", b =>
                {
                    b.Property<Guid>("Handyman_skill_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Handyman_id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Skill_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Handyman_skill_id");

                    b.HasIndex("Handyman_id");

                    b.HasIndex("Skill_id");

                    b.ToTable("tbl_handymanskill");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Interval", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Handyman_id")
                        .HasColumnType("char(36)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Handyman_id");

                    b.ToTable("tbl_interval");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Message", b =>
                {
                    b.Property<Guid>("Message_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("Costumer_id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("Handyman_id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("Ticket_id")
                        .HasColumnType("char(36)");

                    b.HasKey("Message_id");

                    b.HasIndex("Costumer_id");

                    b.HasIndex("Handyman_id");

                    b.HasIndex("Ticket_id");

                    b.ToTable("tbl_message");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.No_use_TicketSkill", b =>
                {
                    b.Property<Guid>("TicketSkill_skill_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Skill_id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Ticket_id")
                        .HasColumnType("char(36)");

                    b.HasKey("TicketSkill_skill_id");

                    b.HasIndex("Skill_id");

                    b.HasIndex("Ticket_id");

                    b.ToTable("tbl_ticketskill");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Skill", b =>
                {
                    b.Property<Guid>("Skill_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsAutoAssign")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Skill_id");

                    b.ToTable("tbl_skill");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Ticket", b =>
                {
                    b.Property<Guid>("Ticket_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("Costumer_id")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("Created_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("Handyman_id")
                        .HasColumnType("char(36)");

                    b.Property<double>("Latitude")
                        .HasColumnType("double");

                    b.Property<double>("Longitude")
                        .HasColumnType("double");

                    b.Property<int?>("SeverityEnum")
                        .HasColumnType("int");

                    b.Property<int?>("StatusEnum")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Ticket_id");

                    b.HasIndex("Costumer_id");

                    b.HasIndex("Handyman_id");

                    b.ToTable("tbl_ticket");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.User", b =>
                {
                    b.Property<Guid>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("User_id");

                    b.ToTable("tbl_user");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Admin", b =>
                {
                    b.HasOne("service_data.Models.EntityModels.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("service_data.Models.EntityModels.Admin", "User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Costumer", b =>
                {
                    b.HasOne("service_data.Models.EntityModels.User", "User")
                        .WithOne("Costumer")
                        .HasForeignKey("service_data.Models.EntityModels.Costumer", "User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Handyman", b =>
                {
                    b.HasOne("service_data.Models.EntityModels.User", "User")
                        .WithOne("Handyman")
                        .HasForeignKey("service_data.Models.EntityModels.Handyman", "User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.HandymanSkill", b =>
                {
                    b.HasOne("service_data.Models.EntityModels.Handyman", "Handyman")
                        .WithMany("HandymanSkills")
                        .HasForeignKey("Handyman_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("service_data.Models.EntityModels.Skill", "Skill")
                        .WithMany("HandymanSkills")
                        .HasForeignKey("Skill_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Handyman");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Interval", b =>
                {
                    b.HasOne("service_data.Models.EntityModels.Handyman", "Handyman")
                        .WithMany("Intervals")
                        .HasForeignKey("Handyman_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Handyman");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Message", b =>
                {
                    b.HasOne("service_data.Models.EntityModels.Costumer", "Costumer")
                        .WithMany("Messages")
                        .HasForeignKey("Costumer_id");

                    b.HasOne("service_data.Models.EntityModels.Handyman", "Handyman")
                        .WithMany("Messages")
                        .HasForeignKey("Handyman_id");

                    b.HasOne("service_data.Models.EntityModels.Ticket", "Ticket")
                        .WithMany("Messages")
                        .HasForeignKey("Ticket_id");

                    b.Navigation("Costumer");

                    b.Navigation("Handyman");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.No_use_TicketSkill", b =>
                {
                    b.HasOne("service_data.Models.EntityModels.Skill", "Skill")
                        .WithMany("TicketSkills")
                        .HasForeignKey("Skill_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("service_data.Models.EntityModels.Ticket", "Ticket")
                        .WithMany("TicketSkills")
                        .HasForeignKey("Ticket_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Ticket", b =>
                {
                    b.HasOne("service_data.Models.EntityModels.Costumer", "Costumer")
                        .WithMany("Tickets")
                        .HasForeignKey("Costumer_id");

                    b.HasOne("service_data.Models.EntityModels.Handyman", "Handyman")
                        .WithMany("Tickets")
                        .HasForeignKey("Handyman_id");

                    b.Navigation("Costumer");

                    b.Navigation("Handyman");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Costumer", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Handyman", b =>
                {
                    b.Navigation("HandymanSkills");

                    b.Navigation("Intervals");

                    b.Navigation("Messages");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Skill", b =>
                {
                    b.Navigation("HandymanSkills");

                    b.Navigation("TicketSkills");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.Ticket", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("TicketSkills");
                });

            modelBuilder.Entity("service_data.Models.EntityModels.User", b =>
                {
                    b.Navigation("Admin")
                        .IsRequired();

                    b.Navigation("Costumer")
                        .IsRequired();

                    b.Navigation("Handyman")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
