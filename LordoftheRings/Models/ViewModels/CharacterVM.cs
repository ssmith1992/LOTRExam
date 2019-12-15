using System;
namespace LordoftheRings.Models.ViewModels
{
    public class CharacterVM
    {

        public int CharacterId { get; set; }


        public string Name { get; set; }

        public string ProfilePicture { get; set; }

        public string Description { get; set; }

        public CharacterVM()
        {
        }
    }
}
