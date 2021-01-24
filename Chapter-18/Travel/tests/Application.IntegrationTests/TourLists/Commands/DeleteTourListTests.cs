using Xunit;

namespace Application.IntegrationTests.TourLists.Commands
{
    using static Testing;
    
    [Collection("Database collection")]
    public class DeleteTourListTests
    {
        public DeleteTourListTests()
        {
            ResetState().GetAwaiter().GetResult();
        }
    }
}