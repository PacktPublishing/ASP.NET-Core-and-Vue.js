using Xunit;

namespace Application.IntegrationTests.TourPackages.Commands
{
    using static Testing;
    
    [Collection("Database collection")]
    public class DeleteTourPackageTests
    {
        public DeleteTourPackageTests()
        {
            ResetState().GetAwaiter().GetResult();
        }
    }
}