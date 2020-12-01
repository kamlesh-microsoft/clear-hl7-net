﻿using System.Collections.Generic;
using System.Linq;
using ClearHl7.Fhir.Helpers;
using ClearHl7.Fhir.V282.Types;

namespace ClearHl7.Fhir.V282.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment LCC - Location Charge Code.
    /// </summary>
    public class LccSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "LCC";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// LCC.1 - Primary Key Value - LCC.
        /// </summary>
        public PersonLocation PrimaryKeyValueLcc { get; set; }

        /// <summary>
        /// LCC.2 - Location Department.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0264</remarks>
        public CodedWithExceptions LocationDepartment { get; set; }

        /// <summary>
        /// LCC.3 - Accommodation Type.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0129</remarks>
        public IEnumerable<CodedWithExceptions> AccommodationType { get; set; }

        /// <summary>
        /// LCC.4 - Charge Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0132</remarks>
        public IEnumerable<CodedWithExceptions> ChargeCode { get; set; }
        
        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 5, Configuration.FieldSeparator),
                                Id,
                                PrimaryKeyValueLcc?.ToDelimitedString(),
                                LocationDepartment?.ToDelimitedString(),
                                AccommodationType != null ? string.Join(Configuration.FieldRepeatSeparator, AccommodationType.Select(x => x.ToDelimitedString())) : null,
                                ChargeCode != null ? string.Join(Configuration.FieldRepeatSeparator, ChargeCode.Select(x => x.ToDelimitedString())) : null
                                ).TrimEnd(Configuration.FieldSeparator);
        }
    }
}