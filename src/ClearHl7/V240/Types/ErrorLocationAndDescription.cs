﻿using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;

namespace ClearHl7.V240.Types
{
    /// <summary>
    /// HL7 Version 2 ELD - Error Location And Description.
    /// </summary>
    public class ErrorLocationAndDescription : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// ELD.1 - Segment ID.
        /// </summary>
        public string SegmentId { get; set; }

        /// <summary>
        /// ELD.2 - Segment Sequence.
        /// </summary>
        public decimal? SegmentSequence { get; set; }

        /// <summary>
        /// ELD.3 - Field Position.
        /// </summary>
        public decimal? FieldPosition { get; set; }

        /// <summary>
        /// ELD.4 - Code Identifying Error.
        /// </summary>
        public CodedElement CodeIdentifyingError { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        public void FromDelimitedString(string delimitedString)
        {
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(separator.ToCharArray());

            SegmentId = segments.ElementAtOrDefault(0);
            SegmentSequence = segments.ElementAtOrDefault(1)?.ToNullableDecimal();
            FieldPosition = segments.ElementAtOrDefault(2)?.ToNullableDecimal();

            if (segments.Length > 3)
            {
                CodeIdentifyingError = new CodedElement { IsSubcomponent = true };
                CodeIdentifyingError.FromDelimitedString(segments.ElementAtOrDefault(3));
            }
            else
            {
                CodeIdentifyingError = null;
            }
        }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 4, separator),
                                SegmentId,
                                SegmentSequence.HasValue ? SegmentSequence.Value.ToString(Consts.NumericFormat, culture) : null,
                                FieldPosition.HasValue ? FieldPosition.Value.ToString(Consts.NumericFormat, culture) : null,
                                CodeIdentifyingError?.ToDelimitedString()
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
