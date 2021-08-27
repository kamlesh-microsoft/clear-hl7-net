﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V270.Types;

namespace ClearHl7.V270.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment SAC - Specimen Container Detail.
    /// </summary>
    public class SacSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "SAC";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// SAC.1 - External Accession Identifier.
        /// </summary>
        public EntityIdentifier ExternalAccessionIdentifier { get; set; }

        /// <summary>
        /// SAC.2 - Accession Identifier.
        /// </summary>
        public EntityIdentifier AccessionIdentifier { get; set; }

        /// <summary>
        /// SAC.3 - Container Identifier.
        /// </summary>
        public EntityIdentifier ContainerIdentifier { get; set; }

        /// <summary>
        /// SAC.4 - Primary (Parent) Container Identifier.
        /// </summary>
        public EntityIdentifier PrimaryParentContainerIdentifier { get; set; }

        /// <summary>
        /// SAC.5 - Equipment Container Identifier.
        /// </summary>
        public EntityIdentifier EquipmentContainerIdentifier { get; set; }

        /// <summary>
        /// SAC.6 - Specimen Source.
        /// </summary>
        public string SpecimenSource { get; set; }

        /// <summary>
        /// SAC.7 - Registration Date/Time.
        /// </summary>
        public DateTime? RegistrationDateTime { get; set; }

        /// <summary>
        /// SAC.8 - Container Status.
        /// <para>Suggested: 0370 Container Status -&gt; ClearHl7.Codes.V270.CodeContainerStatus</para>
        /// </summary>
        public CodedWithExceptions ContainerStatus { get; set; }

        /// <summary>
        /// SAC.9 - Carrier Type.
        /// <para>Suggested: 0378 Carrier Type</para>
        /// </summary>
        public CodedWithExceptions CarrierType { get; set; }

        /// <summary>
        /// SAC.10 - Carrier Identifier.
        /// </summary>
        public EntityIdentifier CarrierIdentifier { get; set; }

        /// <summary>
        /// SAC.11 - Position in Carrier.
        /// </summary>
        public NumericArray PositionInCarrier { get; set; }

        /// <summary>
        /// SAC.12 - Tray Type - SAC.
        /// <para>Suggested: 0379 Tray Type</para>
        /// </summary>
        public CodedWithExceptions TrayTypeSac { get; set; }

        /// <summary>
        /// SAC.13 - Tray Identifier.
        /// </summary>
        public EntityIdentifier TrayIdentifier { get; set; }

        /// <summary>
        /// SAC.14 - Position in Tray.
        /// </summary>
        public NumericArray PositionInTray { get; set; }

        /// <summary>
        /// SAC.15 - Location.
        /// </summary>
        public IEnumerable<CodedWithExceptions> Location { get; set; }

        /// <summary>
        /// SAC.16 - Container Height.
        /// </summary>
        public decimal? ContainerHeight { get; set; }

        /// <summary>
        /// SAC.17 - Container Diameter.
        /// </summary>
        public decimal? ContainerDiameter { get; set; }

        /// <summary>
        /// SAC.18 - Barrier Delta.
        /// </summary>
        public decimal? BarrierDelta { get; set; }

        /// <summary>
        /// SAC.19 - Bottom Delta.
        /// </summary>
        public decimal? BottomDelta { get; set; }

        /// <summary>
        /// SAC.20 - Container Height/Diameter/Delta Units.
        /// </summary>
        public CodedWithExceptions ContainerHeightDiameterDeltaUnits { get; set; }

        /// <summary>
        /// SAC.21 - Container Volume.
        /// </summary>
        public decimal? ContainerVolume { get; set; }

        /// <summary>
        /// SAC.22 - Available Specimen Volume.
        /// </summary>
        public decimal? AvailableSpecimenVolume { get; set; }

        /// <summary>
        /// SAC.23 - Initial Specimen Volume.
        /// </summary>
        public decimal? InitialSpecimenVolume { get; set; }

        /// <summary>
        /// SAC.24 - Volume Units.
        /// </summary>
        public CodedWithExceptions VolumeUnits { get; set; }

        /// <summary>
        /// SAC.25 - Separator Type.
        /// <para>Suggested: 0380 Separator Type</para>
        /// </summary>
        public CodedWithExceptions SeparatorType { get; set; }

        /// <summary>
        /// SAC.26 - Cap Type.
        /// <para>Suggested: 0381 Cap Type</para>
        /// </summary>
        public CodedWithExceptions CapType { get; set; }

        /// <summary>
        /// SAC.27 - Additive.
        /// <para>Suggested: 0371 Additive/Preservative -&gt; ClearHl7.Codes.V270.CodeAdditivePreservative</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> Additive { get; set; }

        /// <summary>
        /// SAC.28 - Specimen Component.
        /// <para>Suggested: 0372 Specimen Component -&gt; ClearHl7.Codes.V270.CodeSpecimenComponent</para>
        /// </summary>
        public CodedWithExceptions SpecimenComponent { get; set; }

        /// <summary>
        /// SAC.29 - Dilution Factor.
        /// </summary>
        public StructuredNumeric DilutionFactor { get; set; }

        /// <summary>
        /// SAC.30 - Treatment.
        /// <para>Suggested: 0373 Treatment -&gt; ClearHl7.Codes.V270.CodeTreatment</para>
        /// </summary>
        public CodedWithExceptions Treatment { get; set; }

        /// <summary>
        /// SAC.31 - Temperature.
        /// </summary>
        public StructuredNumeric Temperature { get; set; }

        /// <summary>
        /// SAC.32 - Hemolysis Index.
        /// </summary>
        public decimal? HemolysisIndex { get; set; }

        /// <summary>
        /// SAC.33 - Hemolysis Index Units.
        /// </summary>
        public CodedWithExceptions HemolysisIndexUnits { get; set; }

        /// <summary>
        /// SAC.34 - Lipemia Index.
        /// </summary>
        public decimal? LipemiaIndex { get; set; }

        /// <summary>
        /// SAC.35 - Lipemia Index Units.
        /// </summary>
        public CodedWithExceptions LipemiaIndexUnits { get; set; }

        /// <summary>
        /// SAC.36 - Icterus Index.
        /// </summary>
        public decimal? IcterusIndex { get; set; }

        /// <summary>
        /// SAC.37 - Icterus Index Units.
        /// </summary>
        public CodedWithExceptions IcterusIndexUnits { get; set; }

        /// <summary>
        /// SAC.38 - Fibrin Index.
        /// </summary>
        public decimal? FibrinIndex { get; set; }

        /// <summary>
        /// SAC.39 - Fibrin Index Units.
        /// </summary>
        public CodedWithExceptions FibrinIndexUnits { get; set; }

        /// <summary>
        /// SAC.40 - System Induced Contaminants.
        /// <para>Suggested: 0374 System Induced Contaminants -&gt; ClearHl7.Codes.V270.CodeSystemInducedContaminants</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> SystemInducedContaminants { get; set; }

        /// <summary>
        /// SAC.41 - Drug Interference.
        /// <para>Suggested: 0382 Drug Interference</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> DrugInterference { get; set; }

        /// <summary>
        /// SAC.42 - Artificial Blood.
        /// <para>Suggested: 0375 Artificial Blood -&gt; ClearHl7.Codes.V270.CodeArtificialBlood</para>
        /// </summary>
        public CodedWithExceptions ArtificialBlood { get; set; }

        /// <summary>
        /// SAC.43 - Special Handling Code.
        /// <para>Suggested: 0376 Special Handling Code -&gt; ClearHl7.Codes.V270.CodeSpecialHandlingCode</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> SpecialHandlingCode { get; set; }

        /// <summary>
        /// SAC.44 - Other Environmental Factors.
        /// <para>Suggested: 0377 Other Environmental Factors -&gt; ClearHl7.Codes.V270.CodeOtherEnvironmentalFactors</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> OtherEnvironmentalFactors { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.  Separators defined in the Configuration class are used to split the string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <exception cref="ArgumentException">delimitedString does not begin with the proper segment Id.</exception>
        public void FromDelimitedString(string delimitedString)
        {
            FromDelimitedString(delimitedString, null);
        }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.  The provided separators are used to split the string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <param name="separators">The separators to use for splitting the string.</param>
        /// <exception cref="ArgumentException">delimitedString does not begin with the proper segment Id.</exception>
        public void FromDelimitedString(string delimitedString, Separators separators)
        {
            Separators seps = separators ?? new Separators().UsingConfigurationValues();
            string[] segments = delimitedString == null
                ? new string[] { }
                : delimitedString.Split(seps.FieldSeparator, StringSplitOptions.None);
            
            if (segments.Length > 0)
            {
                if (string.Compare(Id, segments[0], true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ seps.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            ExternalAccessionIdentifier = segments.Length > 1 && segments[1].Length > 0 ? TypeHelper.Deserialize<EntityIdentifier>(segments[1], false) : null;
            AccessionIdentifier = segments.Length > 2 && segments[2].Length > 0 ? TypeHelper.Deserialize<EntityIdentifier>(segments[2], false) : null;
            ContainerIdentifier = segments.Length > 3 && segments[3].Length > 0 ? TypeHelper.Deserialize<EntityIdentifier>(segments[3], false) : null;
            PrimaryParentContainerIdentifier = segments.Length > 4 && segments[4].Length > 0 ? TypeHelper.Deserialize<EntityIdentifier>(segments[4], false) : null;
            EquipmentContainerIdentifier = segments.Length > 5 && segments[5].Length > 0 ? TypeHelper.Deserialize<EntityIdentifier>(segments[5], false) : null;
            SpecimenSource = segments.Length > 6 && segments[6].Length > 0 ? segments[6] : null;
            RegistrationDateTime = segments.Length > 7 && segments[7].Length > 0 ? segments[7].ToNullableDateTime() : null;
            ContainerStatus = segments.Length > 8 && segments[8].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[8], false) : null;
            CarrierType = segments.Length > 9 && segments[9].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[9], false) : null;
            CarrierIdentifier = segments.Length > 10 && segments[10].Length > 0 ? TypeHelper.Deserialize<EntityIdentifier>(segments[10], false) : null;
            PositionInCarrier = segments.Length > 11 && segments[11].Length > 0 ? TypeHelper.Deserialize<NumericArray>(segments[11], false) : null;
            TrayTypeSac = segments.Length > 12 && segments[12].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[12], false) : null;
            TrayIdentifier = segments.Length > 13 && segments[13].Length > 0 ? TypeHelper.Deserialize<EntityIdentifier>(segments[13], false) : null;
            PositionInTray = segments.Length > 14 && segments[14].Length > 0 ? TypeHelper.Deserialize<NumericArray>(segments[14], false) : null;
            Location = segments.Length > 15 && segments[15].Length > 0 ? segments[15].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            ContainerHeight = segments.Length > 16 && segments[16].Length > 0 ? segments[16].ToNullableDecimal() : null;
            ContainerDiameter = segments.Length > 17 && segments[17].Length > 0 ? segments[17].ToNullableDecimal() : null;
            BarrierDelta = segments.Length > 18 && segments[18].Length > 0 ? segments[18].ToNullableDecimal() : null;
            BottomDelta = segments.Length > 19 && segments[19].Length > 0 ? segments[19].ToNullableDecimal() : null;
            ContainerHeightDiameterDeltaUnits = segments.Length > 20 && segments[20].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[20], false) : null;
            ContainerVolume = segments.Length > 21 && segments[21].Length > 0 ? segments[21].ToNullableDecimal() : null;
            AvailableSpecimenVolume = segments.Length > 22 && segments[22].Length > 0 ? segments[22].ToNullableDecimal() : null;
            InitialSpecimenVolume = segments.Length > 23 && segments[23].Length > 0 ? segments[23].ToNullableDecimal() : null;
            VolumeUnits = segments.Length > 24 && segments[24].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[24], false) : null;
            SeparatorType = segments.Length > 25 && segments[25].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[25], false) : null;
            CapType = segments.Length > 26 && segments[26].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[26], false) : null;
            Additive = segments.Length > 27 && segments[27].Length > 0 ? segments[27].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            SpecimenComponent = segments.Length > 28 && segments[28].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[28], false) : null;
            DilutionFactor = segments.Length > 29 && segments[29].Length > 0 ? TypeHelper.Deserialize<StructuredNumeric>(segments[29], false) : null;
            Treatment = segments.Length > 30 && segments[30].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[30], false) : null;
            Temperature = segments.Length > 31 && segments[31].Length > 0 ? TypeHelper.Deserialize<StructuredNumeric>(segments[31], false) : null;
            HemolysisIndex = segments.Length > 32 && segments[32].Length > 0 ? segments[32].ToNullableDecimal() : null;
            HemolysisIndexUnits = segments.Length > 33 && segments[33].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[33], false) : null;
            LipemiaIndex = segments.Length > 34 && segments[34].Length > 0 ? segments[34].ToNullableDecimal() : null;
            LipemiaIndexUnits = segments.Length > 35 && segments[35].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[35], false) : null;
            IcterusIndex = segments.Length > 36 && segments[36].Length > 0 ? segments[36].ToNullableDecimal() : null;
            IcterusIndexUnits = segments.Length > 37 && segments[37].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[37], false) : null;
            FibrinIndex = segments.Length > 38 && segments[38].Length > 0 ? segments[38].ToNullableDecimal() : null;
            FibrinIndexUnits = segments.Length > 39 && segments[39].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[39], false) : null;
            SystemInducedContaminants = segments.Length > 40 && segments[40].Length > 0 ? segments[40].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            DrugInterference = segments.Length > 41 && segments[41].Length > 0 ? segments[41].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            ArtificialBlood = segments.Length > 42 && segments[42].Length > 0 ? TypeHelper.Deserialize<CodedWithExceptions>(segments[42], false) : null;
            SpecialHandlingCode = segments.Length > 43 && segments[43].Length > 0 ? segments[43].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
            OtherEnvironmentalFactors = segments.Length > 44 && segments[44].Length > 0 ? segments[44].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedWithExceptions>(x, false)) : null;
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
                                StringHelper.StringFormatSequence(0, 45, Configuration.FieldSeparator),
                                Id,
                                ExternalAccessionIdentifier?.ToDelimitedString(),
                                AccessionIdentifier?.ToDelimitedString(),
                                ContainerIdentifier?.ToDelimitedString(),
                                PrimaryParentContainerIdentifier?.ToDelimitedString(),
                                EquipmentContainerIdentifier?.ToDelimitedString(),
                                SpecimenSource,
                                RegistrationDateTime.HasValue ? RegistrationDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ContainerStatus?.ToDelimitedString(),
                                CarrierType?.ToDelimitedString(),
                                CarrierIdentifier?.ToDelimitedString(),
                                PositionInCarrier?.ToDelimitedString(),
                                TrayTypeSac?.ToDelimitedString(),
                                TrayIdentifier?.ToDelimitedString(),
                                PositionInTray?.ToDelimitedString(),
                                Location != null ? string.Join(Configuration.FieldRepeatSeparator, Location.Select(x => x.ToDelimitedString())) : null,
                                ContainerHeight.HasValue ? ContainerHeight.Value.ToString(Consts.NumericFormat, culture) : null,
                                ContainerDiameter.HasValue ? ContainerDiameter.Value.ToString(Consts.NumericFormat, culture) : null,
                                BarrierDelta.HasValue ? BarrierDelta.Value.ToString(Consts.NumericFormat, culture) : null,
                                BottomDelta.HasValue ? BottomDelta.Value.ToString(Consts.NumericFormat, culture) : null,
                                ContainerHeightDiameterDeltaUnits?.ToDelimitedString(),
                                ContainerVolume.HasValue ? ContainerVolume.Value.ToString(Consts.NumericFormat, culture) : null,
                                AvailableSpecimenVolume.HasValue ? AvailableSpecimenVolume.Value.ToString(Consts.NumericFormat, culture) : null,
                                InitialSpecimenVolume.HasValue ? InitialSpecimenVolume.Value.ToString(Consts.NumericFormat, culture) : null,
                                VolumeUnits?.ToDelimitedString(),
                                SeparatorType?.ToDelimitedString(),
                                CapType?.ToDelimitedString(),
                                Additive != null ? string.Join(Configuration.FieldRepeatSeparator, Additive.Select(x => x.ToDelimitedString())) : null,
                                SpecimenComponent?.ToDelimitedString(),
                                DilutionFactor?.ToDelimitedString(),
                                Treatment?.ToDelimitedString(),
                                Temperature?.ToDelimitedString(),
                                HemolysisIndex.HasValue ? HemolysisIndex.Value.ToString(Consts.NumericFormat, culture) : null,
                                HemolysisIndexUnits?.ToDelimitedString(),
                                LipemiaIndex.HasValue ? LipemiaIndex.Value.ToString(Consts.NumericFormat, culture) : null,
                                LipemiaIndexUnits?.ToDelimitedString(),
                                IcterusIndex.HasValue ? IcterusIndex.Value.ToString(Consts.NumericFormat, culture) : null,
                                IcterusIndexUnits?.ToDelimitedString(),
                                FibrinIndex.HasValue ? FibrinIndex.Value.ToString(Consts.NumericFormat, culture) : null,
                                FibrinIndexUnits?.ToDelimitedString(),
                                SystemInducedContaminants != null ? string.Join(Configuration.FieldRepeatSeparator, SystemInducedContaminants.Select(x => x.ToDelimitedString())) : null,
                                DrugInterference != null ? string.Join(Configuration.FieldRepeatSeparator, DrugInterference.Select(x => x.ToDelimitedString())) : null,
                                ArtificialBlood?.ToDelimitedString(),
                                SpecialHandlingCode != null ? string.Join(Configuration.FieldRepeatSeparator, SpecialHandlingCode.Select(x => x.ToDelimitedString())) : null,
                                OtherEnvironmentalFactors != null ? string.Join(Configuration.FieldRepeatSeparator, OtherEnvironmentalFactors.Select(x => x.ToDelimitedString())) : null
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}