using System;
using System.Globalization;
using ClearHl7.Extensions;
using ClearHl7.Helpers;

namespace ClearHl7.V271.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment RFI - Request For Information.
    /// </summary>
    public class RfiSegment : ISegment
    {
        /// <inheritdoc/>
        public string Id { get; } = "RFI";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// RFI.1 - Request Date.
        /// </summary>
        public DateTime? RequestDate { get; set; }

        /// <summary>
        /// RFI.2 - Response Due Date.
        /// </summary>
        public DateTime? ResponseDueDate { get; set; }

        /// <summary>
        /// RFI.3 - Patient Consent.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V271.CodeYesNoIndicator</para>
        /// </summary>
        public string PatientConsent { get; set; }

        /// <summary>
        /// RFI.4 - Date Additional Information Was Submitted.
        /// </summary>
        public DateTime? DateAdditionalInformationWasSubmitted { get; set; }

        /// <inheritdoc/>
        public void FromDelimitedString(string delimitedString)
        {
            FromDelimitedString(delimitedString, null);
        }

        /// <inheritdoc/>
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

            RequestDate = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableDateTime() : null;
            ResponseDueDate = segments.Length > 2 && segments[2].Length > 0 ? segments[2].ToNullableDateTime() : null;
            PatientConsent = segments.Length > 3 && segments[3].Length > 0 ? segments[3] : null;
            DateAdditionalInformationWasSubmitted = segments.Length > 4 && segments[4].Length > 0 ? segments[4].ToNullableDateTime() : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 5, Configuration.FieldSeparator),
                                Id,
                                RequestDate.HasValue ? RequestDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ResponseDueDate.HasValue ? ResponseDueDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                PatientConsent,
                                DateAdditionalInformationWasSubmitted.HasValue ? DateAdditionalInformationWasSubmitted.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}
