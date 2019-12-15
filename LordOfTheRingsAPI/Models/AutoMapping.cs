using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LordoftheRingsAPI.Models;
using AutoMapper;
using LordoftheRings.Models.ViewModels;

namespace LordOfTheRingsAPI.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Character, CharacterVM>();
        }
    }
}
