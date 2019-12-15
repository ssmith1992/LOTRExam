using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LordoftheRings.Models.ViewModels
{
    public class CharactersVM
    {
        public Character Character { get; set; }
        public SelectList RaceSelectList { get; set; }

        public CharactersVM()
        {
        }
    }
}
