﻿using System;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V271.Types;

namespace ClearHl7.V271.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment SCP - Sterilizer Configuration (Anti-Microbial Devices).
    /// </summary>
    public class ScpSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "SCP";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// SCP.1 - Number Of Decontamination/Sterilization Devices.
        /// </summary>
        public decimal? NumberOfDecontaminationSterilizationDevices { get; set; }

        /// <summary>
        /// SCP.2 - Labor Calculation Type.
        /// <para>Suggested: 0651 Labor Calculation Type -&gt; ClearHl7.Codes.V271.CodeLaborCalculationType</para>
        /// </summary>
        public CodedWithExceptions LaborCalculationType { get; set; }

        /// <summary>
        /// SCP.3 - Date Format.
        /// <para>Suggested: 0653 Date Format -&gt; ClearHl7.Codes.V271.CodeDateFormat</para>
        /// </summary>
        public CodedWithExceptions DateFormat { get; set; }

        /// <summary>
        /// SCP.4 - Device Number.
        /// </summary>
        public EntityIdentifier DeviceNumber { get; set; }

        /// <summary>
        /// SCP.5 - Device Name.
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// SCP.6 - Device Model Name.
        /// </summary>
        public string DeviceModelName { get; set; }

        /// <summary>
        /// SCP.7 - Device Type.
        /// <para>Suggested: 0657 Device Type -&gt; ClearHl7.Codes.V271.CodeDeviceType</para>
        /// </summary>
        public CodedWithExceptions DeviceType { get; set; }

        /// <summary>
        /// SCP.8 - Lot Control.
        /// <para>Suggested: 0659 Lot Control -&gt; ClearHl7.Codes.V271.CodeLotControl</para>
        /// </summary>
        public CodedWithExceptions LotControl { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <exception cref="ArgumentException">delimitedString does not begin with the proper segment Id.</exception>
        public void FromDelimitedString(string delimitedString)
        {
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(Configuration.FieldSeparator.ToCharArray());

            if (segments.Length > 0)
            {
                if (string.Compare(Id, segments.First(), true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ Configuration.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            NumberOfDecontaminationSterilizationDevices = segments.ElementAtOrDefault(1)?.ToNullableDecimal();
            LaborCalculationType = segments.Length > 2 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(2), false) : null;
            DateFormat = segments.Length > 3 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(3), false) : null;
            DeviceNumber = segments.Length > 4 ? TypeHelper.Deserialize<EntityIdentifier>(segments.ElementAtOrDefault(4), false) : null;
            DeviceName = segments.ElementAtOrDefault(5);
            DeviceModelName = segments.ElementAtOrDefault(6);
            DeviceType = segments.Length > 7 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(7), false) : null;
            LotControl = segments.Length > 8 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(8), false) : null;
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
                                StringHelper.StringFormatSequence(0, 9, Configuration.FieldSeparator),
                                Id,
                                NumberOfDecontaminationSterilizationDevices.HasValue ? NumberOfDecontaminationSterilizationDevices.Value.ToString(Consts.NumericFormat, culture) : null,
                                LaborCalculationType?.ToDelimitedString(),
                                DateFormat?.ToDelimitedString(),
                                DeviceNumber?.ToDelimitedString(),
                                DeviceName,
                                DeviceModelName,
                                DeviceType?.ToDelimitedString(),
                                LotControl?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}