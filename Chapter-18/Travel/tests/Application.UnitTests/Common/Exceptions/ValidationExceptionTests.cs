using System;
using System.Collections.Generic;
using FluentAssertions;
using FluentValidation.Results;
using Travel.Application.Common.Exceptions;
using Xunit;

namespace Application.UnitTests.Common.Exceptions
{
    public class ValidationExceptionTests
    {
        [Fact]
        public void Default_Constructor_Creates_An_Empty_Error_Dictionary()
        {
            var actual = new ValidationException().Errors;

            actual.Keys.Should().BeEquivalentTo(Array.Empty<string>());
        }
        
        [Fact]
        public void Single_Validation_Failure_Creates_A_Single_Element_Error_Dictionary()
        {
            var failures = new List<ValidationFailure>
            {
                new ("Mobile", "Mobile is required.")
            };

            var actual = new ValidationException(failures).Errors;

            actual.Keys.Should().BeEquivalentTo("Mobile");
            actual["Mobile"].Should().BeEquivalentTo("Mobile is required.");
        }
    }
}