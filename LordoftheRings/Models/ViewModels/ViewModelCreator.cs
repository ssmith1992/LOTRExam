using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LordoftheRings.Models.ViewModels
{
    public class ViewModelCreator
    {

        public static CharactersVM CreateCharacterVm(IRaceRepository raceRepository)
        {
            return new CharactersVM()
            {
                Character = new Character(),
                RaceSelectList = new SelectList(raceRepository.Get(), "RaceId", "Name")
            };

        }

        public static CharactersVM EditCharacterVm(IRaceRepository raceRepository, Character c)
        {
            return new CharactersVM()
            {
                Character = c,
                RaceSelectList = new SelectList(raceRepository.Get(), "RaceId", "Name")
            };
        }

        public ViewModelCreator()
        {
        }
    }
}
