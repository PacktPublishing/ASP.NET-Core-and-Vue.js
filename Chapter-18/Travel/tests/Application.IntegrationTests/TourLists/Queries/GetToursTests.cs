using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Travel.Application.TourLists.Queries.GetTours;
using Travel.Domain.Entities;
using Xunit;

namespace Application.IntegrationTests.TourLists.Queries
{
    using static Testing;

    [Collection("Database collection")]
    public class GetToursTests
    {
        public GetToursTests()
        {
            ResetState().GetAwaiter().GetResult();
        }

        [Fact]
        public async Task ShouldReturnWithEmptyTourListsArray()
        {
            var query = new GetToursQuery();
            var result = await SendAsync(query);
            
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldReturnAllTourListsAndPackages()
        {
            await AddAsync(new TourList()
            {
                City = "Oslo",
                About =
                    "Oslo, the capital of Norway, sits on the country’s southern coast at the head of the Oslofjord. It’s known for its green spaces and museums. Many of these are on the Bygdøy Peninsula, including the waterside Norwegian Maritime Museum and the Viking Ship Museum, with Viking ships from the 9th century. The Holmenkollbakken is a ski-jumping hill with panoramic views of the fjord. It also has a ski museum.",
                Country = "Norway",
                TourPackages = new List<TourPackage>()
            });
            
            var query = new GetToursQuery();
            var result = await SendAsync(query);
            
            result.Lists.Should().HaveCount(1);
        }
    }
}