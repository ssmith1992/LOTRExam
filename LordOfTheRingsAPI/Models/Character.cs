using System;
using System.ComponentModel.DataAnnotations;


namespace LordoftheRingsAPI.Models
{
    public class Character
    {
        public Character(){}

        public int CharacterId { get; set; }


        public string Name { get; set; }

   
        public string ProfilePicture { get; set; }

       
        public string Description { get; set; }

    }
}
