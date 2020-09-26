﻿using System;

namespace ClearHl7.Fhir.V280.Types
{
    /// <summary>
    /// HL7 Version 2 PLN - Practitioner License Or Other Id Number.
    /// </summary>
    public class PractitionerLicenseOrOtherIdNumber : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// PLN.1 - ID Number.
        /// </summary>
        public string IdNumber { get; set; }

        /// <summary>
        /// PLN.2 - Type of ID Number.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0338</remarks>
        public CodedWithExceptions TypeOfIdNumber { get; set; }

        /// <summary>
        /// PLN.3 - State/other Qualifying Information.
        /// </summary>
        public string StateOtherQualifyingInformation { get; set; }

        /// <summary>
        /// PLN.4 - Expiration Date.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                IsSubcomponent ? "{0}&{1}&{2}&{3}" : "{0}^{1}^{2}^{3}",
                                IdNumber,
                                TypeOfIdNumber?.ToDelimitedString(),
                                StateOtherQualifyingInformation,
                                ExpirationDate.HasValue ? ExpirationDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null
                                ).TrimEnd(IsSubcomponent ? '&' : '^');
        }
    }
}