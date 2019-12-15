using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LordoftheRings.Models
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CharacterCrossingContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CharacterCrossingContext>>()))
            {

                // You add more code here to seed database.
                // See: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-3.0&tabs=visual-studio
                if (!context.Races.Any())
                {
                    var races = new Race[] {
                        new Race { Name="Hobbit", Description="Very little human" },
                        new Race { Name="Elf", Description="human with pointy ears" },
                        new Race { Name="Orc", Description="Very ugly human" },
                        new Race { Name="Trolls", Description="Stupid and smelly human" },
                        new Race { Name="Wizard", Description="Smart humans" },
                        new Race { Name="Human", Description="Pure blood" },

                    };

                    context.Races.AddRange(races);
                    //foreach(var spec in species)
                    //{
                    //    context.Species.Add(spec);
                    //}

                    context.SaveChanges();
                }

                if (!context.Characters.Any())
                {
                    var raceType = context.Races.ToList();

                    var characters = new Character[]
                    {
                        new Character{ Name="Liam", Description="Likes walks on the beach", Gender=Gender.Female, BirthDate= new DateTime(2000, 4, 3),  ProfilePicture="https://www.zooplus.dk/magasin/wp-content/uploads/2018/01/fotolia_138361424-768x658.jpg", RaceId= raceType[0].RaceId },
                        new Character{ Name="Mathias", Description="Likes something ", Gender=Gender.Female, BirthDate= new DateTime(2004, 4, 3),  ProfilePicture="https://images2.minutemediacdn.com/image/upload/c_fill,g_auto,h_1248,w_2220/f_auto,q_auto,w_1100/v1555382975/shape/mentalfloss/sphinxhed.png", RaceId=raceType[1].RaceId },
                        new Character{ Name="Simon", Description="Likes eeeeverythin", Gender=Gender.Male, BirthDate= new DateTime(1994, 8, 14),  ProfilePicture="https://images2.minutemediacdn.com/image/upload/c_fill,g_auto,h_1248,w_2220/f_auto,q_auto,w_1100/v1555382975/shape/mentalfloss/sphinxhed.png", RaceId=raceType[2].RaceId },
                        new Character{ Name="Tobias", Description="Likes to study and give grades", Gender=Gender.Female, BirthDate= new DateTime(1980, 5, 10),  ProfilePicture="https://images2.minutemediacdn.com/image/upload/c_fill,g_auto,h_1248,w_2220/f_auto,q_auto,w_1100/v1555382975/shape/mentalfloss/sphinxhed.png", RaceId=raceType[3].RaceId },

                    };
                    context.Characters.AddRange(characters);


                    context.SaveChanges();
                }


            }


        }
    }
}
