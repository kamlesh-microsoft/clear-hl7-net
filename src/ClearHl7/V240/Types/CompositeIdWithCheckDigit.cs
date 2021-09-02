﻿using System; 
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;

namespace ClearHl7.V240.Types
{
    /// <summary>
    /// HL7 Version 2 CK - Composite Id With Check Digit.
    /// </summary>
    public class CompositeIdWithCheckDigit : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// CK.1 - ID Number.
        /// </summary>
        public decimal? IdNumber { get; set; }

        /// <summary>
        /// CK.2 - Check Digit.
        /// </summary>
        public string CheckDigit { get; set; }

        /// <summary>
        /// CK.3 - Code Identifying The Check Digit Scheme Employed.
        /// <para>Suggested: 0061 Check Digit Scheme -&gt; ClearHl7.Codes.V240.CodeCheckDigitScheme</para>
        /// </summary>
        public string CodeIdentifyingTheCheckDigitSchemeEmployed { get; set; }

        /// <summary>
        /// CK.4 - Assigning Authority.
        /// </summary>
        public HierarchicDesignator AssigningAuthority { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.  Separators defined in the Configuration class are used to split the string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        public void FromDelimitedString(string delimitedString)
        {
            FromDelimitedString(delimitedString, null);
        }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.  The provided separators are used to split the string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <param name="separators">The separators to use for splitting the string.</param>
        public void FromDelimitedString(string delimitedString, Separators separators)
        {
            Separators seps = separators ?? new Separators().UsingConfigurationValues();
            string[] separator = IsSubcomponent ? seps.SubcomponentSeparator : seps.ComponentSeparator;
            string[] segments = delimitedString == null
                ? Array.Empty<string>()
                : delimitedString.Split(separator, StringSplitOptions.None);

            IdNumber = segments.Length > 0 && segments[0].Length > 0 ? segments[0].ToNullableDecimal() : null;
            CheckDigit = segments.Length > 1 && segments[1].Length > 0 ? segments[1] : null;
            CodeIdentifyingTheCheckDigitSchemeEmployed = segments.Length > 2 && segments[2].Length > 0 ? segments[2] : null;
            AssigningAuthority = segments.Length > 3 && segments[3].Length > 0 ? TypeSerializer.Deserialize<HierarchicDesignator>(segments[3], true, seps) : null;
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
                                IdNumber.HasValue ? IdNumber.Value.ToString(Consts.NumericFormat, culture) : null,
                                CheckDigit,
                                CodeIdentifyingTheCheckDigitSchemeEmployed,
                                AssigningAuthority?.ToDelimitedString()
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
