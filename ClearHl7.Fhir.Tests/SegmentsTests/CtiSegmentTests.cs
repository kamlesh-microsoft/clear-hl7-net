﻿using ClearHl7.Fhir.V282.Segments;
using ClearHl7.Fhir.V282.Types;
using Xunit;

namespace ClearHl7.Fhir.Tests.SegmentsTests
{
    public class CtiSegmentTests
    {
        /// <summary>
        /// Validates that ToDelimitedString() returns output with all fields populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            ISegment hl7Segment = new CtiSegment
            {
                SponsorStudyId = new EntityIdentifier
                {
                    EntityId = "1"
                },
                StudyPhaseIdentifier = new CodedWithExceptions
                {
                    Identifier = "2"
                },
                StudyScheduledTimePoint = new CodedWithExceptions
                {
                    Identifier = "3"
                }
            };

            string expected = "CTI|1|2|3";
            string actual = hl7Segment.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}
