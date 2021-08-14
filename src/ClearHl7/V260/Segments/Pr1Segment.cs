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
    /// HL7 Version 2 Segment PR1 - Procedures.
    /// </summary>
    public class Pr1Segment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "PR1";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// PR1.1 - Set ID - PR1.
        /// </summary>
        public uint? SetIdPr1 { get; set; }

        /// <summary>
        /// PR1.2 - Procedure Coding Method.
        /// </summary>
        public string ProcedureCodingMethod { get; set; }

        /// <summary>
        /// PR1.3 - Procedure Code.
        /// <para>Suggested: 0088 Procedure Code</para>
        /// </summary>
        public CodedWithNoExceptions ProcedureCode { get; set; }

        /// <summary>
        /// PR1.4 - Procedure Description.
        /// </summary>
        public string ProcedureDescription { get; set; }

        /// <summary>
        /// PR1.5 - Procedure Date/Time.
        /// </summary>
        public DateTime? ProcedureDateTime { get; set; }

        /// <summary>
        /// PR1.6 - Procedure Functional Type.
        /// <para>Suggested: 0230 Procedure Functional Type -&gt; ClearHl7.Codes.V260.CodeProcedureFunctionalType</para>
        /// </summary>
        public string ProcedureFunctionalType { get; set; }

        /// <summary>
        /// PR1.7 - Procedure Minutes.
        /// </summary>
        public decimal? ProcedureMinutes { get; set; }

        /// <summary>
        /// PR1.8 - Anesthesiologist.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons Anesthesiologist { get; set; }

        /// <summary>
        /// PR1.9 - Anesthesia Code.
        /// <para>Suggested: 0019 Anesthesia Code</para>
        /// </summary>
        public string AnesthesiaCode { get; set; }

        /// <summary>
        /// PR1.10 - Anesthesia Minutes.
        /// </summary>
        public decimal? AnesthesiaMinutes { get; set; }

        /// <summary>
        /// PR1.11 - Surgeon.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons Surgeon { get; set; }

        /// <summary>
        /// PR1.12 - Procedure Practitioner.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons ProcedurePractitioner { get; set; }

        /// <summary>
        /// PR1.13 - Consent Code.
        /// <para>Suggested: 0059 Consent Code</para>
        /// </summary>
        public CodedWithExceptions ConsentCode { get; set; }

        /// <summary>
        /// PR1.14 - Procedure Priority.
        /// <para>Suggested: 0418 Procedure Priority -&gt; ClearHl7.Codes.V260.CodeProcedurePriority</para>
        /// </summary>
        public decimal? ProcedurePriority { get; set; }

        /// <summary>
        /// PR1.15 - Associated Diagnosis Code.
        /// <para>Suggested: 0051 Diagnosis Code</para>
        /// </summary>
        public CodedWithExceptions AssociatedDiagnosisCode { get; set; }

        /// <summary>
        /// PR1.16 - Procedure Code Modifier.
        /// <para>Suggested: 0340 Procedure Code Modifier</para>
        /// </summary>
        public IEnumerable<CodedWithNoExceptions> ProcedureCodeModifier { get; set; }

        /// <summary>
        /// PR1.17 - Procedure DRG Type.
        /// <para>Suggested: 0416 Procedure DRG Type -&gt; ClearHl7.Codes.V260.CodeProcedureDrgType</para>
        /// </summary>
        public string ProcedureDrgType { get; set; }

        /// <summary>
        /// PR1.18 - Tissue Type Code.
        /// <para>Suggested: 0417 Tissue Type Code -&gt; ClearHl7.Codes.V260.CodeTissueTypeCode</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> TissueTypeCode { get; set; }

        /// <summary>
        /// PR1.19 - Procedure Identifier.
        /// </summary>
        public EntityIdentifier ProcedureIdentifier { get; set; }

        /// <summary>
        /// PR1.20 - Procedure Action Code.
        /// <para>Suggested: 0206 Segment Action Code -&gt; ClearHl7.Codes.V260.CodeSegmentActionCode</para>
        /// </summary>
        public string ProcedureActionCode { get; set; }

        /// <summary>
        /// PR1.21 - DRG Procedure Determination Status.
        /// <para>Suggested: 0761 DRG Procedure Determination Status -&gt; ClearHl7.Codes.V260.CodeDrgProcedureDeterminationStatus</para>
        /// </summary>
        public string DrgProcedureDeterminationStatus { get; set; }

        /// <summary>
        /// PR1.22 - DRG Procedure Relevance.
        /// <para>Suggested: 0763 DRG Procedure Relevance -&gt; ClearHl7.Codes.V260.CodeDrgProcedureRelevance</para>
        /// </summary>
        public string DrgProcedureRelevance { get; set; }

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
                if (string.Compare(Id, segments.First(), true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ Configuration.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            SetIdPr1 = segments.ElementAtOrDefault(1)?.ToNullableUInt();
            ProcedureCodingMethod = segments.ElementAtOrDefault(2);
            ProcedureCode = segments.Length > 3 ? TypeHelper.Deserialize<CodedWithNoExceptions>(segments.ElementAtOrDefault(3), false) : null;
            ProcedureDescription = segments.ElementAtOrDefault(4);
            ProcedureDateTime = segments.ElementAtOrDefault(5)?.ToNullableDateTime();
            ProcedureFunctionalType = segments.ElementAtOrDefault(6);
            ProcedureMinutes = segments.ElementAtOrDefault(7)?.ToNullableDecimal();
            Anesthesiologist = segments.Length > 8 ? TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments.ElementAtOrDefault(8), false) : null;
            AnesthesiaCode = segments.ElementAtOrDefault(9);
            AnesthesiaMinutes = segments.ElementAtOrDefault(10)?.ToNullableDecimal();
            Surgeon = segments.Length > 11 ? TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments.ElementAtOrDefault(11), false) : null;
            ProcedurePractitioner = segments.Length > 12 ? TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments.ElementAtOrDefault(12), false) : null;
            ConsentCode = segments.Length > 13 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(13), false) : null;
            ProcedurePriority = segments.ElementAtOrDefault(14)?.ToNullableDecimal();
            AssociatedDiagnosisCode = segments.Length > 15 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(15), false) : null;
            ProcedureCodeModifier = segments.Length > 16 ? segments.ElementAtOrDefault(16).Split(separator).Select(x => TypeHelper.Deserialize<CodedWithNoExceptions>(x, false)) : null;
            ProcedureDrgType = segments.ElementAtOrDefault(17);
            TissueTypeCode = segments.Length > 18 ? segments.ElementAtOrDefault(18).Split(separator).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            ProcedureIdentifier = segments.Length > 19 ? TypeHelper.Deserialize<EntityIdentifier>(segments.ElementAtOrDefault(19), false) : null;
            ProcedureActionCode = segments.ElementAtOrDefault(20);
            DrgProcedureDeterminationStatus = segments.ElementAtOrDefault(21);
            DrgProcedureRelevance = segments.ElementAtOrDefault(22);
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
                                StringHelper.StringFormatSequence(0, 23, Configuration.FieldSeparator),
                                Id,
                                SetIdPr1.HasValue ? SetIdPr1.Value.ToString(culture) : null,
                                ProcedureCodingMethod,
                                ProcedureCode?.ToDelimitedString(),
                                ProcedureDescription,
                                ProcedureDateTime.HasValue ? ProcedureDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ProcedureFunctionalType,
                                ProcedureMinutes.HasValue ? ProcedureMinutes.Value.ToString(Consts.NumericFormat, culture) : null,
                                Anesthesiologist?.ToDelimitedString(),
                                AnesthesiaCode,
                                AnesthesiaMinutes.HasValue ? AnesthesiaMinutes.Value.ToString(Consts.NumericFormat, culture) : null,
                                Surgeon?.ToDelimitedString(),
                                ProcedurePractitioner?.ToDelimitedString(),
                                ConsentCode?.ToDelimitedString(),
                                ProcedurePriority.HasValue ? ProcedurePriority.Value.ToString(Consts.NumericFormat, culture) : null,
                                AssociatedDiagnosisCode?.ToDelimitedString(),
                                ProcedureCodeModifier != null ? string.Join(Configuration.FieldRepeatSeparator, ProcedureCodeModifier.Select(x => x.ToDelimitedString())) : null,
                                ProcedureDrgType,
                                TissueTypeCode != null ? string.Join(Configuration.FieldRepeatSeparator, TissueTypeCode.Select(x => x.ToDelimitedString())) : null,
                                ProcedureIdentifier?.ToDelimitedString(),
                                ProcedureActionCode,
                                DrgProcedureDeterminationStatus,
                                DrgProcedureRelevance
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}