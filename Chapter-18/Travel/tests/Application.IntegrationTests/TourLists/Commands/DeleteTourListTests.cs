using System.Threading.Tasks;
using FluentAssertions;
using Travel.Application.Common.Exceptions;
using Travel.Application.TourLists.Commands.CreateTourList;
using Travel.Application.TourLists.Commands.DeleteTourList;
using Travel.Domain.Entities;
using Xunit;

namespace Application.IntegrationTests.TourLists.Commands
{
    using static DatabaseFixture;

    [Collection("DatabaseCollection")]
    public class DeleteTourListTests
    {
        public DeleteTourListTests()
        {
            ResetState().GetAwaiter().GetResult();
        }

        [Fact]
        public void Should_Require_Valid_TourList_Id()
        {
            var command = new DeleteTourListCommand
            {
                Id = 33
            };

            FluentActions.Invoking(() => SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Fact]
        public async Task Should_Delete_TourList()
        {
            var listId = await SendAsync(new CreateTourListCommand
            {
                City = "Beirut",
                Country = "Lebanon",
                About = "Lorem Ipsum"
            });

            await SendAsync(new DeleteTourListCommand
            {
                Id = listId
            });

            var list = await FindAsync<TourList>(listId);

            list.Should().BeNull();
        }
    }
}