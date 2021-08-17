﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V240.Types;

namespace ClearHl7.V240.Segments
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
        /// <para>Suggested: 0089 Procedure Coding Method</para>
        /// </summary>
        public string ProcedureCodingMethod { get; set; }

        /// <summary>
        /// PR1.3 - Procedure Code.
        /// <para>Suggested: 0088 Procedure Code</para>
        /// </summary>
        public CodedElement ProcedureCode { get; set; }

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
        /// <para>Suggested: 0230 Procedure Functional Type -&gt; ClearHl7.Codes.V240.CodeProcedureFunctionalType</para>
        /// </summary>
        public string ProcedureFunctionalType { get; set; }

        /// <summary>
        /// PR1.7 - Procedure Minutes.
        /// </summary>
        public decimal? ProcedureMinutes { get; set; }

        /// <summary>
        /// PR1.8 - Anesthesiologist.
        /// <para>Suggested: 0010 Physician ID</para>
        /// </summary>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> Anesthesiologist { get; set; }

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
        /// <para>Suggested: 0010 Physician ID</para>
        /// </summary>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> Surgeon { get; set; }

        /// <summary>
        /// PR1.12 - Procedure Practitioner.
        /// <para>Suggested: 0010 Physician ID</para>
        /// </summary>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> ProcedurePractitioner { get; set; }

        /// <summary>
        /// PR1.13 - Consent Code.
        /// <para>Suggested: 0059 Consent Code</para>
        /// </summary>
        public CodedElement ConsentCode { get; set; }

        /// <summary>
        /// PR1.14 - Procedure Priority.
        /// <para>Suggested: 0418 Procedure Priority -&gt; ClearHl7.Codes.V240.CodeProcedurePriority</para>
        /// </summary>
        public string ProcedurePriority { get; set; }

        /// <summary>
        /// PR1.15 - Associated Diagnosis Code.
        /// <para>Suggested: 0051 Diagnosis Code</para>
        /// </summary>
        public CodedElement AssociatedDiagnosisCode { get; set; }

        /// <summary>
        /// PR1.16 - Procedure Code Modifier.
        /// <para>Suggested: 0340 Procedure Code Modifier</para>
        /// </summary>
        public IEnumerable<CodedElement> ProcedureCodeModifier { get; set; }

        /// <summary>
        /// PR1.17 - Procedure DRG Type.
        /// <para>Suggested: 0416 Procedure DRG Type -&gt; ClearHl7.Codes.V240.CodeProcedureDrgType</para>
        /// </summary>
        public string ProcedureDrgType { get; set; }

        /// <summary>
        /// PR1.18 - Tissue Type Code.
        /// <para>Suggested: 0417 Tissue Type Code -&gt; ClearHl7.Codes.V240.CodeTissueTypeCode</para>
        /// </summary>
        public IEnumerable<CodedElement> TissueTypeCode { get; set; }

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

            SetIdPr1 = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableUInt() : null;
            ProcedureCodingMethod = segments.Length > 2 && segments[2].Length > 0 ? segments[2] : null;
            ProcedureCode = segments.Length > 3 && segments[3].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[3], false) : null;
            ProcedureDescription = segments.Length > 4 && segments[4].Length > 0 ? segments[4] : null;
            ProcedureDateTime = segments.Length > 5 && segments[5].Length > 0 ? segments[5].ToNullableDateTime() : null;
            ProcedureFunctionalType = segments.Length > 6 && segments[6].Length > 0 ? segments[6] : null;
            ProcedureMinutes = segments.Length > 7 && segments[7].Length > 0 ? segments[7].ToNullableDecimal() : null;
            Anesthesiologist = segments.Length > 8 && segments[8].Length > 0 ? segments[8].Split(separator).Select(x => TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(x, false)) : null;
            AnesthesiaCode = segments.Length > 9 && segments[9].Length > 0 ? segments[9] : null;
            AnesthesiaMinutes = segments.Length > 10 && segments[10].Length > 0 ? segments[10].ToNullableDecimal() : null;
            Surgeon = segments.Length > 11 && segments[11].Length > 0 ? segments[11].Split(separator).Select(x => TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(x, false)) : null;
            ProcedurePractitioner = segments.Length > 12 && segments[12].Length > 0 ? segments[12].Split(separator).Select(x => TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(x, false)) : null;
            ConsentCode = segments.Length > 13 && segments[13].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[13], false) : null;
            ProcedurePriority = segments.Length > 14 && segments[14].Length > 0 ? segments[14] : null;
            AssociatedDiagnosisCode = segments.Length > 15 && segments[15].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[15], false) : null;
            ProcedureCodeModifier = segments.Length > 16 && segments[16].Length > 0 ? segments[16].Split(separator).Select(x => TypeHelper.Deserialize<CodedElement>(x, false)) : null;
            ProcedureDrgType = segments.Length > 17 && segments[17].Length > 0 ? segments[17] : null;
            TissueTypeCode = segments.Length > 18 && segments[18].Length > 0 ? segments[18].Split(separator).Select(x => TypeHelper.Deserialize<CodedElement>(x, false)) : null;
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
                                StringHelper.StringFormatSequence(0, 19, Configuration.FieldSeparator),
                                Id,
                                SetIdPr1.HasValue ? SetIdPr1.Value.ToString(culture) : null,
                                ProcedureCodingMethod,
                                ProcedureCode?.ToDelimitedString(),
                                ProcedureDescription,
                                ProcedureDateTime.HasValue ? ProcedureDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ProcedureFunctionalType,
                                ProcedureMinutes.HasValue ? ProcedureMinutes.Value.ToString(Consts.NumericFormat, culture) : null,
                                Anesthesiologist != null ? string.Join(Configuration.FieldRepeatSeparator, Anesthesiologist.Select(x => x.ToDelimitedString())) : null,
                                AnesthesiaCode,
                                AnesthesiaMinutes.HasValue ? AnesthesiaMinutes.Value.ToString(Consts.NumericFormat, culture) : null,
                                Surgeon != null ? string.Join(Configuration.FieldRepeatSeparator, Surgeon.Select(x => x.ToDelimitedString())) : null,
                                ProcedurePractitioner != null ? string.Join(Configuration.FieldRepeatSeparator, ProcedurePractitioner.Select(x => x.ToDelimitedString())) : null,
                                ConsentCode?.ToDelimitedString(),
                                ProcedurePriority,
                                AssociatedDiagnosisCode?.ToDelimitedString(),
                                ProcedureCodeModifier != null ? string.Join(Configuration.FieldRepeatSeparator, ProcedureCodeModifier.Select(x => x.ToDelimitedString())) : null,
                                ProcedureDrgType,
                                TissueTypeCode != null ? string.Join(Configuration.FieldRepeatSeparator, TissueTypeCode.Select(x => x.ToDelimitedString())) : null
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}