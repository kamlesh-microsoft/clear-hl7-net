﻿using ClearHl7.Fhir.Helpers;

namespace ClearHl7.Fhir.V290.Types
{
    /// <summary>
    /// HL7 Version 2 HD - Hierarchic Designator.
    /// </summary>
    public class HierarchicDesignator : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// HD.1 - Namespace ID.
        /// <para>Suggested: 0300 Namespace ID</para>
        /// </summary>
        public string NamespaceId { get; set; }

        /// <summary>
        /// HD.2 - Universal ID.
        /// </summary>
        public string UniversalId { get; set; }

        /// <summary>
        /// HD.3 - Universal ID Type.
        /// <para>Suggested: 0301 Universal ID Type -&gt; ClearHl7.Fhir.Codes.V290.CodeUniversalIdType</para>
        /// </summary>
        public string UniversalIdType { get; set; }

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
                                NamespaceId,
                                UniversalId,
                                UniversalIdType
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
