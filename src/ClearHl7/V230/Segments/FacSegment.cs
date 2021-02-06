﻿using System.Collections.Generic;
using System.Linq;
using ClearHl7.Helpers;
using ClearHl7.V230.Types;

namespace ClearHl7.V230.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment FAC - Facility.
    /// </summary>
    public class FacSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "FAC";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// FAC.1 - Facility ID-FAC.
        /// </summary>
        public EntityIdentifier FacilityIdFac { get; set; }

        /// <summary>
        /// FAC.2 - Facility Type.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0331</remarks>
        public string FacilityType { get; set; }

        /// <summary>
        /// FAC.3 - Facility Address.
        /// </summary>
        public ExtendedAddress FacilityAddress { get; set; }

        /// <summary>
        /// FAC.4 - Facility Telecommunication.
        /// </summary>
        public ExtendedTelecommunicationNumber FacilityTelecommunication { get; set; }

        /// <summary>
        /// FAC.5 - Contact Person.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> ContactPerson { get; set; }

        /// <summary>
        /// FAC.6 - Contact Title.
        /// </summary>
        public IEnumerable<string> ContactTitle { get; set; }

        /// <summary>
        /// FAC.7 - Contact Address.
        /// </summary>
        public IEnumerable<ExtendedAddress> ContactAddress { get; set; }

        /// <summary>
        /// FAC.8 - Contact Telecommunication.
        /// </summary>
        public IEnumerable<ExtendedTelecommunicationNumber> ContactTelecommunication { get; set; }

        /// <summary>
        /// FAC.9 - Signature Authority.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons SignatureAuthority { get; set; }

        /// <summary>
        /// FAC.10 - Signature Authority Title.
        /// </summary>
        public string SignatureAuthorityTitle { get; set; }

        /// <summary>
        /// FAC.11 - Signature Authority Address.
        /// </summary>
        public ExtendedAddress SignatureAuthorityAddress { get; set; }

        /// <summary>
        /// FAC.12 - Signature Authority Telecommunication.
        /// </summary>
        public ExtendedTelecommunicationNumber SignatureAuthorityTelecommunication { get; set; }
        
        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 13, Configuration.FieldSeparator),
                                Id,
                                FacilityIdFac?.ToDelimitedString(),
                                FacilityType,
                                FacilityAddress?.ToDelimitedString(),
                                FacilityTelecommunication?.ToDelimitedString(),
                                ContactPerson != null ? string.Join(Configuration.FieldRepeatSeparator, ContactPerson.Select(x => x.ToDelimitedString())) : null,
                                ContactTitle != null ? string.Join(Configuration.FieldRepeatSeparator, ContactTitle) : null,
                                ContactAddress != null ? string.Join(Configuration.FieldRepeatSeparator, ContactAddress.Select(x => x.ToDelimitedString())) : null,
                                ContactTelecommunication != null ? string.Join(Configuration.FieldRepeatSeparator, ContactTelecommunication.Select(x => x.ToDelimitedString())) : null,
                                SignatureAuthority?.ToDelimitedString(),
                                SignatureAuthorityTitle,
                                SignatureAuthorityAddress?.ToDelimitedString(),
                                SignatureAuthorityTelecommunication?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}