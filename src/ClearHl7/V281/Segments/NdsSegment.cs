﻿using System;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V281.Types;

namespace ClearHl7.V281.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment NDS - Notification Detail.
    /// </summary>
    public class NdsSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "NDS";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// NDS.1 - Notification Reference Number.
        /// </summary>
        public decimal? NotificationReferenceNumber { get; set; }

        /// <summary>
        /// NDS.2 - Notification Date/Time.
        /// </summary>
        public DateTime? NotificationDateTime { get; set; }

        /// <summary>
        /// NDS.3 - Notification Alert Severity.
        /// <para>Suggested: 0367 Alert Level -&gt; ClearHl7.Codes.V281.CodeAlertLevel</para>
        /// </summary>
        public CodedWithExceptions NotificationAlertSeverity { get; set; }

        /// <summary>
        /// NDS.4 - Notification Code.
        /// </summary>
        public CodedWithExceptions NotificationCode { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.  Separators defined in the Configuration class are used to split the string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <exception cref="ArgumentException">delimitedString does not begin with the proper segment Id.</exception>
        public void FromDelimitedString(string delimitedString)
        {
            FromDelimitedString(delimitedString, null);
        }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.  The provided separators are used to split the string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <param name="separators">The separators to use for splitting the string.</param>
        /// <exception cref="ArgumentException">delimitedString does not begin with the proper segment Id.</exception>
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

            NotificationReferenceNumber = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableDecimal() : null;
            NotificationDateTime = segments.Length > 2 && segments[2].Length > 0 ? segments[2].ToNullableDateTime() : null;
            NotificationAlertSeverity = segments.Length > 3 && segments[3].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[3], false, seps) : null;
            NotificationCode = segments.Length > 4 && segments[4].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[4], false, seps) : null;
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
                                StringHelper.StringFormatSequence(0, 5, Configuration.FieldSeparator),
                                Id,
                                NotificationReferenceNumber.HasValue ? NotificationReferenceNumber.Value.ToString(Consts.NumericFormat, culture) : null,
                                NotificationDateTime.HasValue ? NotificationDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                NotificationAlertSeverity?.ToDelimitedString(),
                                NotificationCode?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}