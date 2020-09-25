﻿using System;

namespace ClearHl7.Fhir.V260.Types
{
    /// <summary>
    /// HL7 Version 2 SPD - Specialty Description.
    /// </summary>
    public class SpecialtyDescription : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// SPD.1 - Specialty Name.
        /// </summary>
        public string SpecialtyName { get; set; }

        /// <summary>
        /// SPD.2 - Governing Board.
        /// </summary>
        public string GoverningBoard { get; set; }

        /// <summary>
        /// SPD.3 - Eligible or Certified.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0337</remarks>
        public string EligibleOrCertified { get; set; }

        /// <summary>
        /// SPD.4 - Date of Certification.
        /// </summary>
        public DateTime? DateOfCertification { get; set; }

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
                                SpecialtyName,
                                GoverningBoard,
                                EligibleOrCertified,
                                DateOfCertification.HasValue ? DateOfCertification.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null
                                ).TrimEnd(IsSubcomponent ? '&' : '^');
        }
    }
}
