using System;
using Microsoft.EntityFrameworkCore;

namespace LordoftheRings.Models
{
    public class CharacterCrossingContext : DbContext
    {
        public CharacterCrossingContext(DbContextOptions<CharacterCrossingContext> options)
            : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Hookup> Hookups { get; set; }
    }
}
