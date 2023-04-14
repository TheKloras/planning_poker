﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanningPokerAPI.Data;

#nullable disable

namespace PlanningPokerAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlanningPokerAPI.Models.CardClear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Clear")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("CardClearTable");
                });

            modelBuilder.Entity("PlanningPokerAPI.Models.CardConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConfigTable");
                });

            modelBuilder.Entity("PlanningPokerAPI.Models.ConnectedUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Voted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("ConnectedUsers");
                });

            modelBuilder.Entity("PlanningPokerAPI.Models.GuestUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("GuestUsers");
                });

            modelBuilder.Entity("PlanningPokerAPI.Models.NotificationMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotificationFor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NotificationMessages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Message = "Voting starts.",
                            NotificationFor = "Waiting for votes"
                        },
                        new
                        {
                            Id = 2,
                            Message = "Voting stopped.",
                            NotificationFor = "All players made their votes"
                        },
                        new
                        {
                            Id = 3,
                            Message = "Moderator flipped the cards. Voting stopped.",
                            NotificationFor = "Moderator pressed \"Flip cards\""
                        },
                        new
                        {
                            Id = 4,
                            Message = "Votes are cleared by the moderator. Voting re-started.",
                            NotificationFor = "Moderator clears the votes"
                        },
                        new
                        {
                            Id = 5,
                            Message = "Voting finished.",
                            NotificationFor = "Moderator press \"Finish voting\""
                        },
                        new
                        {
                            Id = 6,
                            Message = "New voting values saved. Voting session re-started.",
                            NotificationFor = "Moderator saves new voting values selection"
                        });
                });

            modelBuilder.Entity("PlanningPokerAPI.Models.Room", b =>
                {
                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LastUsed")
                        .HasColumnType("datetime2");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("PlanningPokerAPI.Models.RoomCardClear", b =>
                {
                    b.Property<string>("ClearRoom")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("RoomClear")
                        .HasColumnType("bit");

                    b.HasKey("ClearRoom");

                    b.ToTable("RoomCardClearTable");
                });

            modelBuilder.Entity("PlanningPokerAPI.Models.RoomCardConfig", b =>
                {
                    b.Property<string>("ConfigRoom")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConfigRoom");

                    b.ToTable("RoomConfigTable");
                });

            modelBuilder.Entity("PlanningPokerAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PlanningPokerAPI.Models.ConnectedUser", b =>
                {
                    b.HasOne("PlanningPokerAPI.Models.Room", null)
                        .WithMany("ConnectedUsers")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlanningPokerAPI.Models.Room", b =>
                {
                    b.Navigation("ConnectedUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
