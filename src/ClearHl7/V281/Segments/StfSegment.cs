﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V281.Types;

namespace ClearHl7.V281.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment STF - Staff Identification.
    /// </summary>
    public class StfSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "STF";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// STF.1 - Primary Key Value - STF.
        /// </summary>
        public CodedWithExceptions PrimaryKeyValueStf { get; set; }

        /// <summary>
        /// STF.2 - Staff Identifier List.
        /// <para>Suggested: 0061 Check Digit Scheme -&gt; ClearHl7.Codes.V281.CodeCheckDigitScheme</para>
        /// </summary>
        public IEnumerable<ExtendedCompositeIdWithCheckDigit> StaffIdentifierList { get; set; }

        /// <summary>
        /// STF.3 - Staff Name.
        /// </summary>
        public IEnumerable<ExtendedPersonName> StaffName { get; set; }

        /// <summary>
        /// STF.4 - Staff Type.
        /// <para>Suggested: 0182 Staff Type</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> StaffType { get; set; }

        /// <summary>
        /// STF.5 - Administrative Sex.
        /// <para>Suggested: 0001 Administrative Sex -&gt; ClearHl7.Codes.V281.CodeAdministrativeSex</para>
        /// </summary>
        public CodedWithExceptions AdministrativeSex { get; set; }

        /// <summary>
        /// STF.6 - Date/Time of Birth.
        /// </summary>
        public DateTime? DateTimeOfBirth { get; set; }

        /// <summary>
        /// STF.7 - Active/Inactive Flag.
        /// <para>Suggested: 0183 Active/Inactive -&gt; ClearHl7.Codes.V281.CodeActiveInactive</para>
        /// </summary>
        public string ActiveInactiveFlag { get; set; }

        /// <summary>
        /// STF.8 - Department.
        /// <para>Suggested: 0184 Department</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> Department { get; set; }

        /// <summary>
        /// STF.9 - Hospital Service - STF.
        /// <para>Suggested: 0069 Hospital Service -&gt; ClearHl7.Codes.V281.CodeHospitalService</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> HospitalServiceStf { get; set; }

        /// <summary>
        /// STF.10 - Phone.
        /// </summary>
        public IEnumerable<ExtendedTelecommunicationNumber> Phone { get; set; }

        /// <summary>
        /// STF.11 - Office/Home Address/Birthplace.
        /// </summary>
        public IEnumerable<ExtendedAddress> OfficeHomeAddressBirthplace { get; set; }

        /// <summary>
        /// STF.12 - Institution Activation Date.
        /// <para>Suggested: 0537 Institution</para>
        /// </summary>
        public IEnumerable<DateAndInstitutionName> InstitutionActivationDate { get; set; }

        /// <summary>
        /// STF.13 - Institution Inactivation Date.
        /// <para>Suggested: 0537 Institution</para>
        /// </summary>
        public IEnumerable<DateAndInstitutionName> InstitutionInactivationDate { get; set; }

        /// <summary>
        /// STF.14 - Backup Person ID.
        /// </summary>
        public IEnumerable<CodedWithExceptions> BackupPersonId { get; set; }

        /// <summary>
        /// STF.15 - E-Mail Address.
        /// </summary>
        public IEnumerable<string> EmailAddress { get; set; }

        /// <summary>
        /// STF.16 - Preferred Method of Contact.
        /// <para>Suggested: 0185 Preferred Method Of Contact -&gt; ClearHl7.Codes.V281.CodePreferredMethodOfContact</para>
        /// </summary>
        public CodedWithExceptions PreferredMethodOfContact { get; set; }

        /// <summary>
        /// STF.17 - Marital Status.
        /// <para>Suggested: 0002 Marital Status -&gt; ClearHl7.Codes.V281.CodeMaritalStatus</para>
        /// </summary>
        public CodedWithExceptions MaritalStatus { get; set; }

        /// <summary>
        /// STF.18 - Job Title.
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// STF.19 - Job Code/Class.
        /// </summary>
        public JobCodeClass JobCodeClass { get; set; }

        /// <summary>
        /// STF.20 - Employment Status Code.
        /// <para>Suggested: 0066 Employment Status -&gt; ClearHl7.Codes.V281.CodeEmploymentStatus</para>
        /// </summary>
        public CodedWithExceptions EmploymentStatusCode { get; set; }

        /// <summary>
        /// STF.21 - Additional Insured on Auto.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V281.CodeYesNoIndicator</para>
        /// </summary>
        public string AdditionalInsuredOnAuto { get; set; }

        /// <summary>
        /// STF.22 - Driver's License Number - Staff.
        /// </summary>
        public DriversLicenseNumber DriversLicenseNumberStaff { get; set; }

        /// <summary>
        /// STF.23 - Copy Auto Ins.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V281.CodeYesNoIndicator</para>
        /// </summary>
        public string CopyAutoIns { get; set; }

        /// <summary>
        /// STF.24 - Auto Ins Expires.
        /// </summary>
        public DateTime? AutoInsExpires { get; set; }

        /// <summary>
        /// STF.25 - Date Last DMV Review.
        /// </summary>
        public DateTime? DateLastDmvReview { get; set; }

        /// <summary>
        /// STF.26 - Date Next DMV Review.
        /// </summary>
        public DateTime? DateNextDmvReview { get; set; }

        /// <summary>
        /// STF.27 - Race.
        /// <para>Suggested: 0005 Race -&gt; ClearHl7.Codes.V281.CodeRace</para>
        /// </summary>
        public CodedWithExceptions Race { get; set; }

        /// <summary>
        /// STF.28 - Ethnic Group.
        /// <para>Suggested: 0189 Ethnic Group -&gt; ClearHl7.Codes.V281.CodeEthnicGroup</para>
        /// </summary>
        public CodedWithExceptions EthnicGroup { get; set; }

        /// <summary>
        /// STF.29 - Re-activation Approval Indicator.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V281.CodeYesNoIndicator</para>
        /// </summary>
        public string ReactivationApprovalIndicator { get; set; }

        /// <summary>
        /// STF.30 - Citizenship.
        /// <para>Suggested: 0171 Citizenship</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> Citizenship { get; set; }

        /// <summary>
        /// STF.31 - Date/Time of Death.
        /// </summary>
        public DateTime? DateTimeOfDeath { get; set; }

        /// <summary>
        /// STF.32 - Death Indicator.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V281.CodeYesNoIndicator</para>
        /// </summary>
        public string DeathIndicator { get; set; }

        /// <summary>
        /// STF.33 - Institution Relationship Type Code.
        /// <para>Suggested: 0538 Institution Relationship Type -&gt; ClearHl7.Codes.V281.CodeInstitutionRelationshipType</para>
        /// </summary>
        public CodedWithExceptions InstitutionRelationshipTypeCode { get; set; }

        /// <summary>
        /// STF.34 - Institution Relationship Period.
        /// </summary>
        public DateTimeRange InstitutionRelationshipPeriod { get; set; }

        /// <summary>
        /// STF.35 - Expected Return Date.
        /// </summary>
        public DateTime? ExpectedReturnDate { get; set; }

        /// <summary>
        /// STF.36 - Cost Center Code.
        /// <para>Suggested: 0539 Cost Center Code</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> CostCenterCode { get; set; }

        /// <summary>
        /// STF.37 - Generic Classification Indicator.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V281.CodeYesNoIndicator</para>
        /// </summary>
        public string GenericClassificationIndicator { get; set; }

        /// <summary>
        /// STF.38 - Inactive Reason Code.
        /// <para>Suggested: 0540 Inactive Reason Code -&gt; ClearHl7.Codes.V281.CodeInactiveReasonCode</para>
        /// </summary>
        public CodedWithExceptions InactiveReasonCode { get; set; }

        /// <summary>
        /// STF.39 - Generic resource type or category.
        /// <para>Suggested: 0771 Generic Resource Type Or Category</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> GenericResourceTypeOrCategory { get; set; }

        /// <summary>
        /// STF.40 - Religion.
        /// <para>Suggested: 0006 Religion -&gt; ClearHl7.Codes.V281.CodeReligion</para>
        /// </summary>
        public CodedWithExceptions Religion { get; set; }

        /// <summary>
        /// STF.41 - Signature.
        /// </summary>
        public EncapsulatedData Signature { get; set; }

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
                ? new string[] { }
                : delimitedString.Split(seps.FieldSeparator, StringSplitOptions.None);
            
            if (segments.Length > 0)
            {
                if (string.Compare(Id, segments[0], true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ seps.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            PrimaryKeyValueStf = segments.Length > 1 && segments[1].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[1], false) : null;
            StaffIdentifierList = segments.Length > 2 && segments[2].Length > 0 ? segments[2].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<ExtendedCompositeIdWithCheckDigit>(x, false)) : null;
            StaffName = segments.Length > 3 && segments[3].Length > 0 ? segments[3].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<ExtendedPersonName>(x, false)) : null;
            StaffType = segments.Length > 4 && segments[4].Length > 0 ? segments[4].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            AdministrativeSex = segments.Length > 5 && segments[5].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[5], false) : null;
            DateTimeOfBirth = segments.Length > 6 && segments[6].Length > 0 ? segments[6].ToNullableDateTime() : null;
            ActiveInactiveFlag = segments.Length > 7 && segments[7].Length > 0 ? segments[7] : null;
            Department = segments.Length > 8 && segments[8].Length > 0 ? segments[8].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            HospitalServiceStf = segments.Length > 9 && segments[9].Length > 0 ? segments[9].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            Phone = segments.Length > 10 && segments[10].Length > 0 ? segments[10].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<ExtendedTelecommunicationNumber>(x, false)) : null;
            OfficeHomeAddressBirthplace = segments.Length > 11 && segments[11].Length > 0 ? segments[11].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<ExtendedAddress>(x, false)) : null;
            InstitutionActivationDate = segments.Length > 12 && segments[12].Length > 0 ? segments[12].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<DateAndInstitutionName>(x, false)) : null;
            InstitutionInactivationDate = segments.Length > 13 && segments[13].Length > 0 ? segments[13].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<DateAndInstitutionName>(x, false)) : null;
            BackupPersonId = segments.Length > 14 && segments[14].Length > 0 ? segments[14].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            EmailAddress = segments.Length > 15 && segments[15].Length > 0 ? segments[15].Split(seps.FieldRepeatSeparator, StringSplitOptions.None) : null;
            PreferredMethodOfContact = segments.Length > 16 && segments[16].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[16], false) : null;
            MaritalStatus = segments.Length > 17 && segments[17].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[17], false) : null;
            JobTitle = segments.Length > 18 && segments[18].Length > 0 ? segments[18] : null;
            JobCodeClass = segments.Length > 19 && segments[19].Length > 0 ? TypeHelper.Deserialize<JobCodeClass>(segments[19], false) : null;
            EmploymentStatusCode = segments.Length > 20 && segments[20].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[20], false) : null;
            AdditionalInsuredOnAuto = segments.Length > 21 && segments[21].Length > 0 ? segments[21] : null;
            DriversLicenseNumberStaff = segments.Length > 22 && segments[22].Length > 0 ? TypeHelper.Deserialize<DriversLicenseNumber>(segments[22], false) : null;
            CopyAutoIns = segments.Length > 23 && segments[23].Length > 0 ? segments[23] : null;
            AutoInsExpires = segments.Length > 24 && segments[24].Length > 0 ? segments[24].ToNullableDateTime() : null;
            DateLastDmvReview = segments.Length > 25 && segments[25].Length > 0 ? segments[25].ToNullableDateTime() : null;
            DateNextDmvReview = segments.Length > 26 && segments[26].Length > 0 ? segments[26].ToNullableDateTime() : null;
            Race = segments.Length > 27 && segments[27].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[27], false) : null;
            EthnicGroup = segments.Length > 28 && segments[28].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[28], false) : null;
            ReactivationApprovalIndicator = segments.Length > 29 && segments[29].Length > 0 ? segments[29] : null;
            Citizenship = segments.Length > 30 && segments[30].Length > 0 ? segments[30].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            DateTimeOfDeath = segments.Length > 31 && segments[31].Length > 0 ? segments[31].ToNullableDateTime() : null;
            DeathIndicator = segments.Length > 32 && segments[32].Length > 0 ? segments[32] : null;
            InstitutionRelationshipTypeCode = segments.Length > 33 && segments[33].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[33], false) : null;
            InstitutionRelationshipPeriod = segments.Length > 34 && segments[34].Length > 0 ? TypeHelper.Deserialize<DateTimeRange>(segments[34], false) : null;
            ExpectedReturnDate = segments.Length > 35 && segments[35].Length > 0 ? segments[35].ToNullableDateTime() : null;
            CostCenterCode = segments.Length > 36 && segments[36].Length > 0 ? segments[36].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            GenericClassificationIndicator = segments.Length > 37 && segments[37].Length > 0 ? segments[37] : null;
            InactiveReasonCode = segments.Length > 38 && segments[38].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[38], false) : null;
            GenericResourceTypeOrCategory = segments.Length > 39 && segments[39].Length > 0 ? segments[39].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            Religion = segments.Length > 40 && segments[40].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[40], false) : null;
            Signature = segments.Length > 41 && segments[41].Length > 0 ? TypeHelper.Deserialize<EncapsulatedData>(segments[41], false) : null;
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
                                StringHelper.StringFormatSequence(0, 42, Configuration.FieldSeparator),
                                Id,
                                PrimaryKeyValueStf?.ToDelimitedString(),
                                StaffIdentifierList != null ? string.Join(Configuration.FieldRepeatSeparator, StaffIdentifierList.Select(x => x.ToDelimitedString())) : null,
                                StaffName != null ? string.Join(Configuration.FieldRepeatSeparator, StaffName.Select(x => x.ToDelimitedString())) : null,
                                StaffType != null ? string.Join(Configuration.FieldRepeatSeparator, StaffType.Select(x => x.ToDelimitedString())) : null,
                                AdministrativeSex?.ToDelimitedString(),
                                DateTimeOfBirth.HasValue ? DateTimeOfBirth.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ActiveInactiveFlag,
                                Department != null ? string.Join(Configuration.FieldRepeatSeparator, Department.Select(x => x.ToDelimitedString())) : null,
                                HospitalServiceStf != null ? string.Join(Configuration.FieldRepeatSeparator, HospitalServiceStf.Select(x => x.ToDelimitedString())) : null,
                                Phone != null ? string.Join(Configuration.FieldRepeatSeparator, Phone.Select(x => x.ToDelimitedString())) : null,
                                OfficeHomeAddressBirthplace != null ? string.Join(Configuration.FieldRepeatSeparator, OfficeHomeAddressBirthplace.Select(x => x.ToDelimitedString())) : null,
                                InstitutionActivationDate != null ? string.Join(Configuration.FieldRepeatSeparator, InstitutionActivationDate.Select(x => x.ToDelimitedString())) : null,
                                InstitutionInactivationDate != null ? string.Join(Configuration.FieldRepeatSeparator, InstitutionInactivationDate.Select(x => x.ToDelimitedString())) : null,
                                BackupPersonId != null ? string.Join(Configuration.FieldRepeatSeparator, BackupPersonId.Select(x => x.ToDelimitedString())) : null,
                                EmailAddress != null ? string.Join(Configuration.FieldRepeatSeparator, EmailAddress) : null,
                                PreferredMethodOfContact?.ToDelimitedString(),
                                MaritalStatus?.ToDelimitedString(),
                                JobTitle,
                                JobCodeClass?.ToDelimitedString(),
                                EmploymentStatusCode?.ToDelimitedString(),
                                AdditionalInsuredOnAuto,
                                DriversLicenseNumberStaff?.ToDelimitedString(),
                                CopyAutoIns,
                                AutoInsExpires.HasValue ? AutoInsExpires.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                DateLastDmvReview.HasValue ? DateLastDmvReview.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                DateNextDmvReview.HasValue ? DateNextDmvReview.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                Race?.ToDelimitedString(),
                                EthnicGroup?.ToDelimitedString(),
                                ReactivationApprovalIndicator,
                                Citizenship != null ? string.Join(Configuration.FieldRepeatSeparator, Citizenship.Select(x => x.ToDelimitedString())) : null,
                                DateTimeOfDeath.HasValue ? DateTimeOfDeath.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                DeathIndicator,
                                InstitutionRelationshipTypeCode?.ToDelimitedString(),
                                InstitutionRelationshipPeriod?.ToDelimitedString(),
                                ExpectedReturnDate.HasValue ? ExpectedReturnDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                CostCenterCode != null ? string.Join(Configuration.FieldRepeatSeparator, CostCenterCode.Select(x => x.ToDelimitedString())) : null,
                                GenericClassificationIndicator,
                                InactiveReasonCode?.ToDelimitedString(),
                                GenericResourceTypeOrCategory != null ? string.Join(Configuration.FieldRepeatSeparator, GenericResourceTypeOrCategory.Select(x => x.ToDelimitedString())) : null,
                                Religion?.ToDelimitedString(),
                                Signature?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}