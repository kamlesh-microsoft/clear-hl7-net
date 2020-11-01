using System;
using System.Collections.Generic;
using ClearHl7.Fhir.V270.Types;

namespace ClearHl7.Fhir.V270.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment NTE - Notes And Comments.
    /// </summary>
    public class NteSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "NTE";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// NTE.1 - Set ID - NTE.
        /// </summary>
        public uint? SetIdNte { get; set; }

        /// <summary>
        /// NTE.2 - Source of Comment.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0105</remarks>
        public string SourceOfComment { get; set; }

        /// <summary>
        /// NTE.3 - Comment.
        /// </summary>
        public IEnumerable<string> Comment { get; set; }

        /// <summary>
        /// NTE.4 - Comment Type.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0364</remarks>
        public CodedWithExceptions CommentType { get; set; }

        /// <summary>
        /// NTE.5 - Entered By.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons EnteredBy { get; set; }

        /// <summary>
        /// NTE.6 - Entered Date/Time.
        /// </summary>
        public DateTime? EnteredDateTime { get; set; }

        /// <summary>
        /// NTE.7 - Effective Start Date.
        /// </summary>
        public DateTime? EffectiveStartDate { get; set; }

        /// <summary>
        /// NTE.8 - Expiration Date.
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
                                "{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}",
                                Id,
                                SetIdNte.HasValue ? SetIdNte.Value.ToString(culture) : null,
                                SourceOfComment,
                                Comment != null ? string.Join("~", Comment) : null,
                                CommentType?.ToDelimitedString(),
                                EnteredBy?.ToDelimitedString(),
                                EnteredDateTime.HasValue ? EnteredDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                EffectiveStartDate.HasValue ? EffectiveStartDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ExpirationDate.HasValue ? ExpirationDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null
                                ).TrimEnd('|');
        }
    }
}