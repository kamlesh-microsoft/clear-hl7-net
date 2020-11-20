﻿using System;
using ClearHl7.Fhir.V250.Types;

namespace ClearHl7.Fhir.V250.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment EQL - Embedded Query Language.
    /// </summary>
    public class EqlSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "EQL";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// EQL.1 - Query Tag.
        /// </summary>
        public string QueryTag { get; set; }

        /// <summary>
        /// EQL.2 - Query/Response Format Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0106</remarks>
        public string QueryResponseFormatCode { get; set; }

        /// <summary>
        /// EQL.3 - EQL Query Name.
        /// </summary>
        public CodedElement EqlQueryName { get; set; }

        /// <summary>
        /// EQL.4 - EQL Query Statement.
        /// </summary>
        public string EqlQueryStatement { get; set; }
        
        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                "{0}|{1}|{2}|{3}|{4}",
                                Id,
                                QueryTag,
                                QueryResponseFormatCode,
                                EqlQueryName?.ToDelimitedString(),
                                EqlQueryStatement
                                ).TrimEnd('|');
        }
    }
}