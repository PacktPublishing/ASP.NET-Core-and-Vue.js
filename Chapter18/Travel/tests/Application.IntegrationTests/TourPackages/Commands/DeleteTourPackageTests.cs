using System.Threading.Tasks;
using FluentAssertions;
using Travel.Application.Common.Exceptions;
using Travel.Application.TourLists.Commands.CreateTourList;
using Travel.Application.TourPackages.Commands.CreateTourPackage;
using Travel.Application.TourPackages.Commands.DeleteTourPackage;
using Travel.Domain.Entities;
using Xunit;

namespace Application.IntegrationTests.TourPackages.Commands
{
    using static DatabaseFixture;

    [Collection("DatabaseCollection")]
    public class DeleteTourPackageTests
    {
        public DeleteTourPackageTests()
        {
            ResetState().GetAwaiter().GetResult();
        }

        [Fact]
        public void ShouldRequireValidTourPackageId()
        {
            var command = new DeleteTourPackageCommand
            {
                Id = 69
            };

            FluentActions.Invoking(() => SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Fact]
        public async Task ShouldDeleteTourPackage()
        {
            var listId = await SendAsync(new CreateTourListCommand
            {
                City = "Tashkent",
                Country = "Uzbekistan",
                About = "Lorem Ipsum"
            });

            var packageId = await SendAsync(new CreateTourPackageCommand
            {
                ListId = listId,
                Name = "Silk Road Adventures",
                Duration = 8,
                Price = 80,
                InstantConfirmation = false,
                MapLocation = "Lorem Ipsum",
                WhatToExpect = "Lorem Ipsum"
            });

            await SendAsync(new DeleteTourPackageCommand
            {
                Id = packageId
            });

            var list = await FindAsync<TourPackage>(listId);

            list.Should().BeNull();
        }
    }
}