using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LordOfTheRingsAPI.Models
{
    public class CharacterApiContext : DbContext

    {
        public CharacterApiContext(DbContextOptions<CharacterApiContext> options) : base(options)
        {

        }

        public DbSet<LordoftheRingsAPI.Models.Character> Characters { set; get; }
    }
}
