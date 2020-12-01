﻿using ClearHl7.Fhir.Helpers;
using ClearHl7.Fhir.V282.Types;

namespace ClearHl7.Fhir.V282.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment DMI - Drg Master File Information.
    /// </summary>
    public class DmiSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "DMI";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// DMI.1 - Diagnostic Related Group.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0055</remarks>
        public CodedWithNoExceptions DiagnosticRelatedGroup { get; set; }

        /// <summary>
        /// DMI.2 - Major Diagnostic Category.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0118</remarks>
        public CodedWithNoExceptions MajorDiagnosticCategory { get; set; }

        /// <summary>
        /// DMI.3 - Lower and Upper Trim Points.
        /// </summary>
        public NumericRange LowerAndUpperTrimPoints { get; set; }

        /// <summary>
        /// DMI.4 - Average Length of Stay.
        /// </summary>
        public decimal? AverageLengthOfStay { get; set; }

        /// <summary>
        /// DMI.5 - Relative Weight.
        /// </summary>
        public decimal? RelativeWeight { get; set; }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 6, Configuration.FieldSeparator),
                                Id,
                                DiagnosticRelatedGroup?.ToDelimitedString(),
                                MajorDiagnosticCategory?.ToDelimitedString(),
                                LowerAndUpperTrimPoints?.ToDelimitedString(),
                                AverageLengthOfStay.HasValue ? AverageLengthOfStay.Value.ToString(Consts.NumericFormat, culture) : null,
                                RelativeWeight.HasValue ? RelativeWeight.Value.ToString(Consts.NumericFormat, culture) : null
                                ).TrimEnd(Configuration.FieldSeparator);
        }
    }
}