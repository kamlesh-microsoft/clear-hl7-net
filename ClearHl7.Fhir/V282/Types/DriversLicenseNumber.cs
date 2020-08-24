﻿using System;

namespace ClearHl7.Fhir.V282.Types
{
    /// <summary>
    /// HL7 Version 2 DLN - Drivers License Number.
    /// </summary>
    public class DriversLicenseNumber
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// DLN.1 - License Number.
        /// </summary>
        public string LicenseNumber { get; set; }

        /// <summary>
        /// DLN.2 - Issuing State, Province, Country.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0333</remarks>
        public CodedWithExceptions IssuingStateProvinceCountry { get; set; }

        /// <summary>
        /// DLN.3 - Expiration Date.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Returns a pipe-delimited representation of this instance. 
        /// </summary>
        /// <returns>A string.</returns>
        public string ToPipeString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                IsSubcomponent ? "{0}&{1}&{2}" : "{0}^{1}^{2}",
                                LicenseNumber,
                                IssuingStateProvinceCountry?.ToPipeString(),
                                ExpirationDate.HasValue ? ExpirationDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null
                                ).TrimEnd(IsSubcomponent ? '&' : '^');
        }
    }
}
