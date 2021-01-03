﻿using ClearHl7.Fhir.V290.Segments;
using Xunit;

namespace ClearHl7.Fhir.Tests.SegmentsTests
{
    public class FtsSegmentTests
    {
        /// <summary>
        /// Validates that ToDelimitedString() returns output with all fields populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            ISegment hl7Segment = new FtsSegment
            {
                FileBatchCount = 1,
                FileTrailerComment = "2"
            };

            string expected = "FTS|1|2";
            string actual = hl7Segment.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}
