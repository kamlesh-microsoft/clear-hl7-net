﻿using ClearHl7.Fhir.Helpers;

namespace ClearHl7.Fhir.V231.Types
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
        public string StreetAddress { get; set; }

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
        /// </summary>
        /// <remarks>https://www.iso.org/iso-3166-country-codes.html</remarks>
        public string Country { get; set; }

        /// <summary>
        /// XAD.7 - Address Type.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0190</remarks>
        public string AddressType { get; set; }

        /// <summary>
        /// XAD.8 - Other Geographic Designation.
        /// </summary>
        public string OtherGeographicDesignation { get; set; }

        /// <summary>
        /// XAD.9 - County/Parish Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0289</remarks>
        public string CountyParishCode { get; set; }

        /// <summary>
        /// XAD.10 - Census Tract.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0288</remarks>
        public string CensusTract { get; set; }

        /// <summary>
        /// XAD.11 - Address Representation Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0465</remarks>
        public string AddressRepresentationCode { get; set; }

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
                                StringHelper.StringFormatSequence(0, 11, separator),
                                StreetAddress,
                                OtherDesignation,
                                City,
                                StateOrProvince,
                                ZipOrPostalCode,
                                Country,
                                AddressType,
                                OtherGeographicDesignation,
                                CountyParishCode,
                                CensusTract,
                                AddressRepresentationCode
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}