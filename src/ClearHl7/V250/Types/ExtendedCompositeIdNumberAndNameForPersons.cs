﻿using System;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;

namespace ClearHl7.V250.Types
{
    /// <summary>
    /// HL7 Version 2 XCN - Extended Composite Id Number And Name For Persons.
    /// </summary>
    public class ExtendedCompositeIdNumberAndNameForPersons : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// XCN.1 - Person Identifier.
        /// </summary>
        public string PersonIdentifier { get; set; }

        /// <summary>
        /// XCN.2 - Family Name.
        /// </summary>
        public FamilyName FamilyName { get; set; }

        /// <summary>
        /// XCN.3 - Given Name.
        /// </summary>
        public string GivenName { get; set; }

        /// <summary>
        /// XCN.4 - Second and Further Given Names or Initials Thereof.
        /// </summary>
        public string SecondAndFurtherGivenNamesOrInitialsThereof { get; set; }

        /// <summary>
        /// XCN.5 - Suffix (e.g., JR or III).
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// XCN.6 - Prefix (e.g., DR).
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// XCN.7 - Degree (e.g., MD).
        /// <para>Suggested: 0360 Degree/License/Certificate -&gt; ClearHl7.Codes.V250.CodeDegreeLicenseCertificate</para>
        /// </summary>
        public string Degree { get; set; }

        /// <summary>
        /// XCN.8 - Source Table.
        /// <para>Suggested: 0297 Source Table</para>
        /// </summary>
        public string SourceTable { get; set; }

        /// <summary>
        /// XCN.9 - Assigning Authority.
        /// <para>Suggested: 0363 Assigning Authority</para>
        /// </summary>
        public HierarchicDesignator AssigningAuthority { get; set; }

        /// <summary>
        /// XCN.10 - Name Type Code.
        /// <para>Suggested: 0200 Name Type -&gt; ClearHl7.Codes.V250.CodeNameType</para>
        /// </summary>
        public string NameTypeCode { get; set; }

        /// <summary>
        /// XCN.11 - Identifier Check Digit.
        /// </summary>
        public string IdentifierCheckDigit { get; set; }

        /// <summary>
        /// XCN.12 - Check Digit Scheme.
        /// <para>Suggested: 0061 Check Digit Scheme -&gt; ClearHl7.Codes.V250.CodeCheckDigitScheme</para>
        /// </summary>
        public string CheckDigitScheme { get; set; }

        /// <summary>
        /// XCN.13 - Identifier Type Code.
        /// <para>Suggested: 0203 Identifier Type -&gt; ClearHl7.Codes.V250.CodeIdentifierType</para>
        /// </summary>
        public string IdentifierTypeCode { get; set; }

        /// <summary>
        /// XCN.14 - Assigning Facility.
        /// </summary>
        public HierarchicDesignator AssigningFacility { get; set; }

        /// <summary>
        /// XCN.15 - Name Representation Code.
        /// <para>Suggested: 0465 Name/Address Representation -&gt; ClearHl7.Codes.V250.CodeNameAddressRepresentation</para>
        /// </summary>
        public string NameRepresentationCode { get; set; }

        /// <summary>
        /// XCN.16 - Name Context.
        /// <para>Suggested: 0448 Name Context</para>
        /// </summary>
        public CodedElement NameContext { get; set; }

        /// <summary>
        /// XCN.17 - Name Validity Range.
        /// </summary>
        public DateTimeRange NameValidityRange { get; set; }

        /// <summary>
        /// XCN.18 - Name Assembly Order.
        /// <para>Suggested: 0444 Name Assembly Order -&gt; ClearHl7.Codes.V250.CodeNameAssemblyOrder</para>
        /// </summary>
        public string NameAssemblyOrder { get; set; }

        /// <summary>
        /// XCN.19 - Effective Date.
        /// </summary>
        public DateTime? EffectiveDate { get; set; }

        /// <summary>
        /// XCN.20 - Expiration Date.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// XCN.21 - Professional Suffix.
        /// </summary>
        public string ProfessionalSuffix { get; set; }

        /// <summary>
        /// XCN.22 - Assigning Jurisdiction.
        /// </summary>
        public CodedWithExceptions AssigningJurisdiction { get; set; }

        /// <summary>
        /// XCN.23 - Assigning Agency or Department.
        /// </summary>
        public CodedWithExceptions AssigningAgencyOrDepartment { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        public void FromDelimitedString(string delimitedString)
        {
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(separator.ToCharArray());

            PersonIdentifier = segments.ElementAtOrDefault(0);

            if (segments.Length > 1)
            {
                FamilyName = new FamilyName { IsSubcomponent = true };
                FamilyName.FromDelimitedString(segments.ElementAtOrDefault(1));
            }
            else
            {
                FamilyName = null;
            }

            GivenName = segments.ElementAtOrDefault(2);
            SecondAndFurtherGivenNamesOrInitialsThereof = segments.ElementAtOrDefault(3);
            Suffix = segments.ElementAtOrDefault(4);
            Prefix = segments.ElementAtOrDefault(5);
            Degree = segments.ElementAtOrDefault(6);
            SourceTable = segments.ElementAtOrDefault(7);

            if (segments.Length > 8)
            {
                AssigningAuthority = new HierarchicDesignator { IsSubcomponent = true };
                AssigningAuthority.FromDelimitedString(segments.ElementAtOrDefault(8));
            }
            else
            {
                AssigningAuthority = null;
            }

            NameTypeCode = segments.ElementAtOrDefault(9);
            IdentifierCheckDigit = segments.ElementAtOrDefault(10);
            CheckDigitScheme = segments.ElementAtOrDefault(11);
            IdentifierTypeCode = segments.ElementAtOrDefault(12);

            if (segments.Length > 13)
            {
                AssigningFacility = new HierarchicDesignator { IsSubcomponent = true };
                AssigningFacility.FromDelimitedString(segments.ElementAtOrDefault(13));
            }
            else
            {
                AssigningFacility = null;
            }

            NameRepresentationCode = segments.ElementAtOrDefault(14);

            if (segments.Length > 15)
            {
                NameContext = new CodedElement { IsSubcomponent = true };
                NameContext.FromDelimitedString(segments.ElementAtOrDefault(15));
            }
            else
            {
                NameContext = null;
            }

            if (segments.Length > 16)
            {
                NameValidityRange = new DateTimeRange { IsSubcomponent = true };
                NameValidityRange.FromDelimitedString(segments.ElementAtOrDefault(16));
            }
            else
            {
                NameValidityRange = null;
            }

            NameAssemblyOrder = segments.ElementAtOrDefault(17);
            EffectiveDate = segments.ElementAtOrDefault(18)?.ToNullableDateTime(Consts.DateTimeFormatPrecisionSecond);
            ExpirationDate = segments.ElementAtOrDefault(19)?.ToNullableDateTime(Consts.DateTimeFormatPrecisionSecond);
            ProfessionalSuffix = segments.ElementAtOrDefault(20);

            if (segments.Length > 21)
            {
                AssigningJurisdiction = new CodedWithExceptions { IsSubcomponent = true };
                AssigningJurisdiction.FromDelimitedString(segments.ElementAtOrDefault(21));
            }
            else
            {
                AssigningJurisdiction = null;
            }

            if (segments.Length > 22)
            {
                AssigningAgencyOrDepartment = new CodedWithExceptions { IsSubcomponent = true };
                AssigningAgencyOrDepartment.FromDelimitedString(segments.ElementAtOrDefault(22));
            }
            else
            {
                AssigningAgencyOrDepartment = null;
            }
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
                                StringHelper.StringFormatSequence(0, 23, separator),
                                PersonIdentifier,
                                FamilyName?.ToDelimitedString(),
                                GivenName,
                                SecondAndFurtherGivenNamesOrInitialsThereof,
                                Suffix,
                                Prefix,
                                Degree,
                                SourceTable,
                                AssigningAuthority?.ToDelimitedString(),
                                NameTypeCode,
                                IdentifierCheckDigit,
                                CheckDigitScheme,
                                IdentifierTypeCode,
                                AssigningFacility?.ToDelimitedString(),
                                NameRepresentationCode,
                                NameContext?.ToDelimitedString(),
                                NameValidityRange?.ToDelimitedString(),
                                NameAssemblyOrder,
                                EffectiveDate.HasValue ? EffectiveDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ExpirationDate.HasValue ? ExpirationDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ProfessionalSuffix,
                                AssigningJurisdiction?.ToDelimitedString(),
                                AssigningAgencyOrDepartment?.ToDelimitedString()
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
