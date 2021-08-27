﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V271.Types;

namespace ClearHl7.V271.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment PSH - Product Summary Header.
    /// </summary>
    public class PshSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "PSH";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// PSH.1 - Report Type.
        /// </summary>
        public string ReportType { get; set; }

        /// <summary>
        /// PSH.2 - Report Form Identifier.
        /// </summary>
        public string ReportFormIdentifier { get; set; }

        /// <summary>
        /// PSH.3 - Report Date.
        /// </summary>
        public DateTime? ReportDate { get; set; }

        /// <summary>
        /// PSH.4 - Report Interval Start Date.
        /// </summary>
        public DateTime? ReportIntervalStartDate { get; set; }

        /// <summary>
        /// PSH.5 - Report Interval End Date.
        /// </summary>
        public DateTime? ReportIntervalEndDate { get; set; }

        /// <summary>
        /// PSH.6 - Quantity Manufactured.
        /// </summary>
        public CompositeQuantityWithUnits QuantityManufactured { get; set; }

        /// <summary>
        /// PSH.7 - Quantity Distributed.
        /// </summary>
        public CompositeQuantityWithUnits QuantityDistributed { get; set; }

        /// <summary>
        /// PSH.8 - Quantity Distributed Method.
        /// <para>Suggested: 0329 Quantity Method -&gt; ClearHl7.Codes.V271.CodeQuantityMethod</para>
        /// </summary>
        public string QuantityDistributedMethod { get; set; }

        /// <summary>
        /// PSH.9 - Quantity Distributed Comment.
        /// </summary>
        public string QuantityDistributedComment { get; set; }

        /// <summary>
        /// PSH.10 - Quantity in Use.
        /// </summary>
        public CompositeQuantityWithUnits QuantityInUse { get; set; }

        /// <summary>
        /// PSH.11 - Quantity in Use Method.
        /// <para>Suggested: 0329 Quantity Method -&gt; ClearHl7.Codes.V271.CodeQuantityMethod</para>
        /// </summary>
        public string QuantityInUseMethod { get; set; }

        /// <summary>
        /// PSH.12 - Quantity in Use Comment.
        /// </summary>
        public string QuantityInUseComment { get; set; }

        /// <summary>
        /// PSH.13 - Number of Product Experience Reports Filed by Facility.
        /// </summary>
        public IEnumerable<decimal> NumberOfProductExperienceReportsFiledByFacility { get; set; }

        /// <summary>
        /// PSH.14 - Number of Product Experience Reports Filed by Distributor.
        /// </summary>
        public IEnumerable<decimal> NumberOfProductExperienceReportsFiledByDistributor { get; set; }

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

            ReportType = segments.Length > 1 && segments[1].Length > 0 ? segments[1] : null;
            ReportFormIdentifier = segments.Length > 2 && segments[2].Length > 0 ? segments[2] : null;
            ReportDate = segments.Length > 3 && segments[3].Length > 0 ? segments[3].ToNullableDateTime() : null;
            ReportIntervalStartDate = segments.Length > 4 && segments[4].Length > 0 ? segments[4].ToNullableDateTime() : null;
            ReportIntervalEndDate = segments.Length > 5 && segments[5].Length > 0 ? segments[5].ToNullableDateTime() : null;
            QuantityManufactured = segments.Length > 6 && segments[6].Length > 0 ? TypeHelper.Deserialize<CompositeQuantityWithUnits>(segments[6], false) : null;
            QuantityDistributed = segments.Length > 7 && segments[7].Length > 0 ? TypeHelper.Deserialize<CompositeQuantityWithUnits>(segments[7], false) : null;
            QuantityDistributedMethod = segments.Length > 8 && segments[8].Length > 0 ? segments[8] : null;
            QuantityDistributedComment = segments.Length > 9 && segments[9].Length > 0 ? segments[9] : null;
            QuantityInUse = segments.Length > 10 && segments[10].Length > 0 ? TypeHelper.Deserialize<CompositeQuantityWithUnits>(segments[10], false) : null;
            QuantityInUseMethod = segments.Length > 11 && segments[11].Length > 0 ? segments[11] : null;
            QuantityInUseComment = segments.Length > 12 && segments[12].Length > 0 ? segments[12] : null;
            NumberOfProductExperienceReportsFiledByFacility = segments.Length > 13 && segments[13].Length > 0 ? segments[13].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => x.ToDecimal()) : null;
            NumberOfProductExperienceReportsFiledByDistributor = segments.Length > 14 && segments[14].Length > 0 ? segments[14].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => x.ToDecimal()) : null;
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
                                StringHelper.StringFormatSequence(0, 15, Configuration.FieldSeparator),
                                Id,
                                ReportType,
                                ReportFormIdentifier,
                                ReportDate.HasValue ? ReportDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ReportIntervalStartDate.HasValue ? ReportIntervalStartDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ReportIntervalEndDate.HasValue ? ReportIntervalEndDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                QuantityManufactured?.ToDelimitedString(),
                                QuantityDistributed?.ToDelimitedString(),
                                QuantityDistributedMethod,
                                QuantityDistributedComment,
                                QuantityInUse?.ToDelimitedString(),
                                QuantityInUseMethod,
                                QuantityInUseComment,
                                NumberOfProductExperienceReportsFiledByFacility != null ? string.Join(Configuration.FieldRepeatSeparator, NumberOfProductExperienceReportsFiledByFacility.Select(x => x.ToString(Consts.NumericFormat, culture))) : null,
                                NumberOfProductExperienceReportsFiledByDistributor != null ? string.Join(Configuration.FieldRepeatSeparator, NumberOfProductExperienceReportsFiledByDistributor.Select(x => x.ToString(Consts.NumericFormat, culture))) : null
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}