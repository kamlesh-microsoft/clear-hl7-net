﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V230.Types;

namespace ClearHl7.V230.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment AIG - Appointment Information - General Resource.
    /// </summary>
    public class AigSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "AIG";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// AIG.1 - Set ID - AIG.
        /// </summary>
        public uint? SetIdAig { get; set; }

        /// <summary>
        /// AIG.2 - Segment Action Code.
        /// <para>Suggested: 0206 Segment Action Code -&gt; ClearHl7.Codes.V230.CodeSegmentActionCode</para>
        /// </summary>
        public string SegmentActionCode { get; set; }

        /// <summary>
        /// AIG.3 - Resource ID.
        /// </summary>
        public CodedElement ResourceId { get; set; }

        /// <summary>
        /// AIG.4 - Resource Type.
        /// </summary>
        public CodedElement ResourceType { get; set; }

        /// <summary>
        /// AIG.5 - Resource Group.
        /// </summary>
        public IEnumerable<CodedElement> ResourceGroup { get; set; }

        /// <summary>
        /// AIG.6 - Resource Quantity.
        /// </summary>
        public decimal? ResourceQuantity { get; set; }

        /// <summary>
        /// AIG.7 - Resource Quantity Units.
        /// </summary>
        public CodedElement ResourceQuantityUnits { get; set; }

        /// <summary>
        /// AIG.8 - Start Date/Time.
        /// </summary>
        public DateTime? StartDateTime { get; set; }

        /// <summary>
        /// AIG.9 - Start Date/Time Offset.
        /// </summary>
        public decimal? StartDateTimeOffset { get; set; }

        /// <summary>
        /// AIG.10 - Start Date/Time Offset Units.
        /// </summary>
        public CodedElement StartDateTimeOffsetUnits { get; set; }

        /// <summary>
        /// AIG.11 - Duration.
        /// </summary>
        public decimal? Duration { get; set; }

        /// <summary>
        /// AIG.12 - Duration Units.
        /// </summary>
        public CodedElement DurationUnits { get; set; }

        /// <summary>
        /// AIG.13 - Allow Substitution Code.
        /// <para>Suggested: 0279 Allow Substitution Codes -&gt; ClearHl7.Codes.V230.CodeAllowSubstitutionCodes</para>
        /// </summary>
        public string AllowSubstitutionCode { get; set; }

        /// <summary>
        /// AIG.14 - Filler Status Code.
        /// <para>Suggested: 0278 Filler Status Codes -&gt; ClearHl7.Codes.V230.CodeFillerStatusCodes</para>
        /// </summary>
        public CodedElement FillerStatusCode { get; set; }

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

            SetIdAig = segments.ElementAtOrDefault(1)?.ToNullableUInt();
            SegmentActionCode = segments.ElementAtOrDefault(2);
            ResourceId = segments.Length > 3 ? TypeHelper.Deserialize<CodedElement>(segments.ElementAtOrDefault(3), false) : null;
            ResourceType = segments.Length > 4 ? TypeHelper.Deserialize<CodedElement>(segments.ElementAtOrDefault(4), false) : null;
            ResourceGroup = segments.Length > 5 ? segments.ElementAtOrDefault(5).Split(separator).Select(x => TypeHelper.Deserialize<CodedElement>(x, false)) : null;
            ResourceQuantity = segments.ElementAtOrDefault(6)?.ToNullableDecimal();
            ResourceQuantityUnits = segments.Length > 7 ? TypeHelper.Deserialize<CodedElement>(segments.ElementAtOrDefault(7), false) : null;
            StartDateTime = segments.ElementAtOrDefault(8)?.ToNullableDateTime();
            StartDateTimeOffset = segments.ElementAtOrDefault(9)?.ToNullableDecimal();
            StartDateTimeOffsetUnits = segments.Length > 10 ? TypeHelper.Deserialize<CodedElement>(segments.ElementAtOrDefault(10), false) : null;
            Duration = segments.ElementAtOrDefault(11)?.ToNullableDecimal();
            DurationUnits = segments.Length > 12 ? TypeHelper.Deserialize<CodedElement>(segments.ElementAtOrDefault(12), false) : null;
            AllowSubstitutionCode = segments.ElementAtOrDefault(13);
            FillerStatusCode = segments.Length > 14 ? TypeHelper.Deserialize<CodedElement>(segments.ElementAtOrDefault(14), false) : null;
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
                                StringHelper.StringFormatSequence(0, 15, Configuration.FieldSeparator),
                                Id,
                                SetIdAig.HasValue ? SetIdAig.Value.ToString(culture) : null,
                                SegmentActionCode,
                                ResourceId?.ToDelimitedString(),
                                ResourceType?.ToDelimitedString(),
                                ResourceGroup != null ? string.Join(Configuration.FieldRepeatSeparator, ResourceGroup.Select(x => x.ToDelimitedString())) : null,
                                ResourceQuantity.HasValue ? ResourceQuantity.Value.ToString(Consts.NumericFormat, culture) : null,
                                ResourceQuantityUnits?.ToDelimitedString(),
                                StartDateTime.HasValue ? StartDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                StartDateTimeOffset.HasValue ? StartDateTimeOffset.Value.ToString(Consts.NumericFormat, culture) : null,
                                StartDateTimeOffsetUnits?.ToDelimitedString(),
                                Duration.HasValue ? Duration.Value.ToString(Consts.NumericFormat, culture) : null,
                                DurationUnits?.ToDelimitedString(),
                                AllowSubstitutionCode,
                                FillerStatusCode?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}