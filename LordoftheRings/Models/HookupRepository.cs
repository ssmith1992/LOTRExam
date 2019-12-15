using System;
using System.Collections.Generic;
using System.Linq;
using LordoftheRings.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalCrossing.Models.ViewModels
{
    public class HookupRepository : IHookupRepository
    {
        private readonly CharacterCrossingContext _context;


        public HookupRepository(CharacterCrossingContext context)
        {
            this._context = context;
        }

        public List<Hookup> Get()
        {

            return _context.Hookups.Include(x => x.HostCharacter).Include(c => c.GuestCharacter).ToList();

        }

        public void Delete(int HookupId)
        {

            _context.Hookups.Remove(this.Get(HookupId));
        }


        public Hookup Get(int HookupId)
        {
            return _context.Hookups.Find(HookupId);
        }

        public void Save(Hookup h)
        {
            if (h.HookupId == 0)
            {
                _context.Hookups.Add(h);
            }
            else
            {
                _context.Hookups.Update(h);
            }
            _context.SaveChanges();

        }

        List<Hookup> IHookupRepository.Get()
        {
            throw new NotImplementedException();
        }

    }
}
