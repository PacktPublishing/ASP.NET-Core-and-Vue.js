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
                 });

                await context.SaveChangesAsync();
            }
        }
    }
}