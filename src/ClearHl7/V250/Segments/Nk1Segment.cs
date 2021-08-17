﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V250.Types;

namespace ClearHl7.V250.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment NK1 - Next Of Kin   Associated Parties.
    /// </summary>
    public class Nk1Segment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "NK1";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// NK1.1 - Set ID - NK1.
        /// </summary>
        public uint? SetIdNk1 { get; set; }

        /// <summary>
        /// NK1.2 - Name.
        /// </summary>
        public IEnumerable<ExtendedPersonName> Name { get; set; }

        /// <summary>
        /// NK1.3 - Relationship.
        /// <para>Suggested: 0063 Relationship -&gt; ClearHl7.Codes.V250.CodeRelationship</para>
        /// </summary>
        public CodedElement Relationship { get; set; }

        /// <summary>
        /// NK1.4 - Address.
        /// </summary>
        public IEnumerable<ExtendedAddress> Address { get; set; }

        /// <summary>
        /// NK1.5 - Phone Number.
        /// </summary>
        public IEnumerable<ExtendedTelecommunicationNumber> PhoneNumber { get; set; }

        /// <summary>
        /// NK1.6 - Business Phone Number.
        /// </summary>
        public IEnumerable<ExtendedTelecommunicationNumber> BusinessPhoneNumber { get; set; }

        /// <summary>
        /// NK1.7 - Contact Role.
        /// <para>Suggested: 0131 Contact Role -&gt; ClearHl7.Codes.V250.CodeContactRole</para>
        /// </summary>
        public CodedElement ContactRole { get; set; }

        /// <summary>
        /// NK1.8 - Start Date.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// NK1.9 - End Date.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// NK1.10 - Next of Kin / Associated Parties Job Title.
        /// </summary>
        public string NextOfKinAssociatedPartiesJobTitle { get; set; }

        /// <summary>
        /// NK1.11 - Next of Kin / Associated Parties Job Code/Class.
        /// </summary>
        public JobCodeClass NextOfKinAssociatedPartiesJobCodeClass { get; set; }

        /// <summary>
        /// NK1.12 - Next of Kin / Associated Parties Employee Number.
        /// </summary>
        public ExtendedCompositeIdWithCheckDigit NextOfKinAssociatedPartiesEmployeeNumber { get; set; }

        /// <summary>
        /// NK1.13 - Organization Name - NK1.
        /// </summary>
        public IEnumerable<ExtendedCompositeNameAndIdNumberForOrganizations> OrganizationNameNk1 { get; set; }

        /// <summary>
        /// NK1.14 - Marital Status.
        /// <para>Suggested: 0002 Marital Status -&gt; ClearHl7.Codes.V250.CodeMaritalStatus</para>
        /// </summary>
        public CodedElement MaritalStatus { get; set; }

        /// <summary>
        /// NK1.15 - Administrative Sex.
        /// <para>Suggested: 0001 Administrative Sex -&gt; ClearHl7.Codes.V250.CodeAdministrativeSex</para>
        /// </summary>
        public string AdministrativeSex { get; set; }

        /// <summary>
        /// NK1.16 - Date/Time of Birth.
        /// </summary>
        public DateTime? DateTimeOfBirth { get; set; }

        /// <summary>
        /// NK1.17 - Living Dependency.
        /// <para>Suggested: 0223 Living Dependency -&gt; ClearHl7.Codes.V250.CodeLivingDependency</para>
        /// </summary>
        public IEnumerable<string> LivingDependency { get; set; }

        /// <summary>
        /// NK1.18 - Ambulatory Status.
        /// <para>Suggested: 0009 Ambulatory Status -&gt; ClearHl7.Codes.V250.CodeAmbulatoryStatus</para>
        /// </summary>
        public IEnumerable<string> AmbulatoryStatus { get; set; }

        /// <summary>
        /// NK1.19 - Citizenship.
        /// <para>Suggested: 0171 Citizenship</para>
        /// </summary>
        public IEnumerable<CodedElement> Citizenship { get; set; }

        /// <summary>
        /// NK1.20 - Primary Language.
        /// <para>Suggested: 0296 Primary Language</para>
        /// </summary>
        public CodedElement PrimaryLanguage { get; set; }

        /// <summary>
        /// NK1.21 - Living Arrangement.
        /// <para>Suggested: 0220 Living Arrangement -&gt; ClearHl7.Codes.V250.CodeLivingArrangement</para>
        /// </summary>
        public string LivingArrangement { get; set; }

        /// <summary>
        /// NK1.22 - Publicity Code.
        /// <para>Suggested: 0215 Publicity Code -&gt; ClearHl7.Codes.V250.CodePublicityCode</para>
        /// </summary>
        public CodedElement PublicityCode { get; set; }

        /// <summary>
        /// NK1.23 - Protection Indicator.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V250.CodeYesNoIndicator</para>
        /// </summary>
        public string ProtectionIndicator { get; set; }

        /// <summary>
        /// NK1.24 - Student Indicator.
        /// <para>Suggested: 0231 Student Status -&gt; ClearHl7.Codes.V250.CodeStudentStatus</para>
        /// </summary>
        public string StudentIndicator { get; set; }

        /// <summary>
        /// NK1.25 - Religion.
        /// <para>Suggested: 0006 Religion -&gt; ClearHl7.Codes.V250.CodeReligion</para>
        /// </summary>
        public CodedElement Religion { get; set; }

        /// <summary>
        /// NK1.26 - Mother's Maiden Name.
        /// </summary>
        public IEnumerable<ExtendedPersonName> MothersMaidenName { get; set; }

        /// <summary>
        /// NK1.27 - Nationality.
        /// <para>Suggested: 0212 Nationality</para>
        /// </summary>
        public CodedElement Nationality { get; set; }

        /// <summary>
        /// NK1.28 - Ethnic Group.
        /// <para>Suggested: 0189 Ethnic Group -&gt; ClearHl7.Codes.V250.CodeEthnicGroup</para>
        /// </summary>
        public IEnumerable<CodedElement> EthnicGroup { get; set; }

        /// <summary>
        /// NK1.29 - Contact Reason.
        /// <para>Suggested: 0222 Contact Reason</para>
        /// </summary>
        public IEnumerable<CodedElement> ContactReason { get; set; }

        /// <summary>
        /// NK1.30 - Contact Person's Name.
        /// </summary>
        public IEnumerable<ExtendedPersonName> ContactPersonsName { get; set; }

        /// <summary>
        /// NK1.31 - Contact Person's Telephone Number.
        /// </summary>
        public IEnumerable<ExtendedTelecommunicationNumber> ContactPersonsTelephoneNumber { get; set; }

        /// <summary>
        /// NK1.32 - Contact Person's Address.
        /// </summary>
        public IEnumerable<ExtendedAddress> ContactPersonsAddress { get; set; }

        /// <summary>
        /// NK1.33 - Next of Kin/Associated Party's Identifiers.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdWithCheckDigit> NextOfKinAssociatedPartysIdentifiers { get; set; }

        /// <summary>
        /// NK1.34 - Job Status.
        /// <para>Suggested: 0311 Job Status -&gt; ClearHl7.Codes.V250.CodeJobStatus</para>
        /// </summary>
        public string JobStatus { get; set; }

        /// <summary>
        /// NK1.35 - Race.
        /// <para>Suggested: 0005 Race -&gt; ClearHl7.Codes.V250.CodeRace</para>
        /// </summary>
        public IEnumerable<CodedElement> Race { get; set; }

        /// <summary>
        /// NK1.36 - Handicap.
        /// <para>Suggested: 0295 Handicap</para>
        /// </summary>
        public string Handicap { get; set; }

        /// <summary>
        /// NK1.37 - Contact Person Social Security Number.
        /// </summary>
        public string ContactPersonSocialSecurityNumber { get; set; }

        /// <summary>
        /// NK1.38 - Next of Kin Birth Place.
        /// </summary>
        public string NextOfKinBirthPlace { get; set; }

        /// <summary>
        /// NK1.39 - VIP Indicator.
        /// <para>Suggested: 0099 VIP Indicator</para>
        /// </summary>
        public string VipIndicator { get; set; }

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

            SetIdNk1 = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableUInt() : null;
            Name = segments.Length > 2 && segments[2].Length > 0 ? segments[2].Split(separator).Select(x => TypeHelper.Deserialize<ExtendedPersonName>(x, false)) : null;
            Relationship = segments.Length > 3 && segments[3].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[3], false) : null;
            Address = segments.Length > 4 && segments[4].Length > 0 ? segments[4].Split(separator).Select(x => TypeHelper.Deserialize<ExtendedAddress>(x, false)) : null;
            PhoneNumber = segments.Length > 5 && segments[5].Length > 0 ? segments[5].Split(separator).Select(x => TypeHelper.Deserialize<ExtendedTelecommunicationNumber>(x, false)) : null;
            BusinessPhoneNumber = segments.Length > 6 && segments[6].Length > 0 ? segments[6].Split(separator).Select(x => TypeHelper.Deserialize<ExtendedTelecommunicationNumber>(x, false)) : null;
            ContactRole = segments.Length > 7 && segments[7].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[7], false) : null;
            StartDate = segments.Length > 8 && segments[8].Length > 0 ? segments[8].ToNullableDateTime() : null;
            EndDate = segments.Length > 9 && segments[9].Length > 0 ? segments[9].ToNullableDateTime() : null;
            NextOfKinAssociatedPartiesJobTitle = segments.Length > 10 && segments[10].Length > 0 ? segments[10] : null;
            NextOfKinAssociatedPartiesJobCodeClass = segments.Length > 11 && segments[11].Length > 0 ? TypeHelper.Deserialize<JobCodeClass>(segments[11], false) : null;
            NextOfKinAssociatedPartiesEmployeeNumber = segments.Length > 12 && segments[12].Length > 0 ? TypeHelper.Deserialize<ExtendedCompositeIdWithCheckDigit>(segments[12], false) : null;
            OrganizationNameNk1 = segments.Length > 13 && segments[13].Length > 0 ? segments[13].Split(separator).Select(x => TypeHelper.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(x, false)) : null;
            MaritalStatus = segments.Length > 14 && segments[14].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[14], false) : null;
            AdministrativeSex = segments.Length > 15 && segments[15].Length > 0 ? segments[15] : null;
            DateTimeOfBirth = segments.Length > 16 && segments[16].Length > 0 ? segments[16].ToNullableDateTime() : null;
            LivingDependency = segments.Length > 17 && segments[17].Length > 0 ? segments[17].Split(separator) : null;
            AmbulatoryStatus = segments.Length > 18 && segments[18].Length > 0 ? segments[18].Split(separator) : null;
            Citizenship = segments.Length > 19 && segments[19].Length > 0 ? segments[19].Split(separator).Select(x => TypeHelper.Deserialize<CodedElement>(x, false)) : null;
            PrimaryLanguage = segments.Length > 20 && segments[20].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[20], false) : null;
            LivingArrangement = segments.Length > 21 && segments[21].Length > 0 ? segments[21] : null;
            PublicityCode = segments.Length > 22 && segments[22].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[22], false) : null;
            ProtectionIndicator = segments.Length > 23 && segments[23].Length > 0 ? segments[23] : null;
            StudentIndicator = segments.Length > 24 && segments[24].Length > 0 ? segments[24] : null;
            Religion = segments.Length > 25 && segments[25].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[25], false) : null;
            MothersMaidenName = segments.Length > 26 && segments[26].Length > 0 ? segments[26].Split(separator).Select(x => TypeHelper.Deserialize<ExtendedPersonName>(x, false)) : null;
            Nationality = segments.Length > 27 && segments[27].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[27], false) : null;
            EthnicGroup = segments.Length > 28 && segments[28].Length > 0 ? segments[28].Split(separator).Select(x => TypeHelper.Deserialize<CodedElement>(x, false)) : null;
            ContactReason = segments.Length > 29 && segments[29].Length > 0 ? segments[29].Split(separator).Select(x => TypeHelper.Deserialize<CodedElement>(x, false)) : null;
            ContactPersonsName = segments.Length > 30 && segments[30].Length > 0 ? segments[30].Split(separator).Select(x => TypeHelper.Deserialize<ExtendedPersonName>(x, false)) : null;
            ContactPersonsTelephoneNumber = segments.Length > 31 && segments[31].Length > 0 ? segments[31].Split(separator).Select(x => TypeHelper.Deserialize<ExtendedTelecommunicationNumber>(x, false)) : null;
            ContactPersonsAddress = segments.Length > 32 && segments[32].Length > 0 ? segments[32].Split(separator).Select(x => TypeHelper.Deserialize<ExtendedAddress>(x, false)) : null;
            NextOfKinAssociatedPartysIdentifiers = segments.Length > 33 && segments[33].Length > 0 ? segments[33].Split(separator).Select(x => TypeHelper.Deserialize<ExtendedCompositeIdWithCheckDigit>(x, false)) : null;
            JobStatus = segments.Length > 34 && segments[34].Length > 0 ? segments[34] : null;
            Race = segments.Length > 35 && segments[35].Length > 0 ? segments[35].Split(separator).Select(x => TypeHelper.Deserialize<CodedElement>(x, false)) : null;
            Handicap = segments.Length > 36 && segments[36].Length > 0 ? segments[36] : null;
            ContactPersonSocialSecurityNumber = segments.Length > 37 && segments[37].Length > 0 ? segments[37] : null;
            NextOfKinBirthPlace = segments.Length > 38 && segments[38].Length > 0 ? segments[38] : null;
            VipIndicator = segments.Length > 39 && segments[39].Length > 0 ? segments[39] : null;
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
                                StringHelper.StringFormatSequence(0, 40, Configuration.FieldSeparator),
                                Id,
                                SetIdNk1.HasValue ? SetIdNk1.Value.ToString(culture) : null,
                                Name != null ? string.Join(Configuration.FieldRepeatSeparator, Name.Select(x => x.ToDelimitedString())) : null,
                                Relationship?.ToDelimitedString(),
                                Address != null ? string.Join(Configuration.FieldRepeatSeparator, Address.Select(x => x.ToDelimitedString())) : null,
                                PhoneNumber != null ? string.Join(Configuration.FieldRepeatSeparator, PhoneNumber.Select(x => x.ToDelimitedString())) : null,
                                BusinessPhoneNumber != null ? string.Join(Configuration.FieldRepeatSeparator, BusinessPhoneNumber.Select(x => x.ToDelimitedString())) : null,
                                ContactRole?.ToDelimitedString(),
                                StartDate.HasValue ? StartDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                EndDate.HasValue ? EndDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                NextOfKinAssociatedPartiesJobTitle,
                                NextOfKinAssociatedPartiesJobCodeClass?.ToDelimitedString(),
                                NextOfKinAssociatedPartiesEmployeeNumber?.ToDelimitedString(),
                                OrganizationNameNk1 != null ? string.Join(Configuration.FieldRepeatSeparator, OrganizationNameNk1.Select(x => x.ToDelimitedString())) : null,
                                MaritalStatus?.ToDelimitedString(),
                                AdministrativeSex,
                                DateTimeOfBirth.HasValue ? DateTimeOfBirth.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                LivingDependency != null ? string.Join(Configuration.FieldRepeatSeparator, LivingDependency) : null,
                                AmbulatoryStatus != null ? string.Join(Configuration.FieldRepeatSeparator, AmbulatoryStatus) : null,
                                Citizenship != null ? string.Join(Configuration.FieldRepeatSeparator, Citizenship.Select(x => x.ToDelimitedString())) : null,
                                PrimaryLanguage?.ToDelimitedString(),
                                LivingArrangement,
                                PublicityCode?.ToDelimitedString(),
                                ProtectionIndicator,
                                StudentIndicator,
                                Religion?.ToDelimitedString(),
                                MothersMaidenName != null ? string.Join(Configuration.FieldRepeatSeparator, MothersMaidenName.Select(x => x.ToDelimitedString())) : null,
                                Nationality?.ToDelimitedString(),
                                EthnicGroup != null ? string.Join(Configuration.FieldRepeatSeparator, EthnicGroup.Select(x => x.ToDelimitedString())) : null,
                                ContactReason != null ? string.Join(Configuration.FieldRepeatSeparator, ContactReason.Select(x => x.ToDelimitedString())) : null,
                                ContactPersonsName != null ? string.Join(Configuration.FieldRepeatSeparator, ContactPersonsName.Select(x => x.ToDelimitedString())) : null,
                                ContactPersonsTelephoneNumber != null ? string.Join(Configuration.FieldRepeatSeparator, ContactPersonsTelephoneNumber.Select(x => x.ToDelimitedString())) : null,
                                ContactPersonsAddress != null ? string.Join(Configuration.FieldRepeatSeparator, ContactPersonsAddress.Select(x => x.ToDelimitedString())) : null,
                                NextOfKinAssociatedPartysIdentifiers != null ? string.Join(Configuration.FieldRepeatSeparator, NextOfKinAssociatedPartysIdentifiers.Select(x => x.ToDelimitedString())) : null,
                                JobStatus,
                                Race != null ? string.Join(Configuration.FieldRepeatSeparator, Race.Select(x => x.ToDelimitedString())) : null,
                                Handicap,
                                ContactPersonSocialSecurityNumber,
                                NextOfKinBirthPlace,
                                VipIndicator
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}