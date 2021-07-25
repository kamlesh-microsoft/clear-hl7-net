﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V250.Types;

namespace ClearHl7.V250.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment APR - Appointment Preferences.
    /// </summary>
    public class AprSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "APR";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// APR.1 - Time Selection Criteria.
        /// <para>Suggested: 0294 Time Selection Criteria Parameter Class Codes -&gt; ClearHl7.Codes.V250.CodeTimeSelectionCriteriaParameterClassCodes</para>
        /// </summary>
        public IEnumerable<SchedulingClassValuePair> TimeSelectionCriteria { get; set; }

        /// <summary>
        /// APR.2 - Resource Selection Criteria.
        /// <para>Suggested: 0294 Time Selection Criteria Parameter Class Codes -&gt; ClearHl7.Codes.V250.CodeTimeSelectionCriteriaParameterClassCodes</para>
        /// </summary>
        public IEnumerable<SchedulingClassValuePair> ResourceSelectionCriteria { get; set; }

        /// <summary>
        /// APR.3 - Location Selection Criteria.
        /// <para>Suggested: 0294 Time Selection Criteria Parameter Class Codes -&gt; ClearHl7.Codes.V250.CodeTimeSelectionCriteriaParameterClassCodes</para>
        /// </summary>
        public IEnumerable<SchedulingClassValuePair> LocationSelectionCriteria { get; set; }

        /// <summary>
        /// APR.4 - Slot Spacing Criteria.
        /// </summary>
        public decimal? SlotSpacingCriteria { get; set; }

        /// <summary>
        /// APR.5 - Filler Override Criteria.
        /// </summary>
        public IEnumerable<SchedulingClassValuePair> FillerOverrideCriteria { get; set; }

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

            TimeSelectionCriteria = segments.Length > 1 ? segments.ElementAtOrDefault(1).Split(separator).Select(x => TypeHelper.Deserialize<SchedulingClassValuePair>(x, false)) : null;
            ResourceSelectionCriteria = segments.Length > 2 ? segments.ElementAtOrDefault(2).Split(separator).Select(x => TypeHelper.Deserialize<SchedulingClassValuePair>(x, false)) : null;
            LocationSelectionCriteria = segments.Length > 3 ? segments.ElementAtOrDefault(3).Split(separator).Select(x => TypeHelper.Deserialize<SchedulingClassValuePair>(x, false)) : null;
            SlotSpacingCriteria = segments.ElementAtOrDefault(4)?.ToNullableDecimal();
            FillerOverrideCriteria = segments.Length > 5 ? segments.ElementAtOrDefault(5).Split(separator).Select(x => TypeHelper.Deserialize<SchedulingClassValuePair>(x, false)) : null;
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
                                StringHelper.StringFormatSequence(0, 6, Configuration.FieldSeparator),
                                Id,
                                TimeSelectionCriteria != null ? string.Join(Configuration.FieldRepeatSeparator, TimeSelectionCriteria.Select(x => x.ToDelimitedString())) : null,
                                ResourceSelectionCriteria != null ? string.Join(Configuration.FieldRepeatSeparator, ResourceSelectionCriteria.Select(x => x.ToDelimitedString())) : null,
                                LocationSelectionCriteria != null ? string.Join(Configuration.FieldRepeatSeparator, LocationSelectionCriteria.Select(x => x.ToDelimitedString())) : null,
                                SlotSpacingCriteria.HasValue ? SlotSpacingCriteria.Value.ToString(Consts.NumericFormat, culture) : null,
                                FillerOverrideCriteria != null ? string.Join(Configuration.FieldRepeatSeparator, FillerOverrideCriteria.Select(x => x.ToDelimitedString())) : null
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}