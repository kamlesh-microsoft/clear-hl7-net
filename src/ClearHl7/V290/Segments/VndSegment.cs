﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V290.Types;

namespace ClearHl7.V290.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment VND - Purchasing Vendor.
    /// </summary>
    public class VndSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "VND";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// VND.1 - Set Id - VND.
        /// </summary>
        public uint? SetIdVnd { get; set; }

        /// <summary>
        /// VND.2 - Vendor Identifier.
        /// </summary>
        public EntityIdentifier VendorIdentifier { get; set; }

        /// <summary>
        /// VND.3 - Vendor Name.
        /// </summary>
        public string VendorName { get; set; }

        /// <summary>
        /// VND.4 - Vendor Catalog Number.
        /// </summary>
        public EntityIdentifier VendorCatalogNumber { get; set; }

        /// <summary>
        /// VND.5 - Primary Vendor Indicator.
        /// <para>Suggested: 0532 Expanded Yes/No Indicator -&gt; ClearHl7.Codes.V290.CodeExpandedYesNoIndicator</para>
        /// </summary>
        public CodedWithNoExceptions PrimaryVendorIndicator { get; set; }

        /// <summary>
        /// VND.6 - Corporation.
        /// </summary>
        public IEnumerable<EntityIdentifier> Corporation { get; set; }

        /// <summary>
        /// VND.7 - Primary Contact.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons PrimaryContact { get; set; }

        /// <summary>
        /// VND.8 - Contract Adjustment.
        /// </summary>
        public MoneyOrPercentage ContractAdjustment { get; set; }

        /// <summary>
        /// VND.9 - Associated Contract ID.
        /// </summary>
        public IEnumerable<EntityIdentifier> AssociatedContractId { get; set; }

        /// <summary>
        /// VND.10 - Class of Trade.
        /// </summary>
        public IEnumerable<string> ClassOfTrade { get; set; }

        /// <summary>
        /// VND.11 - Pricing Tier Level.
        /// </summary>
        public CodedWithNoExceptions PricingTierLevel { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <exception cref="ArgumentException">delimitedString does not begin with the proper segment Id.</exception>
        public void FromDelimitedString(string delimitedString)
        {
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(Configuration.FieldSeparator.ToCharArray());
            char[] separator = Configuration.FieldRepeatSeparator.ToCharArray();

            if (segments.Length > 0)
            {
                if (string.Compare(Id, segments[0], true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ Configuration.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            SetIdVnd = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableUInt() : null;
            VendorIdentifier = segments.Length > 2 && segments[2].Length > 0 ? TypeHelper.Deserialize<EntityIdentifier>(segments[2], false) : null;
            VendorName = segments.Length > 3 && segments[3].Length > 0 ? segments[3] : null;
            VendorCatalogNumber = segments.Length > 4 && segments[4].Length > 0 ? TypeHelper.Deserialize<EntityIdentifier>(segments[4], false) : null;
            PrimaryVendorIndicator = segments.Length > 5 && segments[5].Length > 0 ? TypeHelper.Deserialize<CodedWithNoExceptions>(segments[5], false) : null;
            Corporation = segments.Length > 6 && segments[6].Length > 0 ? segments[6].Split(separator).Select(x => TypeHelper.Deserialize<EntityIdentifier>(x, false)) : null;
            PrimaryContact = segments.Length > 7 && segments[7].Length > 0 ? TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments[7], false) : null;
            ContractAdjustment = segments.Length > 8 && segments[8].Length > 0 ? TypeHelper.Deserialize<MoneyOrPercentage>(segments[8], false) : null;
            AssociatedContractId = segments.Length > 9 && segments[9].Length > 0 ? segments[9].Split(separator).Select(x => TypeHelper.Deserialize<EntityIdentifier>(x, false)) : null;
            ClassOfTrade = segments.Length > 10 && segments[10].Length > 0 ? segments[10].Split(separator) : null;
            PricingTierLevel = segments.Length > 11 && segments[11].Length > 0 ? TypeHelper.Deserialize<CodedWithNoExceptions>(segments[11], false) : null;
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
                                StringHelper.StringFormatSequence(0, 12, Configuration.FieldSeparator),
                                Id,
                                SetIdVnd.HasValue ? SetIdVnd.Value.ToString(culture) : null,
                                VendorIdentifier?.ToDelimitedString(),
                                VendorName,
                                VendorCatalogNumber?.ToDelimitedString(),
                                PrimaryVendorIndicator?.ToDelimitedString(),
                                Corporation != null ? string.Join(Configuration.FieldRepeatSeparator, Corporation.Select(x => x.ToDelimitedString())) : null,
                                PrimaryContact?.ToDelimitedString(),
                                ContractAdjustment?.ToDelimitedString(),
                                AssociatedContractId != null ? string.Join(Configuration.FieldRepeatSeparator, AssociatedContractId.Select(x => x.ToDelimitedString())) : null,
                                ClassOfTrade != null ? string.Join(Configuration.FieldRepeatSeparator, ClassOfTrade) : null,
                                PricingTierLevel?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}