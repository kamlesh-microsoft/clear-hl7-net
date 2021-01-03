﻿using ClearHl7.Fhir.V290.Segments;
using ClearHl7.Fhir.V290.Types;
using Xunit;

namespace ClearHl7.Fhir.Tests.SegmentsTests
{
    public class SidSegmentTests
    {
        /// <summary>
        /// Validates that ToDelimitedString() returns output with all fields populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            ISegment hl7Segment = new SidSegment
            {
                ApplicationMethodIdentifier = new CodedWithExceptions
                {
                    Identifier = "1"
                },
                SubstanceLotNumber = "2",
                SubstanceContainerIdentifier = "3",
                SubstanceManufacturerIdentifier = new CodedWithExceptions
                {
                    Identifier = "4"
                }
            };

            string expected = "SID|1|2|3|4";
            string actual = hl7Segment.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}
