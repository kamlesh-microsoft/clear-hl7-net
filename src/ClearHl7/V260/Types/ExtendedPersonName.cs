﻿using System;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;

namespace ClearHl7.V260.Types
{
    /// <summary>
    /// HL7 Version 2 XPN - Extended Person Name.
    /// </summary>
    public class ExtendedPersonName : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// XPN.1 - Family Name.
        /// </summary>
        public FamilyName FamilyName { get; set; }

        /// <summary>
        /// XPN.2 - Given Name.
        /// </summary>
        public string GivenName { get; set; }

        /// <summary>
        /// XPN.3 - Second and Further Given Names or Initials Thereof.
        /// </summary>
        public string SecondAndFurtherGivenNamesOrInitialsThereof { get; set; }

        /// <summary>
        /// XPN.4 - Suffix (e.g., JR or III).
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// XPN.5 - Prefix (e.g., DR).
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// XPN.6 - Degree (e.g., MD).
        /// <para>Suggested: 0360 Degree/License/Certificate</para>
        /// </summary>
        public string Degree { get; set; }

        /// <summary>
        /// XPN.7 - Name Type Code.
        /// <para>Suggested: 0200 Name Type -&gt; ClearHl7.Codes.V260.CodeNameType</para>
        /// </summary>
        public string NameTypeCode { get; set; }

        /// <summary>
        /// XPN.8 - Name Representation Code.
        /// <para>Suggested: 0465 Name/Address Representation -&gt; ClearHl7.Codes.V260.CodeNameAddressRepresentation</para>
        /// </summary>
        public string NameRepresentationCode { get; set; }

        /// <summary>
        /// XPN.9 - Name Context.
        /// <para>Suggested: 0448 Name Context</para>
        /// </summary>
        public CodedWithExceptions NameContext { get; set; }

        /// <summary>
        /// XPN.10 - Name Validity Range.
        /// </summary>
        public DateTimeRange NameValidityRange { get; set; }

        /// <summary>
        /// XPN.11 - Name Assembly Order.
        /// <para>Suggested: 0444 Name Assembly Order -&gt; ClearHl7.Codes.V260.CodeNameAssemblyOrder</para>
        /// </summary>
        public string NameAssemblyOrder { get; set; }

        /// <summary>
        /// XPN.12 - Effective Date.
        /// </summary>
        public DateTime? EffectiveDate { get; set; }

        /// <summary>
        /// XPN.13 - Expiration Date.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// XPN.14 - Professional Suffix.
        /// </summary>
        public string ProfessionalSuffix { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        public void FromDelimitedString(string delimitedString)
        {
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(separator.ToCharArray());

            if (segments.Length > 0)
            {
                FamilyName = new FamilyName { IsSubcomponent = true };
                FamilyName.FromDelimitedString(segments.ElementAtOrDefault(0));
            }
            else
            {
                FamilyName = null;
            }

            GivenName = segments.ElementAtOrDefault(1);
            SecondAndFurtherGivenNamesOrInitialsThereof = segments.ElementAtOrDefault(2);
            Suffix = segments.ElementAtOrDefault(3);
            Prefix = segments.ElementAtOrDefault(4);
            Degree = segments.ElementAtOrDefault(5);
            NameTypeCode = segments.ElementAtOrDefault(6);
            NameRepresentationCode = segments.ElementAtOrDefault(7);

            if (segments.Length > 8)
            {
                NameContext = new CodedWithExceptions { IsSubcomponent = true };
                NameContext.FromDelimitedString(segments.ElementAtOrDefault(8));
            }
            else
            {
                NameContext = null;
            }

            if (segments.Length > 9)
            {
                NameValidityRange = new DateTimeRange { IsSubcomponent = true };
                NameValidityRange.FromDelimitedString(segments.ElementAtOrDefault(9));
            }
            else
            {
                NameValidityRange = null;
            }

            NameAssemblyOrder = segments.ElementAtOrDefault(10);
            EffectiveDate = segments.ElementAtOrDefault(11)?.ToNullableDateTime(Consts.DateTimeFormatPrecisionSecond);
            ExpirationDate = segments.ElementAtOrDefault(12)?.ToNullableDateTime(Consts.DateTimeFormatPrecisionSecond);
            ProfessionalSuffix = segments.ElementAtOrDefault(13);
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
                                StringHelper.StringFormatSequence(0, 14, separator),
                                FamilyName?.ToDelimitedString(),
                                GivenName,
                                SecondAndFurtherGivenNamesOrInitialsThereof,
                                Suffix,
                                Prefix,
                                Degree,
                                NameTypeCode,
                                NameRepresentationCode,
                                NameContext?.ToDelimitedString(),
                                NameValidityRange?.ToDelimitedString(),
                                NameAssemblyOrder,
                                EffectiveDate.HasValue ? EffectiveDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ExpirationDate.HasValue ? ExpirationDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ProfessionalSuffix
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
