﻿using System;
using ClearHl7.Fhir.V282.Segments;
using ClearHl7.Fhir.V282.Types;
using Xunit;

namespace ClearHl7.Fhir.Tests.SegmentsTests
{
    public class BtxSegmentTests
    {
        /// <summary>
        /// Validates that ToDelimitedString() returns output with all fields populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            ISegment hl7Segment = new BtxSegment
            {
                SetIdBtx = 1,
                BcDonationId = new EntityIdentifier
                {
                    EntityId = "2"
                },
                BcComponent = new CodedWithNoExceptions
                {
                    Identifier = "3"
                },
                BcBloodGroup = new CodedWithNoExceptions
                {
                    Identifier = "4"
                },
                CpCommercialProduct = new CodedWithExceptions
                {
                    Identifier = "5"
                },
                CpManufacturer = new ExtendedCompositeNameAndIdNumberForOrganizations
                {
                    OrganizationName = "6"
                },
                CpLotNumber = new EntityIdentifier
                {
                    EntityId = "7"
                },
                BpQuantity = 8,
                BpAmount = 9,
                BpUnits = new CodedWithExceptions
                {
                    Identifier = "10"
                },
                BpTransfusionDispositionStatus = new CodedWithExceptions
                {
                    Identifier = "11"
                },
                BpMessageStatus = "12",
                BpDateTimeOfStatus = new DateTime(2020, 1, 13, 0, 0, 13),
                BpTransfusionAdministrator = new ExtendedCompositeIdNumberAndNameForPersons
                {
                    PersonIdentifier = "14"
                },
                BpTransfusionVerifier = new ExtendedCompositeIdNumberAndNameForPersons
                {
                    PersonIdentifier = "15"
                },
                BpTransfusionStartDateTimeOfStatus = new DateTime(2020, 1, 16, 0, 0, 16),
                BpTransfusionEndDateTimeOfStatus = new DateTime(2020, 1, 17, 0, 0, 17),
                BpAdverseReactionType = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "18"
                    }
                },
                BpTransfusionInterruptedReason = new CodedWithExceptions
                {
                    Identifier = "19"
                },
                BpUniqueId = new EntityIdentifier
                {
                    EntityId = "20"
                }
            };

            string expected = "BTX|1|2|3|4|5|6|7|8|9|10|11|12|20200113000013|14|15|20200116000016|20200117000017|18|19|20";
            string actual = hl7Segment.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}
