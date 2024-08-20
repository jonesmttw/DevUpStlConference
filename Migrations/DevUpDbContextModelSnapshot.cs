﻿// <auto-generated />
using System;
using DevUpConference.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DevUpConference.Migrations
{
    [DbContext(typeof(DevUpDbContext))]
    partial class DevUpDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DevUpConference.Database.Models.Attende", b =>
                {
                    b.Property<Guid>("AttendeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AttendeEmailAddress")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("AttendeFirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("AttendeLastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("AttendeId");

                    b.ToTable("Attende", (string)null);
                });

            modelBuilder.Entity("DevUpConference.Database.Models.Feedback", b =>
                {
                    b.Property<Guid>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FeedbackRating")
                        .HasColumnType("int");

                    b.Property<string>("FeedbackText")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.HasKey("FeedbackId");

                    b.ToTable("Feedback", (string)null);
                });

            modelBuilder.Entity("DevUpConference.Database.Models.Room", b =>
                {
                    b.Property<Guid>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoomId");

                    b.ToTable("Room", (string)null);
                });

            modelBuilder.Entity("DevUpConference.Database.Models.Session", b =>
                {
                    b.Property<Guid>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SessionDescription")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<Guid>("SessionLevelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SessionLevelId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionRoomRoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionSpeakerSpeakerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SessionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionTitle")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid?>("SpeakerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SessionId");

                    b.HasIndex("SessionLevelId");

                    b.HasIndex("SessionLevelId1");

                    b.HasIndex("SessionRoomRoomId");

                    b.HasIndex("SessionSpeakerSpeakerId");

                    b.HasIndex("SpeakerId");

                    b.ToTable("Session", (string)null);
                });

            modelBuilder.Entity("DevUpConference.Database.Models.SessionLevel", b =>
                {
                    b.Property<Guid>("SessionLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SessionLevelName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("SessionLevelId");

                    b.ToTable("SessionLevel", (string)null);
                });

            modelBuilder.Entity("DevUpConference.Database.Models.Speaker", b =>
                {
                    b.Property<Guid>("SpeakerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SpeakerBio")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("SpeakerImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpeakerJobTitle")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("SpeakerName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("SpeakerWebsite")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("SpeakerId");

                    b.ToTable("Speaker", (string)null);
                });

            modelBuilder.Entity("DevUpConference.Database.Models.Session", b =>
                {
                    b.HasOne("DevUpConference.Database.Models.SessionLevel", "SessionLevel")
                        .WithMany()
                        .HasForeignKey("SessionLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevUpConference.Database.Models.SessionLevel", null)
                        .WithMany("Sessions")
                        .HasForeignKey("SessionLevelId1");

                    b.HasOne("DevUpConference.Database.Models.Room", "SessionRoom")
                        .WithMany()
                        .HasForeignKey("SessionRoomRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevUpConference.Database.Models.Speaker", "SessionSpeaker")
                        .WithMany()
                        .HasForeignKey("SessionSpeakerSpeakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevUpConference.Database.Models.Speaker", null)
                        .WithMany("Sessions")
                        .HasForeignKey("SpeakerId");

                    b.Navigation("SessionLevel");

                    b.Navigation("SessionRoom");

                    b.Navigation("SessionSpeaker");
                });

            modelBuilder.Entity("DevUpConference.Database.Models.SessionLevel", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("DevUpConference.Database.Models.Speaker", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
