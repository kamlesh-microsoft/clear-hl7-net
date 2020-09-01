using System;
using System.Collections.Generic;
using System.Linq;
using ClearHl7.Fhir.V282.Types;

namespace ClearHl7.Fhir.V282.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment LRL - Location Relationship.
    /// </summary>
    public class LrlSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "LRL";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// LRL.1 - Primary Key Value - LRL.
        /// </summary>
        public PersonLocation PrimaryKeyValueLrl { get; set; }

        /// <summary>
        /// LRL.2 - Segment Action Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0206</remarks>
        public string SegmentActionCode { get; set; }

        /// <summary>
        /// LRL.3 - Segment Unique Key.
        /// </summary>
        public EntityIdentifier SegmentUniqueKey { get; set; }

        /// <summary>
        /// LRL.4 - Location Relationship ID.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0325</remarks>
        public CodedWithExceptions LocationRelationshipId { get; set; }

        /// <summary>
        /// LRL.5 - Organizational Location Relationship Value.
        /// </summary>
        public IEnumerable<ExtendedCompositeNameAndIdNumberForOrganizations> OrganizationalLocationRelationshipValue { get; set; }

        /// <summary>
        /// LRL.6 - Patient Location Relationship Value.
        /// </summary>
        public PersonLocation PatientLocationRelationshipValue { get; set; }
        
        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                "{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                                Id,
                                PrimaryKeyValueLrl?.ToDelimitedString(),
                                SegmentActionCode,
                                SegmentUniqueKey?.ToDelimitedString(),
                                LocationRelationshipId?.ToDelimitedString(),
                                OrganizationalLocationRelationshipValue != null ? string.Join("~", OrganizationalLocationRelationshipValue.Select(x => x.ToDelimitedString())) : null,
                                PatientLocationRelationshipValue?.ToDelimitedString()
                                ).TrimEnd('|');
        }
    }
}