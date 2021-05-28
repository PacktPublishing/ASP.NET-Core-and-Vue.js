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
        public void DefaultConstructorCreatesAnEmptyErrorDictionary()
        {
            var actual = new ValidationException().Errors;

            actual.Keys.Should().BeEquivalentTo(Array.Empty<string>());
        }
        
        [Fact]
        public void SingleValidationFailureCreatesASingleElementErrorDictionary()
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