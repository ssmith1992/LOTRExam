using System;
using System.Collections.Generic;
using System.Linq;

namespace LordoftheRings.Models
{
    public interface IRaceRepository
    {
        public void Save(Race r);

        public List<Race> Get();
        public Race Get(int raceId);
        public void Delete(int raceId);
    }


    public class RaceRepository : IRaceRepository
    {
        private readonly CharacterCrossingContext _context;
        public RaceRepository(CharacterCrossingContext context)
        {
            this._context = context;
        }


        public void Delete(int raceId)
        {
            _context.Races.Remove(this.Get(raceId));
        }

        public List<Race> Get()
        {
            return _context.Races.ToList();
        }

        public Race Get(int raceId)
        {
            return _context.Races.Find(raceId);
        }

        public void Save(Race r)
        {
            if (r.RaceId == 0)
            {
                _context.Races.Add(r);
            }
            else
            {
                _context.Races.Update(r);
            }

            _context.SaveChanges();
        }
    }
}
