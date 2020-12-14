﻿using System;
using ClearHl7.Fhir.V282.Segments;
using ClearHl7.Fhir.V282.Types;
using Xunit;

namespace ClearHl7.Fhir.Tests.SegmentsTests
{
    public class OrgSegmentTests
    {
        /// <summary>
        /// Validates that ToDelimitedString() returns output with all fields populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            ISegment hl7Segment = new OrgSegment
            {
                SetIdOrg = 1,
                OrganizationUnitCode = new CodedWithExceptions
                {
                    Identifier = "2"
                },
                OrganizationUnitTypeCode = new CodedWithExceptions
                {
                    Identifier = "3"
                },
                PrimaryOrgUnitIndicator = "4",
                PractitionerOrgUnitIdentifier = new ExtendedCompositeIdWithCheckDigit
                {
                    IdNumber = "5"
                },
                HealthCareProviderTypeCode = new CodedWithExceptions
                {
                    Identifier = "6"
                },
                HealthCareProviderClassificationCode = new CodedWithExceptions
                {
                    Identifier = "7"
                },
                HealthCareProviderAreaOfSpecializationCode = new CodedWithExceptions
                {
                    Identifier = "8"
                },
                EffectiveDateRange = new DateTimeRange
                {
                    RangeStartDateTime = new DateTime(2020, 9, 9, 0, 0, 9)
                },
                EmploymentStatusCode = new CodedWithExceptions
                {
                    Identifier = "10"
                },
                BoardApprovalIndicator = "11",
                PrimaryCarePhysicianIndicator = "12",
                CostCenterCode = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "13"
                    }
                }
            };

            string expected = "ORG|1|2|3|4|5|6|7|8|20200909000009|10|11|12|13";
            string actual = hl7Segment.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}