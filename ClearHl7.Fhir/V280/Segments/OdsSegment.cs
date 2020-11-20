using System;
using System.Collections.Generic;
using System.Linq;
using ClearHl7.Fhir.V280.Types;

namespace ClearHl7.Fhir.V280.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment ODS - Dietary Orders, Supplements, And Preferences.
    /// </summary>
    public class OdsSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "ODS";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// ODS.1 - Type.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0159</remarks>
        public string Type { get; set; }

        /// <summary>
        /// ODS.2 - Service Period.
        /// </summary>
        public IEnumerable<CodedWithExceptions> ServicePeriod { get; set; }

        /// <summary>
        /// ODS.3 - Diet, Supplement, or Preference Code.
        /// </summary>
        public IEnumerable<CodedWithExceptions> DietSupplementOrPreferenceCode { get; set; }

        /// <summary>
        /// ODS.4 - Text Instruction.
        /// </summary>
        public IEnumerable<string> TextInstruction { get; set; }
        
        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                "{0}|{1}|{2}|{3}|{4}",
                                Id,
                                Type,
                                ServicePeriod != null ? string.Join("~", ServicePeriod.Select(x => x.ToDelimitedString())) : null,
                                DietSupplementOrPreferenceCode != null ? string.Join("~", DietSupplementOrPreferenceCode.Select(x => x.ToDelimitedString())) : null,
                                TextInstruction != null ? string.Join("~", TextInstruction) : null
                                ).TrimEnd('|');
        }
    }
}