using DevUpConference.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUpConference.Database;

public class DevUpDbContext : DbContext
{
    public DevUpDbContext(DbContextOptions<DevUpDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Attende> Attendees { get; set; }
    public virtual DbSet<Feedback> Feedbacks { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }
    public virtual DbSet<Session> Sessions { get; set; }
    public virtual DbSet<SessionLevel> SessionLevels { get; set; }
    public virtual DbSet<Speaker> Speakers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attende>(entity =>
        {
            entity.ToTable("Attende");

            entity.HasKey(e => e.AttendeId);

            entity.Property(e => e.AttendeFirstName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.AttendeLastName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.AttendeEmailAddress)
                .IsRequired()
                .HasMaxLength(150);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.ToTable("Feedback");

            entity.HasKey("FeedbackId");

            entity.Property(e => e.FeedbackRating)
                .IsRequired();

            entity.Property(e => e.FeedbackText)
                .IsRequired()
                .HasMaxLength(2500);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Room");

            entity.HasKey(e => e.RoomId);

            entity.Property(e => e.RoomNumber)
                .IsRequired()
                .HasMaxLength(50);
            
            entity.HasMany(e => e.Sessions)
                .WithOne();
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.ToTable("Session");

            entity.HasKey(e => e.SessionId);

            entity.Property(e => e.SessionDescription)
                .IsRequired()
                .HasMaxLength(2500);

            entity.Property(e => e.SessionTime)
                .IsRequired();

            entity.Property(e => e.SessionTitle)
                .IsRequired()
                .HasMaxLength(250);

            entity.HasOne(e => e.SessionSpeaker)
                .WithMany();

            entity.HasOne(e => e.SessionLevel)
                .WithMany();

            entity.HasOne(e => e.SessionRoom)
                .WithMany();
        });

        modelBuilder.Entity<SessionLevel>(entity =>
        {
            entity.ToTable("SessionLevel");

            entity.HasKey(e => e.SessionLevelId);

            entity.Property(e => e.SessionLevelName)
                .IsRequired()
                .HasMaxLength(25);

            entity.HasMany(e => e.Sessions)
                .WithOne();
        });

        modelBuilder.Entity<Speaker>(entity =>
        {
            entity.ToTable("Speaker");

            entity.HasKey(e => e.SpeakerId);

            entity.Property(e => e.SpeakerName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.SpeakerBio)
                .IsRequired()
                .HasMaxLength(1000);

            entity.Property(e => e.SpeakerJobTitle)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.SpeakerWebsite)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.SpeakerImage)
                .IsRequired();

            entity.HasMany(e => e.Sessions)
                .WithOne();
        });


        base.OnModelCreating(modelBuilder);
    }
}
