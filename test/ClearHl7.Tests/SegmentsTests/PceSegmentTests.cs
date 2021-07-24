﻿using ClearHl7.V290.Segments;
using ClearHl7.V290.Types;
using FluentAssertions;
using Xunit;

namespace ClearHl7.Tests.SegmentsTests
{
    public class PceSegmentTests
    {
        /// <summary>
        /// Validates that FromDelimitedString() returns the object instance with all properties correctly initialized.
        /// </summary>
        [Fact]
        public void FromDelimitedString_WithAllProperties_ReturnsCorrectlyInitializedFields()
        {
            ISegment expected = new PceSegment
            {
                SetIdPce = 1,
                CostCenterAccountNumber = new ExtendedCompositeIdWithCheckDigit
                {
                    IdNumber = "2"
                },
                TransactionCode = new CodedWithExceptions
                {
                    Identifier = "3"
                },
                TransactionAmountUnit = new CompositePrice
                {
                    Price = new Money
                    {
                        Quantity = 4
                    }
                }
            };

            ISegment actual = new PceSegment();
            actual.FromDelimitedString("PCE|1|2|3|4");

            expected.Should().BeEquivalentTo(actual);
        }

        /// <summary>
        /// Validates that ToDelimitedString() returns output with all properties populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            ISegment hl7Segment = new PceSegment
            {
                SetIdPce = 1,
                CostCenterAccountNumber = new ExtendedCompositeIdWithCheckDigit
                {
                    IdNumber = "2"
                },
                TransactionCode = new CodedWithExceptions
                {
                    Identifier = "3"
                },
                TransactionAmountUnit = new CompositePrice
                {
                    Price = new Money
                    {
                        Quantity = 4
                    }
                }
            };

            string expected = "PCE|1|2|3|4";
            string actual = hl7Segment.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}
