﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V260.Types;

namespace ClearHl7.V260.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment SPM - Specimen.
    /// </summary>
    public class SpmSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "SPM";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// SPM.1 - Set ID - SPM.
        /// </summary>
        public uint? SetIdSpm { get; set; }

        /// <summary>
        /// SPM.2 - Specimen ID.
        /// </summary>
        public EntityIdentifierPair SpecimenId { get; set; }

        /// <summary>
        /// SPM.3 - Specimen Parent IDs.
        /// </summary>
        public IEnumerable<EntityIdentifierPair> SpecimenParentIds { get; set; }

        /// <summary>
        /// SPM.4 - Specimen Type.
        /// <para>Suggested: 0487 Specimen Type -&gt; ClearHl7.Codes.V260.CodeSpecimenType</para>
        /// </summary>
        public CodedWithExceptions SpecimenType { get; set; }

        /// <summary>
        /// SPM.5 - Specimen Type Modifier.
        /// <para>Suggested: 0541 Specimen Type Modifier</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> SpecimenTypeModifier { get; set; }

        /// <summary>
        /// SPM.6 - Specimen Additives.
        /// <para>Suggested: 0371 Additive/Preservative -&gt; ClearHl7.Codes.V260.CodeAdditivePreservative</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> SpecimenAdditives { get; set; }

        /// <summary>
        /// SPM.7 - Specimen Collection Method.
        /// <para>Suggested: 0488 Specimen Collection Method -&gt; ClearHl7.Codes.V260.CodeSpecimenCollectionMethod</para>
        /// </summary>
        public CodedWithExceptions SpecimenCollectionMethod { get; set; }

        /// <summary>
        /// SPM.8 - Specimen Source Site.
        /// </summary>
        public CodedWithExceptions SpecimenSourceSite { get; set; }

        /// <summary>
        /// SPM.9 - Specimen Source Site Modifier.
        /// <para>Suggested: 0542 Specimen Source Type Modifier</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> SpecimenSourceSiteModifier { get; set; }

        /// <summary>
        /// SPM.10 - Specimen Collection Site.
        /// <para>Suggested: 0543 Specimen Collection Site</para>
        /// </summary>
        public CodedWithExceptions SpecimenCollectionSite { get; set; }

        /// <summary>
        /// SPM.11 - Specimen Role.
        /// <para>Suggested: 0369 Specimen Role -&gt; ClearHl7.Codes.V260.CodeSpecimenRole</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> SpecimenRole { get; set; }

        /// <summary>
        /// SPM.12 - Specimen Collection Amount.
        /// </summary>
        public CompositeQuantityWithUnits SpecimenCollectionAmount { get; set; }

        /// <summary>
        /// SPM.13 - Grouped Specimen Count.
        /// </summary>
        public decimal? GroupedSpecimenCount { get; set; }

        /// <summary>
        /// SPM.14 - Specimen Description.
        /// </summary>
        public IEnumerable<string> SpecimenDescription { get; set; }

        /// <summary>
        /// SPM.15 - Specimen Handling Code.
        /// <para>Suggested: 0376 Special Handling Code -&gt; ClearHl7.Codes.V260.CodeSpecialHandlingCode</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> SpecimenHandlingCode { get; set; }

        /// <summary>
        /// SPM.16 - Specimen Risk Code.
        /// <para>Suggested: 0489 Risk Codes -&gt; ClearHl7.Codes.V260.CodeRiskCodes</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> SpecimenRiskCode { get; set; }

        /// <summary>
        /// SPM.17 - Specimen Collection Date/Time.
        /// </summary>
        public DateTimeRange SpecimenCollectionDateTime { get; set; }

        /// <summary>
        /// SPM.18 - Specimen Received Date/Time *.
        /// </summary>
        public DateTime? SpecimenReceivedDateTime { get; set; }

        /// <summary>
        /// SPM.19 - Specimen Expiration Date/Time.
        /// </summary>
        public DateTime? SpecimenExpirationDateTime { get; set; }

        /// <summary>
        /// SPM.20 - Specimen Availability.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V260.CodeYesNoIndicator</para>
        /// </summary>
        public string SpecimenAvailability { get; set; }

        /// <summary>
        /// SPM.21 - Specimen Reject Reason.
        /// <para>Suggested: 0490 Specimen Reject Reason -&gt; ClearHl7.Codes.V260.CodeSpecimenRejectReason</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> SpecimenRejectReason { get; set; }

        /// <summary>
        /// SPM.22 - Specimen Quality.
        /// <para>Suggested: 0491 Specimen Quality -&gt; ClearHl7.Codes.V260.CodeSpecimenQuality</para>
        /// </summary>
        public CodedWithExceptions SpecimenQuality { get; set; }

        /// <summary>
        /// SPM.23 - Specimen Appropriateness.
        /// <para>Suggested: 0492 Specimen Appropriateness -&gt; ClearHl7.Codes.V260.CodeSpecimenAppropriateness</para>
        /// </summary>
        public CodedWithExceptions SpecimenAppropriateness { get; set; }

        /// <summary>
        /// SPM.24 - Specimen Condition.
        /// <para>Suggested: 0493 Specimen Condition -&gt; ClearHl7.Codes.V260.CodeSpecimenCondition</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> SpecimenCondition { get; set; }

        /// <summary>
        /// SPM.25 - Specimen Current Quantity.
        /// </summary>
        public CompositeQuantityWithUnits SpecimenCurrentQuantity { get; set; }

        /// <summary>
        /// SPM.26 - Number of Specimen Containers.
        /// </summary>
        public decimal? NumberOfSpecimenContainers { get; set; }

        /// <summary>
        /// SPM.27 - Container Type.
        /// </summary>
        public CodedWithExceptions ContainerType { get; set; }

        /// <summary>
        /// SPM.28 - Container Condition.
        /// <para>Suggested: 0544 Container Condition</para>
        /// </summary>
        public CodedWithExceptions ContainerCondition { get; set; }

        /// <summary>
        /// SPM.29 - Specimen Child Role.
        /// <para>Suggested: 0494 Specimen Child Role -&gt; ClearHl7.Codes.V260.CodeSpecimenChildRole</para>
        /// </summary>
        public CodedWithExceptions SpecimenChildRole { get; set; }

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

            SetIdSpm = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableUInt() : null;
            SpecimenId = segments.Length > 2 && segments[2].Length > 0 ? TypeHelper.Deserialize<EntityIdentifierPair>(segments[2], false) : null;
            SpecimenParentIds = segments.Length > 3 && segments[3].Length > 0 ? segments[3].Split(separator).Select(x => TypeHelper.Deserialize<EntityIdentifierPair>(x, false)) : null;
            SpecimenType = segments.Length > 4 && segments[4].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[4], false) : null;
            SpecimenTypeModifier = segments.Length > 5 && segments[5].Length > 0 ? segments[5].Split(separator).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            SpecimenAdditives = segments.Length > 6 && segments[6].Length > 0 ? segments[6].Split(separator).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            SpecimenCollectionMethod = segments.Length > 7 && segments[7].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[7], false) : null;
            SpecimenSourceSite = segments.Length > 8 && segments[8].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[8], false) : null;
            SpecimenSourceSiteModifier = segments.Length > 9 && segments[9].Length > 0 ? segments[9].Split(separator).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            SpecimenCollectionSite = segments.Length > 10 && segments[10].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[10], false) : null;
            SpecimenRole = segments.Length > 11 && segments[11].Length > 0 ? segments[11].Split(separator).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            SpecimenCollectionAmount = segments.Length > 12 && segments[12].Length > 0 ? TypeHelper.Deserialize<CompositeQuantityWithUnits>(segments[12], false) : null;
            GroupedSpecimenCount = segments.Length > 13 && segments[13].Length > 0 ? segments[13].ToNullableDecimal() : null;
            SpecimenDescription = segments.Length > 14 && segments[14].Length > 0 ? segments[14].Split(separator) : null;
            SpecimenHandlingCode = segments.Length > 15 && segments[15].Length > 0 ? segments[15].Split(separator).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            SpecimenRiskCode = segments.Length > 16 && segments[16].Length > 0 ? segments[16].Split(separator).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            SpecimenCollectionDateTime = segments.Length > 17 && segments[17].Length > 0 ? TypeHelper.Deserialize<DateTimeRange>(segments[17], false) : null;
            SpecimenReceivedDateTime = segments.Length > 18 && segments[18].Length > 0 ? segments[18].ToNullableDateTime() : null;
            SpecimenExpirationDateTime = segments.Length > 19 && segments[19].Length > 0 ? segments[19].ToNullableDateTime() : null;
            SpecimenAvailability = segments.Length > 20 && segments[20].Length > 0 ? segments[20] : null;
            SpecimenRejectReason = segments.Length > 21 && segments[21].Length > 0 ? segments[21].Split(separator).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            SpecimenQuality = segments.Length > 22 && segments[22].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[22], false) : null;
            SpecimenAppropriateness = segments.Length > 23 && segments[23].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[23], false) : null;
            SpecimenCondition = segments.Length > 24 && segments[24].Length > 0 ? segments[24].Split(separator).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            SpecimenCurrentQuantity = segments.Length > 25 && segments[25].Length > 0 ? TypeHelper.Deserialize<CompositeQuantityWithUnits>(segments[25], false) : null;
            NumberOfSpecimenContainers = segments.Length > 26 && segments[26].Length > 0 ? segments[26].ToNullableDecimal() : null;
            ContainerType = segments.Length > 27 && segments[27].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[27], false) : null;
            ContainerCondition = segments.Length > 28 && segments[28].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[28], false) : null;
            SpecimenChildRole = segments.Length > 29 && segments[29].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[29], false) : null;
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
                                StringHelper.StringFormatSequence(0, 30, Configuration.FieldSeparator),
                                Id,
                                SetIdSpm.HasValue ? SetIdSpm.Value.ToString(culture) : null,
                                SpecimenId?.ToDelimitedString(),
                                SpecimenParentIds != null ? string.Join(Configuration.FieldRepeatSeparator, SpecimenParentIds.Select(x => x.ToDelimitedString())) : null,
                                SpecimenType?.ToDelimitedString(),
                                SpecimenTypeModifier != null ? string.Join(Configuration.FieldRepeatSeparator, SpecimenTypeModifier.Select(x => x.ToDelimitedString())) : null,
                                SpecimenAdditives != null ? string.Join(Configuration.FieldRepeatSeparator, SpecimenAdditives.Select(x => x.ToDelimitedString())) : null,
                                SpecimenCollectionMethod?.ToDelimitedString(),
                                SpecimenSourceSite?.ToDelimitedString(),
                                SpecimenSourceSiteModifier != null ? string.Join(Configuration.FieldRepeatSeparator, SpecimenSourceSiteModifier.Select(x => x.ToDelimitedString())) : null,
                                SpecimenCollectionSite?.ToDelimitedString(),
                                SpecimenRole != null ? string.Join(Configuration.FieldRepeatSeparator, SpecimenRole.Select(x => x.ToDelimitedString())) : null,
                                SpecimenCollectionAmount?.ToDelimitedString(),
                                GroupedSpecimenCount.HasValue ? GroupedSpecimenCount.Value.ToString(Consts.NumericFormat, culture) : null,
                                SpecimenDescription != null ? string.Join(Configuration.FieldRepeatSeparator, SpecimenDescription) : null,
                                SpecimenHandlingCode != null ? string.Join(Configuration.FieldRepeatSeparator, SpecimenHandlingCode.Select(x => x.ToDelimitedString())) : null,
                                SpecimenRiskCode != null ? string.Join(Configuration.FieldRepeatSeparator, SpecimenRiskCode.Select(x => x.ToDelimitedString())) : null,
                                SpecimenCollectionDateTime?.ToDelimitedString(),
                                SpecimenReceivedDateTime.HasValue ? SpecimenReceivedDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                SpecimenExpirationDateTime.HasValue ? SpecimenExpirationDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                SpecimenAvailability,
                                SpecimenRejectReason != null ? string.Join(Configuration.FieldRepeatSeparator, SpecimenRejectReason.Select(x => x.ToDelimitedString())) : null,
                                SpecimenQuality?.ToDelimitedString(),
                                SpecimenAppropriateness?.ToDelimitedString(),
                                SpecimenCondition != null ? string.Join(Configuration.FieldRepeatSeparator, SpecimenCondition.Select(x => x.ToDelimitedString())) : null,
                                SpecimenCurrentQuantity?.ToDelimitedString(),
                                NumberOfSpecimenContainers.HasValue ? NumberOfSpecimenContainers.Value.ToString(Consts.NumericFormat, culture) : null,
                                ContainerType?.ToDelimitedString(),
                                ContainerCondition?.ToDelimitedString(),
                                SpecimenChildRole?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}