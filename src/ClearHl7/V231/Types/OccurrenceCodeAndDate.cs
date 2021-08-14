﻿using System;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;

namespace ClearHl7.V231.Types
{
    /// <summary>
    /// HL7 Version 2 OCD - Occurrence Code And Date.
    /// </summary>
    public class OccurrenceCodeAndDate : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// OCD.1 - Occurrence Code.
        /// <para>Suggested: 0350 Occurrence Code -&gt; ClearHl7.Codes.V231.CodeOccurrenceCode</para>
        /// </summary>
        public CodedWithNoExceptions OccurrenceCode { get; set; }

        /// <summary>
        /// OCD.2 - Occurrence Date.
        /// </summary>
        public DateTime? OccurrenceDate { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        public void FromDelimitedString(string delimitedString)
        {
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(separator.ToCharArray());

            OccurrenceCode = segments.Length > 0 ? TypeHelper.Deserialize<CodedWithNoExceptions>(segments.ElementAtOrDefault(0), true) : null;
            OccurrenceDate = segments.ElementAtOrDefault(1)?.ToNullableDateTime();
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
                                StringHelper.StringFormatSequence(0, 2, separator),
                                OccurrenceCode?.ToDelimitedString(),
                                OccurrenceDate.HasValue ? OccurrenceDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
