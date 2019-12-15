using System;
using System.ComponentModel.DataAnnotations;

namespace LordoftheRings.Models
{
    public class Character
    {
        public Character()
        {
        }

        // C# properties = java attribute and public get and set.
        
        public int CharacterId { get; set; }


        [Required(ErrorMessage = "All Characters must have a name to Date")]
        public string Name { get; set; }


        public Gender? Gender { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        public string ProfilePicture { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Description { get; set; }

        // Ratings..Comments, Reviews
        //public List<Review> Reviews { get; set; }


        public int RaceId { get; set; }
        public Race races { get; set; }
    }

    public enum Gender { Male, Female};

}
