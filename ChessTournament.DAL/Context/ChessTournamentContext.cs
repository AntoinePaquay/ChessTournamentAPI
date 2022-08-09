using ChessTournament.DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChessTournament.DAL.Context
{
    public class ChessTournamentContext : DbContext
    {
        public DbSet<Tournament> Tournaments { get; set; } = null!;
        public DbSet<Matchup> Matchups { get; set; } = null!;
        public DbSet<Member> Members { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;

        public ChessTournamentContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Matchup>()
                .HasOne(m => m.White)
                .WithMany(p => p.MatchupsAsWhite)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Matchup>()
                .HasOne(m => m.Black)
                .WithMany(p => p.MatchupsAsBlack)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Matchup>()
                .HasOne(m => m.Tournament)
                .WithMany(p => p.Matchups)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Member>().HasIndex(m => m.Email).IsUnique();
            builder.Entity<Member>().HasIndex(m => m.Pseudo).IsUnique();
        }
    }
}
