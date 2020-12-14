﻿using System;
using ClearHl7.Fhir.V282.Segments;
using ClearHl7.Fhir.V282.Types;
using Xunit;

namespace ClearHl7.Fhir.Tests.SegmentsTests
{
    public class NteSegmentTests
    {
        /// <summary>
        /// Validates that ToDelimitedString() returns output with all fields populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            ISegment hl7Segment = new NteSegment
            {
                SetIdNte = 1,
                SourceOfComment = "2",
                Comment = new string[]
                {
                    "3"
                },
                CommentType = new CodedWithExceptions
                {
                    Identifier = "4"
                },
                EnteredBy = new ExtendedCompositeIdNumberAndNameForPersons
                {
                    PersonIdentifier = "5"
                },
                EnteredDateTime = new DateTime(2020, 6, 6, 0, 0, 6),
                EffectiveStartDate = new DateTime(2020, 7, 7, 0, 0, 7),
                ExpirationDate = new DateTime(2020, 8, 8, 0, 0, 8)
            };

            string expected = "NTE|1|2|3|4|5|20200606000006|20200707000007|20200808000008";
            string actual = hl7Segment.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}