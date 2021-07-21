﻿using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;

namespace ClearHl7.V270.Types
{
    /// <summary>
    /// HL7 Version 2 MA - Multiplexed Array.
    /// </summary>
    public class MultiplexedArray : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// MA.1 - Sample Y From Channel 1.
        /// </summary>
        public decimal? SampleYFromChannel1 { get; set; }

        /// <summary>
        /// MA.2 - Sample Y From Channel 2.
        /// </summary>
        public decimal? SampleYFromChannel2 { get; set; }

        /// <summary>
        /// MA.3 - Sample Y From Channel 3.
        /// </summary>
        public decimal? SampleYFromChannel3 { get; set; }

        /// <summary>
        /// MA.4 - Sample Y From Channel 4.
        /// </summary>
        public decimal? SampleYFromChannel4 { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        public void FromDelimitedString(string delimitedString)
        {
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(separator.ToCharArray());

            SampleYFromChannel1 = segments.ElementAtOrDefault(0)?.ToNullableDecimal();
            SampleYFromChannel2 = segments.ElementAtOrDefault(1)?.ToNullableDecimal();
            SampleYFromChannel3 = segments.ElementAtOrDefault(2)?.ToNullableDecimal();
            SampleYFromChannel4 = segments.ElementAtOrDefault(3)?.ToNullableDecimal();
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
                                StringHelper.StringFormatSequence(0, 4, separator),
                                SampleYFromChannel1.HasValue ? SampleYFromChannel1.Value.ToString(Consts.NumericFormat, culture) : null,
                                SampleYFromChannel2.HasValue ? SampleYFromChannel2.Value.ToString(Consts.NumericFormat, culture) : null,
                                SampleYFromChannel3.HasValue ? SampleYFromChannel3.Value.ToString(Consts.NumericFormat, culture) : null,
                                SampleYFromChannel4.HasValue ? SampleYFromChannel4.Value.ToString(Consts.NumericFormat, culture) : null
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
