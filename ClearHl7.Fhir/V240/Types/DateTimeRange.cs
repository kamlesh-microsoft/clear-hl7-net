﻿using System;

namespace ClearHl7.Fhir.V240.Types
{
    /// <summary>
    /// HL7 Version 2 DR - Date/Time Range.
    /// </summary>
    public class DateTimeRange : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// DR.1 - Range Start Date/Time.
        /// </summary>
        public DateTime? RangeStartDateTime { get; set; }

        /// <summary>
        /// DR.2 - Range End Date/Time.
        /// </summary>
        public DateTime? RangeEndDateTime { get; set; }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                IsSubcomponent ? "{0}&{1}" : "{0}^{1}",
                                RangeStartDateTime.HasValue ? RangeStartDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                RangeEndDateTime.HasValue ? RangeEndDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null
                                ).TrimEnd(IsSubcomponent ? '&' : '^');
        }
    }
}