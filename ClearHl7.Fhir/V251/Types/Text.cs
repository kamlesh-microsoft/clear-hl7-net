﻿using System;

namespace ClearHl7.Fhir.V251.Types
{
    /// <summary>
    /// HL7 Version 2 TX - Text.
    /// </summary>
    public class Text : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// TX.1 - Value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                "{0}",
                                Value
                                );
        }
    }
}
