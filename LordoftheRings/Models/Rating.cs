using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LordoftheRings.Models
{
    public class Rating
    {
        [Key]
        public int ReviewId { get; set; }

        [Required(ErrorMessage ="select a rating for the hookup")]
        public Rates? Rates { get; set; } // 1-5

        public int RatingCharacterId { get; set; }
        public Character RatingChacter { get; set; }

        [Required(ErrorMessage = "you have to write comment")]
        public string Comment { get; set; }

        public Rating()
        {
        }
    }
    public enum Rates { bad, okay, good, hot, best }
}
