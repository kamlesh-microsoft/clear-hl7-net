﻿using System;

namespace ClearHl7.Fhir.V230.Types
{
    /// <summary>
    /// HL7 Version 2 ED - Encapsulated Data.
    /// </summary>
    public class EncapsulatedData : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// ED.1 - Source Application.
        /// </summary>
        public HierarchicDesignator SourceApplication { get; set; }

        /// <summary>
        /// ED.2 - Type of Data.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0191</remarks>
        public string TypeOfData { get; set; }

        /// <summary>
        /// ED.3 - Data Subtype.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0291</remarks>
        public string DataSubtype { get; set; }

        /// <summary>
        /// ED.4 - Encoding.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0299</remarks>
        public string Encoding { get; set; }

        /// <summary>
        /// ED.5 - Data.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                IsSubcomponent ? "{0}&{1}&{2}&{3}&{4}" : "{0}^{1}^{2}^{3}^{4}",
                                SourceApplication?.ToDelimitedString(),
                                TypeOfData,
                                DataSubtype,
                                Encoding,
                                Data
                                ).TrimEnd(IsSubcomponent ? '&' : '^');
        }
    }
}
