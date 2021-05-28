using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Travel.Application.TourLists.Queries.GetTours;
using Travel.Domain.Entities;
using Xunit;

namespace Application.IntegrationTests.TourLists.Queries
{
    using static DatabaseFixture;

    [Collection("DatabaseCollection")]
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
            await AddAsync(new TourList
            {
                City = "Manila",
                Country = "Philippines",
                About = "Lorem Ipsum",
                TourPackages = new List<TourPackage>
                {
                    new()
                    {
                        Name = "Free Walking Tour Manila",
                        Duration = 2,
                        Price = 10,
                        InstantConfirmation = true,
                        MapLocation = "Lorem Ipsum",
                        WhatToExpect = "Lorem Ipsum"
                    }
                }
            });
            
            var query = new GetToursQuery();
            var result = await SendAsync(query);
            
            result.Lists.Should().HaveCount(1);
        }
    }
}