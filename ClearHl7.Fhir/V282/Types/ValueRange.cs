﻿using System;

namespace ClearHl7.Fhir.V282.Types
{
    /// <summary>
    /// HL7 Version 2 VR - Value Range.
    /// </summary>
    public class ValueRange
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// VR.1 - First Data Code Value.
        /// </summary>
        public string FirstDataCodeValue { get; set; }

        /// <summary>
        /// VR.2 - Last Data Code Value.
        /// </summary>
        public string LastDataCodeValue { get; set; }

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
                                FirstDataCodeValue,
                                LastDataCodeValue
                                ).TrimEnd(IsSubcomponent ? '&' : '^');
        }
    }
}
