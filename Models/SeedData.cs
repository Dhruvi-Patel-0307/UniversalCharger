using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniversalCharger.Data;
using System;
using System.Linq;

namespace UniversalCharger.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UniversalChargerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<UniversalChargerContext>>()))
            {
                // Look for any movies.
                if (context.Charger.Any())
                {
                    return;   // DB has been seeded
                }

                context.Charger.AddRange(

                     new Charger
                     {
                         Name = "ChargerPoint",
                         Company = "ChargerPoint",
                         Colour = "White",
                         Price = 468M,
                         type = "USB-C",
                         voltage = 5,
                         Rating = 5
                     },
                      new Charger
                      {
                          Name = "blink charging",
                          Company = "blink charging",
                          Colour = "Blue",
                          Price = 128M,
                          type = "C - C",
                          voltage = 3,
                          Rating = 7
                      },
                       new Charger
                       {
                           Name = "tesla",
                           Company = "tesla",
                           Colour = "White",
                           Price = 85M,
                           type = "USB- C",
                           voltage = 7,
                           Rating = 3
                       },
                        new Charger
                        {
                            Name = "siemens ag",
                            Company = "siemens ag",
                            Colour = "Black",
                            Price = 280M,
                            type = "USB- C",
                            voltage = 5,
                            Rating = 4
                        }, 
                        new Charger
                        {
                            Name = "evbox",
                            Company = "evbox",
                            Colour = "White",
                            Price = 468M,
                            type = "USB-",
                            voltage = 8,
                            Rating = 4
                        },
                         new Charger
                         {
                             Name = "electrify america",
                             Company = "electrify america",
                             Colour = "White",
                             Price = 377M,
                             type = "Micro-USB",
                             voltage = 9,
                             Rating = 5
                         },
                          new Charger
                          {
                              Name = "abb",
                              Company = "abb",
                              Colour = "Blue",
                              Price =566M,
                              type = "C - C",
                              voltage = 7,
                              Rating = 7
                          },
                           new Charger
                           {
                               Name = "evgo",
                               Company = "evgo",
                               Colour = "Black",
                               Price = 345M,
                               type = "USB- C",
                               voltage = 8,
                               Rating = 8
                           },
                            new Charger
                            {
                                Name = "clippercreek",
                                Company = "clippercree",
                                Colour = "White",
                                Price = 344M,
                                type = "Micro-USB",
                                voltage = 8,
                                Rating = 6
                            },
                             new Charger
                             {
                                 Name = "allego charging station",
                                 Company = "allego charging station",
                                 Colour = "Blue",
                                 Price = 398M,
                                 type = "C -C",
                                 voltage = 8,
                                 Rating = 4
                             }



                );
                context.SaveChanges();
            }
        }
    }
}