using Microsoft.EntityFrameworkCore;
using UVEMS.DAL.Models;
public class EMSDbContext : DbContext
{
    public EMSDbContext(DbContextOptions<EMSDbContext> options)
        : base(options) { }

    public DbSet<UserInfo> Users { get; set; }
    public DbSet<EventDetails> Events { get; set; }
    public DbSet<SessionInfo> Sessions { get; set; }
    public DbSet<SpeakerDetails> Speakers { get; set; }
    public DbSet<ParticipantEventDetails> ParticipantEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParticipantEventDetails>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.ParticipantEmailId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<SessionInfo>()
            .HasOne(s => s.Event)
            .WithMany(e => e.Sessions)
            .HasForeignKey(s => s.EventId);

        modelBuilder.Entity<SessionInfo>()
            .HasOne(s => s.Speaker)
            .WithMany()
            .HasForeignKey(s => s.SpeakerId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
