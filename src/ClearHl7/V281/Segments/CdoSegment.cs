﻿using System;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V281.Types;

namespace ClearHl7.V281.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment CDO - Cumulative Dosage.
    /// </summary>
    public class CdoSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "CDO";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// CDO.1 - Set ID - CDO.
        /// </summary>
        public uint? SetIdCdo { get; set; }

        /// <summary>
        /// CDO.2 - Action Code.
        /// <para>Suggested: 0206 Segment Action Code -&gt; ClearHl7.Codes.V281.CodeSegmentActionCode</para>
        /// </summary>
        public string ActionCode { get; set; }

        /// <summary>
        /// CDO.3 - Cumulative Dosage Limit.
        /// </summary>
        public CompositeQuantityWithUnits CumulativeDosageLimit { get; set; }

        /// <summary>
        /// CDO.4 - Cumulative Dosage Limit Time Interval.
        /// <para>Suggested: 0924 Cumulative Dosage Limit UoM -&gt; ClearHl7.Codes.V281.CodeCumulativeDosageLimitUom</para>
        /// </summary>
        public CompositeQuantityWithUnits CumulativeDosageLimitTimeInterval { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <exception cref="ArgumentException">delimitedString does not begin with the proper segment Id.</exception>
        public void FromDelimitedString(string delimitedString)
        {
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(Configuration.FieldSeparator.ToCharArray());

            if (segments.Length > 0)
            {
                if (string.Compare(Id, segments[0], true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ Configuration.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            SetIdCdo = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableUInt() : null;
            ActionCode = segments.Length > 2 && segments[2].Length > 0 ? segments[2] : null;
            CumulativeDosageLimit = segments.Length > 3 && segments[3].Length > 0 ? TypeHelper.Deserialize<CompositeQuantityWithUnits>(segments[3], false) : null;
            CumulativeDosageLimitTimeInterval = segments.Length > 4 && segments[4].Length > 0 ? TypeHelper.Deserialize<CompositeQuantityWithUnits>(segments[4], false) : null;
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
                                SetIdCdo.HasValue ? SetIdCdo.Value.ToString(culture) : null,
                                ActionCode,
                                CumulativeDosageLimit?.ToDelimitedString(),
                                CumulativeDosageLimitTimeInterval?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}