﻿using System;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V281.Types;

namespace ClearHl7.V281.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment RXV - Pharmacy Treatment Infusion.
    /// </summary>
    public class RxvSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "RXV";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// RXV.1 - Set ID - RXV.
        /// </summary>
        public uint? SetIdRxv { get; set; }

        /// <summary>
        /// RXV.2 - Bolus Type.
        /// <para>Suggested: 0917 Bolus Type -&gt; ClearHl7.Codes.V281.CodeBolusType</para>
        /// </summary>
        public string BolusType { get; set; }

        /// <summary>
        /// RXV.3 - Bolus Dose Amount.
        /// </summary>
        public decimal? BolusDoseAmount { get; set; }

        /// <summary>
        /// RXV.4 - Bolus Dose Amount Units.
        /// </summary>
        public CodedWithExceptions BolusDoseAmountUnits { get; set; }

        /// <summary>
        /// RXV.5 - Bolus Dose Volume.
        /// </summary>
        public decimal? BolusDoseVolume { get; set; }

        /// <summary>
        /// RXV.6 - Bolus Dose Volume Units.
        /// </summary>
        public CodedWithExceptions BolusDoseVolumeUnits { get; set; }

        /// <summary>
        /// RXV.7 - PCA Type.
        /// <para>Suggested: 0918 PCA Type -&gt; ClearHl7.Codes.V281.CodePcaType</para>
        /// </summary>
        public string PcaType { get; set; }

        /// <summary>
        /// RXV.8 - PCA Dose Amount.
        /// </summary>
        public decimal? PcaDoseAmount { get; set; }

        /// <summary>
        /// RXV.9 - PCA Dose Amount Units.
        /// </summary>
        public CodedWithExceptions PcaDoseAmountUnits { get; set; }

        /// <summary>
        /// RXV.10 - PCA Dose Amount Volume.
        /// </summary>
        public decimal? PcaDoseAmountVolume { get; set; }

        /// <summary>
        /// RXV.11 - PCA Dose Amount Volume Units.
        /// </summary>
        public CodedWithExceptions PcaDoseAmountVolumeUnits { get; set; }

        /// <summary>
        /// RXV.12 - Max Dose Amount.
        /// </summary>
        public decimal? MaxDoseAmount { get; set; }

        /// <summary>
        /// RXV.13 - Max Dose Amount Units.
        /// </summary>
        public CodedWithExceptions MaxDoseAmountUnits { get; set; }

        /// <summary>
        /// RXV.14 - Max Dose Amount Volume.
        /// </summary>
        public decimal? MaxDoseAmountVolume { get; set; }

        /// <summary>
        /// RXV.15 - Max Dose Amount Volume Units.
        /// </summary>
        public CodedWithExceptions MaxDoseAmountVolumeUnits { get; set; }

        /// <summary>
        /// RXV.16 - Max Dose per Time.
        /// </summary>
        public CompositeQuantityWithUnits MaxDosePerTime { get; set; }

        /// <summary>
        /// RXV.17 - Lockout Interval.
        /// </summary>
        public CompositeQuantityWithUnits LockoutInterval { get; set; }

        /// <summary>
        /// RXV.18 - Syringe Manufacturer.
        /// </summary>
        public CodedWithExceptions SyringeManufacturer { get; set; }

        /// <summary>
        /// RXV.19 - Syringe Model Number.
        /// </summary>
        public CodedWithExceptions SyringeModelNumber { get; set; }

        /// <summary>
        /// RXV.20 - Syringe Size.
        /// </summary>
        public decimal? SyringeSize { get; set; }

        /// <summary>
        /// RXV.21 - Syringe Size Units.
        /// </summary>
        public CodedWithExceptions SyringeSizeUnits { get; set; }

        /// <summary>
        /// RXV.22 - Action Code.
        /// <para>Suggested: 0206 Segment Action Code -&gt; ClearHl7.Codes.V281.CodeSegmentActionCode</para>
        /// </summary>
        public string ActionCode { get; set; }

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
                ? new string[] { }
                : delimitedString.Split(seps.FieldSeparator, StringSplitOptions.None);

            if (segments.Length > 0)
            {
                if (string.Compare(Id, segments[0], true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ seps.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            SetIdRxv = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableUInt() : null;
            BolusType = segments.Length > 2 && segments[2].Length > 0 ? segments[2] : null;
            BolusDoseAmount = segments.Length > 3 && segments[3].Length > 0 ? segments[3].ToNullableDecimal() : null;
            BolusDoseAmountUnits = segments.Length > 4 && segments[4].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[4], false) : null;
            BolusDoseVolume = segments.Length > 5 && segments[5].Length > 0 ? segments[5].ToNullableDecimal() : null;
            BolusDoseVolumeUnits = segments.Length > 6 && segments[6].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[6], false) : null;
            PcaType = segments.Length > 7 && segments[7].Length > 0 ? segments[7] : null;
            PcaDoseAmount = segments.Length > 8 && segments[8].Length > 0 ? segments[8].ToNullableDecimal() : null;
            PcaDoseAmountUnits = segments.Length > 9 && segments[9].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[9], false) : null;
            PcaDoseAmountVolume = segments.Length > 10 && segments[10].Length > 0 ? segments[10].ToNullableDecimal() : null;
            PcaDoseAmountVolumeUnits = segments.Length > 11 && segments[11].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[11], false) : null;
            MaxDoseAmount = segments.Length > 12 && segments[12].Length > 0 ? segments[12].ToNullableDecimal() : null;
            MaxDoseAmountUnits = segments.Length > 13 && segments[13].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[13], false) : null;
            MaxDoseAmountVolume = segments.Length > 14 && segments[14].Length > 0 ? segments[14].ToNullableDecimal() : null;
            MaxDoseAmountVolumeUnits = segments.Length > 15 && segments[15].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[15], false) : null;
            MaxDosePerTime = segments.Length > 16 && segments[16].Length > 0 ? TypeHelper.Deserialize<CompositeQuantityWithUnits>(segments[16], false) : null;
            LockoutInterval = segments.Length > 17 && segments[17].Length > 0 ? TypeHelper.Deserialize<CompositeQuantityWithUnits>(segments[17], false) : null;
            SyringeManufacturer = segments.Length > 18 && segments[18].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[18], false) : null;
            SyringeModelNumber = segments.Length > 19 && segments[19].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[19], false) : null;
            SyringeSize = segments.Length > 20 && segments[20].Length > 0 ? segments[20].ToNullableDecimal() : null;
            SyringeSizeUnits = segments.Length > 21 && segments[21].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[21], false) : null;
            ActionCode = segments.Length > 22 && segments[22].Length > 0 ? segments[22] : null;
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
                                SetIdRxv.HasValue ? SetIdRxv.Value.ToString(culture) : null,
                                BolusType,
                                BolusDoseAmount.HasValue ? BolusDoseAmount.Value.ToString(Consts.NumericFormat, culture) : null,
                                BolusDoseAmountUnits?.ToDelimitedString(),
                                BolusDoseVolume.HasValue ? BolusDoseVolume.Value.ToString(Consts.NumericFormat, culture) : null,
                                BolusDoseVolumeUnits?.ToDelimitedString(),
                                PcaType,
                                PcaDoseAmount.HasValue ? PcaDoseAmount.Value.ToString(Consts.NumericFormat, culture) : null,
                                PcaDoseAmountUnits?.ToDelimitedString(),
                                PcaDoseAmountVolume.HasValue ? PcaDoseAmountVolume.Value.ToString(Consts.NumericFormat, culture) : null,
                                PcaDoseAmountVolumeUnits?.ToDelimitedString(),
                                MaxDoseAmount.HasValue ? MaxDoseAmount.Value.ToString(Consts.NumericFormat, culture) : null,
                                MaxDoseAmountUnits?.ToDelimitedString(),
                                MaxDoseAmountVolume.HasValue ? MaxDoseAmountVolume.Value.ToString(Consts.NumericFormat, culture) : null,
                                MaxDoseAmountVolumeUnits?.ToDelimitedString(),
                                MaxDosePerTime?.ToDelimitedString(),
                                LockoutInterval?.ToDelimitedString(),
                                SyringeManufacturer?.ToDelimitedString(),
                                SyringeModelNumber?.ToDelimitedString(),
                                SyringeSize.HasValue ? SyringeSize.Value.ToString(Consts.NumericFormat, culture) : null,
                                SyringeSizeUnits?.ToDelimitedString(),
                                ActionCode
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}