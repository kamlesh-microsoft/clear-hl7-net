﻿using System;
using System.Collections.Generic;
using System.Linq;
using ClearHl7.Fhir.V250.Types;

namespace ClearHl7.Fhir.V250.Segments
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
        public DateTimeRange TransactionDate { get; set; }

        /// <summary>
        /// FT1.5 - Transaction Posting Date.
        /// </summary>
        public DateTime? TransactionPostingDate { get; set; }

        /// <summary>
        /// FT1.6 - Transaction Type.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0017</remarks>
        public string TransactionType { get; set; }

        /// <summary>
        /// FT1.7 - Transaction Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0132</remarks>
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
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0049</remarks>
        public CodedElement DepartmentCode { get; set; }

        /// <summary>
        /// FT1.14 - Health Plan ID.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0072</remarks>
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
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0024</remarks>
        public string FeeSchedule { get; set; }

        /// <summary>
        /// FT1.18 - Patient Type.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0018</remarks>
        public string PatientType { get; set; }

        /// <summary>
        /// FT1.19 - Diagnosis Code - FT1.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0051</remarks>
        public IEnumerable<CodedElement> DiagnosisCodeFt1 { get; set; }

        /// <summary>
        /// FT1.20 - Performed By Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0084</remarks>
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
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0088</remarks>
        public CodedElement ProcedureCode { get; set; }

        /// <summary>
        /// FT1.26 - Procedure Code Modifier.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0340</remarks>
        public IEnumerable<CodedElement> ProcedureCodeModifier { get; set; }

        /// <summary>
        /// FT1.27 - Advanced Beneficiary Notice Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0339</remarks>
        public CodedElement AdvancedBeneficiaryNoticeCode { get; set; }

        /// <summary>
        /// FT1.28 - Medically Necessary Duplicate Procedure Reason.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0476</remarks>
        public CodedWithExceptions MedicallyNecessaryDuplicateProcedureReason { get; set; }

        /// <summary>
        /// FT1.29 - NDC Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0549</remarks>
        public CodedWithNoExceptions NdcCode { get; set; }

        /// <summary>
        /// FT1.30 - Payment Reference ID.
        /// </summary>
        public ExtendedCompositeIdWithCheckDigit PaymentReferenceId { get; set; }

        /// <summary>
        /// FT1.31 - Transaction Reference Key.
        /// </summary>
        public IEnumerable<uint> TransactionReferenceKey { get; set; }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                "{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|{30}|{31}",
                                Id,
                                SetIdFt1.HasValue ? SetIdFt1.Value.ToString(culture) : null,
                                TransactionId,
                                TransactionBatchId,
                                TransactionDate?.ToDelimitedString(),
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
                                DiagnosisCodeFt1 != null ? string.Join("~", DiagnosisCodeFt1.Select(x => x.ToDelimitedString())) : null,
                                PerformedByCode != null ? string.Join("~", PerformedByCode.Select(x => x.ToDelimitedString())) : null,
                                OrderedByCode != null ? string.Join("~", OrderedByCode.Select(x => x.ToDelimitedString())) : null,
                                UnitCost?.ToDelimitedString(),
                                FillerOrderNumber?.ToDelimitedString(),
                                EnteredByCode != null ? string.Join("~", EnteredByCode.Select(x => x.ToDelimitedString())) : null,
                                ProcedureCode?.ToDelimitedString(),
                                ProcedureCodeModifier != null ? string.Join("~", ProcedureCodeModifier.Select(x => x.ToDelimitedString())) : null,
                                AdvancedBeneficiaryNoticeCode?.ToDelimitedString(),
                                MedicallyNecessaryDuplicateProcedureReason?.ToDelimitedString(),
                                NdcCode?.ToDelimitedString(),
                                PaymentReferenceId?.ToDelimitedString(),
                                TransactionReferenceKey != null ? string.Join("~", TransactionReferenceKey.Select(x => x.ToString(Consts.NumericFormat, culture))) : null
                                ).TrimEnd('|');
        }
    }
}