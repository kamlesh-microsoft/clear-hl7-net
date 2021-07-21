﻿using System.Linq;
using ClearHl7.Helpers;

namespace ClearHl7.V240.Types
{
    /// <summary>
    /// HL7 Version 2 PRL - Parent Result Link.
    /// </summary>
    public class ParentResultLink : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// PRL.1 - Parent Observation Identifier.
        /// </summary>
        public CodedElement ParentObservationIdentifier { get; set; }

        /// <summary>
        /// PRL.2 - Parent Observation Sub-identifier.
        /// </summary>
        public string ParentObservationSubIdentifier { get; set; }

        /// <summary>
        /// PRL.3 - Parent Observation Value Descriptor.
        /// </summary>
        public Text ParentObservationValueDescriptor { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        public void FromDelimitedString(string delimitedString)
        {
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(separator.ToCharArray());

            if (segments.Length > 0)
            {
                ParentObservationIdentifier = new CodedElement { IsSubcomponent = true };
                ParentObservationIdentifier.FromDelimitedString(segments.ElementAtOrDefault(0));
            }
            else
            {
                ParentObservationIdentifier = null;
            }

            ParentObservationSubIdentifier = segments.ElementAtOrDefault(1);

            if (segments.Length > 2)
            {
                ParentObservationValueDescriptor = new Text { IsSubcomponent = true };
                ParentObservationValueDescriptor.FromDelimitedString(segments.ElementAtOrDefault(2));
            }
            else
            {
                ParentObservationValueDescriptor = null;
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
                                ParentObservationIdentifier?.ToDelimitedString(),
                                ParentObservationSubIdentifier,
                                ParentObservationValueDescriptor?.ToDelimitedString()
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
