﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V240.Types;

namespace ClearHl7.V240.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment URS - R/U Where Subject Definition.
    /// </summary>
    public class UrsSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "URS";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// URS.1 - R/U Where Subject Definition.
        /// </summary>
        public IEnumerable<string> RuWhereSubjectDefinition { get; set; }

        /// <summary>
        /// URS.2 - R/U When Data Start Date/Time.
        /// </summary>
        public DateTime? RuWhenDataStartDateTime { get; set; }

        /// <summary>
        /// URS.3 - R/U When Data End Date/Time.
        /// </summary>
        public DateTime? RuWhenDataEndDateTime { get; set; }

        /// <summary>
        /// URS.4 - R/U What User Qualifier.
        /// </summary>
        public IEnumerable<string> RuWhatUserQualifier { get; set; }

        /// <summary>
        /// URS.5 - R/U Other Results Subject Definition.
        /// </summary>
        public IEnumerable<string> RuOtherResultsSubjectDefinition { get; set; }

        /// <summary>
        /// URS.6 - R/U Which Date/Time Qualifier.
        /// <para>Suggested: 0156 Which Date/Time Qualifier -&gt; ClearHl7.Codes.V240.CodeWhichDateTimeQualifier</para>
        /// </summary>
        public IEnumerable<string> RuWhichDateTimeQualifier { get; set; }

        /// <summary>
        /// URS.7 - R/U Which Date/Time Status Qualifier.
        /// <para>Suggested: 0157 Which Date/Time Status Qualifier -&gt; ClearHl7.Codes.V240.CodeWhichDateTimeStatusQualifier</para>
        /// </summary>
        public IEnumerable<string> RuWhichDateTimeStatusQualifier { get; set; }

        /// <summary>
        /// URS.8 - R/U Date/Time Selection Qualifier.
        /// <para>Suggested: 0158 Date/Time Selection Qualifier -&gt; ClearHl7.Codes.V240.CodeDateTimeSelectionQualifier</para>
        /// </summary>
        public IEnumerable<string> RuDateTimeSelectionQualifier { get; set; }

        /// <summary>
        /// URS.9 - R/U Quantity/Timing Qualifier.
        /// </summary>
        public TimingQuantity RuQuantityTimingQualifier { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <exception cref="ArgumentException">delimitedString does not begin with the proper segment Id.</exception>
        public void FromDelimitedString(string delimitedString)
        {
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(Configuration.FieldSeparator.ToCharArray());
            char[] separator = Configuration.FieldRepeatSeparator.ToCharArray();

            if (segments.Length > 0)
            {
                if (string.Compare(Id, segments.First(), true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ Configuration.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            RuWhereSubjectDefinition = segments.Length > 1 ? segments.ElementAtOrDefault(1).Split(separator) : null;
            RuWhenDataStartDateTime = segments.ElementAtOrDefault(2)?.ToNullableDateTime();
            RuWhenDataEndDateTime = segments.ElementAtOrDefault(3)?.ToNullableDateTime();
            RuWhatUserQualifier = segments.Length > 4 ? segments.ElementAtOrDefault(4).Split(separator) : null;
            RuOtherResultsSubjectDefinition = segments.Length > 5 ? segments.ElementAtOrDefault(5).Split(separator) : null;
            RuWhichDateTimeQualifier = segments.Length > 6 ? segments.ElementAtOrDefault(6).Split(separator) : null;
            RuWhichDateTimeStatusQualifier = segments.Length > 7 ? segments.ElementAtOrDefault(7).Split(separator) : null;
            RuDateTimeSelectionQualifier = segments.Length > 8 ? segments.ElementAtOrDefault(8).Split(separator) : null;
            RuQuantityTimingQualifier = segments.Length > 9 ? TypeHelper.Deserialize<TimingQuantity>(segments.ElementAtOrDefault(9), false) : null;
        }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 10, Configuration.FieldSeparator),
                                Id,
                                RuWhereSubjectDefinition != null ? string.Join(Configuration.FieldRepeatSeparator, RuWhereSubjectDefinition) : null,
                                RuWhenDataStartDateTime.HasValue ? RuWhenDataStartDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                RuWhenDataEndDateTime.HasValue ? RuWhenDataEndDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                RuWhatUserQualifier != null ? string.Join(Configuration.FieldRepeatSeparator, RuWhatUserQualifier) : null,
                                RuOtherResultsSubjectDefinition != null ? string.Join(Configuration.FieldRepeatSeparator, RuOtherResultsSubjectDefinition) : null,
                                RuWhichDateTimeQualifier != null ? string.Join(Configuration.FieldRepeatSeparator, RuWhichDateTimeQualifier) : null,
                                RuWhichDateTimeStatusQualifier != null ? string.Join(Configuration.FieldRepeatSeparator, RuWhichDateTimeStatusQualifier) : null,
                                RuDateTimeSelectionQualifier != null ? string.Join(Configuration.FieldRepeatSeparator, RuDateTimeSelectionQualifier) : null,
                                RuQuantityTimingQualifier?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}