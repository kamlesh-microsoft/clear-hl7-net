﻿using System;
using System.Globalization;
using System.Linq;
using ClearHl7.Helpers;
using ClearHl7.V231.Types;

namespace ClearHl7.V231.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment RQ1 - Requisition Detail-1.
    /// </summary>
    public class Rq1Segment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "RQ1";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// RQ1.1 - Anticipated Price.
        /// </summary>
        public string AnticipatedPrice { get; set; }

        /// <summary>
        /// RQ1.2 - Manufacturer Identifier.
        /// </summary>
        public CodedElement ManufacturerIdentifier { get; set; }

        /// <summary>
        /// RQ1.3 - Manufacturer's Catalog.
        /// </summary>
        public string ManufacturersCatalog { get; set; }

        /// <summary>
        /// RQ1.4 - Vendor ID.
        /// </summary>
        public CodedElement VendorId { get; set; }

        /// <summary>
        /// RQ1.5 - Vendor Catalog.
        /// </summary>
        public string VendorCatalog { get; set; }

        /// <summary>
        /// RQ1.6 - Taxable.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V231.CodeYesNoIndicator</para>
        /// </summary>
        public string Taxable { get; set; }

        /// <summary>
        /// RQ1.7 - Substitute Allowed.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V231.CodeYesNoIndicator</para>
        /// </summary>
        public string SubstituteAllowed { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <exception cref="ArgumentException">delimitedString does not begin with the proper segment Id.</exception>
        public void FromDelimitedString(string delimitedString)
        {
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(Configuration.FieldSeparator.ToCharArray());

            if (segments.Length > 0)
            {
                if (string.Compare(Id, segments.First(), true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ Configuration.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            AnticipatedPrice = segments.ElementAtOrDefault(1);
            ManufacturerIdentifier = segments.Length > 2 ? TypeHelper.Deserialize<CodedElement>(segments.ElementAtOrDefault(2), false) : null;
            ManufacturersCatalog = segments.ElementAtOrDefault(3);
            VendorId = segments.Length > 4 ? TypeHelper.Deserialize<CodedElement>(segments.ElementAtOrDefault(4), false) : null;
            VendorCatalog = segments.ElementAtOrDefault(5);
            Taxable = segments.ElementAtOrDefault(6);
            SubstituteAllowed = segments.ElementAtOrDefault(7);
        }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 8, Configuration.FieldSeparator),
                                Id,
                                AnticipatedPrice,
                                ManufacturerIdentifier?.ToDelimitedString(),
                                ManufacturersCatalog,
                                VendorId?.ToDelimitedString(),
                                VendorCatalog,
                                Taxable,
                                SubstituteAllowed
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}