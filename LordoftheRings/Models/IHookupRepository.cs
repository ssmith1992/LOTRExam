using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LordoftheRings.Models
{
    interface IHookupRepository
    {
        public List<Hookup> Get();
        public void Save(Hookup h);
        public Hookup Get(int HookupId);
        public void Delete(int HookupId);
    }
}
