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
        public async Task ShouldReturnTourLists()
        {
            var query = new GetToursQuery();
            var result = await SendAsync(query);
            
            result.Lists.Should().NotBeEmpty();
        }

        [Fact]
        public async Task ShouldReturnAllTourListsAndPackages()
        {
            await AddAsync(new TourList()
            {
                City = "Manila",
                About =
                    "Manila, the capital of the Philippines, is a densely populated bayside city on the island of Luzon, which mixes Spanish colonial architecture with modern skyscrapers. Intramuros, a walled city in colonial times, is the heart of Old Manila. It’s home to the baroque 16th-century San Agustin Church as well as Fort Santiago, a storied citadel and former military prison. ",
                Country = "Philippines",
                TourPackages = new List<TourPackage>()
                {
                    new()
                    {
                        Name = "Fort Santiago",
                        Duration = 4,
                        InstantConfirmation = false,
                        WhatToExpect = "This museum and public park was built as a stone fortress at the turn of the 17th century and marked the beginning of the walled city's riverside barricades.",
                        Price = 50,
                        MapLocation = "https://www.google.com/maps/place/Intramuros,+Manila,+1002+Metro+Manila,+Philippines/@14.5891952,120.9656417,15z/data=!3m1!4b1!4m5!3m4!1s0x3397ca3d1375e1fb:0x49ebfa658c0ba08!8m2!3d14.5895972!4d120.9747258"
                    }
                }
            });
            
            var query = new GetToursQuery();
            var result = await SendAsync(query);
            
            result.Lists.Should().HaveCount(1);
        }
    }
}