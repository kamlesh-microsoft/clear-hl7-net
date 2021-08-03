﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V281.Types;

namespace ClearHl7.V281.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment PCR - Possible Causal Relationship.
    /// </summary>
    public class PcrSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "PCR";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// PCR.1 - Implicated Product.
        /// </summary>
        public CodedWithExceptions ImplicatedProduct { get; set; }

        /// <summary>
        /// PCR.2 - Generic Product.
        /// <para>Suggested: 0249 Generic Product</para>
        /// </summary>
        public string GenericProduct { get; set; }

        /// <summary>
        /// PCR.3 - Product Class.
        /// </summary>
        public CodedWithExceptions ProductClass { get; set; }

        /// <summary>
        /// PCR.4 - Total Duration Of Therapy.
        /// </summary>
        public CompositeQuantityWithUnits TotalDurationOfTherapy { get; set; }

        /// <summary>
        /// PCR.5 - Product Manufacture Date.
        /// </summary>
        public DateTime? ProductManufactureDate { get; set; }

        /// <summary>
        /// PCR.6 - Product Expiration Date.
        /// </summary>
        public DateTime? ProductExpirationDate { get; set; }

        /// <summary>
        /// PCR.7 - Product Implantation Date.
        /// </summary>
        public DateTime? ProductImplantationDate { get; set; }

        /// <summary>
        /// PCR.8 - Product Explantation Date.
        /// </summary>
        public DateTime? ProductExplantationDate { get; set; }

        /// <summary>
        /// PCR.9 - Single Use Device.
        /// <para>Suggested: 0244 Single Use Device</para>
        /// </summary>
        public CodedWithExceptions SingleUseDevice { get; set; }

        /// <summary>
        /// PCR.10 - Indication For Product Use.
        /// </summary>
        public CodedWithExceptions IndicationForProductUse { get; set; }

        /// <summary>
        /// PCR.11 - Product Problem.
        /// <para>Suggested: 0245 Product Problem</para>
        /// </summary>
        public CodedWithExceptions ProductProblem { get; set; }

        /// <summary>
        /// PCR.12 - Product Serial/Lot Number.
        /// </summary>
        public IEnumerable<string> ProductSerialLotNumber { get; set; }

        /// <summary>
        /// PCR.13 - Product Available For Inspection.
        /// <para>Suggested: 0246 Product Available For Inspection</para>
        /// </summary>
        public CodedWithExceptions ProductAvailableForInspection { get; set; }

        /// <summary>
        /// PCR.14 - Product Evaluation Performed.
        /// </summary>
        public CodedWithExceptions ProductEvaluationPerformed { get; set; }

        /// <summary>
        /// PCR.15 - Product Evaluation Status.
        /// <para>Suggested: 0247 Status Of Evaluation -&gt; ClearHl7.Codes.V281.CodeStatusOfEvaluation</para>
        /// </summary>
        public CodedWithExceptions ProductEvaluationStatus { get; set; }

        /// <summary>
        /// PCR.16 - Product Evaluation Results.
        /// </summary>
        public CodedWithExceptions ProductEvaluationResults { get; set; }

        /// <summary>
        /// PCR.17 - Evaluated Product Source.
        /// <para>Suggested: 0248 Product Source -&gt; ClearHl7.Codes.V281.CodeProductSource</para>
        /// </summary>
        public string EvaluatedProductSource { get; set; }

        /// <summary>
        /// PCR.18 - Date Product Returned To Manufacturer.
        /// </summary>
        public DateTime? DateProductReturnedToManufacturer { get; set; }

        /// <summary>
        /// PCR.19 - Device Operator Qualifications.
        /// <para>Suggested: 0242 Primary Observer's Qualification -&gt; ClearHl7.Codes.V281.CodePrimaryObserversQualification</para>
        /// </summary>
        public string DeviceOperatorQualifications { get; set; }

        /// <summary>
        /// PCR.20 - Relatedness Assessment.
        /// <para>Suggested: 0250 Relatedness Assessment -&gt; ClearHl7.Codes.V281.CodeRelatednessAssessment</para>
        /// </summary>
        public string RelatednessAssessment { get; set; }

        /// <summary>
        /// PCR.21 - Action Taken In Response To The Event.
        /// <para>Suggested: 0251 Action Taken In Response To The Event -&gt; ClearHl7.Codes.V281.CodeActionTakenInResponseToTheEvent</para>
        /// </summary>
        public IEnumerable<string> ActionTakenInResponseToTheEvent { get; set; }

        /// <summary>
        /// PCR.22 - Event Causality Observations.
        /// <para>Suggested: 0252 Causality Observations -&gt; ClearHl7.Codes.V281.CodeCausalityObservations</para>
        /// </summary>
        public IEnumerable<string> EventCausalityObservations { get; set; }

        /// <summary>
        /// PCR.23 - Indirect Exposure Mechanism.
        /// <para>Suggested: 0253 Indirect Exposure Mechanism -&gt; ClearHl7.Codes.V281.CodeIndirectExposureMechanism</para>
        /// </summary>
        public IEnumerable<string> IndirectExposureMechanism { get; set; }

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

            ImplicatedProduct = segments.Length > 1 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(1), false) : null;
            GenericProduct = segments.ElementAtOrDefault(2);
            ProductClass = segments.Length > 3 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(3), false) : null;
            TotalDurationOfTherapy = segments.Length > 4 ? TypeHelper.Deserialize<CompositeQuantityWithUnits>(segments.ElementAtOrDefault(4), false) : null;
            ProductManufactureDate = segments.ElementAtOrDefault(5)?.ToNullableDateTime(Consts.DateTimeFormatPrecisionSecond);
            ProductExpirationDate = segments.ElementAtOrDefault(6)?.ToNullableDateTime(Consts.DateTimeFormatPrecisionSecond);
            ProductImplantationDate = segments.ElementAtOrDefault(7)?.ToNullableDateTime(Consts.DateTimeFormatPrecisionSecond);
            ProductExplantationDate = segments.ElementAtOrDefault(8)?.ToNullableDateTime(Consts.DateTimeFormatPrecisionSecond);
            SingleUseDevice = segments.Length > 9 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(9), false) : null;
            IndicationForProductUse = segments.Length > 10 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(10), false) : null;
            ProductProblem = segments.Length > 11 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(11), false) : null;
            ProductSerialLotNumber = segments.Length > 12 ? segments.ElementAtOrDefault(12).Split(separator) : null;
            ProductAvailableForInspection = segments.Length > 13 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(13), false) : null;
            ProductEvaluationPerformed = segments.Length > 14 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(14), false) : null;
            ProductEvaluationStatus = segments.Length > 15 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(15), false) : null;
            ProductEvaluationResults = segments.Length > 16 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(16), false) : null;
            EvaluatedProductSource = segments.ElementAtOrDefault(17);
            DateProductReturnedToManufacturer = segments.ElementAtOrDefault(18)?.ToNullableDateTime(Consts.DateTimeFormatPrecisionSecond);
            DeviceOperatorQualifications = segments.ElementAtOrDefault(19);
            RelatednessAssessment = segments.ElementAtOrDefault(20);
            ActionTakenInResponseToTheEvent = segments.Length > 21 ? segments.ElementAtOrDefault(21).Split(separator) : null;
            EventCausalityObservations = segments.Length > 22 ? segments.ElementAtOrDefault(22).Split(separator) : null;
            IndirectExposureMechanism = segments.Length > 23 ? segments.ElementAtOrDefault(23).Split(separator) : null;
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
                                StringHelper.StringFormatSequence(0, 24, Configuration.FieldSeparator),
                                Id,
                                ImplicatedProduct?.ToDelimitedString(),
                                GenericProduct,
                                ProductClass?.ToDelimitedString(),
                                TotalDurationOfTherapy?.ToDelimitedString(),
                                ProductManufactureDate.HasValue ? ProductManufactureDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ProductExpirationDate.HasValue ? ProductExpirationDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ProductImplantationDate.HasValue ? ProductImplantationDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ProductExplantationDate.HasValue ? ProductExplantationDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                SingleUseDevice?.ToDelimitedString(),
                                IndicationForProductUse?.ToDelimitedString(),
                                ProductProblem?.ToDelimitedString(),
                                ProductSerialLotNumber != null ? string.Join(Configuration.FieldRepeatSeparator, ProductSerialLotNumber) : null,
                                ProductAvailableForInspection?.ToDelimitedString(),
                                ProductEvaluationPerformed?.ToDelimitedString(),
                                ProductEvaluationStatus?.ToDelimitedString(),
                                ProductEvaluationResults?.ToDelimitedString(),
                                EvaluatedProductSource,
                                DateProductReturnedToManufacturer.HasValue ? DateProductReturnedToManufacturer.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                DeviceOperatorQualifications,
                                RelatednessAssessment,
                                ActionTakenInResponseToTheEvent != null ? string.Join(Configuration.FieldRepeatSeparator, ActionTakenInResponseToTheEvent) : null,
                                EventCausalityObservations != null ? string.Join(Configuration.FieldRepeatSeparator, EventCausalityObservations) : null,
                                IndirectExposureMechanism != null ? string.Join(Configuration.FieldRepeatSeparator, IndirectExposureMechanism) : null
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}