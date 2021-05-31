﻿using System;
using ClearHl7.V290.Types;
using FluentAssertions;
using Xunit;

namespace ClearHl7.Tests.TypesTests
{
    public class CodedWithNoExceptionsTests
    {
        /// <summary>
        /// Validates that FromDelimitedString() returns the object instance with all properties correctly initialized.
        /// </summary>
        [Fact]
        public void FromDelimitedString_WithAllProperties_ReturnsCorrectlyInitializedFields()
        {
            CodedWithNoExceptions expected = new()
            {
                Identifier = "1",
                Text = "2",
                NameOfCodingSystem = "3",
                AlternateIdentifier = "4",
                AlternateText = "5",
                NameOfAlternateCodingSystem = "6",
                CodingSystemVersionId = "7",
                AlternateCodingSystemVersionId = "8",
                OriginalText = "9",
                SecondAlternateIdentifier = "10",
                SecondAlternateText = "11",
                NameOfSecondAlternateCodingSystem = "12",
                SecondAlternateCodingSystemVersionId = "13",
                CodingSystemOid = "14",
                ValueSetOid = "15",
                ValueSetVersionId = new DateTime(2020, 1, 16),
                AlternateCodingSystemOid = "17",
                AlternateValueSetOid = "18",
                AlternateValueSetVersionId = new DateTime(2020, 1, 19),
                SecondAlternateCodingSystemOid = "20",
                SecondAlternateValueSetOid = "21",
                SecondAlternateValueSetVersionId = new DateTime(2020, 1, 22)
            };
            CodedWithNoExceptions actual = new CodedWithNoExceptions().FromDelimitedString("1^2^3^4^5^6^7^8^9^10^11^12^13^14^15^20200116^17^18^20200119^20^21^20200122");

            expected.Should().BeEquivalentTo(actual);
        }

        /// <summary>
        /// Validates that ToDelimitedString() returns output with all properties populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            IType hl7Type = new CodedWithNoExceptions
            {
                Identifier = "1",
                Text = "2",
                NameOfCodingSystem = "3",
                AlternateIdentifier = "4",
                AlternateText = "5",
                NameOfAlternateCodingSystem = "6",
                CodingSystemVersionId = "7",
                AlternateCodingSystemVersionId = "8",
                OriginalText = "9",
                SecondAlternateIdentifier = "10",
                SecondAlternateText = "11",
                NameOfSecondAlternateCodingSystem = "12",
                SecondAlternateCodingSystemVersionId = "13",
                CodingSystemOid = "14",
                ValueSetOid = "15",
                ValueSetVersionId = new DateTime(2020, 1, 16),
                AlternateCodingSystemOid = "17",
                AlternateValueSetOid = "18",
                AlternateValueSetVersionId = new DateTime(2020, 1, 19),
                SecondAlternateCodingSystemOid = "20",
                SecondAlternateValueSetOid = "21",
                SecondAlternateValueSetVersionId = new DateTime(2020, 1, 22)
            };

            string expected = "1^2^3^4^5^6^7^8^9^10^11^12^13^14^15^20200116^17^18^20200119^20^21^20200122";
            string actual = hl7Type.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}
