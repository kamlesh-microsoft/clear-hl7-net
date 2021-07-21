﻿using System.Linq;
using ClearHl7.Helpers;

namespace ClearHl7.V231.Types
{
    /// <summary>
    /// HL7 Version 2 PN - Person Name.
    /// </summary>
    public class PersonName : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// PN.1 - Family Name.
        /// </summary>
        public string FamilyName { get; set; }

        /// <summary>
        /// PN.2 - Given Name.
        /// </summary>
        public string GivenName { get; set; }

        /// <summary>
        /// PN.3 - Second and Further Given Names or Initials Thereof.
        /// </summary>
        public string SecondAndFurtherGivenNamesOrInitialsThereof { get; set; }

        /// <summary>
        /// PN.4 - Suffix.
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// PN.5 - Prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// PN.6 - Degree.
        /// <para>Suggested: 0360 Degree/License/Certificate -&gt; ClearHl7.Codes.V231.CodeDegreeLicenseCertificate</para>
        /// </summary>
        public string Degree { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        public void FromDelimitedString(string delimitedString)
        {
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(separator.ToCharArray());

            FamilyName = segments.ElementAtOrDefault(0);
            GivenName = segments.ElementAtOrDefault(1);
            SecondAndFurtherGivenNamesOrInitialsThereof = segments.ElementAtOrDefault(2);
            Suffix = segments.ElementAtOrDefault(3);
            Prefix = segments.ElementAtOrDefault(4);
            Degree = segments.ElementAtOrDefault(5);
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
                                StringHelper.StringFormatSequence(0, 6, separator),
                                FamilyName,
                                GivenName,
                                SecondAndFurtherGivenNamesOrInitialsThereof,
                                Suffix,
                                Prefix,
                                Degree
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
