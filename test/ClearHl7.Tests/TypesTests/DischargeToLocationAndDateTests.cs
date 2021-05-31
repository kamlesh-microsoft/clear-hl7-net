﻿using System;
using ClearHl7.V290.Types;
using FluentAssertions;
using Xunit;

namespace ClearHl7.Tests.TypesTests
{
    public class DischargeToLocationAndDateTests
    {
        /// <summary>
        /// Validates that FromDelimitedString() returns the object instance with all properties correctly initialized.
        /// </summary>
        [Fact]
        public void FromDelimitedString_WithAllProperties_ReturnsCorrectlyInitializedFields()
        {
            DischargeToLocationAndDate expected = new()
            {
                DischargeToLocation = new CodedWithExceptions
                {
                    Identifier = "1"
                },
                EffectiveDate = new DateTime(2020, 2, 2, 0, 0, 2)
            };
            DischargeToLocationAndDate actual = new DischargeToLocationAndDate().FromDelimitedString("1^20200202000002");

            expected.Should().BeEquivalentTo(actual);
        }

        /// <summary>
        /// Validates that ToDelimitedString() returns output with all properties populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            IType hl7Type = new DischargeToLocationAndDate
            {
                DischargeToLocation = new CodedWithExceptions
                {
                    Identifier = "1"
                },
                EffectiveDate = new DateTime(2020, 2, 2, 0, 0, 2)
            };

            string expected = "1^20200202000002";
            string actual = hl7Type.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}
