using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LordoftheRings.Models
{
    public interface ICharacterRepository
    {
        public void Save(Character c);

        public List<Character> Get();
        public Character Get(int characterId);
        public void Delete(int characterId);
        public List<Character> FindOppositeGender(Character c);

        public List<Character> Find(string search);
    }


    public class CharacterRepository : ICharacterRepository
    {
        private readonly CharacterCrossingContext _context;
        public CharacterRepository(CharacterCrossingContext _context)
        {
            this._context = _context;
        }
        
        public void Delete(int characterId)
        {
            _context.Characters.Remove(this.Get(characterId));
        }

        public List<Character> Find(string search)
        {
            var character = from m in _context.Characters
                            select m;

            if (!String.IsNullOrEmpty(search))
            {
                character = character.Include(c => c.races).Where(c => c.Name.ToLower().Contains(search.ToLower()) ||
                                                                        c.Description.ToLower().Contains(search.ToLower()) ||
                                                                        c.races.Name.ToLower().Contains(search.ToLower()));
            }
           
            return character.ToList();

        }

        public List<Character> FindOppositeGender(Character c)
        {
            var characters = from m in _context.Characters
                       select m;

            if (c != null)
            {
                characters = characters.Include(chars => chars.races).Where(chars => chars.RaceId == c.RaceId && chars.Gender != c.Gender);

            }

            return characters.ToList();
        }

        public List<Character> Get()
        {

            return _context.Characters.Include(chars => chars.races).ToList();
        }

        public Character Get(int characterId)
        {
            return _context.Characters.Find(characterId);
        }

        public void Save(Character c)
        {
            if (c.CharacterId == 0)
            {
                _context.Characters.Add(c);
            }
            else
            {
                _context.Characters.Update(c);
            }

            _context.SaveChanges();
        }
    }
}
