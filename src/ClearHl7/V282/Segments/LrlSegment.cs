﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Helpers;
using ClearHl7.V282.Types;

namespace ClearHl7.V282.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment LRL - Location Relationship.
    /// </summary>
    public class LrlSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "LRL";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// LRL.1 - Primary Key Value - LRL.
        /// </summary>
        public PersonLocation PrimaryKeyValueLrl { get; set; }

        /// <summary>
        /// LRL.2 - Segment Action Code.
        /// <para>Suggested: 0206 Segment Action Code -&gt; ClearHl7.Codes.V282.CodeSegmentActionCode</para>
        /// </summary>
        public string SegmentActionCode { get; set; }

        /// <summary>
        /// LRL.3 - Segment Unique Key.
        /// </summary>
        public EntityIdentifier SegmentUniqueKey { get; set; }

        /// <summary>
        /// LRL.4 - Location Relationship ID.
        /// <para>Suggested: 0325 Location Relationship ID -&gt; ClearHl7.Codes.V282.CodeLocationRelationshipId</para>
        /// </summary>
        public CodedWithExceptions LocationRelationshipId { get; set; }

        /// <summary>
        /// LRL.5 - Organizational Location Relationship Value.
        /// </summary>
        public IEnumerable<ExtendedCompositeNameAndIdNumberForOrganizations> OrganizationalLocationRelationshipValue { get; set; }

        /// <summary>
        /// LRL.6 - Patient Location Relationship Value.
        /// </summary>
        public PersonLocation PatientLocationRelationshipValue { get; set; }

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

            PrimaryKeyValueLrl = segments.Length > 1 ? TypeHelper.Deserialize<PersonLocation>(segments.ElementAtOrDefault(1), false) : null;
            SegmentActionCode = segments.ElementAtOrDefault(2);
            SegmentUniqueKey = segments.Length > 3 ? TypeHelper.Deserialize<EntityIdentifier>(segments.ElementAtOrDefault(3), false) : null;
            LocationRelationshipId = segments.Length > 4 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(4), false) : null;
            OrganizationalLocationRelationshipValue = segments.Length > 5 ? segments.ElementAtOrDefault(5).Split(separator).Select(x => TypeHelper.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(x, false)) : null;
            PatientLocationRelationshipValue = segments.Length > 6 ? TypeHelper.Deserialize<PersonLocation>(segments.ElementAtOrDefault(6), false) : null;
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
                                StringHelper.StringFormatSequence(0, 7, Configuration.FieldSeparator),
                                Id,
                                PrimaryKeyValueLrl?.ToDelimitedString(),
                                SegmentActionCode,
                                SegmentUniqueKey?.ToDelimitedString(),
                                LocationRelationshipId?.ToDelimitedString(),
                                OrganizationalLocationRelationshipValue != null ? string.Join(Configuration.FieldRepeatSeparator, OrganizationalLocationRelationshipValue.Select(x => x.ToDelimitedString())) : null,
                                PatientLocationRelationshipValue?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}