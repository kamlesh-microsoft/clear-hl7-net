﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V282.Types;

namespace ClearHl7.V282.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment IAM - Patient Adverse Reaction Information.
    /// </summary>
    public class IamSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "IAM";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// IAM.1 - Set ID - IAM.
        /// </summary>
        public uint? SetIdIam { get; set; }

        /// <summary>
        /// IAM.2 - Allergen Type Code.
        /// <para>Suggested: 0127 Allergen Type -&gt; ClearHl7.Codes.V282.CodeAllergenType</para>
        /// </summary>
        public CodedWithExceptions AllergenTypeCode { get; set; }

        /// <summary>
        /// IAM.3 - Allergen Code/Mnemonic/Description.
        /// </summary>
        public CodedWithExceptions AllergenCodeMnemonicDescription { get; set; }

        /// <summary>
        /// IAM.4 - Allergy Severity Code.
        /// <para>Suggested: 0128 Allergy Severity -&gt; ClearHl7.Codes.V282.CodeAllergySeverity</para>
        /// </summary>
        public CodedWithExceptions AllergySeverityCode { get; set; }

        /// <summary>
        /// IAM.5 - Allergy Reaction Code.
        /// </summary>
        public IEnumerable<string> AllergyReactionCode { get; set; }

        /// <summary>
        /// IAM.6 - Allergy Action Code.
        /// <para>Suggested: 0206 Segment Action Code -&gt; ClearHl7.Codes.V282.CodeSegmentActionCode</para>
        /// </summary>
        public CodedWithNoExceptions AllergyActionCode { get; set; }

        /// <summary>
        /// IAM.7 - Allergy Unique Identifier.
        /// </summary>
        public EntityIdentifier AllergyUniqueIdentifier { get; set; }

        /// <summary>
        /// IAM.8 - Action Reason.
        /// </summary>
        public string ActionReason { get; set; }

        /// <summary>
        /// IAM.9 - Sensitivity to Causative Agent Code.
        /// <para>Suggested: 0436 Sensitivity To Causative Agent Code -&gt; ClearHl7.Codes.V282.CodeSensitivityToCausativeAgentCode</para>
        /// </summary>
        public CodedWithExceptions SensitivityToCausativeAgentCode { get; set; }

        /// <summary>
        /// IAM.10 - Allergen Group Code/Mnemonic/Description.
        /// </summary>
        public CodedWithExceptions AllergenGroupCodeMnemonicDescription { get; set; }

        /// <summary>
        /// IAM.11 - Onset Date.
        /// </summary>
        public DateTime? OnsetDate { get; set; }

        /// <summary>
        /// IAM.12 - Onset Date Text.
        /// </summary>
        public string OnsetDateText { get; set; }

        /// <summary>
        /// IAM.13 - Reported Date/Time.
        /// </summary>
        public DateTime? ReportedDateTime { get; set; }

        /// <summary>
        /// IAM.14 - Reported By.
        /// </summary>
        public ExtendedPersonName ReportedBy { get; set; }

        /// <summary>
        /// IAM.15 - Relationship to Patient Code.
        /// <para>Suggested: 0063 Relationship -&gt; ClearHl7.Codes.V282.CodeRelationship</para>
        /// </summary>
        public CodedWithExceptions RelationshipToPatientCode { get; set; }

        /// <summary>
        /// IAM.16 - Alert Device Code.
        /// <para>Suggested: 0437 Alert Device Code -&gt; ClearHl7.Codes.V282.CodeAlertDeviceCode</para>
        /// </summary>
        public CodedWithExceptions AlertDeviceCode { get; set; }

        /// <summary>
        /// IAM.17 - Allergy Clinical Status Code.
        /// <para>Suggested: 0438 Allergy Clinical Status -&gt; ClearHl7.Codes.V282.CodeAllergyClinicalStatus</para>
        /// </summary>
        public CodedWithExceptions AllergyClinicalStatusCode { get; set; }

        /// <summary>
        /// IAM.18 - Statused by Person.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons StatusedByPerson { get; set; }

        /// <summary>
        /// IAM.19 - Statused by Organization.
        /// </summary>
        public ExtendedCompositeNameAndIdNumberForOrganizations StatusedByOrganization { get; set; }

        /// <summary>
        /// IAM.20 - Statused at Date/Time.
        /// </summary>
        public DateTime? StatusedAtDateTime { get; set; }

        /// <summary>
        /// IAM.21 - Inactivated by Person.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons InactivatedByPerson { get; set; }

        /// <summary>
        /// IAM.22 - Inactivated Date/Time.
        /// </summary>
        public DateTime? InactivatedDateTime { get; set; }

        /// <summary>
        /// IAM.23 - Initially Recorded by Person.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons InitiallyRecordedByPerson { get; set; }

        /// <summary>
        /// IAM.24 - Initially Recorded Date/Time.
        /// </summary>
        public DateTime? InitiallyRecordedDateTime { get; set; }

        /// <summary>
        /// IAM.25 - Modified by Person.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons ModifiedByPerson { get; set; }

        /// <summary>
        /// IAM.26 - Modified Date/Time.
        /// </summary>
        public DateTime? ModifiedDateTime { get; set; }

        /// <summary>
        /// IAM.27 - Clinician Identified Code.
        /// </summary>
        public CodedWithExceptions ClinicianIdentifiedCode { get; set; }

        /// <summary>
        /// IAM.28 - Initially Recorded by Organization.
        /// </summary>
        public ExtendedCompositeNameAndIdNumberForOrganizations InitiallyRecordedByOrganization { get; set; }

        /// <summary>
        /// IAM.29 - Modified by Organization.
        /// </summary>
        public ExtendedCompositeNameAndIdNumberForOrganizations ModifiedByOrganization { get; set; }

        /// <summary>
        /// IAM.30 - Inactivated by Organization.
        /// </summary>
        public ExtendedCompositeNameAndIdNumberForOrganizations InactivatedByOrganization { get; set; }

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

            SetIdIam = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableUInt() : null;
            AllergenTypeCode = segments.Length > 2 && segments[2].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[2], false) : null;
            AllergenCodeMnemonicDescription = segments.Length > 3 && segments[3].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[3], false) : null;
            AllergySeverityCode = segments.Length > 4 && segments[4].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[4], false) : null;
            AllergyReactionCode = segments.Length > 5 && segments[5].Length > 0 ? segments[5].Split(separator) : null;
            AllergyActionCode = segments.Length > 6 && segments[6].Length > 0 ? TypeHelper.Deserialize<CodedWithNoExceptions>(segments[6], false) : null;
            AllergyUniqueIdentifier = segments.Length > 7 && segments[7].Length > 0 ? TypeHelper.Deserialize<EntityIdentifier>(segments[7], false) : null;
            ActionReason = segments.Length > 8 && segments[8].Length > 0 ? segments[8] : null;
            SensitivityToCausativeAgentCode = segments.Length > 9 && segments[9].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[9], false) : null;
            AllergenGroupCodeMnemonicDescription = segments.Length > 10 && segments[10].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[10], false) : null;
            OnsetDate = segments.Length > 11 && segments[11].Length > 0 ? segments[11].ToNullableDateTime() : null;
            OnsetDateText = segments.Length > 12 && segments[12].Length > 0 ? segments[12] : null;
            ReportedDateTime = segments.Length > 13 && segments[13].Length > 0 ? segments[13].ToNullableDateTime() : null;
            ReportedBy = segments.Length > 14 && segments[14].Length > 0 ? TypeHelper.Deserialize<ExtendedPersonName>(segments[14], false) : null;
            RelationshipToPatientCode = segments.Length > 15 && segments[15].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[15], false) : null;
            AlertDeviceCode = segments.Length > 16 && segments[16].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[16], false) : null;
            AllergyClinicalStatusCode = segments.Length > 17 && segments[17].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[17], false) : null;
            StatusedByPerson = segments.Length > 18 && segments[18].Length > 0 ? TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments[18], false) : null;
            StatusedByOrganization = segments.Length > 19 && segments[19].Length > 0 ? TypeHelper.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(segments[19], false) : null;
            StatusedAtDateTime = segments.Length > 20 && segments[20].Length > 0 ? segments[20].ToNullableDateTime() : null;
            InactivatedByPerson = segments.Length > 21 && segments[21].Length > 0 ? TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments[21], false) : null;
            InactivatedDateTime = segments.Length > 22 && segments[22].Length > 0 ? segments[22].ToNullableDateTime() : null;
            InitiallyRecordedByPerson = segments.Length > 23 && segments[23].Length > 0 ? TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments[23], false) : null;
            InitiallyRecordedDateTime = segments.Length > 24 && segments[24].Length > 0 ? segments[24].ToNullableDateTime() : null;
            ModifiedByPerson = segments.Length > 25 && segments[25].Length > 0 ? TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments[25], false) : null;
            ModifiedDateTime = segments.Length > 26 && segments[26].Length > 0 ? segments[26].ToNullableDateTime() : null;
            ClinicianIdentifiedCode = segments.Length > 27 && segments[27].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[27], false) : null;
            InitiallyRecordedByOrganization = segments.Length > 28 && segments[28].Length > 0 ? TypeHelper.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(segments[28], false) : null;
            ModifiedByOrganization = segments.Length > 29 && segments[29].Length > 0 ? TypeHelper.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(segments[29], false) : null;
            InactivatedByOrganization = segments.Length > 30 && segments[30].Length > 0 ? TypeHelper.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(segments[30], false) : null;
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
                                StringHelper.StringFormatSequence(0, 31, Configuration.FieldSeparator),
                                Id,
                                SetIdIam.HasValue ? SetIdIam.Value.ToString(culture) : null,
                                AllergenTypeCode?.ToDelimitedString(),
                                AllergenCodeMnemonicDescription?.ToDelimitedString(),
                                AllergySeverityCode?.ToDelimitedString(),
                                AllergyReactionCode != null ? string.Join(Configuration.FieldRepeatSeparator, AllergyReactionCode) : null,
                                AllergyActionCode?.ToDelimitedString(),
                                AllergyUniqueIdentifier?.ToDelimitedString(),
                                ActionReason,
                                SensitivityToCausativeAgentCode?.ToDelimitedString(),
                                AllergenGroupCodeMnemonicDescription?.ToDelimitedString(),
                                OnsetDate.HasValue ? OnsetDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                OnsetDateText,
                                ReportedDateTime.HasValue ? ReportedDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ReportedBy?.ToDelimitedString(),
                                RelationshipToPatientCode?.ToDelimitedString(),
                                AlertDeviceCode?.ToDelimitedString(),
                                AllergyClinicalStatusCode?.ToDelimitedString(),
                                StatusedByPerson?.ToDelimitedString(),
                                StatusedByOrganization?.ToDelimitedString(),
                                StatusedAtDateTime.HasValue ? StatusedAtDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                InactivatedByPerson?.ToDelimitedString(),
                                InactivatedDateTime.HasValue ? InactivatedDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                InitiallyRecordedByPerson?.ToDelimitedString(),
                                InitiallyRecordedDateTime.HasValue ? InitiallyRecordedDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ModifiedByPerson?.ToDelimitedString(),
                                ModifiedDateTime.HasValue ? ModifiedDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ClinicianIdentifiedCode?.ToDelimitedString(),
                                InitiallyRecordedByOrganization?.ToDelimitedString(),
                                ModifiedByOrganization?.ToDelimitedString(),
                                InactivatedByOrganization?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}