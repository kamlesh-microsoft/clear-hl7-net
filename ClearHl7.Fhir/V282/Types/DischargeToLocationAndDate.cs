﻿using System;

namespace ClearHl7.Fhir.V282.Types
{
    /// <summary>
    /// HL7 Version 2 DLD - Discharge To Location And Date.
    /// </summary>
    public class DischargeToLocationAndDate
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// DLD.1 - Discharge to Location.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0113</remarks>
        public CodedWithExceptions DischargeToLocation { get; set; }

        /// <summary>
        /// DLD.2 - Effective Date.
        /// </summary>
        public DateTime? EffectiveDate { get; set; }

        /// <summary>
        /// Returns a pipe-delimited representation of this instance. 
        /// </summary>
        /// <returns>A string.</returns>
        public string ToPipeString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                IsSubcomponent ? "{0}&{1}" : "{0}^{1}",
                                DischargeToLocation?.ToPipeString(),
                                EffectiveDate.HasValue ? EffectiveDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null
                                ).TrimEnd(IsSubcomponent ? '&' : '^');
        }
    }
}
