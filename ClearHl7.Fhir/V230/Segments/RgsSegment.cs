﻿using ClearHl7.Fhir.Helpers;
using ClearHl7.Fhir.V230.Types;

namespace ClearHl7.Fhir.V230.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment RGS - Resource Group.
    /// </summary>
    public class RgsSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "RGS";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// RGS.1 - Set ID - RGS.
        /// </summary>
        public uint? SetIdRgs { get; set; }

        /// <summary>
        /// RGS.2 - Segment Action Code.
        /// </summary>
        public string SegmentActionCode { get; set; }

        /// <summary>
        /// RGS.3 - Resource Group ID.
        /// </summary>
        public CodedElement ResourceGroupId { get; set; }
        
        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 4, Configuration.FieldSeparator),
                                Id,
                                SetIdRgs.HasValue ? SetIdRgs.Value.ToString(culture) : null,
                                SegmentActionCode,
                                ResourceGroupId?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator);
        }
    }
}