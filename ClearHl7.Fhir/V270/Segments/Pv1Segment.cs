using System;
using System.Collections.Generic;
using System.Linq;
using ClearHl7.Fhir.V270.Types;

namespace ClearHl7.Fhir.V270.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment PV1 - Patient Visit.
    /// </summary>
    public class Pv1Segment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "PV1";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// PV1.1 - Set ID - PV1.
        /// </summary>
        public uint? SetIdPv1 { get; set; }

        /// <summary>
        /// PV1.2 - Patient Class.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0004</remarks>
        public CodedWithExceptions PatientClass { get; set; }

        /// <summary>
        /// PV1.3 - Assigned Patient Location.
        /// </summary>
        public PersonLocation AssignedPatientLocation { get; set; }

        /// <summary>
        /// PV1.4 - Admission Type.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0007</remarks>
        public CodedWithExceptions AdmissionType { get; set; }

        /// <summary>
        /// PV1.5 - Preadmit Number.
        /// </summary>
        public ExtendedCompositeIdWithCheckDigit PreadmitNumber { get; set; }

        /// <summary>
        /// PV1.6 - Prior Patient Location.
        /// </summary>
        public PersonLocation PriorPatientLocation { get; set; }

        /// <summary>
        /// PV1.7 - Attending Doctor.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0010</remarks>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> AttendingDoctor { get; set; }

        /// <summary>
        /// PV1.8 - Referring Doctor.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0010</remarks>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> ReferringDoctor { get; set; }

        /// <summary>
        /// PV1.9 - Consulting Doctor.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> ConsultingDoctor { get; set; }

        /// <summary>
        /// PV1.10 - Hospital Service.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0069</remarks>
        public CodedWithExceptions HospitalService { get; set; }

        /// <summary>
        /// PV1.11 - Temporary Location.
        /// </summary>
        public PersonLocation TemporaryLocation { get; set; }

        /// <summary>
        /// PV1.12 - Preadmit Test Indicator.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0087</remarks>
        public CodedWithExceptions PreadmitTestIndicator { get; set; }

        /// <summary>
        /// PV1.13 - Re-admission Indicator.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0092</remarks>
        public CodedWithExceptions ReAdmissionIndicator { get; set; }

        /// <summary>
        /// PV1.14 - Admit Source.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0023</remarks>
        public CodedWithExceptions AdmitSource { get; set; }

        /// <summary>
        /// PV1.15 - Ambulatory Status.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0009</remarks>
        public IEnumerable<CodedWithExceptions> AmbulatoryStatus { get; set; }

        /// <summary>
        /// PV1.16 - VIP Indicator.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0099</remarks>
        public CodedWithExceptions VipIndicator { get; set; }

        /// <summary>
        /// PV1.17 - Admitting Doctor.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0010</remarks>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> AdmittingDoctor { get; set; }

        /// <summary>
        /// PV1.18 - Patient Type.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0018</remarks>
        public CodedWithExceptions PatientType { get; set; }

        /// <summary>
        /// PV1.19 - Visit Number.
        /// </summary>
        public ExtendedCompositeIdWithCheckDigit VisitNumber { get; set; }

        /// <summary>
        /// PV1.20 - Financial Class.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0064</remarks>
        public IEnumerable<FinancialClass> FinancialClass { get; set; }

        /// <summary>
        /// PV1.21 - Charge Price Indicator.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0032</remarks>
        public CodedWithExceptions ChargePriceIndicator { get; set; }

        /// <summary>
        /// PV1.22 - Courtesy Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0045</remarks>
        public CodedWithExceptions CourtesyCode { get; set; }

        /// <summary>
        /// PV1.23 - Credit Rating.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0046</remarks>
        public CodedWithExceptions CreditRating { get; set; }

        /// <summary>
        /// PV1.24 - Contract Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0044</remarks>
        public IEnumerable<CodedWithExceptions> ContractCode { get; set; }

        /// <summary>
        /// PV1.25 - Contract Effective Date.
        /// </summary>
        public IEnumerable<DateTime> ContractEffectiveDate { get; set; }

        /// <summary>
        /// PV1.26 - Contract Amount.
        /// </summary>
        public IEnumerable<decimal> ContractAmount { get; set; }

        /// <summary>
        /// PV1.27 - Contract Period.
        /// </summary>
        public IEnumerable<decimal> ContractPeriod { get; set; }

        /// <summary>
        /// PV1.28 - Interest Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0073</remarks>
        public CodedWithExceptions InterestCode { get; set; }

        /// <summary>
        /// PV1.29 - Transfer to Bad Debt Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0110</remarks>
        public CodedWithExceptions TransferToBadDebtCode { get; set; }

        /// <summary>
        /// PV1.30 - Transfer to Bad Debt Date.
        /// </summary>
        public DateTime? TransferToBadDebtDate { get; set; }

        /// <summary>
        /// PV1.31 - Bad Debt Agency Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0021</remarks>
        public CodedWithExceptions BadDebtAgencyCode { get; set; }

        /// <summary>
        /// PV1.32 - Bad Debt Transfer Amount.
        /// </summary>
        public decimal? BadDebtTransferAmount { get; set; }

        /// <summary>
        /// PV1.33 - Bad Debt Recovery Amount.
        /// </summary>
        public decimal? BadDebtRecoveryAmount { get; set; }

        /// <summary>
        /// PV1.34 - Delete Account Indicator.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0111</remarks>
        public CodedWithExceptions DeleteAccountIndicator { get; set; }

        /// <summary>
        /// PV1.35 - Delete Account Date.
        /// </summary>
        public DateTime? DeleteAccountDate { get; set; }

        /// <summary>
        /// PV1.36 - Discharge Disposition.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0112</remarks>
        public CodedWithExceptions DischargeDisposition { get; set; }

        /// <summary>
        /// PV1.37 - Discharged to Location.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0113</remarks>
        public DischargeToLocationAndDate DischargedToLocation { get; set; }

        /// <summary>
        /// PV1.38 - Diet Type.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0114</remarks>
        public CodedWithExceptions DietType { get; set; }

        /// <summary>
        /// PV1.39 - Servicing Facility.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0115</remarks>
        public CodedWithExceptions ServicingFacility { get; set; }

        /// <summary>
        /// PV1.40 - Bed Status.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0116</remarks>
        public CodedWithExceptions BedStatus { get; set; }

        /// <summary>
        /// PV1.41 - Account Status.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0117</remarks>
        public CodedWithExceptions AccountStatus { get; set; }

        /// <summary>
        /// PV1.42 - Pending Location.
        /// </summary>
        public PersonLocation PendingLocation { get; set; }

        /// <summary>
        /// PV1.43 - Prior Temporary Location.
        /// </summary>
        public PersonLocation PriorTemporaryLocation { get; set; }

        /// <summary>
        /// PV1.44 - Admit Date/Time.
        /// </summary>
        public DateTime? AdmitDateTime { get; set; }

        /// <summary>
        /// PV1.45 - Discharge Date/Time.
        /// </summary>
        public DateTime? DischargeDateTime { get; set; }

        /// <summary>
        /// PV1.46 - Current Patient Balance.
        /// </summary>
        public decimal? CurrentPatientBalance { get; set; }

        /// <summary>
        /// PV1.47 - Total Charges.
        /// </summary>
        public decimal? TotalCharges { get; set; }

        /// <summary>
        /// PV1.48 - Total Adjustments.
        /// </summary>
        public decimal? TotalAdjustments { get; set; }

        /// <summary>
        /// PV1.49 - Total Payments.
        /// </summary>
        public decimal? TotalPayments { get; set; }

        /// <summary>
        /// PV1.50 - Alternate Visit ID.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0203</remarks>
        public ExtendedCompositeIdWithCheckDigit AlternateVisitId { get; set; }

        /// <summary>
        /// PV1.51 - Visit Indicator.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0326</remarks>
        public CodedWithExceptions VisitIndicator { get; set; }

        /// <summary>
        /// PV1.52 - Other Healthcare Provider.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons OtherHealthcareProvider { get; set; }

        /// <summary>
        /// PV1.53 - Service Episode Description.
        /// </summary>
        public string ServiceEpisodeDescription { get; set; }

        /// <summary>
        /// PV1.54 - Service Episode Identifier.
        /// </summary>
        public ExtendedCompositeIdWithCheckDigit ServiceEpisodeIdentifier { get; set; }
        
        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                "{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|{30}|{31}|{32}|{33}|{34}|{35}|{36}|{37}|{38}|{39}|{40}|{41}|{42}|{43}|{44}|{45}|{46}|{47}|{48}|{49}|{50}|{51}|{52}|{53}|{54}",
                                Id,
                                SetIdPv1.HasValue ? SetIdPv1.Value.ToString(culture) : null,
                                PatientClass?.ToDelimitedString(),
                                AssignedPatientLocation?.ToDelimitedString(),
                                AdmissionType?.ToDelimitedString(),
                                PreadmitNumber?.ToDelimitedString(),
                                PriorPatientLocation?.ToDelimitedString(),
                                AttendingDoctor != null ? string.Join("~", AttendingDoctor.Select(x => x.ToDelimitedString())) : null,
                                ReferringDoctor != null ? string.Join("~", ReferringDoctor.Select(x => x.ToDelimitedString())) : null,
                                ConsultingDoctor != null ? string.Join("~", ConsultingDoctor.Select(x => x.ToDelimitedString())) : null,
                                HospitalService?.ToDelimitedString(),
                                TemporaryLocation?.ToDelimitedString(),
                                PreadmitTestIndicator?.ToDelimitedString(),
                                ReAdmissionIndicator?.ToDelimitedString(),
                                AdmitSource?.ToDelimitedString(),
                                AmbulatoryStatus != null ? string.Join("~", AmbulatoryStatus.Select(x => x.ToDelimitedString())) : null,
                                VipIndicator?.ToDelimitedString(),
                                AdmittingDoctor != null ? string.Join("~", AdmittingDoctor.Select(x => x.ToDelimitedString())) : null,
                                PatientType?.ToDelimitedString(),
                                VisitNumber?.ToDelimitedString(),
                                FinancialClass != null ? string.Join("~", FinancialClass.Select(x => x.ToDelimitedString())) : null,
                                ChargePriceIndicator?.ToDelimitedString(),
                                CourtesyCode?.ToDelimitedString(),
                                CreditRating?.ToDelimitedString(),
                                ContractCode != null ? string.Join("~", ContractCode.Select(x => x.ToDelimitedString())) : null,
                                ContractEffectiveDate != null ? string.Join("~", ContractEffectiveDate.Select(x => x.ToString(Consts.DateFormatPrecisionDay, culture))) : null,
                                ContractAmount != null ? string.Join("~", ContractAmount.Select(x => x.ToString(Consts.NumericFormat, culture))) : null,
                                ContractPeriod != null ? string.Join("~", ContractPeriod.Select(x => x.ToString(Consts.NumericFormat, culture))) : null,
                                InterestCode?.ToDelimitedString(),
                                TransferToBadDebtCode?.ToDelimitedString(),
                                TransferToBadDebtDate.HasValue ? TransferToBadDebtDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                BadDebtAgencyCode?.ToDelimitedString(),
                                BadDebtTransferAmount.HasValue ? BadDebtTransferAmount.Value.ToString(Consts.NumericFormat, culture) : null,
                                BadDebtRecoveryAmount.HasValue ? BadDebtRecoveryAmount.Value.ToString(Consts.NumericFormat, culture) : null,
                                DeleteAccountIndicator?.ToDelimitedString(),
                                DeleteAccountDate.HasValue ? DeleteAccountDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                DischargeDisposition?.ToDelimitedString(),
                                DischargedToLocation?.ToDelimitedString(),
                                DietType?.ToDelimitedString(),
                                ServicingFacility?.ToDelimitedString(),
                                BedStatus?.ToDelimitedString(),
                                AccountStatus?.ToDelimitedString(),
                                PendingLocation?.ToDelimitedString(),
                                PriorTemporaryLocation?.ToDelimitedString(),
                                AdmitDateTime.HasValue ? AdmitDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                DischargeDateTime.HasValue ? DischargeDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                CurrentPatientBalance.HasValue ? CurrentPatientBalance.Value.ToString(Consts.NumericFormat, culture) : null,
                                TotalCharges.HasValue ? TotalCharges.Value.ToString(Consts.NumericFormat, culture) : null,
                                TotalAdjustments.HasValue ? TotalAdjustments.Value.ToString(Consts.NumericFormat, culture) : null,
                                TotalPayments.HasValue ? TotalPayments.Value.ToString(Consts.NumericFormat, culture) : null,
                                AlternateVisitId?.ToDelimitedString(),
                                VisitIndicator?.ToDelimitedString(),
                                OtherHealthcareProvider?.ToDelimitedString(),
                                ServiceEpisodeDescription,
                                ServiceEpisodeIdentifier?.ToDelimitedString()
                                ).TrimEnd('|');
        }
    }
}