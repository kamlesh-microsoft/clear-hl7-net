﻿using System;
using ClearHl7.V260.Types;
using Xunit;

namespace ClearHl7.Tests.TypesTests
{
    public class TimingQuantityTests
    {
        /// <summary>
        /// Validates that ToDelimitedString() returns output with all fields populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            IType hl7Type = new TimingQuantity
            {
                Quantity = new CompositeQuantityWithUnits
                {
                    Quantity = 1
                },
                Interval = new RepeatInterval
                {
                    RepeatPattern = new CodedWithExceptions
                    {
                        Identifier = "2"
                    }
                },
                Duration = "3",
                StartDateTime = new DateTime(2020, 4, 4, 0, 0, 4),
                EndDateTime = new DateTime(2020, 5, 5, 0, 0, 5),
                Priority = "6",
                Condition = "7",
                Text = new Text
                {
                    Value = "8"
                },
                Conjunction = "9",
                OrderSequencing = new OrderSequenceDefinition
                {
                    SequenceResultsFlag = "10"
                },
                OccurrenceDuration = new CodedWithExceptions
                {
                    Identifier = "11"
                },
                TotalOccurrences = 12
            };

            string expected = "1^2^3^20200404000004^20200505000005^6^7^8^9^10^11^12";
            string actual = hl7Type.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}
