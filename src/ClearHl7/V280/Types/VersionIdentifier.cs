﻿using System.Linq;
using ClearHl7.Helpers;

namespace ClearHl7.V280.Types
{
    /// <summary>
    /// HL7 Version 2 VID - Version Identifier.
    /// </summary>
    public class VersionIdentifier : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// VID.1 - Version ID.
        /// <para>Suggested: 0104 Version ID -&gt; ClearHl7.Codes.V280.CodeVersionId</para>
        /// </summary>
        public string VersionId { get; set; }

        /// <summary>
        /// VID.2 - Internationalization Code.
        /// <para>Suggested: 0399 Country Code -&gt; https://www.iso.org/iso-3166-country-codes.html</para>
        /// </summary>
        public CodedWithExceptions InternationalizationCode { get; set; }

        /// <summary>
        /// VID.3 - International Version ID.
        /// </summary>
        public CodedWithExceptions InternationalVersionId { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        public void FromDelimitedString(string delimitedString)
        {
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(separator.ToCharArray());

            VersionId = segments.ElementAtOrDefault(0);

            if (segments.Length > 1)
            {
                InternationalizationCode = new CodedWithExceptions { IsSubcomponent = true };
                InternationalizationCode.FromDelimitedString(segments.ElementAtOrDefault(1));
            }
            else
            {
                InternationalizationCode = null;
            }

            if (segments.Length > 2)
            {
                InternationalVersionId = new CodedWithExceptions { IsSubcomponent = true };
                InternationalVersionId.FromDelimitedString(segments.ElementAtOrDefault(2));
            }
            else
            {
                InternationalVersionId = null;
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
                                VersionId,
                                InternationalizationCode?.ToDelimitedString(),
                                InternationalVersionId?.ToDelimitedString()
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
