using Xunit;

namespace Application.IntegrationTests.TourPackages.Commands
{
    using static Testing;
    
    [Collection("Database collection")]
    public class CreateTourPackageTests
    {
        public CreateTourPackageTests()
        {
            ResetState().GetAwaiter().GetResult();
        }
    }
}