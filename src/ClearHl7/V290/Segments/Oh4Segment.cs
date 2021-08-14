﻿using System;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V290.Types;

namespace ClearHl7.V290.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment OH4 - Combat Zone Work.
    /// </summary>
    public class Oh4Segment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "OH4";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// OH4.1 - Set ID.
        /// </summary>
        public uint? SetId { get; set; }

        /// <summary>
        /// OH4.2 - Action Code.
        /// </summary>
        public string ActionCode { get; set; }

        /// <summary>
        /// OH4.3 - Combat Zone Start Date.
        /// </summary>
        public DateTime? CombatZoneStartDate { get; set; }

        /// <summary>
        /// OH4.4 - Combat Zone End Date.
        /// <para>Suggested: 0955 Industry</para>
        /// </summary>
        public DateTime? CombatZoneEndDate { get; set; }

        /// <summary>
        /// OH4.5 - Entered Date.
        /// </summary>
        public DateTime? EnteredDate { get; set; }

        /// <summary>
        /// OH4.6 - Combat Zone Unique Identifier.
        /// </summary>
        public EntityIdentifier CombatZoneUniqueIdentifier { get; set; }

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
                if (string.Compare(Id, segments.First(), true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ Configuration.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            SetId = segments.ElementAtOrDefault(1)?.ToNullableUInt();
            ActionCode = segments.ElementAtOrDefault(2);
            CombatZoneStartDate = segments.ElementAtOrDefault(3)?.ToNullableDateTime();
            CombatZoneEndDate = segments.ElementAtOrDefault(4)?.ToNullableDateTime();
            EnteredDate = segments.ElementAtOrDefault(5)?.ToNullableDateTime();
            CombatZoneUniqueIdentifier = segments.Length > 6 ? TypeHelper.Deserialize<EntityIdentifier>(segments.ElementAtOrDefault(6), false) : null;
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
                                StringHelper.StringFormatSequence(0, 7, Configuration.FieldSeparator),
                                Id,
                                SetId.HasValue ? SetId.Value.ToString(culture) : null,
                                ActionCode,
                                CombatZoneStartDate.HasValue ? CombatZoneStartDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                CombatZoneEndDate.HasValue ? CombatZoneEndDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                EnteredDate.HasValue ? EnteredDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                CombatZoneUniqueIdentifier?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}