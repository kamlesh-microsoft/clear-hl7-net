﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V231.Types;

namespace ClearHl7.V231.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment PRA - Practitioner Detail.
    /// </summary>
    public class PraSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "PRA";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// PRA.1 - Primary Key Value - PRA.
        /// </summary>
        public CodedElement PrimaryKeyValuePra { get; set; }

        /// <summary>
        /// PRA.2 - Practitioner Group.
        /// <para>Suggested: 0358 Practitioner Group</para>
        /// </summary>
        public IEnumerable<CodedElement> PractitionerGroup { get; set; }

        /// <summary>
        /// PRA.3 - Practitioner Category.
        /// <para>Suggested: 0186 Practitioner Category</para>
        /// </summary>
        public IEnumerable<string> PractitionerCategory { get; set; }

        /// <summary>
        /// PRA.4 - Provider Billing.
        /// <para>Suggested: 0187 Provider Billing -&gt; ClearHl7.Codes.V231.CodeProviderBilling</para>
        /// </summary>
        public string ProviderBilling { get; set; }

        /// <summary>
        /// PRA.5 - Specialty.
        /// <para>Suggested: 0337 Certification Status -&gt; ClearHl7.Codes.V231.CodeCertificationStatus</para>
        /// </summary>
        public IEnumerable<SpecialtyDescription> Specialty { get; set; }

        /// <summary>
        /// PRA.6 - Practitioner ID Numbers.
        /// <para>Suggested: 0338 Practitioner ID Number Type -&gt; ClearHl7.Codes.V231.CodePractitionerIdNumberType</para>
        /// </summary>
        public IEnumerable<PractitionerLicenseOrOtherIdNumber> PractitionerIdNumbers { get; set; }

        /// <summary>
        /// PRA.7 - Privileges.
        /// </summary>
        public IEnumerable<PractitionerInstitutionalPrivileges> Privileges { get; set; }

        /// <summary>
        /// PRA.8 - Date Entered Practice.
        /// </summary>
        public DateTime? DateEnteredPractice { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <exception cref="ArgumentException">delimitedString does not begin with the proper segment Id.</exception>
        public void FromDelimitedString(string delimitedString)
        {
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(Configuration.FieldSeparator.ToCharArray());
            char[] separator = Configuration.FieldRepeatSeparator.ToCharArray();

            if (segments.Length > 0)
            {
                if (string.Compare(Id, segments[0], true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ Configuration.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            PrimaryKeyValuePra = segments.Length > 1 && segments[1].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[1], false) : null;
            PractitionerGroup = segments.Length > 2 && segments[2].Length > 0 ? segments[2].Split(separator).Select(x => TypeHelper.Deserialize<CodedElement>(x, false)) : null;
            PractitionerCategory = segments.Length > 3 && segments[3].Length > 0 ? segments[3].Split(separator) : null;
            ProviderBilling = segments.Length > 4 && segments[4].Length > 0 ? segments[4] : null;
            Specialty = segments.Length > 5 && segments[5].Length > 0 ? segments[5].Split(separator).Select(x => TypeHelper.Deserialize<SpecialtyDescription>(x, false)) : null;
            PractitionerIdNumbers = segments.Length > 6 && segments[6].Length > 0 ? segments[6].Split(separator).Select(x => TypeHelper.Deserialize<PractitionerLicenseOrOtherIdNumber>(x, false)) : null;
            Privileges = segments.Length > 7 && segments[7].Length > 0 ? segments[7].Split(separator).Select(x => TypeHelper.Deserialize<PractitionerInstitutionalPrivileges>(x, false)) : null;
            DateEnteredPractice = segments.Length > 8 && segments[8].Length > 0 ? segments[8].ToNullableDateTime() : null;
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
                                StringHelper.StringFormatSequence(0, 9, Configuration.FieldSeparator),
                                Id,
                                PrimaryKeyValuePra?.ToDelimitedString(),
                                PractitionerGroup != null ? string.Join(Configuration.FieldRepeatSeparator, PractitionerGroup.Select(x => x.ToDelimitedString())) : null,
                                PractitionerCategory != null ? string.Join(Configuration.FieldRepeatSeparator, PractitionerCategory) : null,
                                ProviderBilling,
                                Specialty != null ? string.Join(Configuration.FieldRepeatSeparator, Specialty.Select(x => x.ToDelimitedString())) : null,
                                PractitionerIdNumbers != null ? string.Join(Configuration.FieldRepeatSeparator, PractitionerIdNumbers.Select(x => x.ToDelimitedString())) : null,
                                Privileges != null ? string.Join(Configuration.FieldRepeatSeparator, Privileges.Select(x => x.ToDelimitedString())) : null,
                                DateEnteredPractice.HasValue ? DateEnteredPractice.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}