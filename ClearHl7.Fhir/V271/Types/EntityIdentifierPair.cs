﻿using ClearHl7.Fhir.Helpers;

namespace ClearHl7.Fhir.V271.Types
{
    /// <summary>
    /// HL7 Version 2 EIP - Entity Identifier Pair.
    /// </summary>
    public class EntityIdentifierPair : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// EIP.1 - Placer Assigned Identifier.
        /// </summary>
        public EntityIdentifier PlacerAssignedIdentifier { get; set; }

        /// <summary>
        /// EIP.2 - Filler Assigned Identifier.
        /// </summary>
        public EntityIdentifier FillerAssignedIdentifier { get; set; }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
            char separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 2, separator),
                                PlacerAssignedIdentifier?.ToDelimitedString(),
                                FillerAssignedIdentifier?.ToDelimitedString()
                                ).TrimEnd(separator);
        }
    }
}
