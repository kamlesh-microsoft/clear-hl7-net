﻿using System;
using System.Collections.Generic;
using System.Linq;
using ClearHl7.Fhir.V230.Types;

namespace ClearHl7.Fhir.V230.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment RXE - Pharmacy Treatment Encoded Order.
    /// </summary>
    public class RxeSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "RXE";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// RXE.1 - Quantity/Timing.
        /// </summary>
        public TimingQuantity QuantityTiming { get; set; }

        /// <summary>
        /// RXE.2 - Give Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0292</remarks>
        public CodedElement GiveCode { get; set; }

        /// <summary>
        /// RXE.3 - Give Amount - Minimum.
        /// </summary>
        public decimal? GiveAmountMinimum { get; set; }

        /// <summary>
        /// RXE.4 - Give Amount - Maximum.
        /// </summary>
        public decimal? GiveAmountMaximum { get; set; }

        /// <summary>
        /// RXE.5 - Give Units.
        /// </summary>
        public CodedElement GiveUnits { get; set; }

        /// <summary>
        /// RXE.6 - Give Dosage Form.
        /// </summary>
        public CodedElement GiveDosageForm { get; set; }

        /// <summary>
        /// RXE.7 - Provider's Administration Instructions.
        /// </summary>
        public IEnumerable<CodedElement> ProvidersAdministrationInstructions { get; set; }

        /// <summary>
        /// RXE.8 - Deliver-To Location.
        /// </summary>
        public LocationWithAddressVariationOne DeliverToLocation { get; set; }

        /// <summary>
        /// RXE.9 - Substitution Status.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0167</remarks>
        public string SubstitutionStatus { get; set; }

        /// <summary>
        /// RXE.10 - Dispense Amount.
        /// </summary>
        public decimal? DispenseAmount { get; set; }

        /// <summary>
        /// RXE.11 - Dispense Units.
        /// </summary>
        public CodedElement DispenseUnits { get; set; }

        /// <summary>
        /// RXE.12 - Number Of Refills.
        /// </summary>
        public decimal? NumberOfRefills { get; set; }

        /// <summary>
        /// RXE.13 - Ordering Provider's DEA Number.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons OrderingProvidersDeaNumber { get; set; }

        /// <summary>
        /// RXE.14 - Pharmacist/Treatment Supplier's Verifier ID.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons PharmacistTreatmentSuppliersVerifierId { get; set; }

        /// <summary>
        /// RXE.15 - Prescription Number.
        /// </summary>
        public string PrescriptionNumber { get; set; }

        /// <summary>
        /// RXE.16 - Number of Refills Remaining.
        /// </summary>
        public decimal? NumberOfRefillsRemaining { get; set; }

        /// <summary>
        /// RXE.17 - Number of Refills/Doses Dispensed.
        /// </summary>
        public decimal? NumberOfRefillsDosesDispensed { get; set; }

        /// <summary>
        /// RXE.18 - D/T of Most Recent Refill or Dose Dispensed.
        /// </summary>
        public DateTime? DTOfMostRecentRefillOrDoseDispensed { get; set; }

        /// <summary>
        /// RXE.19 - Total Daily Dose.
        /// </summary>
        public CompositeQuantityWithUnits TotalDailyDose { get; set; }

        /// <summary>
        /// RXE.20 - Needs Human Review.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0136</remarks>
        public string NeedsHumanReview { get; set; }

        /// <summary>
        /// RXE.21 - Special Dispensing Instructions.
        /// </summary>
        public IEnumerable<CodedElement> SpecialDispensingInstructions { get; set; }

        /// <summary>
        /// RXE.22 - Give Per (Time Unit).
        /// </summary>
        public string GivePerTimeUnit { get; set; }

        /// <summary>
        /// RXE.23 - Give Rate Amount.
        /// </summary>
        public string GiveRateAmount { get; set; }

        /// <summary>
        /// RXE.24 - Give Rate Units.
        /// </summary>
        public CodedElement GiveRateUnits { get; set; }

        /// <summary>
        /// RXE.25 - Give Strength.
        /// </summary>
        public decimal? GiveStrength { get; set; }

        /// <summary>
        /// RXE.26 - Give Strength Units.
        /// </summary>
        public CodedElement GiveStrengthUnits { get; set; }

        /// <summary>
        /// RXE.27 - Give Indication.
        /// </summary>
        public IEnumerable<CodedElement> GiveIndication { get; set; }

        /// <summary>
        /// RXE.28 - Dispense Package Size.
        /// </summary>
        public decimal? DispensePackageSize { get; set; }

        /// <summary>
        /// RXE.29 - Dispense Package Size Unit.
        /// </summary>
        public CodedElement DispensePackageSizeUnit { get; set; }

        /// <summary>
        /// RXE.30 - Dispense Package Method.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0321</remarks>
        public string DispensePackageMethod { get; set; }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                "{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|{30}",
                                Id,
                                QuantityTiming?.ToDelimitedString(),
                                GiveCode?.ToDelimitedString(),
                                GiveAmountMinimum.HasValue ? GiveAmountMinimum.Value.ToString(Consts.NumericFormat, culture) : null,
                                GiveAmountMaximum.HasValue ? GiveAmountMaximum.Value.ToString(Consts.NumericFormat, culture) : null,
                                GiveUnits?.ToDelimitedString(),
                                GiveDosageForm?.ToDelimitedString(),
                                ProvidersAdministrationInstructions != null ? string.Join("~", ProvidersAdministrationInstructions.Select(x => x.ToDelimitedString())) : null,
                                DeliverToLocation?.ToDelimitedString(),
                                SubstitutionStatus,
                                DispenseAmount.HasValue ? DispenseAmount.Value.ToString(Consts.NumericFormat, culture) : null,
                                DispenseUnits?.ToDelimitedString(),
                                NumberOfRefills.HasValue ? NumberOfRefills.Value.ToString(Consts.NumericFormat, culture) : null,
                                OrderingProvidersDeaNumber?.ToDelimitedString(),
                                PharmacistTreatmentSuppliersVerifierId?.ToDelimitedString(),
                                PrescriptionNumber,
                                NumberOfRefillsRemaining.HasValue ? NumberOfRefillsRemaining.Value.ToString(Consts.NumericFormat, culture) : null,
                                NumberOfRefillsDosesDispensed.HasValue ? NumberOfRefillsDosesDispensed.Value.ToString(Consts.NumericFormat, culture) : null,
                                DTOfMostRecentRefillOrDoseDispensed.HasValue ? DTOfMostRecentRefillOrDoseDispensed.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                TotalDailyDose?.ToDelimitedString(),
                                NeedsHumanReview,
                                SpecialDispensingInstructions != null ? string.Join("~", SpecialDispensingInstructions.Select(x => x.ToDelimitedString())) : null,
                                GivePerTimeUnit,
                                GiveRateAmount,
                                GiveRateUnits?.ToDelimitedString(),
                                GiveStrength.HasValue ? GiveStrength.Value.ToString(Consts.NumericFormat, culture) : null,
                                GiveStrengthUnits?.ToDelimitedString(),
                                GiveIndication != null ? string.Join("~", GiveIndication.Select(x => x.ToDelimitedString())) : null,
                                DispensePackageSize.HasValue ? DispensePackageSize.Value.ToString(Consts.NumericFormat, culture) : null,
                                DispensePackageSizeUnit?.ToDelimitedString(),
                                DispensePackageMethod
                                ).TrimEnd('|');
        }
    }
}