﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V280.Types;

namespace ClearHl7.V280.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment RF1 - Referral Information.
    /// </summary>
    public class Rf1Segment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "RF1";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// RF1.1 - Referral Status.
        /// <para>Suggested: 0283 Referral Status -&gt; ClearHl7.Codes.V280.CodeReferralStatus</para>
        /// </summary>
        public CodedWithExceptions ReferralStatus { get; set; }

        /// <summary>
        /// RF1.2 - Referral Priority.
        /// <para>Suggested: 0280 Referral Priority -&gt; ClearHl7.Codes.V280.CodeReferralPriority</para>
        /// </summary>
        public CodedWithExceptions ReferralPriority { get; set; }

        /// <summary>
        /// RF1.3 - Referral Type.
        /// <para>Suggested: 0281 Referral Type -&gt; ClearHl7.Codes.V280.CodeReferralType</para>
        /// </summary>
        public CodedWithExceptions ReferralType { get; set; }

        /// <summary>
        /// RF1.4 - Referral Disposition.
        /// <para>Suggested: 0282 Referral Disposition -&gt; ClearHl7.Codes.V280.CodeReferralDisposition</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> ReferralDisposition { get; set; }

        /// <summary>
        /// RF1.5 - Referral Category.
        /// <para>Suggested: 0284 Referral Category -&gt; ClearHl7.Codes.V280.CodeReferralCategory</para>
        /// </summary>
        public CodedWithExceptions ReferralCategory { get; set; }

        /// <summary>
        /// RF1.6 - Originating Referral Identifier.
        /// </summary>
        public EntityIdentifier OriginatingReferralIdentifier { get; set; }

        /// <summary>
        /// RF1.7 - Effective Date.
        /// </summary>
        public DateTime? EffectiveDate { get; set; }

        /// <summary>
        /// RF1.8 - Expiration Date.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// RF1.9 - Process Date.
        /// </summary>
        public DateTime? ProcessDate { get; set; }

        /// <summary>
        /// RF1.10 - Referral Reason.
        /// <para>Suggested: 0336 Referral Reason -&gt; ClearHl7.Codes.V280.CodeReferralReason</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> ReferralReason { get; set; }

        /// <summary>
        /// RF1.11 - External Referral Identifier.
        /// </summary>
        public IEnumerable<EntityIdentifier> ExternalReferralIdentifier { get; set; }

        /// <summary>
        /// RF1.12 - Referral Documentation Completion Status.
        /// <para>Suggested: 0865 Referral Documentation Completion Status</para>
        /// </summary>
        public CodedWithExceptions ReferralDocumentationCompletionStatus { get; set; }

        /// <summary>
        /// RF1.13 - Planned Treatment Stop Date.
        /// </summary>
        public DateTime? PlannedTreatmentStopDate { get; set; }

        /// <summary>
        /// RF1.14 - Referral Reason Text.
        /// </summary>
        public string ReferralReasonText { get; set; }

        /// <summary>
        /// RF1.15 - Number of Authorized Treatments/Units.
        /// </summary>
        public CompositeQuantityWithUnits NumberOfAuthorizedTreatmentsUnits { get; set; }

        /// <summary>
        /// RF1.16 - Number of Used Treatments/Units.
        /// </summary>
        public CompositeQuantityWithUnits NumberOfUsedTreatmentsUnits { get; set; }

        /// <summary>
        /// RF1.17 - Number of Schedule Treatments/Units.
        /// </summary>
        public CompositeQuantityWithUnits NumberOfScheduleTreatmentsUnits { get; set; }

        /// <summary>
        /// RF1.18 - Remaining Benefit Amount.
        /// </summary>
        public Money RemainingBenefitAmount { get; set; }

        /// <summary>
        /// RF1.19 - Authorized Provider.
        /// </summary>
        public ExtendedCompositeNameAndIdNumberForOrganizations AuthorizedProvider { get; set; }

        /// <summary>
        /// RF1.20 - Authorized Health Professional.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons AuthorizedHealthProfessional { get; set; }

        /// <summary>
        /// RF1.21 - Source Text.
        /// </summary>
        public string SourceText { get; set; }

        /// <summary>
        /// RF1.22 - Source Date.
        /// </summary>
        public DateTime? SourceDate { get; set; }

        /// <summary>
        /// RF1.23 - Source Phone.
        /// </summary>
        public ExtendedTelecommunicationNumber SourcePhone { get; set; }

        /// <summary>
        /// RF1.24 - Comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// RF1.25 - Action Code.
        /// <para>Suggested: 0206 Segment Action Code -&gt; ClearHl7.Codes.V280.CodeSegmentActionCode</para>
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

            ReferralStatus = segments.Length > 1 && segments[1].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[1], false) : null;
            ReferralPriority = segments.Length > 2 && segments[2].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[2], false) : null;
            ReferralType = segments.Length > 3 && segments[3].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[3], false) : null;
            ReferralDisposition = segments.Length > 4 && segments[4].Length > 0 ? segments[4].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            ReferralCategory = segments.Length > 5 && segments[5].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[5], false) : null;
            OriginatingReferralIdentifier = segments.Length > 6 && segments[6].Length > 0 ? TypeHelper.Deserialize<EntityIdentifier>(segments[6], false) : null;
            EffectiveDate = segments.Length > 7 && segments[7].Length > 0 ? segments[7].ToNullableDateTime() : null;
            ExpirationDate = segments.Length > 8 && segments[8].Length > 0 ? segments[8].ToNullableDateTime() : null;
            ProcessDate = segments.Length > 9 && segments[9].Length > 0 ? segments[9].ToNullableDateTime() : null;
            ReferralReason = segments.Length > 10 && segments[10].Length > 0 ? segments[10].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            ExternalReferralIdentifier = segments.Length > 11 && segments[11].Length > 0 ? segments[11].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<EntityIdentifier>(x, false)) : null;
            ReferralDocumentationCompletionStatus = segments.Length > 12 && segments[12].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[12], false) : null;
            PlannedTreatmentStopDate = segments.Length > 13 && segments[13].Length > 0 ? segments[13].ToNullableDateTime() : null;
            ReferralReasonText = segments.Length > 14 && segments[14].Length > 0 ? segments[14] : null;
            NumberOfAuthorizedTreatmentsUnits = segments.Length > 15 && segments[15].Length > 0 ? TypeHelper.Deserialize<CompositeQuantityWithUnits>(segments[15], false) : null;
            NumberOfUsedTreatmentsUnits = segments.Length > 16 && segments[16].Length > 0 ? TypeHelper.Deserialize<CompositeQuantityWithUnits>(segments[16], false) : null;
            NumberOfScheduleTreatmentsUnits = segments.Length > 17 && segments[17].Length > 0 ? TypeHelper.Deserialize<CompositeQuantityWithUnits>(segments[17], false) : null;
            RemainingBenefitAmount = segments.Length > 18 && segments[18].Length > 0 ? TypeHelper.Deserialize<Money>(segments[18], false) : null;
            AuthorizedProvider = segments.Length > 19 && segments[19].Length > 0 ? TypeHelper.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(segments[19], false) : null;
            AuthorizedHealthProfessional = segments.Length > 20 && segments[20].Length > 0 ? TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments[20], false) : null;
            SourceText = segments.Length > 21 && segments[21].Length > 0 ? segments[21] : null;
            SourceDate = segments.Length > 22 && segments[22].Length > 0 ? segments[22].ToNullableDateTime() : null;
            SourcePhone = segments.Length > 23 && segments[23].Length > 0 ? TypeHelper.Deserialize<ExtendedTelecommunicationNumber>(segments[23], false) : null;
            Comment = segments.Length > 24 && segments[24].Length > 0 ? segments[24] : null;
            ActionCode = segments.Length > 25 && segments[25].Length > 0 ? segments[25] : null;
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
                                StringHelper.StringFormatSequence(0, 26, Configuration.FieldSeparator),
                                Id,
                                ReferralStatus?.ToDelimitedString(),
                                ReferralPriority?.ToDelimitedString(),
                                ReferralType?.ToDelimitedString(),
                                ReferralDisposition != null ? string.Join(Configuration.FieldRepeatSeparator, ReferralDisposition.Select(x => x.ToDelimitedString())) : null,
                                ReferralCategory?.ToDelimitedString(),
                                OriginatingReferralIdentifier?.ToDelimitedString(),
                                EffectiveDate.HasValue ? EffectiveDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ExpirationDate.HasValue ? ExpirationDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ProcessDate.HasValue ? ProcessDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ReferralReason != null ? string.Join(Configuration.FieldRepeatSeparator, ReferralReason.Select(x => x.ToDelimitedString())) : null,
                                ExternalReferralIdentifier != null ? string.Join(Configuration.FieldRepeatSeparator, ExternalReferralIdentifier.Select(x => x.ToDelimitedString())) : null,
                                ReferralDocumentationCompletionStatus?.ToDelimitedString(),
                                PlannedTreatmentStopDate.HasValue ? PlannedTreatmentStopDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ReferralReasonText,
                                NumberOfAuthorizedTreatmentsUnits?.ToDelimitedString(),
                                NumberOfUsedTreatmentsUnits?.ToDelimitedString(),
                                NumberOfScheduleTreatmentsUnits?.ToDelimitedString(),
                                RemainingBenefitAmount?.ToDelimitedString(),
                                AuthorizedProvider?.ToDelimitedString(),
                                AuthorizedHealthProfessional?.ToDelimitedString(),
                                SourceText,
                                SourceDate.HasValue ? SourceDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                SourcePhone?.ToDelimitedString(),
                                Comment,
                                ActionCode
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}