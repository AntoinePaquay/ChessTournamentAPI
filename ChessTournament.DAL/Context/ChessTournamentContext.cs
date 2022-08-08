using ChessTournament.DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChessTournament.DAL.Context
{
    public class ChessTournamentContext : DbContext
    {
        public DbSet<Tournament> Tournaments { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Matchup> Matchups { get; set; } = null!;
        public DbSet<Member> Members { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;

        public ChessTournamentContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //TODO Constraint
        }
    }
}
