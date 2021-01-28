using System;
using AutoMapper;
using Travel.Application.Common.Mappings;
using Travel.Application.Dtos.Tour;
using Travel.Domain.Entities;
using Xunit;

namespace Application.UnitTests.Common.Mappings
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        /// <summary>
        /// Should have valid mapper configurations.
        /// </summary>
        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
        
        [Theory]
        [InlineData(typeof(TourList), typeof(TourListDto))]
        [InlineData(typeof(TourPackage), typeof(TourPackageDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}