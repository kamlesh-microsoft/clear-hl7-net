using System;
using System.Globalization;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V270.Types;

namespace ClearHl7.V270.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment SFT - Software Segment.
    /// </summary>
    public class SftSegment : ISegment
    {
        /// <inheritdoc/>
        public string Id { get; } = "SFT";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// SFT.1 - Software Vendor Organization.
        /// </summary>
        public ExtendedCompositeNameAndIdNumberForOrganizations SoftwareVendorOrganization { get; set; }

        /// <summary>
        /// SFT.2 - Software Certified Version or Release Number.
        /// </summary>
        public string SoftwareCertifiedVersionOrReleaseNumber { get; set; }

        /// <summary>
        /// SFT.3 - Software Product Name.
        /// </summary>
        public string SoftwareProductName { get; set; }

        /// <summary>
        /// SFT.4 - Software Binary ID.
        /// </summary>
        public string SoftwareBinaryId { get; set; }

        /// <summary>
        /// SFT.5 - Software Product Information.
        /// </summary>
        public Text SoftwareProductInformation { get; set; }

        /// <summary>
        /// SFT.6 - Software Install Date.
        /// </summary>
        public DateTime? SoftwareInstallDate { get; set; }

        /// <inheritdoc/>
        public void FromDelimitedString(string delimitedString)
        {
            FromDelimitedString(delimitedString, null);
        }

        /// <inheritdoc/>
        public void FromDelimitedString(string delimitedString, Separators separators)
        {
            Separators seps = separators ?? new Separators().UsingConfigurationValues();
            string[] segments = delimitedString == null
                ? Array.Empty<string>()
                : delimitedString.Split(seps.FieldSeparator, StringSplitOptions.None);

            if (segments.Length > 0)
            {
                if (string.Compare(Id, segments[0], true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ seps.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            SoftwareVendorOrganization = segments.Length > 1 && segments[1].Length > 0 ? TypeSerializer.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(segments[1], false, seps) : null;
            SoftwareCertifiedVersionOrReleaseNumber = segments.Length > 2 && segments[2].Length > 0 ? segments[2] : null;
            SoftwareProductName = segments.Length > 3 && segments[3].Length > 0 ? segments[3] : null;
            SoftwareBinaryId = segments.Length > 4 && segments[4].Length > 0 ? segments[4] : null;
            SoftwareProductInformation = segments.Length > 5 && segments[5].Length > 0 ? TypeSerializer.Deserialize<Text>(segments[5], false, seps) : null;
            SoftwareInstallDate = segments.Length > 6 && segments[6].Length > 0 ? segments[6].ToNullableDateTime() : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 7, Configuration.FieldSeparator),
                                Id,
                                SoftwareVendorOrganization?.ToDelimitedString(),
                                SoftwareCertifiedVersionOrReleaseNumber,
                                SoftwareProductName,
                                SoftwareBinaryId,
                                SoftwareProductInformation?.ToDelimitedString(),
                                SoftwareInstallDate.HasValue ? SoftwareInstallDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}
