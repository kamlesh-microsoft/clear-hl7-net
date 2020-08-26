using System;
using System.Collections.Generic;
using System.Linq;
using ClearHl7.Fhir.V282.Types;

namespace ClearHl7.Fhir.V282.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment AFF - Professional Affiliation.
    /// </summary>
    public class AffSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "AFF";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// AFF.1 - Set ID - AFF.
        /// </summary>
        public uint? SetIdAff { get; set; }

        /// <summary>
        /// AFF.2 - Professional Organization.
        /// </summary>
        public ExtendedCompositeNameAndIdNumberForOrganizations ProfessionalOrganization { get; set; }

        /// <summary>
        /// AFF.3 - Professional Organization Address.
        /// </summary>
        public ExtendedAddress ProfessionalOrganizationAddress { get; set; }

        /// <summary>
        /// AFF.4 - Professional Organization Affiliation Date Range.
        /// </summary>
        public IEnumerable<DateTimeRange> ProfessionalOrganizationAffiliationDateRange { get; set; }

        /// <summary>
        /// AFF.5 - Professional Affiliation Additional Information.
        /// </summary>
        public string ProfessionalAffiliationAdditionalInformation { get; set; }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                "{0}|{1}|{2}|{3}|{4}|{5}",
                                Id,
                                SetIdAff.HasValue ? SetIdAff.Value.ToString(culture) : null,
                                ProfessionalOrganization?.ToDelimitedString(),
                                ProfessionalOrganizationAddress?.ToDelimitedString(),
                                ProfessionalOrganizationAffiliationDateRange != null ? string.Join("~", ProfessionalOrganizationAffiliationDateRange.Select(x => x.ToDelimitedString())) : null,
                                ProfessionalAffiliationAdditionalInformation
                                ).TrimEnd('|');
        }
    }
}