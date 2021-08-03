﻿using System;
using System.Globalization;
using System.Linq;
using ClearHl7.Helpers;
using ClearHl7.V271.Types;

namespace ClearHl7.V271.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment OVR - Override Segment.
    /// </summary>
    public class OvrSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "OVR";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// OVR.1 - Business Rule Override Type.
        /// <para>Suggested: 0518 Override Type -&gt; ClearHl7.Codes.V271.CodeOverrideType</para>
        /// </summary>
        public CodedWithExceptions BusinessRuleOverrideType { get; set; }

        /// <summary>
        /// OVR.2 - Business Rule Override Code.
        /// <para>Suggested: 0521 Override Code</para>
        /// </summary>
        public CodedWithExceptions BusinessRuleOverrideCode { get; set; }

        /// <summary>
        /// OVR.3 - Override Comments.
        /// </summary>
        public Text OverrideComments { get; set; }

        /// <summary>
        /// OVR.4 - Override Entered By.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons OverrideEnteredBy { get; set; }

        /// <summary>
        /// OVR.5 - Override Authorized By.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons OverrideAuthorizedBy { get; set; }

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

            BusinessRuleOverrideType = segments.Length > 1 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(1), false) : null;
            BusinessRuleOverrideCode = segments.Length > 2 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(2), false) : null;
            OverrideComments = segments.Length > 3 ? TypeHelper.Deserialize<Text>(segments.ElementAtOrDefault(3), false) : null;
            OverrideEnteredBy = segments.Length > 4 ? TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments.ElementAtOrDefault(4), false) : null;
            OverrideAuthorizedBy = segments.Length > 5 ? TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments.ElementAtOrDefault(5), false) : null;
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
                                StringHelper.StringFormatSequence(0, 6, Configuration.FieldSeparator),
                                Id,
                                BusinessRuleOverrideType?.ToDelimitedString(),
                                BusinessRuleOverrideCode?.ToDelimitedString(),
                                OverrideComments?.ToDelimitedString(),
                                OverrideEnteredBy?.ToDelimitedString(),
                                OverrideAuthorizedBy?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}