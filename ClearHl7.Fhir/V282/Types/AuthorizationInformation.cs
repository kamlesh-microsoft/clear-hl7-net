﻿using System;

namespace ClearHl7.Fhir.V282.Types
{
    /// <summary>
    /// HL7 Version 2 AUI - Authorization Information.
    /// </summary>
    public class AuthorizationInformation
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// AUI.1 - Authorization Number.
        /// </summary>
        public string AuthorizationNumber { get; set; }

        /// <summary>
        /// AUI.2 - Date.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// AUI.3 - Source.
        /// </summary>
        public string Source { get; set; }

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
                                AuthorizationNumber,
                                Date.HasValue ? Date.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                Source
                                ).TrimEnd(IsSubcomponent ? '&' : '^');
        }
    }
}
