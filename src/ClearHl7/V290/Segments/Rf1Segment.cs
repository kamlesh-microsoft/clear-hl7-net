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
        /// <para>Suggested: 0283 Referral Status -&gt; ClearHl7.Codes.V290.CodeReferralStatus</para>
        /// </summary>
        public CodedWithExceptions ReferralStatus { get; set; }

        /// <summary>
        /// RF1.2 - Referral Priority.
        /// <para>Suggested: 0280 Referral Priority -&gt; ClearHl7.Codes.V290.CodeReferralPriority</para>
        /// </summary>
        public CodedWithExceptions ReferralPriority { get; set; }

        /// <summary>
        /// RF1.3 - Referral Type.
        /// <para>Suggested: 0281 Referral Type -&gt; ClearHl7.Codes.V290.CodeReferralType</para>
        /// </summary>
        public CodedWithExceptions ReferralType { get; set; }

        /// <summary>
        /// RF1.4 - Referral Disposition.
        /// <para>Suggested: 0282 Referral Disposition -&gt; ClearHl7.Codes.V290.CodeReferralDisposition</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> ReferralDisposition { get; set; }

        /// <summary>
        /// RF1.5 - Referral Category.
        /// <para>Suggested: 0284 Referral Category -&gt; ClearHl7.Codes.V290.CodeReferralCategory</para>
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
        /// <para>Suggested: 0336 Referral Reason -&gt; ClearHl7.Codes.V290.CodeReferralReason</para>
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
        /// <para>Suggested: 0206 Segment Action Code -&gt; ClearHl7.Codes.V290.CodeSegmentActionCode</para>
        /// </summary>
        public string ActionCode { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <exception cref="ArgumentException">delimitedString does not begin with the proper segment Id.</exception>
        public Rf1Segment FromDelimitedString(string delimitedString)
        {
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(Configuration.FieldSeparator.ToCharArray());
            char[] separator = Configuration.FieldRepeatSeparator.ToCharArray();

            if (segments.Length > 0)
            {
                if (string.Compare(Id, segments.First(), true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ Configuration.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            ReferralStatus = segments.Length > 1 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(1)) : null;
            ReferralPriority = segments.Length > 2 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(2)) : null;
            ReferralType = segments.Length > 3 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(3)) : null;
            ReferralDisposition = segments.Length > 4 ? segments.ElementAtOrDefault(4).Split(separator).Select(x => new CodedWithExceptions().FromDelimitedString(x)) : null;
            ReferralCategory = segments.Length > 5 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(5)) : null;
            OriginatingReferralIdentifier = segments.Length > 6 ? new EntityIdentifier().FromDelimitedString(segments.ElementAtOrDefault(6)) : null;
            EffectiveDate = segments.ElementAtOrDefault(7)?.ToNullableDateTime(Consts.DateTimeFormatPrecisionSecond);
            ExpirationDate = segments.ElementAtOrDefault(8)?.ToNullableDateTime(Consts.DateTimeFormatPrecisionSecond);
            ProcessDate = segments.ElementAtOrDefault(9)?.ToNullableDateTime(Consts.DateTimeFormatPrecisionSecond);
            ReferralReason = segments.Length > 10 ? segments.ElementAtOrDefault(10).Split(separator).Select(x => new CodedWithExceptions().FromDelimitedString(x)) : null;
            ExternalReferralIdentifier = segments.Length > 11 ? segments.ElementAtOrDefault(11).Split(separator).Select(x => new EntityIdentifier().FromDelimitedString(x)) : null;
            ReferralDocumentationCompletionStatus = segments.Length > 12 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(12)) : null;
            PlannedTreatmentStopDate = segments.ElementAtOrDefault(13)?.ToNullableDateTime(Consts.DateTimeFormatPrecisionSecond);
            ReferralReasonText = segments.ElementAtOrDefault(14);
            NumberOfAuthorizedTreatmentsUnits = segments.Length > 15 ? new CompositeQuantityWithUnits().FromDelimitedString(segments.ElementAtOrDefault(15)) : null;
            NumberOfUsedTreatmentsUnits = segments.Length > 16 ? new CompositeQuantityWithUnits().FromDelimitedString(segments.ElementAtOrDefault(16)) : null;
            NumberOfScheduleTreatmentsUnits = segments.Length > 17 ? new CompositeQuantityWithUnits().FromDelimitedString(segments.ElementAtOrDefault(17)) : null;
            RemainingBenefitAmount = segments.Length > 18 ? new Money().FromDelimitedString(segments.ElementAtOrDefault(18)) : null;
            AuthorizedProvider = segments.Length > 19 ? new ExtendedCompositeNameAndIdNumberForOrganizations().FromDelimitedString(segments.ElementAtOrDefault(19)) : null;
            AuthorizedHealthProfessional = segments.Length > 20 ? new ExtendedCompositeIdNumberAndNameForPersons().FromDelimitedString(segments.ElementAtOrDefault(20)) : null;
            SourceText = segments.ElementAtOrDefault(21);
            SourceDate = segments.ElementAtOrDefault(22)?.ToNullableDateTime(Consts.DateTimeFormatPrecisionSecond);
            SourcePhone = segments.Length > 23 ? new ExtendedTelecommunicationNumber().FromDelimitedString(segments.ElementAtOrDefault(23)) : null;
            Comment = segments.ElementAtOrDefault(24);
            ActionCode = segments.ElementAtOrDefault(25);
            
            return this;
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