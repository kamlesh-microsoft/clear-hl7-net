﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V281.Types;

namespace ClearHl7.V281.Segments
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
        /// Initializes properties of this instance with values parsed from the given delimited string.  Separators defined in the Configuration class are used to split the string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <exception cref="ArgumentException">delimitedString does not begin with the proper segment Id.</exception>
        public void FromDelimitedString(string delimitedString)
        {
            FromDelimitedString(delimitedString, null);
        }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.  The provided separators are used to split the string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <param name="separators">The separators to use for splitting the string.</param>
        /// <exception cref="ArgumentException">delimitedString does not begin with the proper segment Id.</exception>
        public void FromDelimitedString(string delimitedString, Separators separators)
        {
            Separators seps = separators ?? new Separators().UsingConfigurationValues();
            string[] segments = delimitedString == null
                ? Array.Empty<string>()
                : delimitedString.Split(seps.FieldSeparator, StringSplitOptions.None);
            
            if (segments.Length > 0)
            {
                if (string.Compare(Id, segments[0], true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ seps.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            SetIdAff = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableUInt() : null;
            ProfessionalOrganization = segments.Length > 2 && segments[2].Length > 0 ? TypeSerializer.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(segments[2], false, seps) : null;
            ProfessionalOrganizationAddress = segments.Length > 3 && segments[3].Length > 0 ? TypeSerializer.Deserialize<ExtendedAddress>(segments[3], false, seps) : null;
            ProfessionalOrganizationAffiliationDateRange = segments.Length > 4 && segments[4].Length > 0 ? segments[4].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<DateTimeRange>(x, false, seps)) : null;
            ProfessionalAffiliationAdditionalInformation = segments.Length > 5 && segments[5].Length > 0 ? segments[5] : null;
        }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 6, Configuration.FieldSeparator),
                                Id,
                                SetIdAff.HasValue ? SetIdAff.Value.ToString(culture) : null,
                                ProfessionalOrganization?.ToDelimitedString(),
                                ProfessionalOrganizationAddress?.ToDelimitedString(),
                                ProfessionalOrganizationAffiliationDateRange != null ? string.Join(Configuration.FieldRepeatSeparator, ProfessionalOrganizationAffiliationDateRange.Select(x => x.ToDelimitedString())) : null,
                                ProfessionalAffiliationAdditionalInformation
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}