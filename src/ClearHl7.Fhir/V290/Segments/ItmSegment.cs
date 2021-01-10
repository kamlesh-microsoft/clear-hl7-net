﻿using System.Collections.Generic;
using System.Linq;
using ClearHl7.Fhir.Helpers;
using ClearHl7.Fhir.V290.Types;

namespace ClearHl7.Fhir.V290.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment ITM - Material Item.
    /// </summary>
    public class ItmSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "ITM";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// ITM.1 - Item Identifier.
        /// </summary>
        public EntityIdentifier ItemIdentifier { get; set; }

        /// <summary>
        /// ITM.2 - Item Description.
        /// </summary>
        public string ItemDescription { get; set; }

        /// <summary>
        /// ITM.3 - Item Status.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0776</remarks>
        public CodedWithExceptions ItemStatus { get; set; }

        /// <summary>
        /// ITM.4 - Item Type.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0778</remarks>
        public CodedWithExceptions ItemType { get; set; }

        /// <summary>
        /// ITM.5 - Item Category.
        /// </summary>
        public CodedWithExceptions ItemCategory { get; set; }

        /// <summary>
        /// ITM.6 - Subject to Expiration Indicator.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0532</remarks>
        public CodedWithNoExceptions SubjectToExpirationIndicator { get; set; }

        /// <summary>
        /// ITM.7 - Manufacturer Identifier.
        /// </summary>
        public EntityIdentifier ManufacturerIdentifier { get; set; }

        /// <summary>
        /// ITM.8 - Manufacturer Name.
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// ITM.9 - Manufacturer Catalog Number.
        /// </summary>
        public string ManufacturerCatalogNumber { get; set; }

        /// <summary>
        /// ITM.10 - Manufacturer Labeler Identification Code.
        /// </summary>
        public CodedWithExceptions ManufacturerLabelerIdentificationCode { get; set; }

        /// <summary>
        /// ITM.11 - Patient Chargeable Indicator.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0532</remarks>
        public CodedWithNoExceptions PatientChargeableIndicator { get; set; }

        /// <summary>
        /// ITM.12 - Transaction Code.
        /// <para>Suggested: 0132 Transaction Code</para>
        /// </summary>
        public CodedWithExceptions TransactionCode { get; set; }

        /// <summary>
        /// ITM.13 - Transaction amount - unit.
        /// </summary>
        public CompositePrice TransactionAmountUnit { get; set; }

        /// <summary>
        /// ITM.14 - Stocked Item Indicator.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0532</remarks>
        public CodedWithNoExceptions StockedItemIndicator { get; set; }

        /// <summary>
        /// ITM.15 - Supply Risk Codes.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0871</remarks>
        public CodedWithExceptions SupplyRiskCodes { get; set; }

        /// <summary>
        /// ITM.16 - Approving Regulatory Agency.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0790</remarks>
        public IEnumerable<ExtendedCompositeNameAndIdNumberForOrganizations> ApprovingRegulatoryAgency { get; set; }

        /// <summary>
        /// ITM.17 - Latex Indicator.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0532</remarks>
        public CodedWithNoExceptions LatexIndicator { get; set; }

        /// <summary>
        /// ITM.18 - Ruling Act.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0793</remarks>
        public IEnumerable<CodedWithExceptions> RulingAct { get; set; }

        /// <summary>
        /// ITM.19 - Item Natural Account Code.
        /// <para>Suggested: 0320 Item Natural Account Code</para>
        /// </summary>
        public CodedWithExceptions ItemNaturalAccountCode { get; set; }

        /// <summary>
        /// ITM.20 - Approved To Buy Quantity.
        /// </summary>
        public decimal? ApprovedToBuyQuantity { get; set; }

        /// <summary>
        /// ITM.21 - Approved To Buy Price.
        /// </summary>
        public Money ApprovedToBuyPrice { get; set; }

        /// <summary>
        /// ITM.22 - Taxable Item Indicator.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0532</remarks>
        public CodedWithNoExceptions TaxableItemIndicator { get; set; }

        /// <summary>
        /// ITM.23 - Freight Charge Indicator.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0532</remarks>
        public CodedWithNoExceptions FreightChargeIndicator { get; set; }

        /// <summary>
        /// ITM.24 - Item Set Indicator.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0532</remarks>
        public CodedWithNoExceptions ItemSetIndicator { get; set; }

        /// <summary>
        /// ITM.25 - Item Set Identifier.
        /// </summary>
        public EntityIdentifier ItemSetIdentifier { get; set; }

        /// <summary>
        /// ITM.26 - Track Department Usage Indicator.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0532</remarks>
        public CodedWithNoExceptions TrackDepartmentUsageIndicator { get; set; }

        /// <summary>
        /// ITM.27 - Procedure Code.
        /// <para>Suggested: 0088 Procedure Code</para>
        /// </summary>
        public CodedWithNoExceptions ProcedureCode { get; set; }

        /// <summary>
        /// ITM.28 - Procedure Code Modifier.
        /// <para>Suggested: 0340 Procedure Code Modifier</para>
        /// </summary>
        public IEnumerable<CodedWithNoExceptions> ProcedureCodeModifier { get; set; }

        /// <summary>
        /// ITM.29 - Special Handling Code.
        /// <para>Suggested: 0376 Special Handling Code -&gt; ClearHl7.Fhir.Codes.V290.CodeSpecialHandlingCode</para>
        /// </summary>
        public CodedWithExceptions SpecialHandlingCode { get; set; }

        /// <summary>
        /// ITM.30 - Hazardous Indicator.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0532</remarks>
        public CodedWithNoExceptions HazardousIndicator { get; set; }

        /// <summary>
        /// ITM.31 - Sterile Indicator.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0532</remarks>
        public CodedWithNoExceptions SterileIndicator { get; set; }

        /// <summary>
        /// ITM.32 - Material Data Safety Sheet Number.
        /// </summary>
        public EntityIdentifier MaterialDataSafetySheetNumber { get; set; }

        /// <summary>
        /// ITM.33 - United Nations Standard Products and Services Code (UNSPSC).
        /// <para>Suggested: 0396 Coding System</para>
        /// </summary>
        public CodedWithExceptions UnitedNationsStandardProductsAndServicesCode { get; set; }

        /// <summary>
        /// ITM.34 - Contract Date.
        /// </summary>
        public DateTimeRange ContractDate { get; set; }

        /// <summary>
        /// ITM.35 - Manufacturer Contact Name.
        /// </summary>
        public ExtendedPersonName ManufacturerContactName { get; set; }

        /// <summary>
        /// ITM.36 - Manufacturer Contact Information.
        /// </summary>
        public ExtendedTelecommunicationNumber ManufacturerContactInformation { get; set; }

        /// <summary>
        /// ITM.37 - Class of Trade.
        /// </summary>
        public string ClassOfTrade { get; set; }

        /// <summary>
        /// ITM.38 - Field Level Event Code.
        /// <para>Suggested: 0180 Masterfile Action Code -&gt; ClearHl7.Fhir.Codes.V290.CodeMasterfileActionCode</para>
        /// </summary>
        public string FieldLevelEventCode { get; set; }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 39, Configuration.FieldSeparator),
                                Id,
                                ItemIdentifier?.ToDelimitedString(),
                                ItemDescription,
                                ItemStatus?.ToDelimitedString(),
                                ItemType?.ToDelimitedString(),
                                ItemCategory?.ToDelimitedString(),
                                SubjectToExpirationIndicator?.ToDelimitedString(),
                                ManufacturerIdentifier?.ToDelimitedString(),
                                ManufacturerName,
                                ManufacturerCatalogNumber,
                                ManufacturerLabelerIdentificationCode?.ToDelimitedString(),
                                PatientChargeableIndicator?.ToDelimitedString(),
                                TransactionCode?.ToDelimitedString(),
                                TransactionAmountUnit?.ToDelimitedString(),
                                StockedItemIndicator?.ToDelimitedString(),
                                SupplyRiskCodes?.ToDelimitedString(),
                                ApprovingRegulatoryAgency != null ? string.Join(Configuration.FieldRepeatSeparator, ApprovingRegulatoryAgency.Select(x => x.ToDelimitedString())) : null,
                                LatexIndicator?.ToDelimitedString(),
                                RulingAct != null ? string.Join(Configuration.FieldRepeatSeparator, RulingAct.Select(x => x.ToDelimitedString())) : null,
                                ItemNaturalAccountCode?.ToDelimitedString(),
                                ApprovedToBuyQuantity.HasValue ? ApprovedToBuyQuantity.Value.ToString(Consts.NumericFormat, culture) : null,
                                ApprovedToBuyPrice?.ToDelimitedString(),
                                TaxableItemIndicator?.ToDelimitedString(),
                                FreightChargeIndicator?.ToDelimitedString(),
                                ItemSetIndicator?.ToDelimitedString(),
                                ItemSetIdentifier?.ToDelimitedString(),
                                TrackDepartmentUsageIndicator?.ToDelimitedString(),
                                ProcedureCode?.ToDelimitedString(),
                                ProcedureCodeModifier != null ? string.Join(Configuration.FieldRepeatSeparator, ProcedureCodeModifier.Select(x => x.ToDelimitedString())) : null,
                                SpecialHandlingCode?.ToDelimitedString(),
                                HazardousIndicator?.ToDelimitedString(),
                                SterileIndicator?.ToDelimitedString(),
                                MaterialDataSafetySheetNumber?.ToDelimitedString(),
                                UnitedNationsStandardProductsAndServicesCode?.ToDelimitedString(),
                                ContractDate?.ToDelimitedString(),
                                ManufacturerContactName?.ToDelimitedString(),
                                ManufacturerContactInformation?.ToDelimitedString(),
                                ClassOfTrade,
                                FieldLevelEventCode
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}