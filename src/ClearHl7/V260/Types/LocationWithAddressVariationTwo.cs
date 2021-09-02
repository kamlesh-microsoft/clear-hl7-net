﻿using System;
using System.Linq;
using ClearHl7.Helpers;
using ClearHl7.Serialization;

namespace ClearHl7.V260.Types
{
    /// <summary>
    /// HL7 Version 2 LA2 - Location With Address Variation 2.
    /// </summary>
    public class LocationWithAddressVariationTwo : IType
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this instance is a subcomponent of another HL7 component instance.
        /// </summary>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// LA2.1 - Point of Care.
        /// <para>Suggested: 0302 Point Of Care</para>
        /// </summary>
        public string PointOfCare { get; set; }

        /// <summary>
        /// LA2.2 - Room.
        /// <para>Suggested: 0303 Room</para>
        /// </summary>
        public string Room { get; set; }

        /// <summary>
        /// LA2.3 - Bed.
        /// <para>Suggested: 0304 Bed</para>
        /// </summary>
        public string Bed { get; set; }

        /// <summary>
        /// LA2.4 - Facility.
        /// </summary>
        public HierarchicDesignator Facility { get; set; }

        /// <summary>
        /// LA2.5 - Location Status.
        /// <para>Suggested: 0306 Location Status</para>
        /// </summary>
        public string LocationStatus { get; set; }

        /// <summary>
        /// LA2.6 - Patient Location Type.
        /// <para>Suggested: 0305 Person Location Type -&gt; ClearHl7.Codes.V260.CodePersonLocationType</para>
        /// </summary>
        public string PatientLocationType { get; set; }

        /// <summary>
        /// LA2.7 - Building.
        /// <para>Suggested: 0307 Building</para>
        /// </summary>
        public string Building { get; set; }

        /// <summary>
        /// LA2.8 - Floor.
        /// <para>Suggested: 0308 Floor</para>
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// LA2.9 - Street Address.
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// LA2.10 - Other Designation.
        /// </summary>
        public string OtherDesignation { get; set; }

        /// <summary>
        /// LA2.11 - City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// LA2.12 - State or Province.
        /// </summary>
        public string StateOrProvince { get; set; }

        /// <summary>
        /// LA2.13 - Zip or Postal Code.
        /// </summary>
        public string ZipOrPostalCode { get; set; }

        /// <summary>
        /// LA2.14 - Country.
        /// <para>Suggested: 0399 Country Code -&gt; https://www.iso.org/iso-3166-country-codes.html</para>
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// LA2.15 - Address Type.
        /// <para>Suggested: 0190 Address Type -&gt; ClearHl7.Codes.V260.CodeAddressType</para>
        /// </summary>
        public string AddressType { get; set; }

        /// <summary>
        /// LA2.16 - Other Geographic Designation .
        /// </summary>
        public string OtherGeographicDesignation { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.  Separators defined in the Configuration class are used to split the string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        public void FromDelimitedString(string delimitedString)
        {
            FromDelimitedString(delimitedString, null);
        }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.  The provided separators are used to split the string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <param name="separators">The separators to use for splitting the string.</param>
        public void FromDelimitedString(string delimitedString, Separators separators)
        {
            Separators seps = separators ?? new Separators().UsingConfigurationValues();
            string[] separator = IsSubcomponent ? seps.SubcomponentSeparator : seps.ComponentSeparator;
            string[] segments = delimitedString == null
                ? Array.Empty<string>()
                : delimitedString.Split(separator, StringSplitOptions.None);

            PointOfCare = segments.Length > 0 && segments[0].Length > 0 ? segments[0] : null;
            Room = segments.Length > 1 && segments[1].Length > 0 ? segments[1] : null;
            Bed = segments.Length > 2 && segments[2].Length > 0 ? segments[2] : null;
            Facility = segments.Length > 3 && segments[3].Length > 0 ? TypeSerializer.Deserialize<HierarchicDesignator>(segments[3], true, seps) : null;
            LocationStatus = segments.Length > 4 && segments[4].Length > 0 ? segments[4] : null;
            PatientLocationType = segments.Length > 5 && segments[5].Length > 0 ? segments[5] : null;
            Building = segments.Length > 6 && segments[6].Length > 0 ? segments[6] : null;
            Floor = segments.Length > 7 && segments[7].Length > 0 ? segments[7] : null;
            StreetAddress = segments.Length > 8 && segments[8].Length > 0 ? segments[8] : null;
            OtherDesignation = segments.Length > 9 && segments[9].Length > 0 ? segments[9] : null;
            City = segments.Length > 10 && segments[10].Length > 0 ? segments[10] : null;
            StateOrProvince = segments.Length > 11 && segments[11].Length > 0 ? segments[11] : null;
            ZipOrPostalCode = segments.Length > 12 && segments[12].Length > 0 ? segments[12] : null;
            Country = segments.Length > 13 && segments[13].Length > 0 ? segments[13] : null;
            AddressType = segments.Length > 14 && segments[14].Length > 0 ? segments[14] : null;
            OtherGeographicDesignation = segments.Length > 15 && segments[15].Length > 0 ? segments[15] : null;
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
                                StringHelper.StringFormatSequence(0, 16, separator),
                                PointOfCare,
                                Room,
                                Bed,
                                Facility?.ToDelimitedString(),
                                LocationStatus,
                                PatientLocationType,
                                Building,
                                Floor,
                                StreetAddress,
                                OtherDesignation,
                                City,
                                StateOrProvince,
                                ZipOrPostalCode,
                                Country,
                                AddressType,
                                OtherGeographicDesignation
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}