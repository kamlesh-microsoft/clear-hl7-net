﻿using System.Linq;
using ClearHl7.Helpers;

namespace ClearHl7.V270.Types
{
    /// <summary>
    /// HL7 Version 2 PL - Person Location.
    /// </summary>
    public class PersonLocation : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// PL.1 - Point of Care.
        /// <para>Suggested: 0302 Point Of Care</para>
        /// </summary>
        public HierarchicDesignator PointOfCare { get; set; }

        /// <summary>
        /// PL.2 - Room.
        /// <para>Suggested: 0303 Room</para>
        /// </summary>
        public HierarchicDesignator Room { get; set; }

        /// <summary>
        /// PL.3 - Bed.
        /// <para>Suggested: 0304 Bed</para>
        /// </summary>
        public HierarchicDesignator Bed { get; set; }

        /// <summary>
        /// PL.4 - Facility.
        /// </summary>
        public HierarchicDesignator Facility { get; set; }

        /// <summary>
        /// PL.5 - Location Status.
        /// <para>Suggested: 0306 Location Status</para>
        /// </summary>
        public string LocationStatus { get; set; }

        /// <summary>
        /// PL.6 - Person Location Type.
        /// <para>Suggested: 0305 Person Location Type -&gt; ClearHl7.Codes.V270.CodePersonLocationType</para>
        /// </summary>
        public string PersonLocationType { get; set; }

        /// <summary>
        /// PL.7 - Building.
        /// <para>Suggested: 0307 Building</para>
        /// </summary>
        public HierarchicDesignator Building { get; set; }

        /// <summary>
        /// PL.8 - Floor.
        /// <para>Suggested: 0308 Floor</para>
        /// </summary>
        public HierarchicDesignator Floor { get; set; }

        /// <summary>
        /// PL.9 - Location Description.
        /// </summary>
        public string LocationDescription { get; set; }

        /// <summary>
        /// PL.10 - Comprehensive Location Identifier.
        /// </summary>
        public EntityIdentifier ComprehensiveLocationIdentifier { get; set; }

        /// <summary>
        /// PL.11 - Assigning Authority for Location.
        /// <para>Suggested: 0363 Assigning Authority -&gt; ClearHl7.Codes.V270.CodeAssigningAuthority</para>
        /// </summary>
        public HierarchicDesignator AssigningAuthorityForLocation { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        public void FromDelimitedString(string delimitedString)
        {
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(separator.ToCharArray());

            PointOfCare = segments.Length > 0 ? TypeHelper.Deserialize<HierarchicDesignator>(segments.ElementAtOrDefault(0), true) : null;
            Room = segments.Length > 1 ? TypeHelper.Deserialize<HierarchicDesignator>(segments.ElementAtOrDefault(1), true) : null;
            Bed = segments.Length > 2 ? TypeHelper.Deserialize<HierarchicDesignator>(segments.ElementAtOrDefault(2), true) : null;
            Facility = segments.Length > 3 ? TypeHelper.Deserialize<HierarchicDesignator>(segments.ElementAtOrDefault(3), true) : null;
            LocationStatus = segments.ElementAtOrDefault(4);
            PersonLocationType = segments.ElementAtOrDefault(5);
            Building = segments.Length > 6 ? TypeHelper.Deserialize<HierarchicDesignator>(segments.ElementAtOrDefault(6), true) : null;
            Floor = segments.Length > 7 ? TypeHelper.Deserialize<HierarchicDesignator>(segments.ElementAtOrDefault(7), true) : null;
            LocationDescription = segments.ElementAtOrDefault(8);
            ComprehensiveLocationIdentifier = segments.Length > 9 ? TypeHelper.Deserialize<EntityIdentifier>(segments.ElementAtOrDefault(9), true) : null;
            AssigningAuthorityForLocation = segments.Length > 10 ? TypeHelper.Deserialize<HierarchicDesignator>(segments.ElementAtOrDefault(10), true) : null;
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
                                StringHelper.StringFormatSequence(0, 11, separator),
                                PointOfCare?.ToDelimitedString(),
                                Room?.ToDelimitedString(),
                                Bed?.ToDelimitedString(),
                                Facility?.ToDelimitedString(),
                                LocationStatus,
                                PersonLocationType,
                                Building?.ToDelimitedString(),
                                Floor?.ToDelimitedString(),
                                LocationDescription,
                                ComprehensiveLocationIdentifier?.ToDelimitedString(),
                                AssigningAuthorityForLocation?.ToDelimitedString()
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
