﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V250.Types;

namespace ClearHl7.V250.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment URD - Results/Update Definition.
    /// </summary>
    public class UrdSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "URD";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// URD.1 - R/U Date/Time.
        /// </summary>
        public DateTime? RuDateTime { get; set; }

        /// <summary>
        /// URD.2 - Report Priority.
        /// <para>Suggested: 0109 Report Priority -&gt; ClearHl7.Codes.V250.CodeReportPriority</para>
        /// </summary>
        public string ReportPriority { get; set; }

        /// <summary>
        /// URD.3 - R/U Who Subject Definition.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> RuWhoSubjectDefinition { get; set; }

        /// <summary>
        /// URD.4 - R/U What Subject Definition.
        /// <para>Suggested: 0048 What Subject Filter -&gt; ClearHl7.Codes.V250.CodeWhatSubjectFilter</para>
        /// </summary>
        public IEnumerable<CodedElement> RuWhatSubjectDefinition { get; set; }

        /// <summary>
        /// URD.5 - R/U What Department Code.
        /// </summary>
        public IEnumerable<CodedElement> RuWhatDepartmentCode { get; set; }

        /// <summary>
        /// URD.6 - R/U Display/Print Locations.
        /// </summary>
        public IEnumerable<string> RuDisplayPrintLocations { get; set; }

        /// <summary>
        /// URD.7 - R/U Results Level.
        /// <para>Suggested: 0108 Query Results Level -&gt; ClearHl7.Codes.V250.CodeQueryResultsLevel</para>
        /// </summary>
        public string RuResultsLevel { get; set; }

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

            RuDateTime = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableDateTime() : null;
            ReportPriority = segments.Length > 2 && segments[2].Length > 0 ? segments[2] : null;
            RuWhoSubjectDefinition = segments.Length > 3 && segments[3].Length > 0 ? segments[3].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(x, false, seps)) : null;
            RuWhatSubjectDefinition = segments.Length > 4 && segments[4].Length > 0 ? segments[4].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<CodedElement>(x, false, seps)) : null;
            RuWhatDepartmentCode = segments.Length > 5 && segments[5].Length > 0 ? segments[5].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<CodedElement>(x, false, seps)) : null;
            RuDisplayPrintLocations = segments.Length > 6 && segments[6].Length > 0 ? segments[6].Split(seps.FieldRepeatSeparator, StringSplitOptions.None) : null;
            RuResultsLevel = segments.Length > 7 && segments[7].Length > 0 ? segments[7] : null;
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
                                StringHelper.StringFormatSequence(0, 8, Configuration.FieldSeparator),
                                Id,
                                RuDateTime.HasValue ? RuDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ReportPriority,
                                RuWhoSubjectDefinition != null ? string.Join(Configuration.FieldRepeatSeparator, RuWhoSubjectDefinition.Select(x => x.ToDelimitedString())) : null,
                                RuWhatSubjectDefinition != null ? string.Join(Configuration.FieldRepeatSeparator, RuWhatSubjectDefinition.Select(x => x.ToDelimitedString())) : null,
                                RuWhatDepartmentCode != null ? string.Join(Configuration.FieldRepeatSeparator, RuWhatDepartmentCode.Select(x => x.ToDelimitedString())) : null,
                                RuDisplayPrintLocations != null ? string.Join(Configuration.FieldRepeatSeparator, RuDisplayPrintLocations) : null,
                                RuResultsLevel
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}