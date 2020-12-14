﻿using System;
using ClearHl7.Fhir.V282.Segments;
using ClearHl7.Fhir.V282.Types;
using Xunit;

namespace ClearHl7.Fhir.Tests.SegmentsTests
{
    public class SpmSegmentTests
    {
        /// <summary>
        /// Validates that ToDelimitedString() returns output with all fields populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            ISegment hl7Segment = new SpmSegment
            {
                SetIdSpm = 1,
                SpecimenId = new EntityIdentifierPair
                {
                    PlacerAssignedIdentifier = new EntityIdentifier
                    {
                        EntityId = "2"
                    }
                },
                SpecimenParentIds = new EntityIdentifierPair[]
                {
                    new EntityIdentifierPair
                    {
                        PlacerAssignedIdentifier = new EntityIdentifier
                        {
                            EntityId = "3"
                        }
                    }
                },
                SpecimenType = new CodedWithExceptions
                {
                    Identifier = "4"
                },
                SpecimenTypeModifier = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "5"
                    }
                },
                SpecimenAdditives = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "6"
                    }
                },
                SpecimenCollectionMethod = new CodedWithExceptions
                {
                    Identifier = "7"
                },
                SpecimenSourceSite = new CodedWithExceptions
                {
                    Identifier = "8"
                },
                SpecimenSourceSiteModifier = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "9"
                    }
                },
                SpecimenCollectionSite = new CodedWithExceptions
                {
                    Identifier = "10"
                },
                SpecimenRole = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "11"
                    }
                },
                SpecimenCollectionAmount = new CompositeQuantityWithUnits
                {
                    Quantity = 12
                },
                GroupedSpecimenCount = 13,
                SpecimenDescription = new string[]
                {
                    "14"
                },
                SpecimenHandlingCode = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "15"
                    }
                },
                SpecimenRiskCode = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "16"
                    }
                },
                SpecimenCollectionDateTime = new DateTimeRange
                {
                    RangeStartDateTime = new DateTime(2020, 1, 17, 0, 0, 17)
                },
                SpecimenReceivedDateTime = new DateTime(2020, 1, 18, 0, 0, 18),
                SpecimenExpirationDateTime = new DateTime(2020, 1, 19, 0, 0, 19),
                SpecimenAvailability = "20",
                SpecimenRejectReason = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "21"
                    }
                },
                SpecimenQuality = new CodedWithExceptions
                {
                    Identifier = "22"
                },
                SpecimenAppropriateness = new CodedWithExceptions
                {
                    Identifier = "23"
                },
                SpecimenCondition = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "24"
                    }
                },
                SpecimenCurrentQuantity = new CompositeQuantityWithUnits
                {
                    Quantity = 25
                },
                NumberOfSpecimenContainers = 26,
                ContainerType = new CodedWithExceptions
                {
                    Identifier = "27"
                },
                ContainerCondition = new CodedWithExceptions
                {
                    Identifier = "28"
                },
                SpecimenChildRole = new CodedWithExceptions
                {
                    Identifier = "29"
                },
                AccessionId = new ExtendedCompositeIdWithCheckDigit[]
                {
                    new ExtendedCompositeIdWithCheckDigit
                    {
                        IdNumber = "30"
                    }
                },
                OtherSpecimenId = new ExtendedCompositeIdWithCheckDigit[]
                {
                    new ExtendedCompositeIdWithCheckDigit
                    {
                        IdNumber = "31"
                    }
                },
                ShipmentId = new EntityIdentifier
                {
                    EntityId = "32"
                }
            };

            string expected = "SPM|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|20200117000017|20200118000018|20200119000019|20|21|22|23|24|25|26|27|28|29|30|31|32";
            string actual = hl7Segment.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}