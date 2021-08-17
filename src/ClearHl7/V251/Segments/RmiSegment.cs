﻿using System;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V251.Types;

namespace ClearHl7.V251.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment RMI - Risk Management Incident.
    /// </summary>
    public class RmiSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "RMI";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// RMI.1 - Risk Management Incident Code.
        /// <para>Suggested: 0427 Risk Management Incident Code -&gt; ClearHl7.Codes.V251.CodeRiskManagementIncidentCode</para>
        /// </summary>
        public CodedElement RiskManagementIncidentCode { get; set; }

        /// <summary>
        /// RMI.2 - Date/Time Incident.
        /// </summary>
        public DateTime? DateTimeIncident { get; set; }

        /// <summary>
        /// RMI.3 - Incident Type Code.
        /// <para>Suggested: 0428 Incident Type Code -&gt; ClearHl7.Codes.V251.CodeIncidentTypeCode</para>
        /// </summary>
        public CodedElement IncidentTypeCode { get; set; }

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
                if (string.Compare(Id, segments[0], true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ Configuration.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            RiskManagementIncidentCode = segments.Length > 1 && segments[1].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[1], false) : null;
            DateTimeIncident = segments.Length > 2 && segments[2].Length > 0 ? segments[2].ToNullableDateTime() : null;
            IncidentTypeCode = segments.Length > 3 && segments[3].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[3], false) : null;
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
                                StringHelper.StringFormatSequence(0, 4, Configuration.FieldSeparator),
                                Id,
                                RiskManagementIncidentCode?.ToDelimitedString(),
                                DateTimeIncident.HasValue ? DateTimeIncident.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                IncidentTypeCode?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}