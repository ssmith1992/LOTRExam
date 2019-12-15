using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LordoftheRings.Models
{
    public class Hookup
    {
        
        public int HookupId { get; set; }

        [ForeignKey("CharacterId")]
        public int HostId { get; set; } // CharacterId
        public Character HostCharacter { get; set; }

        [ForeignKey("CharacterId")]
        public int GuestId { get; set; } // CharacterId
        public Character GuestCharacter { get; set; }

        public string Location { get; set; }
        public DateTime DateTime { get; set; }


        public Hookup()
        {
        }
    }
}
