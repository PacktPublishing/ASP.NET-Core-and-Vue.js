using Xunit;

namespace Application.IntegrationTests.TourPackages.Commands
{
    using static Testing;
    
    [Collection("Database collection")]
    public class UpdateTourPackageDetailTests
    {
        public UpdateTourPackageDetailTests()
        {
            ResetState().GetAwaiter().GetResult();
        }
    }
}