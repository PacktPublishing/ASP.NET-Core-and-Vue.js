using System.Threading.Tasks;
using FluentAssertions;
using Travel.Application.Common.Exceptions;
using Travel.Application.TourLists.Commands.CreateTourList;
using Travel.Domain.Entities;
using Xunit;

namespace Application.IntegrationTests.TourLists.Commands
{
    using static DatabaseFixture;

    [Collection("DatabaseCollection")]
    public class CreateTourListTests
    {
        public CreateTourListTests()
        {
            ResetState().GetAwaiter().GetResult();
        }

        [Fact]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateTourListCommand();

            FluentActions.Invoking(() => SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Fact]
        public void ShouldRequireAbout()
        {
            var command = new CreateTourListCommand
            {
                City = "Antananarivo",
                Country = "Madagascar",
                About = ""
            };

            FluentActions.Invoking(() => SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Fact]
        public async Task ShouldCreateTourList()
        {
            var command = new CreateTourListCommand
            {
                City = "Antananarivo",
                Country = "Madagascar",
                About = "Lorem Ipsum"
            };

            var id = await SendAsync(command);

            var list = await FindAsync<TourList>(id);

            list.Should().NotBeNull();
            list.City.Should().Be(command.City);
            list.Country.Should().Be(command.Country);
            list.About.Should().Be(command.About);
        }
    }
}