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
        /// <para>Suggested: 0370 Container Status -&gt; ClearHl7.Codes.V290.CodeContainerStatus</para>
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
        /// <para>Suggested: 0774 Location</para>
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
        /// <para>Suggested: 0775 Container Height/Diameter/Delta Units</para>
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
        /// <para>Suggested: 0777 Volume Units</para>
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
        /// <para>Suggested: 0371 Additive/Preservative -&gt; ClearHl7.Codes.V290.CodeAdditivePreservative</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> Additive { get; set; }

        /// <summary>
        /// SAC.28 - Specimen Component.
        /// <para>Suggested: 0372 Specimen Component -&gt; ClearHl7.Codes.V290.CodeSpecimenComponent</para>
        /// </summary>
        public CodedWithExceptions SpecimenComponent { get; set; }

        /// <summary>
        /// SAC.29 - Dilution Factor.
        /// </summary>
        public StructuredNumeric DilutionFactor { get; set; }

        /// <summary>
        /// SAC.30 - Treatment.
        /// <para>Suggested: 0373 Treatment -&gt; ClearHl7.Codes.V290.CodeTreatment</para>
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
        /// <para>Suggested: 0779 Hemolysis Index Units</para>
        /// </summary>
        public CodedWithExceptions HemolysisIndexUnits { get; set; }

        /// <summary>
        /// SAC.34 - Lipemia Index.
        /// </summary>
        public decimal? LipemiaIndex { get; set; }

        /// <summary>
        /// SAC.35 - Lipemia Index Units.
        /// <para>Suggested: 0780 Lipemia Index Units</para>
        /// </summary>
        public CodedWithExceptions LipemiaIndexUnits { get; set; }

        /// <summary>
        /// SAC.36 - Icterus Index.
        /// </summary>
        public decimal? IcterusIndex { get; set; }

        /// <summary>
        /// SAC.37 - Icterus Index Units.
        /// <para>Suggested: 0781 Icterus Index Units</para>
        /// </summary>
        public CodedWithExceptions IcterusIndexUnits { get; set; }

        /// <summary>
        /// SAC.38 - Fibrin Index.
        /// </summary>
        public decimal? FibrinIndex { get; set; }

        /// <summary>
        /// SAC.39 - Fibrin Index Units.
        /// <para>Suggested: 0782 Fibrin Index Units</para>
        /// </summary>
        public CodedWithExceptions FibrinIndexUnits { get; set; }

        /// <summary>
        /// SAC.40 - System Induced Contaminants.
        /// <para>Suggested: 0374 System Induced Contaminants -&gt; ClearHl7.Codes.V290.CodeSystemInducedContaminants</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> SystemInducedContaminants { get; set; }

        /// <summary>
        /// SAC.41 - Drug Interference.
        /// <para>Suggested: 0382 Drug Interference</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> DrugInterference { get; set; }

        /// <summary>
        /// SAC.42 - Artificial Blood.
        /// <para>Suggested: 0375 Artificial Blood -&gt; ClearHl7.Codes.V290.CodeArtificialBlood</para>
        /// </summary>
        public CodedWithExceptions ArtificialBlood { get; set; }

        /// <summary>
        /// SAC.43 - Special Handling Code.
        /// <para>Suggested: 0376 Special Handling Code -&gt; ClearHl7.Codes.V290.CodeSpecialHandlingCode</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> SpecialHandlingCode { get; set; }

        /// <summary>
        /// SAC.44 - Other Environmental Factors.
        /// <para>Suggested: 0377 Other Environmental Factors -&gt; ClearHl7.Codes.V290.CodeOtherEnvironmentalFactors</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> OtherEnvironmentalFactors { get; set; }

        /// <summary>
        /// SAC.45 - Container Length.
        /// </summary>
        public CompositeQuantityWithUnits ContainerLength { get; set; }

        /// <summary>
        /// SAC.46 - Container Width.
        /// </summary>
        public CompositeQuantityWithUnits ContainerWidth { get; set; }

        /// <summary>
        /// SAC.47 - Container Form.
        /// <para>Suggested: 0967 Container Form</para>
        /// </summary>
        public CodedWithExceptions ContainerForm { get; set; }

        /// <summary>
        /// SAC.48 - Container Material.
        /// <para>Suggested: 0968 Container Material</para>
        /// </summary>
        public CodedWithExceptions ContainerMaterial { get; set; }

        /// <summary>
        /// SAC.49 - Container Common Name.
        /// <para>Suggested: 0969 Container Common Name</para>
        /// </summary>
        public CodedWithExceptions ContainerCommonName { get; set; }

        /// <summary>
        /// Initializes properties of this instance with values parsed from the given delimited string.
        /// </summary>
        /// <param name="delimitedString">A string representation that will be deserialized into the object instance.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <exception cref="ArgumentException">delimitedString does not begin with the proper segment Id.</exception>
        public SacSegment FromDelimitedString(string delimitedString)
        {
            string[] segments = delimitedString == null ? new string[] { } : delimitedString.Split(Configuration.FieldSeparator.ToCharArray());
            char[] separator = Configuration.FieldRepeatSeparator.ToCharArray();

            if (segments.Length > 0)
            {
                if (string.Compare(Id, segments.First(), true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ Configuration.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            ExternalAccessionIdentifier = segments.Length > 1 ? new EntityIdentifier().FromDelimitedString(segments.ElementAtOrDefault(1)) : null;
            AccessionIdentifier = segments.Length > 2 ? new EntityIdentifier().FromDelimitedString(segments.ElementAtOrDefault(2)) : null;
            ContainerIdentifier = segments.Length > 3 ? new EntityIdentifier().FromDelimitedString(segments.ElementAtOrDefault(3)) : null;
            PrimaryParentContainerIdentifier = segments.Length > 4 ? new EntityIdentifier().FromDelimitedString(segments.ElementAtOrDefault(4)) : null;
            EquipmentContainerIdentifier = segments.Length > 5 ? new EntityIdentifier().FromDelimitedString(segments.ElementAtOrDefault(5)) : null;
            SpecimenSource = segments.ElementAtOrDefault(6);
            RegistrationDateTime = segments.ElementAtOrDefault(7)?.ToNullableDateTime(Consts.DateTimeFormatPrecisionSecond);
            ContainerStatus = segments.Length > 8 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(8)) : null;
            CarrierType = segments.Length > 9 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(9)) : null;
            CarrierIdentifier = segments.Length > 10 ? new EntityIdentifier().FromDelimitedString(segments.ElementAtOrDefault(10)) : null;
            PositionInCarrier = segments.Length > 11 ? new NumericArray().FromDelimitedString(segments.ElementAtOrDefault(11)) : null;
            TrayTypeSac = segments.Length > 12 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(12)) : null;
            TrayIdentifier = segments.Length > 13 ? new EntityIdentifier().FromDelimitedString(segments.ElementAtOrDefault(13)) : null;
            PositionInTray = segments.Length > 14 ? new NumericArray().FromDelimitedString(segments.ElementAtOrDefault(14)) : null;
            Location = segments.Length > 15 ? segments.ElementAtOrDefault(15).Split(separator).Select(x => new CodedWithExceptions().FromDelimitedString(x)) : null;
            ContainerHeight = segments.ElementAtOrDefault(16)?.ToNullableDecimal();
            ContainerDiameter = segments.ElementAtOrDefault(17)?.ToNullableDecimal();
            BarrierDelta = segments.ElementAtOrDefault(18)?.ToNullableDecimal();
            BottomDelta = segments.ElementAtOrDefault(19)?.ToNullableDecimal();
            ContainerHeightDiameterDeltaUnits = segments.Length > 20 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(20)) : null;
            ContainerVolume = segments.ElementAtOrDefault(21)?.ToNullableDecimal();
            AvailableSpecimenVolume = segments.ElementAtOrDefault(22)?.ToNullableDecimal();
            InitialSpecimenVolume = segments.ElementAtOrDefault(23)?.ToNullableDecimal();
            VolumeUnits = segments.Length > 24 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(24)) : null;
            SeparatorType = segments.Length > 25 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(25)) : null;
            CapType = segments.Length > 26 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(26)) : null;
            Additive = segments.Length > 27 ? segments.ElementAtOrDefault(27).Split(separator).Select(x => new CodedWithExceptions().FromDelimitedString(x)) : null;
            SpecimenComponent = segments.Length > 28 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(28)) : null;
            DilutionFactor = segments.Length > 29 ? new StructuredNumeric().FromDelimitedString(segments.ElementAtOrDefault(29)) : null;
            Treatment = segments.Length > 30 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(30)) : null;
            Temperature = segments.Length > 31 ? new StructuredNumeric().FromDelimitedString(segments.ElementAtOrDefault(31)) : null;
            HemolysisIndex = segments.ElementAtOrDefault(32)?.ToNullableDecimal();
            HemolysisIndexUnits = segments.Length > 33 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(33)) : null;
            LipemiaIndex = segments.ElementAtOrDefault(34)?.ToNullableDecimal();
            LipemiaIndexUnits = segments.Length > 35 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(35)) : null;
            IcterusIndex = segments.ElementAtOrDefault(36)?.ToNullableDecimal();
            IcterusIndexUnits = segments.Length > 37 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(37)) : null;
            FibrinIndex = segments.ElementAtOrDefault(38)?.ToNullableDecimal();
            FibrinIndexUnits = segments.Length > 39 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(39)) : null;
            SystemInducedContaminants = segments.Length > 40 ? segments.ElementAtOrDefault(40).Split(separator).Select(x => new CodedWithExceptions().FromDelimitedString(x)) : null;
            DrugInterference = segments.Length > 41 ? segments.ElementAtOrDefault(41).Split(separator).Select(x => new CodedWithExceptions().FromDelimitedString(x)) : null;
            ArtificialBlood = segments.Length > 42 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(42)) : null;
            SpecialHandlingCode = segments.Length > 43 ? segments.ElementAtOrDefault(43).Split(separator).Select(x => new CodedWithExceptions().FromDelimitedString(x)) : null;
            OtherEnvironmentalFactors = segments.Length > 44 ? segments.ElementAtOrDefault(44).Split(separator).Select(x => new CodedWithExceptions().FromDelimitedString(x)) : null;
            ContainerLength = segments.Length > 45 ? new CompositeQuantityWithUnits().FromDelimitedString(segments.ElementAtOrDefault(45)) : null;
            ContainerWidth = segments.Length > 46 ? new CompositeQuantityWithUnits().FromDelimitedString(segments.ElementAtOrDefault(46)) : null;
            ContainerForm = segments.Length > 47 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(47)) : null;
            ContainerMaterial = segments.Length > 48 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(48)) : null;
            ContainerCommonName = segments.Length > 49 ? new CodedWithExceptions().FromDelimitedString(segments.ElementAtOrDefault(49)) : null;
            
            return this;
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
                                StringHelper.StringFormatSequence(0, 50, Configuration.FieldSeparator),
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
                                OtherEnvironmentalFactors != null ? string.Join(Configuration.FieldRepeatSeparator, OtherEnvironmentalFactors.Select(x => x.ToDelimitedString())) : null,
                                ContainerLength?.ToDelimitedString(),
                                ContainerWidth?.ToDelimitedString(),
                                ContainerForm?.ToDelimitedString(),
                                ContainerMaterial?.ToDelimitedString(),
                                ContainerCommonName?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}