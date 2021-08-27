﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V290.Types;

namespace ClearHl7.V290.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment DON - Donation.
    /// </summary>
    public class DonSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "DON";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// DON.1 - Donation Identification Number - DIN.
        /// </summary>
        public EntityIdentifier DonationIdentificationNumberDin { get; set; }

        /// <summary>
        /// DON.2 - Donation Type.
        /// </summary>
        public CodedWithNoExceptions DonationType { get; set; }

        /// <summary>
        /// DON.3 - Phlebotomy Start Date/Time.
        /// </summary>
        public DateTime? PhlebotomyStartDateTime { get; set; }

        /// <summary>
        /// DON.4 - Phlebotomy End Date/Time.
        /// </summary>
        public DateTime? PhlebotomyEndDateTime { get; set; }

        /// <summary>
        /// DON.5 - Donation Duration.
        /// </summary>
        public decimal? DonationDuration { get; set; }

        /// <summary>
        /// DON.6 - Donation Duration Units.
        /// <para>Suggested: 0932 Donation Duration Units</para>
        /// </summary>
        public CodedWithNoExceptions DonationDurationUnits { get; set; }

        /// <summary>
        /// DON.7 - Intended Procedure Type.
        /// <para>Suggested: 0933 Intended Procedure Type -&gt; ClearHl7.Codes.V290.CodeIntendedProcedureType</para>
        /// </summary>
        public IEnumerable<CodedWithNoExceptions> IntendedProcedureType { get; set; }

        /// <summary>
        /// DON.8 - Actual Procedure Type.
        /// <para>Suggested: 0933 Intended Procedure Type -&gt; ClearHl7.Codes.V290.CodeIntendedProcedureType</para>
        /// </summary>
        public IEnumerable<CodedWithNoExceptions> ActualProcedureType { get; set; }

        /// <summary>
        /// DON.9 - Donor Eligibility Flag.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V290.CodeYesNoIndicator</para>
        /// </summary>
        public string DonorEligibilityFlag { get; set; }

        /// <summary>
        /// DON.10 - Donor Eligibility Procedure Type.
        /// <para>Suggested: 0933 Intended Procedure Type -&gt; ClearHl7.Codes.V290.CodeIntendedProcedureType</para>
        /// </summary>
        public IEnumerable<CodedWithNoExceptions> DonorEligibilityProcedureType { get; set; }

        /// <summary>
        /// DON.11 - Donor Eligibility Date.
        /// </summary>
        public DateTime? DonorEligibilityDate { get; set; }

        /// <summary>
        /// DON.12 - Process Interruption.
        /// <para>Suggested: 0923 Process Interruption -&gt; ClearHl7.Codes.V290.CodeProcessInterruption</para>
        /// </summary>
        public CodedWithNoExceptions ProcessInterruption { get; set; }

        /// <summary>
        /// DON.13 - Process Interruption Reason.
        /// <para>Suggested: 0935 Process Interruption Reason -&gt; ClearHl7.Codes.V290.CodeProcessInterruptionReason</para>
        /// </summary>
        public CodedWithNoExceptions ProcessInterruptionReason { get; set; }

        /// <summary>
        /// DON.14 - Phlebotomy Issue.
        /// <para>Suggested: 0925 Phlebotomy Issue -&gt; ClearHl7.Codes.V290.CodePhlebotomyIssue</para>
        /// </summary>
        public IEnumerable<CodedWithNoExceptions> PhlebotomyIssue { get; set; }

        /// <summary>
        /// DON.15 - Intended Recipient Blood Relative.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V290.CodeYesNoIndicator</para>
        /// </summary>
        public string IntendedRecipientBloodRelative { get; set; }

        /// <summary>
        /// DON.16 - Intended Recipient Name.
        /// </summary>
        public ExtendedPersonName IntendedRecipientName { get; set; }

        /// <summary>
        /// DON.17 - Intended Recipient DOB.
        /// </summary>
        public DateTime? IntendedRecipientDob { get; set; }

        /// <summary>
        /// DON.18 - Intended Recipient Facility.
        /// </summary>
        public ExtendedCompositeNameAndIdNumberForOrganizations IntendedRecipientFacility { get; set; }

        /// <summary>
        /// DON.19 - Intended Recipient Procedure Date.
        /// </summary>
        public DateTime? IntendedRecipientProcedureDate { get; set; }

        /// <summary>
        /// DON.20 - Intended Recipient Ordering Provider.
        /// </summary>
        public ExtendedPersonName IntendedRecipientOrderingProvider { get; set; }

        /// <summary>
        /// DON.21 - Phlebotomy Status.
        /// <para>Suggested: 0926 Phlebotomy Status -&gt; ClearHl7.Codes.V290.CodePhlebotomyStatus</para>
        /// </summary>
        public CodedWithNoExceptions PhlebotomyStatus { get; set; }

        /// <summary>
        /// DON.22 - Arm Stick.
        /// <para>Suggested: 0927 Arm Stick -&gt; ClearHl7.Codes.V290.CodeArmStick</para>
        /// </summary>
        public CodedWithNoExceptions ArmStick { get; set; }

        /// <summary>
        /// DON.23 - Bleed Start Phlebotomist.
        /// </summary>
        public ExtendedPersonName BleedStartPhlebotomist { get; set; }

        /// <summary>
        /// DON.24 - Bleed End Phlebotomist.
        /// </summary>
        public ExtendedPersonName BleedEndPhlebotomist { get; set; }

        /// <summary>
        /// DON.25 - Aphaeresis Type Machine.
        /// </summary>
        public string AphaeresisTypeMachine { get; set; }

        /// <summary>
        /// DON.26 - Aphaeresis Machine Serial Number.
        /// </summary>
        public string AphaeresisMachineSerialNumber { get; set; }

        /// <summary>
        /// DON.27 - Donor Reaction.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V290.CodeYesNoIndicator</para>
        /// </summary>
        public string DonorReaction { get; set; }

        /// <summary>
        /// DON.28 - Final Review Staff ID.
        /// </summary>
        public ExtendedPersonName FinalReviewStaffId { get; set; }

        /// <summary>
        /// DON.29 - Final Review Date/Time.
        /// </summary>
        public DateTime? FinalReviewDateTime { get; set; }

        /// <summary>
        /// DON.30 - Number of Tubes Collected.
        /// </summary>
        public decimal? NumberOfTubesCollected { get; set; }

        /// <summary>
        /// DON.31 - Donation Sample Identifier.
        /// </summary>
        public IEnumerable<EntityIdentifier> DonationSampleIdentifier { get; set; }

        /// <summary>
        /// DON.32 - Donation Accept Staff.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons DonationAcceptStaff { get; set; }

        /// <summary>
        /// DON.33 - Donation Material Review Staff.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> DonationMaterialReviewStaff { get; set; }

        /// <summary>
        /// DON.34 - Action Code.
        /// </summary>
        public string ActionCode { get; set; }

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

            DonationIdentificationNumberDin = segments.Length > 1 && segments[1].Length > 0 ? TypeHelper.Deserialize<EntityIdentifier>(segments[1], false) : null;
            DonationType = segments.Length > 2 && segments[2].Length > 0 ? TypeHelper.Deserialize<CodedWithNoExceptions>(segments[2], false) : null;
            PhlebotomyStartDateTime = segments.Length > 3 && segments[3].Length > 0 ? segments[3].ToNullableDateTime() : null;
            PhlebotomyEndDateTime = segments.Length > 4 && segments[4].Length > 0 ? segments[4].ToNullableDateTime() : null;
            DonationDuration = segments.Length > 5 && segments[5].Length > 0 ? segments[5].ToNullableDecimal() : null;
            DonationDurationUnits = segments.Length > 6 && segments[6].Length > 0 ? TypeHelper.Deserialize<CodedWithNoExceptions>(segments[6], false) : null;
            IntendedProcedureType = segments.Length > 7 && segments[7].Length > 0 ? segments[7].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithNoExceptions>(x, false)) : null;
            ActualProcedureType = segments.Length > 8 && segments[8].Length > 0 ? segments[8].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithNoExceptions>(x, false)) : null;
            DonorEligibilityFlag = segments.Length > 9 && segments[9].Length > 0 ? segments[9] : null;
            DonorEligibilityProcedureType = segments.Length > 10 && segments[10].Length > 0 ? segments[10].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithNoExceptions>(x, false)) : null;
            DonorEligibilityDate = segments.Length > 11 && segments[11].Length > 0 ? segments[11].ToNullableDateTime() : null;
            ProcessInterruption = segments.Length > 12 && segments[12].Length > 0 ? TypeHelper.Deserialize<CodedWithNoExceptions>(segments[12], false) : null;
            ProcessInterruptionReason = segments.Length > 13 && segments[13].Length > 0 ? TypeHelper.Deserialize<CodedWithNoExceptions>(segments[13], false) : null;
            PhlebotomyIssue = segments.Length > 14 && segments[14].Length > 0 ? segments[14].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithNoExceptions>(x, false)) : null;
            IntendedRecipientBloodRelative = segments.Length > 15 && segments[15].Length > 0 ? segments[15] : null;
            IntendedRecipientName = segments.Length > 16 && segments[16].Length > 0 ? TypeHelper.Deserialize<ExtendedPersonName>(segments[16], false) : null;
            IntendedRecipientDob = segments.Length > 17 && segments[17].Length > 0 ? segments[17].ToNullableDateTime() : null;
            IntendedRecipientFacility = segments.Length > 18 && segments[18].Length > 0 ? TypeHelper.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(segments[18], false) : null;
            IntendedRecipientProcedureDate = segments.Length > 19 && segments[19].Length > 0 ? segments[19].ToNullableDateTime() : null;
            IntendedRecipientOrderingProvider = segments.Length > 20 && segments[20].Length > 0 ? TypeHelper.Deserialize<ExtendedPersonName>(segments[20], false) : null;
            PhlebotomyStatus = segments.Length > 21 && segments[21].Length > 0 ? TypeHelper.Deserialize<CodedWithNoExceptions>(segments[21], false) : null;
            ArmStick = segments.Length > 22 && segments[22].Length > 0 ? TypeHelper.Deserialize<CodedWithNoExceptions>(segments[22], false) : null;
            BleedStartPhlebotomist = segments.Length > 23 && segments[23].Length > 0 ? TypeHelper.Deserialize<ExtendedPersonName>(segments[23], false) : null;
            BleedEndPhlebotomist = segments.Length > 24 && segments[24].Length > 0 ? TypeHelper.Deserialize<ExtendedPersonName>(segments[24], false) : null;
            AphaeresisTypeMachine = segments.Length > 25 && segments[25].Length > 0 ? segments[25] : null;
            AphaeresisMachineSerialNumber = segments.Length > 26 && segments[26].Length > 0 ? segments[26] : null;
            DonorReaction = segments.Length > 27 && segments[27].Length > 0 ? segments[27] : null;
            FinalReviewStaffId = segments.Length > 28 && segments[28].Length > 0 ? TypeHelper.Deserialize<ExtendedPersonName>(segments[28], false) : null;
            FinalReviewDateTime = segments.Length > 29 && segments[29].Length > 0 ? segments[29].ToNullableDateTime() : null;
            NumberOfTubesCollected = segments.Length > 30 && segments[30].Length > 0 ? segments[30].ToNullableDecimal() : null;
            DonationSampleIdentifier = segments.Length > 31 && segments[31].Length > 0 ? segments[31].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<EntityIdentifier>(x, false)) : null;
            DonationAcceptStaff = segments.Length > 32 && segments[32].Length > 0 ? TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments[32], false) : null;
            DonationMaterialReviewStaff = segments.Length > 33 && segments[33].Length > 0 ? segments[33].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(x, false)) : null;
            ActionCode = segments.Length > 34 && segments[34].Length > 0 ? segments[34] : null;
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
                                StringHelper.StringFormatSequence(0, 35, Configuration.FieldSeparator),
                                Id,
                                DonationIdentificationNumberDin?.ToDelimitedString(),
                                DonationType?.ToDelimitedString(),
                                PhlebotomyStartDateTime.HasValue ? PhlebotomyStartDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                PhlebotomyEndDateTime.HasValue ? PhlebotomyEndDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                DonationDuration.HasValue ? DonationDuration.Value.ToString(Consts.NumericFormat, culture) : null,
                                DonationDurationUnits?.ToDelimitedString(),
                                IntendedProcedureType != null ? string.Join(Configuration.FieldRepeatSeparator, IntendedProcedureType.Select(x => x.ToDelimitedString())) : null,
                                ActualProcedureType != null ? string.Join(Configuration.FieldRepeatSeparator, ActualProcedureType.Select(x => x.ToDelimitedString())) : null,
                                DonorEligibilityFlag,
                                DonorEligibilityProcedureType != null ? string.Join(Configuration.FieldRepeatSeparator, DonorEligibilityProcedureType.Select(x => x.ToDelimitedString())) : null,
                                DonorEligibilityDate.HasValue ? DonorEligibilityDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ProcessInterruption?.ToDelimitedString(),
                                ProcessInterruptionReason?.ToDelimitedString(),
                                PhlebotomyIssue != null ? string.Join(Configuration.FieldRepeatSeparator, PhlebotomyIssue.Select(x => x.ToDelimitedString())) : null,
                                IntendedRecipientBloodRelative,
                                IntendedRecipientName?.ToDelimitedString(),
                                IntendedRecipientDob.HasValue ? IntendedRecipientDob.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                IntendedRecipientFacility?.ToDelimitedString(),
                                IntendedRecipientProcedureDate.HasValue ? IntendedRecipientProcedureDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                IntendedRecipientOrderingProvider?.ToDelimitedString(),
                                PhlebotomyStatus?.ToDelimitedString(),
                                ArmStick?.ToDelimitedString(),
                                BleedStartPhlebotomist?.ToDelimitedString(),
                                BleedEndPhlebotomist?.ToDelimitedString(),
                                AphaeresisTypeMachine,
                                AphaeresisMachineSerialNumber,
                                DonorReaction,
                                FinalReviewStaffId?.ToDelimitedString(),
                                FinalReviewDateTime.HasValue ? FinalReviewDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                NumberOfTubesCollected.HasValue ? NumberOfTubesCollected.Value.ToString(Consts.NumericFormat, culture) : null,
                                DonationSampleIdentifier != null ? string.Join(Configuration.FieldRepeatSeparator, DonationSampleIdentifier.Select(x => x.ToDelimitedString())) : null,
                                DonationAcceptStaff?.ToDelimitedString(),
                                DonationMaterialReviewStaff != null ? string.Join(Configuration.FieldRepeatSeparator, DonationMaterialReviewStaff.Select(x => x.ToDelimitedString())) : null,
                                ActionCode
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}