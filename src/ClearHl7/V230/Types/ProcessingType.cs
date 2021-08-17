﻿using System.Linq;
using ClearHl7.Helpers;

namespace ClearHl7.V230.Types
{
    /// <summary>
    /// HL7 Version 2 PT - Processing Type.
    /// </summary>
    public class ProcessingType : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// PT.1 - Processing ID.
        /// <para>Suggested: 0103 Processing ID -&gt; ClearHl7.Codes.V230.CodeProcessingId</para>
        /// </summary>
        public string ProcessingId { get; set; }

        /// <summary>
        /// PT.2 - Processing Mode.
        /// <para>Suggested: 0207 Processing Mode -&gt; ClearHl7.Codes.V230.CodeProcessingMode</para>
        /// </summary>
        public string ProcessingMode { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        public void FromDelimitedString(string delimitedString)
        {
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(separator.ToCharArray());

            ProcessingId = segments.Length > 0 && segments[0].Length > 0 ? segments[0] : null;
            ProcessingMode = segments.Length > 1 && segments[1].Length > 0 ? segments[1] : null;
        }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 2, separator),
                                ProcessingId,
                                ProcessingMode
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
