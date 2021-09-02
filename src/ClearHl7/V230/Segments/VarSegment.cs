﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V230.Types;

namespace ClearHl7.V230.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment VAR - Variance.
    /// </summary>
    public class VarSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "VAR";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// VAR.1 - Variance Instance ID.
        /// </summary>
        public EntityIdentifier VarianceInstanceId { get; set; }

        /// <summary>
        /// VAR.2 - Documented Date/Time.
        /// </summary>
        public DateTime? DocumentedDateTime { get; set; }

        /// <summary>
        /// VAR.3 - Stated Variance Date/Time.
        /// </summary>
        public DateTime? StatedVarianceDateTime { get; set; }

        /// <summary>
        /// VAR.4 - Variance Originator.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons VarianceOriginator { get; set; }

        /// <summary>
        /// VAR.5 - Variance Classification.
        /// </summary>
        public CodedElement VarianceClassification { get; set; }

        /// <summary>
        /// VAR.6 - Variance Description.
        /// </summary>
        public IEnumerable<string> VarianceDescription { get; set; }

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
                ? Array.Empty<string>()
                : delimitedString.Split(seps.FieldSeparator, StringSplitOptions.None);
            
            if (segments.Length > 0)
            {
                if (string.Compare(Id, segments[0], true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ seps.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            VarianceInstanceId = segments.Length > 1 && segments[1].Length > 0 ? TypeSerializer.Deserialize<EntityIdentifier>(segments[1], false, seps) : null;
            DocumentedDateTime = segments.Length > 2 && segments[2].Length > 0 ? segments[2].ToNullableDateTime() : null;
            StatedVarianceDateTime = segments.Length > 3 && segments[3].Length > 0 ? segments[3].ToNullableDateTime() : null;
            VarianceOriginator = segments.Length > 4 && segments[4].Length > 0 ? TypeSerializer.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments[4], false, seps) : null;
            VarianceClassification = segments.Length > 5 && segments[5].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[5], false, seps) : null;
            VarianceDescription = segments.Length > 6 && segments[6].Length > 0 ? segments[6].Split(seps.FieldRepeatSeparator, StringSplitOptions.None) : null;
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
                                VarianceInstanceId?.ToDelimitedString(),
                                DocumentedDateTime.HasValue ? DocumentedDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                StatedVarianceDateTime.HasValue ? StatedVarianceDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                VarianceOriginator?.ToDelimitedString(),
                                VarianceClassification?.ToDelimitedString(),
                                VarianceDescription != null ? string.Join(Configuration.FieldRepeatSeparator, VarianceDescription) : null
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}