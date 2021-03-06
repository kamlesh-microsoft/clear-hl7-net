using System;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;

namespace ClearHl7.V230.Types
{
    /// <summary>
    /// HL7 Version 2 CK - Composite Id With Check Digit.
    /// </summary>
    public class CompositeIdWithCheckDigit : IType
    {
        /// <inheritdoc/>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// CK.1 - ID Number.
        /// </summary>
        public decimal? IdNumber { get; set; }

        /// <summary>
        /// CK.2 - Check Digit.
        /// </summary>
        public decimal? CheckDigit { get; set; }

        /// <summary>
        /// CK.3 - Code Identifying The Check Digit Scheme Employed.
        /// </summary>
        public string CodeIdentifyingTheCheckDigitSchemeEmployed { get; set; }

        /// <summary>
        /// CK.4 - Assigning Authority.
        /// </summary>
        public HierarchicDesignator AssigningAuthority { get; set; }

        /// <inheritdoc/>
        public void FromDelimitedString(string delimitedString)
        {
            FromDelimitedString(delimitedString, null);
        }

        /// <inheritdoc/>
        public void FromDelimitedString(string delimitedString, Separators separators)
        {
            Separators seps = separators ?? new Separators().UsingConfigurationValues();
            string[] separator = IsSubcomponent ? seps.SubcomponentSeparator : seps.ComponentSeparator;
            string[] segments = delimitedString == null
                ? Array.Empty<string>()
                : delimitedString.Split(separator, StringSplitOptions.None);

            IdNumber = segments.Length > 0 && segments[0].Length > 0 ? segments[0].ToNullableDecimal() : null;
            CheckDigit = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableDecimal() : null;
            CodeIdentifyingTheCheckDigitSchemeEmployed = segments.Length > 2 && segments[2].Length > 0 ? segments[2] : null;
            AssigningAuthority = segments.Length > 3 && segments[3].Length > 0 ? TypeSerializer.Deserialize<HierarchicDesignator>(segments[3], true, seps) : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 4, separator),
                                IdNumber.HasValue ? IdNumber.Value.ToString(Consts.NumericFormat, culture) : null,
                                CheckDigit.HasValue ? CheckDigit.Value.ToString(Consts.NumericFormat, culture) : null,
                                CodeIdentifyingTheCheckDigitSchemeEmployed,
                                AssigningAuthority?.ToDelimitedString()
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
