﻿using System.Linq;
using ClearHl7.Helpers;

namespace ClearHl7.V251.Types
{
    /// <summary>
    /// HL7 Version 2 JCC - Job Code Class.
    /// </summary>
    public class JobCodeClass : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// JCC.1 - Job Code.
        /// <para>Suggested: 0327 Job Code</para>
        /// </summary>
        public string JobCode { get; set; }

        /// <summary>
        /// JCC.2 - Job Class.
        /// <para>Suggested: 0328 Job Class</para>
        /// </summary>
        public string JobClass { get; set; }

        /// <summary>
        /// JCC.3 - Job Description Text.
        /// </summary>
        public Text JobDescriptionText { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        public void FromDelimitedString(string delimitedString)
        {
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(separator.ToCharArray());

            JobCode = segments.ElementAtOrDefault(0);
            JobClass = segments.ElementAtOrDefault(1);

            if (segments.Length > 2)
            {
                JobDescriptionText = new Text { IsSubcomponent = true };
                JobDescriptionText.FromDelimitedString(segments.ElementAtOrDefault(2));
            }
            else
            {
                JobDescriptionText = null;
            }
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
                                StringHelper.StringFormatSequence(0, 3, separator),
                                JobCode,
                                JobClass,
                                JobDescriptionText?.ToDelimitedString()
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
