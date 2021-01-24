using Xunit;

namespace Application.IntegrationTests.TourLists.Commands
{
    using static Testing;
    
    [Collection("Database collection")]
    public class CreateTourListTests
    {
        public CreateTourListTests()
        {
            ResetState().GetAwaiter().GetResult();
        }
    }
}