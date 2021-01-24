using Xunit;

namespace Application.IntegrationTests.TourLists.Commands
{
    using static Testing;
    
    [Collection("Database collection")]
    public class UpdateTourListTests
    {
        public UpdateTourListTests()
        {
            ResetState().GetAwaiter().GetResult();
        }
    }
}