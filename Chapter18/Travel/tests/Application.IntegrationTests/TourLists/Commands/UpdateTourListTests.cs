using System.Threading.Tasks;
using FluentAssertions;
using Travel.Application.Common.Exceptions;
using Travel.Application.TourLists.Commands.CreateTourList;
using Travel.Application.TourLists.Commands.UpdateTourList;
using Travel.Domain.Entities;
using Xunit;

namespace Application.IntegrationTests.TourLists.Commands
{
    using static DatabaseFixture;

    [Collection("DatabaseCollection")]
    public class UpdateTourListTests
    {
        public UpdateTourListTests()
        {
            ResetState().GetAwaiter().GetResult();
        }

        [Fact]
        public void ShouldRequiredValidTourListId()
        {
            var command = new UpdateTourListCommand
            {
                Id = 8,
                City = "Caracas",
                Country = "Venezuela",
                About = "Lorem Ipsum"
            };

            FluentActions.Invoking(() => SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Fact]
        public async Task ShouldUpdateTourList()
        {
            var listId = await SendAsync(new CreateTourListCommand
            {
                City = "Al Ghanim",
                Country = "Qatar",
                About = "Lorem Ipsum"
            });

            var command = new UpdateTourListCommand
            {
                Id = listId,
                City = "Doha",
                Country = "Qatar",
                About = "Lorem Ipsum"
            };

            await SendAsync(command);

            var list = await FindAsync<TourList>(listId);

            list.City.Should().Be(command.City);
            list.Country.Should().Be(command.Country);
            list.About.Should().NotBeNull();
        }
    }
}