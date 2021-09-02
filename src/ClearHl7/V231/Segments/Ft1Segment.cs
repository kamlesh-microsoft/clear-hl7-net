﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V231.Types;

namespace ClearHl7.V231.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment FT1 - Financial Transaction.
    /// </summary>
    public class Ft1Segment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "FT1";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// FT1.1 - Set ID - FT1.
        /// </summary>
        public uint? SetIdFt1 { get; set; }

        /// <summary>
        /// FT1.2 - Transaction ID.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// FT1.3 - Transaction Batch ID.
        /// </summary>
        public string TransactionBatchId { get; set; }

        /// <summary>
        /// FT1.4 - Transaction Date.
        /// </summary>
        public DateTime? TransactionDate { get; set; }

        /// <summary>
        /// FT1.5 - Transaction Posting Date.
        /// </summary>
        public DateTime? TransactionPostingDate { get; set; }

        /// <summary>
        /// FT1.6 - Transaction Type.
        /// <para>Suggested: 0017 Transaction Type -&gt; ClearHl7.Codes.V231.CodeTransactionType</para>
        /// </summary>
        public string TransactionType { get; set; }

        /// <summary>
        /// FT1.7 - Transaction Code.
        /// <para>Suggested: 0132 Transaction Code</para>
        /// </summary>
        public CodedElement TransactionCode { get; set; }

        /// <summary>
        /// FT1.8 - Transaction Description.
        /// </summary>
        public string TransactionDescription { get; set; }

        /// <summary>
        /// FT1.9 - Transaction Description - Alt.
        /// </summary>
        public string TransactionDescriptionAlt { get; set; }

        /// <summary>
        /// FT1.10 - Transaction Quantity.
        /// </summary>
        public decimal? TransactionQuantity { get; set; }

        /// <summary>
        /// FT1.11 - Transaction Amount - Extended.
        /// </summary>
        public CompositePrice TransactionAmountExtended { get; set; }

        /// <summary>
        /// FT1.12 - Transaction amount - unit.
        /// </summary>
        public CompositePrice TransactionAmountUnit { get; set; }

        /// <summary>
        /// FT1.13 - Department Code.
        /// <para>Suggested: 0049 Department Code</para>
        /// </summary>
        public CodedElement DepartmentCode { get; set; }

        /// <summary>
        /// FT1.14 - Health Plan ID.
        /// <para>Suggested: 0072 Insurance Plan ID</para>
        /// </summary>
        public CodedElement HealthPlanId { get; set; }

        /// <summary>
        /// FT1.15 - Insurance Amount.
        /// </summary>
        public CompositePrice InsuranceAmount { get; set; }

        /// <summary>
        /// FT1.16 - Assigned Patient Location.
        /// </summary>
        public PersonLocation AssignedPatientLocation { get; set; }

        /// <summary>
        /// FT1.17 - Fee Schedule.
        /// <para>Suggested: 0024 Fee Schedule</para>
        /// </summary>
        public string FeeSchedule { get; set; }

        /// <summary>
        /// FT1.18 - Patient Type.
        /// <para>Suggested: 0018 Patient Type</para>
        /// </summary>
        public string PatientType { get; set; }

        /// <summary>
        /// FT1.19 - Diagnosis Code - FT1.
        /// <para>Suggested: 0051 Diagnosis Code</para>
        /// </summary>
        public IEnumerable<CodedElement> DiagnosisCodeFt1 { get; set; }

        /// <summary>
        /// FT1.20 - Performed By Code.
        /// <para>Suggested: 0084 Performed By</para>
        /// </summary>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> PerformedByCode { get; set; }

        /// <summary>
        /// FT1.21 - Ordered By Code.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> OrderedByCode { get; set; }

        /// <summary>
        /// FT1.22 - Unit Cost.
        /// </summary>
        public CompositePrice UnitCost { get; set; }

        /// <summary>
        /// FT1.23 - Filler Order Number.
        /// </summary>
        public EntityIdentifier FillerOrderNumber { get; set; }

        /// <summary>
        /// FT1.24 - Entered By Code.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> EnteredByCode { get; set; }

        /// <summary>
        /// FT1.25 - Procedure Code.
        /// <para>Suggested: 0088 Procedure Code</para>
        /// </summary>
        public CodedElement ProcedureCode { get; set; }

        /// <summary>
        /// FT1.26 - Procedure Code Modifier.
        /// <para>Suggested: 0340 Procedure Code Modifier</para>
        /// </summary>
        public IEnumerable<CodedElement> ProcedureCodeModifier { get; set; }

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
                ? Array.Empty<string>()
                : delimitedString.Split(seps.FieldSeparator, StringSplitOptions.None);
            
            if (segments.Length > 0)
            {
                if (string.Compare(Id, segments[0], true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ seps.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            SetIdFt1 = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableUInt() : null;
            TransactionId = segments.Length > 2 && segments[2].Length > 0 ? segments[2] : null;
            TransactionBatchId = segments.Length > 3 && segments[3].Length > 0 ? segments[3] : null;
            TransactionDate = segments.Length > 4 && segments[4].Length > 0 ? segments[4].ToNullableDateTime() : null;
            TransactionPostingDate = segments.Length > 5 && segments[5].Length > 0 ? segments[5].ToNullableDateTime() : null;
            TransactionType = segments.Length > 6 && segments[6].Length > 0 ? segments[6] : null;
            TransactionCode = segments.Length > 7 && segments[7].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[7], false, seps) : null;
            TransactionDescription = segments.Length > 8 && segments[8].Length > 0 ? segments[8] : null;
            TransactionDescriptionAlt = segments.Length > 9 && segments[9].Length > 0 ? segments[9] : null;
            TransactionQuantity = segments.Length > 10 && segments[10].Length > 0 ? segments[10].ToNullableDecimal() : null;
            TransactionAmountExtended = segments.Length > 11 && segments[11].Length > 0 ? TypeSerializer.Deserialize<CompositePrice>(segments[11], false, seps) : null;
            TransactionAmountUnit = segments.Length > 12 && segments[12].Length > 0 ? TypeSerializer.Deserialize<CompositePrice>(segments[12], false, seps) : null;
            DepartmentCode = segments.Length > 13 && segments[13].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[13], false, seps) : null;
            HealthPlanId = segments.Length > 14 && segments[14].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[14], false, seps) : null;
            InsuranceAmount = segments.Length > 15 && segments[15].Length > 0 ? TypeSerializer.Deserialize<CompositePrice>(segments[15], false, seps) : null;
            AssignedPatientLocation = segments.Length > 16 && segments[16].Length > 0 ? TypeSerializer.Deserialize<PersonLocation>(segments[16], false, seps) : null;
            FeeSchedule = segments.Length > 17 && segments[17].Length > 0 ? segments[17] : null;
            PatientType = segments.Length > 18 && segments[18].Length > 0 ? segments[18] : null;
            DiagnosisCodeFt1 = segments.Length > 19 && segments[19].Length > 0 ? segments[19].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<CodedElement>(x, false, seps)) : null;
            PerformedByCode = segments.Length > 20 && segments[20].Length > 0 ? segments[20].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(x, false, seps)) : null;
            OrderedByCode = segments.Length > 21 && segments[21].Length > 0 ? segments[21].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(x, false, seps)) : null;
            UnitCost = segments.Length > 22 && segments[22].Length > 0 ? TypeSerializer.Deserialize<CompositePrice>(segments[22], false, seps) : null;
            FillerOrderNumber = segments.Length > 23 && segments[23].Length > 0 ? TypeSerializer.Deserialize<EntityIdentifier>(segments[23], false, seps) : null;
            EnteredByCode = segments.Length > 24 && segments[24].Length > 0 ? segments[24].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(x, false, seps)) : null;
            ProcedureCode = segments.Length > 25 && segments[25].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[25], false, seps) : null;
            ProcedureCodeModifier = segments.Length > 26 && segments[26].Length > 0 ? segments[26].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<CodedElement>(x, false, seps)) : null;
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
                                StringHelper.StringFormatSequence(0, 27, Configuration.FieldSeparator),
                                Id,
                                SetIdFt1.HasValue ? SetIdFt1.Value.ToString(culture) : null,
                                TransactionId,
                                TransactionBatchId,
                                TransactionDate.HasValue ? TransactionDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                TransactionPostingDate.HasValue ? TransactionPostingDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                TransactionType,
                                TransactionCode?.ToDelimitedString(),
                                TransactionDescription,
                                TransactionDescriptionAlt,
                                TransactionQuantity.HasValue ? TransactionQuantity.Value.ToString(Consts.NumericFormat, culture) : null,
                                TransactionAmountExtended?.ToDelimitedString(),
                                TransactionAmountUnit?.ToDelimitedString(),
                                DepartmentCode?.ToDelimitedString(),
                                HealthPlanId?.ToDelimitedString(),
                                InsuranceAmount?.ToDelimitedString(),
                                AssignedPatientLocation?.ToDelimitedString(),
                                FeeSchedule,
                                PatientType,
                                DiagnosisCodeFt1 != null ? string.Join(Configuration.FieldRepeatSeparator, DiagnosisCodeFt1.Select(x => x.ToDelimitedString())) : null,
                                PerformedByCode != null ? string.Join(Configuration.FieldRepeatSeparator, PerformedByCode.Select(x => x.ToDelimitedString())) : null,
                                OrderedByCode != null ? string.Join(Configuration.FieldRepeatSeparator, OrderedByCode.Select(x => x.ToDelimitedString())) : null,
                                UnitCost?.ToDelimitedString(),
                                FillerOrderNumber?.ToDelimitedString(),
                                EnteredByCode != null ? string.Join(Configuration.FieldRepeatSeparator, EnteredByCode.Select(x => x.ToDelimitedString())) : null,
                                ProcedureCode?.ToDelimitedString(),
                                ProcedureCodeModifier != null ? string.Join(Configuration.FieldRepeatSeparator, ProcedureCodeModifier.Select(x => x.ToDelimitedString())) : null
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}