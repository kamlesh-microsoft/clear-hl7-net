using System;
using System.Globalization;
using ClearHl7.Helpers;

namespace ClearHl7.V250.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment ADD - Addendum.
    /// </summary>
    public class AddSegment : ISegment
    {
        /// <inheritdoc/>
        public string Id { get; } = "ADD";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// ADD.1 - Addendum Continuation Pointer.
        /// </summary>
        public string AddendumContinuationPointer { get; set; }

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

            AddendumContinuationPointer = segments.Length > 1 && segments[1].Length > 0 ? segments[1] : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 2, Configuration.FieldSeparator),
                                Id,
                                AddendumContinuationPointer
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}
