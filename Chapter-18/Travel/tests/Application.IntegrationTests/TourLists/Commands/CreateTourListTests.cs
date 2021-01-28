using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
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
        public void Should_Require_Minimum_Fields()
        {
            var command = new CreateTourListCommand();

            FluentActions.Invoking(() => SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Fact]
        public void Should_Require_About()
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
        public async Task Should_Create_TourList()
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