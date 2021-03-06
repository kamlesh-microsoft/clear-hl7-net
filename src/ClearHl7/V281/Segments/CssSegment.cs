using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V281.Types;

namespace ClearHl7.V281.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment CSS - Clinical Study Data Schedule Segment.
    /// </summary>
    public class CssSegment : ISegment
    {
        /// <inheritdoc/>
        public string Id { get; } = "CSS";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// CSS.1 - Study Scheduled Time Point.
        /// </summary>
        public CodedWithExceptions StudyScheduledTimePoint { get; set; }

        /// <summary>
        /// CSS.2 - Study Scheduled Patient Time Point.
        /// </summary>
        public DateTime? StudyScheduledPatientTimePoint { get; set; }

        /// <summary>
        /// CSS.3 - Study Quality Control Codes.
        /// </summary>
        public IEnumerable<CodedWithExceptions> StudyQualityControlCodes { get; set; }

        /// <inheritdoc/>
        public void FromDelimitedString(string delimitedString)
        {
            FromDelimitedString(delimitedString, null);
        }

        /// <inheritdoc/>
        public void FromDelimitedString(string delimitedString, Separators separators)
        {
            Separators seps = separators ?? new Separators().UsingConfigurationValues();
            string[] segments = delimitedString == null
                ? Array.Empty<string>()
                : delimitedString.Split(seps.FieldSeparator, StringSplitOptions.None);

            if (segments.Length > 0)
            {
                if (string.Compare(Id, segments[0], true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ seps.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            StudyScheduledTimePoint = segments.Length > 1 && segments[1].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[1], false, seps) : null;
            StudyScheduledPatientTimePoint = segments.Length > 2 && segments[2].Length > 0 ? segments[2].ToNullableDateTime() : null;
            StudyQualityControlCodes = segments.Length > 3 && segments[3].Length > 0 ? segments[3].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<CodedWithExceptions>(x, false, seps)) : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 4, Configuration.FieldSeparator),
                                Id,
                                StudyScheduledTimePoint?.ToDelimitedString(),
                                StudyScheduledPatientTimePoint.HasValue ? StudyScheduledPatientTimePoint.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                StudyQualityControlCodes != null ? string.Join(Configuration.FieldRepeatSeparator, StudyQualityControlCodes.Select(x => x.ToDelimitedString())) : null
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}
