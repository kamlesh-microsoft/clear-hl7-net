using System;
using ClearHl7.Extensions;
using ClearHl7.Helpers;

namespace ClearHl7.V250.Types
{
    /// <summary>
    /// HL7 Version 2 CCP - Channel Calibration Parameters.
    /// </summary>
    public class ChannelCalibrationParameters : IType
    {
        /// <inheritdoc/>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// CCP.1 - Channel Calibration Sensitivity Correction Factor.
        /// </summary>
        public decimal? ChannelCalibrationSensitivityCorrectionFactor { get; set; }

        /// <summary>
        /// CCP.2 - Channel Calibration Baseline.
        /// </summary>
        public decimal? ChannelCalibrationBaseline { get; set; }

        /// <summary>
        /// CCP.3 - Channel Calibration Time Skew.
        /// </summary>
        public decimal? ChannelCalibrationTimeSkew { get; set; }

        /// <inheritdoc/>
        public void FromDelimitedString(string delimitedString)
        {
            FromDelimitedString(delimitedString, null);
        }

        /// <inheritdoc/>
        public void FromDelimitedString(string delimitedString, Separators separators)
        {
            Separators seps = separators ?? new Separators().UsingConfigurationValues();
            string[] separator = IsSubcomponent ? seps.SubcomponentSeparator : seps.ComponentSeparator;
            string[] segments = delimitedString == null
                ? Array.Empty<string>()
                : delimitedString.Split(separator, StringSplitOptions.None);

            ChannelCalibrationSensitivityCorrectionFactor = segments.Length > 0 && segments[0].Length > 0 ? segments[0].ToNullableDecimal() : null;
            ChannelCalibrationBaseline = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableDecimal() : null;
            ChannelCalibrationTimeSkew = segments.Length > 2 && segments[2].Length > 0 ? segments[2].ToNullableDecimal() : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 3, separator),
                                ChannelCalibrationSensitivityCorrectionFactor.HasValue ? ChannelCalibrationSensitivityCorrectionFactor.Value.ToString(Consts.NumericFormat, culture) : null,
                                ChannelCalibrationBaseline.HasValue ? ChannelCalibrationBaseline.Value.ToString(Consts.NumericFormat, culture) : null,
                                ChannelCalibrationTimeSkew.HasValue ? ChannelCalibrationTimeSkew.Value.ToString(Consts.NumericFormat, culture) : null
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}
