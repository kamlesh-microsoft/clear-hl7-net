﻿using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;

namespace ClearHl7.V290.Types
{
    /// <summary>
    /// HL7 Version 2 ERL - Message Location.
    /// </summary>
    public class MessageLocation : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// ERL.1 - Segment ID.
        /// </summary>
        public string SegmentId { get; set; }

        /// <summary>
        /// ERL.2 - Segment Sequence.
        /// </summary>
        public uint? SegmentSequence { get; set; }

        /// <summary>
        /// ERL.3 - Field Position.
        /// </summary>
        public uint? FieldPosition { get; set; }

        /// <summary>
        /// ERL.4 - Field Repetition.
        /// </summary>
        public uint? FieldRepetition { get; set; }

        /// <summary>
        /// ERL.5 - Component Number.
        /// </summary>
        public uint? ComponentNumber { get; set; }

        /// <summary>
        /// ERL.6 - Sub-Component Number.
        /// </summary>
        public uint? SubComponentNumber { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public MessageLocation FromDelimitedString(string delimitedString)
        {
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(separator.ToCharArray());

            SegmentId = segments.ElementAtOrDefault(0);
            SegmentSequence = segments.ElementAtOrDefault(1)?.ToNullableUInt();
            FieldPosition = segments.ElementAtOrDefault(2)?.ToNullableUInt();
            FieldRepetition = segments.ElementAtOrDefault(3)?.ToNullableUInt();
            ComponentNumber = segments.ElementAtOrDefault(4)?.ToNullableUInt();
            SubComponentNumber = segments.ElementAtOrDefault(5)?.ToNullableUInt();

            return this;
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
                                StringHelper.StringFormatSequence(0, 6, separator),
                                SegmentId,
                                SegmentSequence.HasValue ? SegmentSequence.Value.ToString(culture) : null,
                                FieldPosition.HasValue ? FieldPosition.Value.ToString(culture) : null,
                                FieldRepetition.HasValue ? FieldRepetition.Value.ToString(culture) : null,
                                ComponentNumber.HasValue ? ComponentNumber.Value.ToString(culture) : null,
                                SubComponentNumber.HasValue ? SubComponentNumber.Value.ToString(culture) : null
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
