﻿using System;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;

namespace ClearHl7.V270.Types
{
    /// <summary>
    /// HL7 Version 2 XAD - Extended Address.
    /// </summary>
    public class ExtendedAddress : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// XAD.1 - Street Address.
        /// </summary>
        public StreetAddress StreetAddress { get; set; }

        /// <summary>
        /// XAD.2 - Other Designation.
        /// </summary>
        public string OtherDesignation { get; set; }

        /// <summary>
        /// XAD.3 - City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// XAD.4 - State or Province.
        /// </summary>
        public string StateOrProvince { get; set; }

        /// <summary>
        /// XAD.5 - Zip or Postal Code.
        /// </summary>
        public string ZipOrPostalCode { get; set; }

        /// <summary>
        /// XAD.6 - Country.
        /// <para>Suggested: 0399 Country Code -&gt; https://www.iso.org/iso-3166-country-codes.html</para>
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// XAD.7 - Address Type.
        /// <para>Suggested: 0190 Address Type -&gt; ClearHl7.Codes.V270.CodeAddressType</para>
        /// </summary>
        public string AddressType { get; set; }

        /// <summary>
        /// XAD.8 - Other Geographic Designation.
        /// </summary>
        public string OtherGeographicDesignation { get; set; }

        /// <summary>
        /// XAD.9 - County/Parish Code.
        /// <para>Suggested: 0289 County/Parish Code</para>
        /// </summary>
        public CodedWithExceptions CountyParishCode { get; set; }

        /// <summary>
        /// XAD.10 - Census Tract.
        /// <para>Suggested: 0288 Census Tract</para>
        /// </summary>
        public CodedWithExceptions CensusTract { get; set; }

        /// <summary>
        /// XAD.11 - Address Representation Code.
        /// <para>Suggested: 0465 Name/Address Representation -&gt; ClearHl7.Codes.V270.CodeNameAddressRepresentation</para>
        /// </summary>
        public string AddressRepresentationCode { get; set; }

        /// <summary>
        /// XAD.12 - Address Validity Range.
        /// </summary>
        public DateTimeRange AddressValidityRange { get; set; }

        /// <summary>
        /// XAD.13 - Effective Date.
        /// </summary>
        public DateTime? EffectiveDate { get; set; }

        /// <summary>
        /// XAD.14 - Expiration Date.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// XAD.15 - Expiration Reason.
        /// <para>Suggested: 0616 Address Expiration Reason -&gt; ClearHl7.Codes.V270.CodeAddressExpirationReason</para>
        /// </summary>
        public CodedWithExceptions ExpirationReason { get; set; }

        /// <summary>
        /// XAD.16 - Temporary Indicator.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V270.CodeYesNoIndicator</para>
        /// </summary>
        public string TemporaryIndicator { get; set; }

        /// <summary>
        /// XAD.17 - Bad Address Indicator.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V270.CodeYesNoIndicator</para>
        /// </summary>
        public string BadAddressIndicator { get; set; }

        /// <summary>
        /// XAD.18 - Address Usage.
        /// <para>Suggested: 0617 Address Usage -&gt; ClearHl7.Codes.V270.CodeAddressUsage</para>
        /// </summary>
        public string AddressUsage { get; set; }

        /// <summary>
        /// XAD.19 - Addressee.
        /// </summary>
        public string Addressee { get; set; }

        /// <summary>
        /// XAD.20 - Comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// XAD.21 - Preference Order.
        /// </summary>
        public decimal? PreferenceOrder { get; set; }

        /// <summary>
        /// XAD.22 - Protection Code.
        /// <para>Suggested: 0618 Protection Code -&gt; ClearHl7.Codes.V270.CodeProtectionCode</para>
        /// </summary>
        public CodedWithExceptions ProtectionCode { get; set; }

        /// <summary>
        /// XAD.23 - Address Identifier.
        /// </summary>
        public EntityIdentifier AddressIdentifier { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        public void FromDelimitedString(string delimitedString)
        {
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(separator.ToCharArray());

            StreetAddress = segments.Length > 0 && segments[0].Length > 0 ? TypeHelper.Deserialize<StreetAddress>(segments[0], true) : null;
            OtherDesignation = segments.Length > 1 && segments[1].Length > 0 ? segments[1] : null;
            City = segments.Length > 2 && segments[2].Length > 0 ? segments[2] : null;
            StateOrProvince = segments.Length > 3 && segments[3].Length > 0 ? segments[3] : null;
            ZipOrPostalCode = segments.Length > 4 && segments[4].Length > 0 ? segments[4] : null;
            Country = segments.Length > 5 && segments[5].Length > 0 ? segments[5] : null;
            AddressType = segments.Length > 6 && segments[6].Length > 0 ? segments[6] : null;
            OtherGeographicDesignation = segments.Length > 7 && segments[7].Length > 0 ? segments[7] : null;
            CountyParishCode = segments.Length > 8 && segments[8].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[8], true) : null;
            CensusTract = segments.Length > 9 && segments[9].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[9], true) : null;
            AddressRepresentationCode = segments.Length > 10 && segments[10].Length > 0 ? segments[10] : null;
            AddressValidityRange = segments.Length > 11 && segments[11].Length > 0 ? TypeHelper.Deserialize<DateTimeRange>(segments[11], true) : null;
            EffectiveDate = segments.Length > 12 && segments[12].Length > 0 ? segments[12].ToNullableDateTime() : null;
            ExpirationDate = segments.Length > 13 && segments[13].Length > 0 ? segments[13].ToNullableDateTime() : null;
            ExpirationReason = segments.Length > 14 && segments[14].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[14], true) : null;
            TemporaryIndicator = segments.Length > 15 && segments[15].Length > 0 ? segments[15] : null;
            BadAddressIndicator = segments.Length > 16 && segments[16].Length > 0 ? segments[16] : null;
            AddressUsage = segments.Length > 17 && segments[17].Length > 0 ? segments[17] : null;
            Addressee = segments.Length > 18 && segments[18].Length > 0 ? segments[18] : null;
            Comment = segments.Length > 19 && segments[19].Length > 0 ? segments[19] : null;
            PreferenceOrder = segments.Length > 20 && segments[20].Length > 0 ? segments[20].ToNullableDecimal() : null;
            ProtectionCode = segments.Length > 21 && segments[21].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[21], true) : null;
            AddressIdentifier = segments.Length > 22 && segments[22].Length > 0 ? TypeHelper.Deserialize<EntityIdentifier>(segments[22], true) : null;
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
                                StreetAddress?.ToDelimitedString(),
                                OtherDesignation,
                                City,
                                StateOrProvince,
                                ZipOrPostalCode,
                                Country,
                                AddressType,
                                OtherGeographicDesignation,
                                CountyParishCode?.ToDelimitedString(),
                                CensusTract?.ToDelimitedString(),
                                AddressRepresentationCode,
                                AddressValidityRange?.ToDelimitedString(),
                                EffectiveDate.HasValue ? EffectiveDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ExpirationDate.HasValue ? ExpirationDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ExpirationReason?.ToDelimitedString(),
                                TemporaryIndicator,
                                BadAddressIndicator,
                                AddressUsage,
                                Addressee,
                                Comment,
                                PreferenceOrder.HasValue ? PreferenceOrder.Value.ToString(Consts.NumericFormat, culture) : null,
                                ProtectionCode?.ToDelimitedString(),
                                AddressIdentifier?.ToDelimitedString()
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
