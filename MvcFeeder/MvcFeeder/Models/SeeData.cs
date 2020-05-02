using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace MvcFeeder.Models
{
    public class SeeData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcFeederContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcFeederContext>>()))
            {
                // Look for any movies.
                if (context.BreastFeed.Any())
                {
                    return;   // DB has been seeded
                }

                context.BreastFeed.AddRange(
                    new BreastFeed
                    {
                        Name = "Harry",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Side = "left",
                        hour = 7,
                        Note =" rien"
                    },

                    new BreastFeed
                    {
                        Name = "Jhon",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Side = "right",
                        hour = 7,
                        Note = " pas suffisant"
                    },

                    new BreastFeed
                    {
                        Name = "Harry",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Side = "right",
                        hour = 10,
                        Note = " pas faim"
                    },

                    new BreastFeed
                    {
                        Name = "Jhon",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Side = "left",
                        hour = 10,
                        Note = " grincheux comme d'habitude"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

