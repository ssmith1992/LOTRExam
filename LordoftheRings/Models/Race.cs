using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LordoftheRings.Models
{
    public class Race
    {
        public int RaceId { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }

        public List<Character> Characters { get; set; }


        public Race()
        {
        }
    }
}
