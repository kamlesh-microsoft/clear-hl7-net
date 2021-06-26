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
    /// HL7 Version 2 Segment RXC - Pharmacy Treatment Component Order.
    /// </summary>
    public class RxcSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "RXC";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// RXC.1 - RX Component Type.
        /// <para>Suggested: 0166 RX Component Type -&gt; ClearHl7.Codes.V290.CodeRXComponentType</para>
        /// </summary>
        public string RxComponentType { get; set; }

        /// <summary>
        /// RXC.2 - Component Code.
        /// <para>Suggested: 0697 Component Code</para>
        /// </summary>
        public CodedWithExceptions ComponentCode { get; set; }

        /// <summary>
        /// RXC.3 - Component Amount.
        /// </summary>
        public decimal? ComponentAmount { get; set; }

        /// <summary>
        /// RXC.4 - Component Units.
        /// <para>Suggested: 0698 Component Units</para>
        /// </summary>
        public CodedWithExceptions ComponentUnits { get; set; }

        /// <summary>
        /// RXC.5 - Component Strength.
        /// </summary>
        public decimal? ComponentStrength { get; set; }

        /// <summary>
        /// RXC.6 - Component Strength Units.
        /// <para>Suggested: 0699 Component Strength Units</para>
        /// </summary>
        public CodedWithExceptions ComponentStrengthUnits { get; set; }

        /// <summary>
        /// RXC.7 - Supplementary Code.
        /// <para>Suggested: 0700 Supplementary Code</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> SupplementaryCode { get; set; }

        /// <summary>
        /// RXC.8 - Component Drug Strength Volume.
        /// </summary>
        public decimal? ComponentDrugStrengthVolume { get; set; }

        /// <summary>
        /// RXC.9 - Component Drug Strength Volume Units.
        /// <para>Suggested: 0701 Component Drug Strength Volume Units</para>
        /// </summary>
        public CodedWithExceptions ComponentDrugStrengthVolumeUnits { get; set; }

        /// <summary>
        /// RXC.10 - Dispense Amount.
        /// </summary>
        public decimal? DispenseAmount { get; set; }

        /// <summary>
        /// RXC.11 - Dispense Units.
        /// <para>Suggested: 0703 Dispense Units</para>
        /// </summary>
        public CodedWithExceptions DispenseUnits { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <exception cref="ArgumentException">delimitedString does not begin with the proper segment Id.</exception>
        public RxcSegment FromDelimitedString(string delimitedString)
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

            RxComponentType = segments.ElementAtOrDefault(1);
            ComponentCode = segments.Length > 2 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(2)) : null;
            ComponentAmount = segments.ElementAtOrDefault(3)?.ToNullableDecimal();
            ComponentUnits = segments.Length > 4 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(4)) : null;
            ComponentStrength = segments.ElementAtOrDefault(5)?.ToNullableDecimal();
            ComponentStrengthUnits = segments.Length > 6 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(6)) : null;
            SupplementaryCode = segments.Length > 7 ? segments.ElementAtOrDefault(7).Split(separator).Select(x => new CodedWithExceptions().FromDelimitedString(x)) : null;
            ComponentDrugStrengthVolume = segments.ElementAtOrDefault(8)?.ToNullableDecimal();
            ComponentDrugStrengthVolumeUnits = segments.Length > 9 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(9)) : null;
            DispenseAmount = segments.ElementAtOrDefault(10)?.ToNullableDecimal();
            DispenseUnits = segments.Length > 11 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(11)) : null;
            
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
                                StringHelper.StringFormatSequence(0, 12, Configuration.FieldSeparator),
                                Id,
                                RxComponentType,
                                ComponentCode?.ToDelimitedString(),
                                ComponentAmount.HasValue ? ComponentAmount.Value.ToString(Consts.NumericFormat, culture) : null,
                                ComponentUnits?.ToDelimitedString(),
                                ComponentStrength.HasValue ? ComponentStrength.Value.ToString(Consts.NumericFormat, culture) : null,
                                ComponentStrengthUnits?.ToDelimitedString(),
                                SupplementaryCode != null ? string.Join(Configuration.FieldRepeatSeparator, SupplementaryCode.Select(x => x.ToDelimitedString())) : null,
                                ComponentDrugStrengthVolume.HasValue ? ComponentDrugStrengthVolume.Value.ToString(Consts.NumericFormat, culture) : null,
                                ComponentDrugStrengthVolumeUnits?.ToDelimitedString(),
                                DispenseAmount.HasValue ? DispenseAmount.Value.ToString(Consts.NumericFormat, culture) : null,
                                DispenseUnits?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}