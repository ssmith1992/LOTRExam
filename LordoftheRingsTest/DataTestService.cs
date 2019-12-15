using System;
using System.Collections.Generic;
using LordoftheRings.Models;

namespace LordoftheRingsTest
{
    public class DataTestService
    {
        public static List<Race> GetTestRace()
        {
            var sessions = new List<Race>();
            sessions.Add(new Race()
            {
                RaceId = 1,
                Name = "Elf"
            });
            sessions.Add(new Race()
            {
                RaceId = 2,
                Name = "Hobbit"
            });
            return sessions;
        }

        public DataTestService()
        {
        }
    }
}
