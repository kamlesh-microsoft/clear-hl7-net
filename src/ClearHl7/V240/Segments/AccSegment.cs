﻿using System;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V240.Types;

namespace ClearHl7.V240.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment ACC - Accident.
    /// </summary>
    public class AccSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "ACC";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// ACC.1 - Accident Date/Time.
        /// </summary>
        public DateTime? AccidentDateTime { get; set; }

        /// <summary>
        /// ACC.2 - Accident Code.
        /// <para>Suggested: 0050 Accident Code</para>
        /// </summary>
        public CodedElement AccidentCode { get; set; }

        /// <summary>
        /// ACC.3 - Accident Location.
        /// </summary>
        public string AccidentLocation { get; set; }

        /// <summary>
        /// ACC.4 - Auto Accident State.
        /// <para>Suggested: 0347 State/Province</para>
        /// </summary>
        public CodedElement AutoAccidentState { get; set; }

        /// <summary>
        /// ACC.5 - Accident Job Related Indicator.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V240.CodeYesNoIndicator</para>
        /// </summary>
        public string AccidentJobRelatedIndicator { get; set; }

        /// <summary>
        /// ACC.6 - Accident Death Indicator.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V240.CodeYesNoIndicator</para>
        /// </summary>
        public string AccidentDeathIndicator { get; set; }

        /// <summary>
        /// ACC.7 - Entered By.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons EnteredBy { get; set; }

        /// <summary>
        /// ACC.8 - Accident Description.
        /// </summary>
        public string AccidentDescription { get; set; }

        /// <summary>
        /// ACC.9 - Brought In By.
        /// </summary>
        public string BroughtInBy { get; set; }

        /// <summary>
        /// ACC.10 - Police Notified Indicator.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V240.CodeYesNoIndicator</para>
        /// </summary>
        public string PoliceNotifiedIndicator { get; set; }

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

            AccidentDateTime = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableDateTime() : null;
            AccidentCode = segments.Length > 2 && segments[2].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[2], false) : null;
            AccidentLocation = segments.Length > 3 && segments[3].Length > 0 ? segments[3] : null;
            AutoAccidentState = segments.Length > 4 && segments[4].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[4], false) : null;
            AccidentJobRelatedIndicator = segments.Length > 5 && segments[5].Length > 0 ? segments[5] : null;
            AccidentDeathIndicator = segments.Length > 6 && segments[6].Length > 0 ? segments[6] : null;
            EnteredBy = segments.Length > 7 && segments[7].Length > 0 ? TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments[7], false) : null;
            AccidentDescription = segments.Length > 8 && segments[8].Length > 0 ? segments[8] : null;
            BroughtInBy = segments.Length > 9 && segments[9].Length > 0 ? segments[9] : null;
            PoliceNotifiedIndicator = segments.Length > 10 && segments[10].Length > 0 ? segments[10] : null;
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
                                StringHelper.StringFormatSequence(0, 11, Configuration.FieldSeparator),
                                Id,
                                AccidentDateTime.HasValue ? AccidentDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                AccidentCode?.ToDelimitedString(),
                                AccidentLocation,
                                AutoAccidentState?.ToDelimitedString(),
                                AccidentJobRelatedIndicator,
                                AccidentDeathIndicator,
                                EnteredBy?.ToDelimitedString(),
                                AccidentDescription,
                                BroughtInBy,
                                PoliceNotifiedIndicator
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}