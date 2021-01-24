using Xunit;

namespace Application.IntegrationTests.TourPackages.Commands
{
    using static Testing;
    
    [Collection("Database collection")]
    public class UpdateTourPackageTests
    {
        public UpdateTourPackageTests()
        {
            ResetState().GetAwaiter().GetResult();
        }
    }
}