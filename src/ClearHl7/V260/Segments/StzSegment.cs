﻿using System;
using System.Globalization;
using System.Linq;
using ClearHl7.Helpers;
using ClearHl7.V260.Types;

namespace ClearHl7.V260.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment STZ - Sterilization Parameter.
    /// </summary>
    public class StzSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "STZ";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// STZ.1 - Sterilization Type.
        /// <para>Suggested: 0806 Sterilization Type -&gt; ClearHl7.Codes.V260.CodeSterilizationType</para>
        /// </summary>
        public CodedWithExceptions SterilizationType { get; set; }

        /// <summary>
        /// STZ.2 - Sterilization Cycle.
        /// </summary>
        public CodedWithExceptions SterilizationCycle { get; set; }

        /// <summary>
        /// STZ.3 - Maintenance Cycle.
        /// <para>Suggested: 0809 Maintenance Cycle</para>
        /// </summary>
        public CodedWithExceptions MaintenanceCycle { get; set; }

        /// <summary>
        /// STZ.4 - Maintenance Type.
        /// <para>Suggested: 0811 Maintenance Type</para>
        /// </summary>
        public CodedWithExceptions MaintenanceType { get; set; }

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

            SterilizationType = segments.Length > 1 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(1), false) : null;
            SterilizationCycle = segments.Length > 2 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(2), false) : null;
            MaintenanceCycle = segments.Length > 3 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(3), false) : null;
            MaintenanceType = segments.Length > 4 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(4), false) : null;
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
                                StringHelper.StringFormatSequence(0, 5, Configuration.FieldSeparator),
                                Id,
                                SterilizationType?.ToDelimitedString(),
                                SterilizationCycle?.ToDelimitedString(),
                                MaintenanceCycle?.ToDelimitedString(),
                                MaintenanceType?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}