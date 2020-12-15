﻿using System;
using ClearHl7.Fhir.V282.Segments;
using ClearHl7.Fhir.V282.Types;
using Xunit;

namespace ClearHl7.Fhir.Tests.SegmentsTests
{
    public class PslSegmentTests
    {
        /// <summary>
        /// Validates that ToDelimitedString() returns output with all fields populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            ISegment hl7Segment = new PslSegment
            {
                ProviderProductServiceLineItemNumber = new EntityIdentifier
                {
                    EntityId = "1"
                },
                PayerProductServiceLineItemNumber = new EntityIdentifier
                {
                    EntityId = "2"
                },
                ProductServiceLineItemSequenceNumber = 3,
                ProviderTrackingId = new EntityIdentifier
                {
                    EntityId = "4"
                },
                PayerTrackingId = new EntityIdentifier
                {
                    EntityId = "5"
                },
                ProductServiceLineItemStatus = new CodedWithExceptions
                {
                    Identifier = "6"
                },
                ProductServiceCode = new CodedWithExceptions
                {
                    Identifier = "7"
                },
                ProductServiceCodeModifier = new CodedWithExceptions
                {
                    Identifier = "8"
                },
                ProductServiceCodeDescription = "9",
                ProductServiceEffectiveDate = new DateTime(2020, 10, 10, 0, 0, 10),
                ProductServiceExpirationDate = new DateTime(2020, 11, 11, 0, 0, 11),
                ProductServiceQuantity = new CompositeQuantityWithUnits
                {
                    Quantity = 12
                },
                ProductServiceUnitCost = new CompositePrice
                {
                    Price = new Money
                    {
                        Quantity = 13
                    }
                },
                NumberOfItemsPerUnit = 14,
                ProductServiceGrossAmount = new CompositePrice
                {
                    Price = new Money
                    {
                        Quantity = 15
                    }
                },
                ProductServiceBilledAmount = new CompositePrice
                {
                    Price = new Money
                    {
                        Quantity = 16
                    }
                },
                ProductServiceClarificationCodeType = new CodedWithExceptions
                {
                    Identifier = "17"
                },
                ProductServiceClarificationCodeValue = "18",
                HealthDocumentReferenceIdentifier = new EntityIdentifier
                {
                    EntityId = "19"
                },
                ProcessingConsiderationCode = new CodedWithExceptions
                {
                    Identifier = "20"
                },
                RestrictedDisclosureIndicator = "21",
                RelatedProductServiceCodeIndicator = new CodedWithExceptions
                {
                    Identifier = "22"
                },
                ProductServiceAmountForPhysician = new CompositePrice
                {
                    Price = new Money
                    {
                        Quantity = 23
                    }
                },
                ProductServiceCostFactor = 24,
                CostCenter = new ExtendedCompositeIdWithCheckDigit
                {
                    IdNumber = "25"
                },
                BillingPeriod = new DateTimeRange
                {
                    RangeStartDateTime = new DateTime(2020, 1, 26, 0, 0, 26)
                },
                DaysWithoutBilling = 27,
                SessionNo = 28,
                ExecutingPhysicianId = new ExtendedCompositeIdNumberAndNameForPersons
                {
                    PersonIdentifier = "29"
                },
                ResponsiblePhysicianId = new ExtendedCompositeIdNumberAndNameForPersons
                {
                    PersonIdentifier = "30"
                },
                RoleExecutingPhysician = new CodedWithExceptions
                {
                    Identifier = "31"
                },
                MedicalRoleExecutingPhysician = new CodedWithExceptions
                {
                    Identifier = "32"
                },
                SideOfBody = new CodedWithExceptions
                {
                    Identifier = "33"
                },
                NumberOfTpsPp = 34,
                TpValuePp = new CompositePrice
                {
                    Price = new Money
                    {
                        Quantity = 35
                    }
                },
                InternalScalingFactorPp = 36,
                ExternalScalingFactorPp = 37,
                AmountPp = new CompositePrice
                {
                    Price = new Money
                    {
                        Quantity = 38
                    }
                },
                NumberOfTpsTechnicalPart = 39,
                TpValueTechnicalPart = new CompositePrice
                {
                    Price = new Money
                    {
                        Quantity = 40
                    }
                },
                InternalScalingFactorTechnicalPart = 41,
                ExternalScalingFactorTechnicalPart = 42,
                AmountTechnicalPart = new CompositePrice
                {
                    Price = new Money
                    {
                        Quantity = 43
                    }
                },
                TotalAmountProfessionalPartTechnicalPart = new CompositePrice
                {
                    Price = new Money
                    {
                        Quantity = 44
                    }
                },
                VatRate = 45,
                MainService = "46",
                Validation = "47",
                Comment = "48"
            };

            string expected = "PSL|1|2|3|4|5|6|7|8|9|20201010000010|20201111000011|12|13|14|15|16|17|18|19|20|21|22|23|24|25|20200126000026|27|28|29|30|31|32|33|34|35|36|37|38|39|40|41|42|43|44|45|46|47|48";
            string actual = hl7Segment.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}
