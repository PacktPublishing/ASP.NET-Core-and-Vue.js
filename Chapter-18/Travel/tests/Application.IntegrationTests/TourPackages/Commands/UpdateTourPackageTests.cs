using Travel.Application.Common.Exceptions;
using Travel.Application.TourLists.Commands.CreateTourList;
using Travel.Application.TourPackages.Commands.CreateTourPackage;
using Travel.Application.TourPackages.Commands.UpdateTourPackage;
using Travel.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Application.IntegrationTests.TourPackages.Commands
{
    using static DatabaseFixture;

    [Collection("DatabaseCollection")]
    public class UpdateTourPackageTests
    {
        public UpdateTourPackageTests()
        {
            ResetState().GetAwaiter().GetResult();
        }

        [Fact]
        public void ShouldRequireValidTourPackageId()
        {
            var command = new UpdateTourPackageCommand
            {
                Id = 4,
                Name = "Free Walking Tour"
            };

            FluentActions.Invoking(() => SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Fact]
        public async Task ShouldUpdateTourPackage()
        {
            var listId = await SendAsync(new CreateTourListCommand
            {
                City = "Rabat",
                Country = "Morocco",
                About = "Lorem Ipsum"
            });

            var packageId = await SendAsync(new CreateTourPackageCommand
            {
                ListId = listId,
                Name = "Free Walking Tour Rabat",
                Duration = 2,
                Price = 10,
                InstantConfirmation = true,
                MapLocation = "Lorem Ipsum",
                WhatToExpect = "Lorem Ipsum"
            });

            var command = new UpdateTourPackageCommand
            {
                Id = packageId,
                Name = "Night Free Walking Tour Rabat"
            };

            await SendAsync(command);

            var item = await FindAsync<TourPackage>(packageId);

            item.Name.Should().Be(command.Name);
            item.WhatToExpect.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldRequireUniqueName()
        {
            var listId = await SendAsync(new CreateTourListCommand
            {
                City = "Bogota",
                Country = "Colombia",
                About = "Lorem Ipsum"
            });

            await SendAsync(new CreateTourPackageCommand
            {
                ListId = listId,
                Name = "Bike Tour in Bogota"
            });

            await SendAsync(new CreateTourPackageCommand
            {
                ListId = listId,
                Name = "Salt Cathedral Tour"
            });

            var command = new UpdateTourPackageCommand
            {
                Id = listId,
                Name = "Salt Cathedral Tour"
            };

            FluentActions.Invoking(() => SendAsync(command))
                .Should()
                .Throw<ValidationException>()
                .Where(ex => ex.Errors.ContainsKey("Name"))
                .And.Errors["Name"]
                .Should()
                .Contain("The specified name already exists.");
        }
    }
}