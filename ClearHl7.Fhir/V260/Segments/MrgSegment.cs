using System;
using System.Collections.Generic;
using System.Linq;
using ClearHl7.Fhir.V260.Types;

namespace ClearHl7.Fhir.V260.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment MRG - Merge Patient Information.
    /// </summary>
    public class MrgSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "MRG";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// MRG.1 - Prior Patient Identifier List.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdWithCheckDigit> PriorPatientIdentifierList { get; set; }

        /// <summary>
        /// MRG.2 - Prior Alternate Patient ID.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdWithCheckDigit> PriorAlternatePatientId { get; set; }

        /// <summary>
        /// MRG.3 - Prior Patient Account Number.
        /// </summary>
        public ExtendedCompositeIdWithCheckDigit PriorPatientAccountNumber { get; set; }

        /// <summary>
        /// MRG.4 - Prior Patient ID.
        /// </summary>
        public ExtendedCompositeIdWithCheckDigit PriorPatientId { get; set; }

        /// <summary>
        /// MRG.5 - Prior Visit Number.
        /// </summary>
        public ExtendedCompositeIdWithCheckDigit PriorVisitNumber { get; set; }

        /// <summary>
        /// MRG.6 - Prior Alternate Visit ID.
        /// </summary>
        public ExtendedCompositeIdWithCheckDigit PriorAlternateVisitId { get; set; }

        /// <summary>
        /// MRG.7 - Prior Patient Name.
        /// </summary>
        public IEnumerable<ExtendedPersonName> PriorPatientName { get; set; }
        
        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                "{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}",
                                Id,
                                PriorPatientIdentifierList != null ? string.Join("~", PriorPatientIdentifierList.Select(x => x.ToDelimitedString())) : null,
                                PriorAlternatePatientId != null ? string.Join("~", PriorAlternatePatientId.Select(x => x.ToDelimitedString())) : null,
                                PriorPatientAccountNumber?.ToDelimitedString(),
                                PriorPatientId,
                                PriorVisitNumber?.ToDelimitedString(),
                                PriorAlternateVisitId?.ToDelimitedString(),
                                PriorPatientName != null ? string.Join("~", PriorPatientName.Select(x => x.ToDelimitedString())) : null
                                ).TrimEnd('|');
        }
    }
}