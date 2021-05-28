using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Domain.Entities;

namespace Travel.Data.Contexts
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.TourLists.Any())
            {
                 await context.TourLists.AddAsync(new TourList
                 {
                     City = "Oslo",
                     About =
                         "Oslo, the capital of Norway, sits on the country’s southern coast at the head of the Oslofjord. It’s known for its green spaces and museums. Many of these are on the Bygdøy Peninsula, including the waterside Norwegian Maritime Museum and the Viking Ship Museum, with Viking ships from the 9th century. The Holmenkollbakken is a ski-jumping hill with panoramic views of the fjord. It also has a ski museum.",
                     Country = "Norway",
                     TourPackages = new List<TourPackage>()
                     {
                         new()
                         {
                             Name = "Taste of Oslo Walking",
                             Duration = 4,
                             InstantConfirmation = true,
                             WhatToExpect = "Meet your guide and the rest of your group in downtown Oslo. Before embarking upon your tasting tour, there's time for a visit to a traditional Norwegian clothing (bunad) shop to learn about Norwegian apparel and traditions.",
                             Price = 900,
                             MapLocation = "https://www.google.com/maps/place/Freiabutikken/@59.9170582,10.7361595,16z/data=!4m5!3m4!1s0x0:0x212f45ff2fb8e661!8m2!3d59.9136754!4d10.7396571"
                         }
                     }
                 });

                await context.SaveChangesAsync();
            }
        }
    }
}