using System;
using System.Collections.Generic;
using System.Linq;
using ClearHl7.Fhir.V270.Types;

namespace ClearHl7.Fhir.V270.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment PAC - Shipment Package.
    /// </summary>
    public class PacSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "PAC";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// PAC.1 - Set Id - PAC.
        /// </summary>
        public uint? SetIdPac { get; set; }

        /// <summary>
        /// PAC.2 - Package ID.
        /// </summary>
        public EntityIdentifier PackageId { get; set; }

        /// <summary>
        /// PAC.3 - Parent Package ID.
        /// </summary>
        public EntityIdentifier ParentPackageId { get; set; }

        /// <summary>
        /// PAC.4 - Position in Parent Package.
        /// </summary>
        public NumericArray PositionInParentPackage { get; set; }

        /// <summary>
        /// PAC.5 - Package Type.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0908</remarks>
        public CodedWithExceptions PackageType { get; set; }

        /// <summary>
        /// PAC.6 - Package Condition.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0544</remarks>
        public IEnumerable<CodedWithExceptions> PackageCondition { get; set; }

        /// <summary>
        /// PAC.7 - Package Handling Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0376</remarks>
        public IEnumerable<CodedWithExceptions> PackageHandlingCode { get; set; }

        /// <summary>
        /// PAC.8 - Package Risk Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0489</remarks>
        public IEnumerable<CodedWithExceptions> PackageRiskCode { get; set; }
        
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
                                SetIdPac.HasValue ? SetIdPac.Value.ToString(culture) : null,
                                PackageId?.ToDelimitedString(),
                                ParentPackageId?.ToDelimitedString(),
                                PositionInParentPackage?.ToDelimitedString(),
                                PackageType?.ToDelimitedString(),
                                PackageCondition != null ? string.Join("~", PackageCondition.Select(x => x.ToDelimitedString())) : null,
                                PackageHandlingCode != null ? string.Join("~", PackageHandlingCode.Select(x => x.ToDelimitedString())) : null,
                                PackageRiskCode != null ? string.Join("~", PackageRiskCode.Select(x => x.ToDelimitedString())) : null
                                ).TrimEnd('|');
        }
    }
}