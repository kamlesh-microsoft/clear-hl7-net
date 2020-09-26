﻿using System;

namespace ClearHl7.Fhir.V260.Types
{
    /// <summary>
    /// HL7 Version 2 CP - Composite Price.
    /// </summary>
    public class CompositePrice : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// CP.1 - Price.
        /// </summary>
        public Money Price { get; set; }

        /// <summary>
        /// CP.2 - Price Type.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0205</remarks>
        public string PriceType { get; set; }

        /// <summary>
        /// CP.3 - From Value.
        /// </summary>
        public decimal? FromValue { get; set; }

        /// <summary>
        /// CP.4 - To Value.
        /// </summary>
        public decimal? ToValue { get; set; }

        /// <summary>
        /// CP.5 - Range Units.
        /// </summary>
        public CodedWithExceptions RangeUnits { get; set; }

        /// <summary>
        /// CP.6 - Range Type.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0298</remarks>
        public string RangeType { get; set; }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                IsSubcomponent ? "{0}&{1}&{2}&{3}&{4}&{5}" : "{0}^{1}^{2}^{3}^{4}^{5}",
                                Price?.ToDelimitedString(),
                                PriceType,
                                FromValue.HasValue ? FromValue.Value.ToString(Consts.NumericFormat, culture) : null,
                                ToValue.HasValue ? ToValue.Value.ToString(Consts.NumericFormat, culture) : null,
                                RangeUnits?.ToDelimitedString(),
                                RangeType
                                ).TrimEnd(IsSubcomponent ? '&' : '^');
        }
    }
}