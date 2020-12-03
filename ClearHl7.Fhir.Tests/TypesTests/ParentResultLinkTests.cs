﻿using ClearHl7.Fhir.V282.Types;
using Xunit;

namespace ClearHl7.Fhir.Tests.TypesTests
{
    public class ParentResultLinkTests
    {
        /// <summary>
        /// Validates that ToDelimitedString() returns output with all fields populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            IType hl7Type = new ParentResultLink
            {
                ParentObservationIdentifier = new CodedWithExceptions
                {
                    Identifier = "1"
                },
                ParentObservationSubIdentifier = new ObservationGrouper
                {
                    OriginalSubIdentifier = "2"
                },
                ParentObservationValueDescriptor = new Text
                {
                    Value = "3"
                }
            };

            string expected = "1^2^3";
            string actual = hl7Type.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}