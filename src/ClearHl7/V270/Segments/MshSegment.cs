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
    /// HL7 Version 2 Segment MSH - Message Header.
    /// </summary>
    public class MshSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "MSH";

        /// <summary>
        /// Gets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.  This property is read-only.
        /// </summary>
        public int Ordinal { get; } = int.MinValue;

        /// <summary>
        /// MSH.1 - Field Separator.  This property is read-only.
        /// </summary>
        public string FieldSeparator => Configuration.FieldSeparator;

        /// <summary>
        /// MSH.2 - Encoding Characters.  This property is read-only.
        /// </summary>
        public string EncodingCharacters => $"{ Configuration.ComponentSeparator }{ Configuration.FieldRepeatSeparator }{ Configuration.EscapeCharacter }{ Configuration.SubcomponentSeparator }";

        /// <summary>
        /// MSH.3 - Sending Application.
        /// <para>Suggested: 0361 Application</para>
        /// </summary>
        public HierarchicDesignator SendingApplication { get; set; }

        /// <summary>
        /// MSH.4 - Sending Facility.
        /// <para>Suggested: 0362 Facility</para>
        /// </summary>
        public HierarchicDesignator SendingFacility { get; set; }

        /// <summary>
        /// MSH.5 - Receiving Application.
        /// <para>Suggested: 0361 Application</para>
        /// </summary>
        public HierarchicDesignator ReceivingApplication { get; set; }

        /// <summary>
        /// MSH.6 - Receiving Facility.
        /// <para>Suggested: 0362 Facility</para>
        /// </summary>
        public HierarchicDesignator ReceivingFacility { get; set; }

        /// <summary>
        /// MSH.7 - Date/Time of Message.
        /// </summary>
        public DateTime? DateTimeOfMessage { get; set; }

        /// <summary>
        /// MSH.8 - Security.
        /// </summary>
        public string Security { get; set; }

        /// <summary>
        /// MSH.9 - Message Type.
        /// </summary>
        public MessageType MessageType { get; set; }

        /// <summary>
        /// MSH.10 - Message Control ID.
        /// </summary>
        public string MessageControlId { get; set; }

        /// <summary>
        /// MSH.11 - Processing ID.
        /// </summary>
        public ProcessingType ProcessingId { get; set; }

        /// <summary>
        /// MSH.12 - Version ID.
        /// </summary>
        public VersionIdentifier VersionId { get; set; } = new VersionIdentifier { VersionId = "2.7" };

        /// <summary>
        /// MSH.13 - Sequence Number.
        /// </summary>
        public decimal? SequenceNumber { get; set; }

        /// <summary>
        /// MSH.14 - Continuation Pointer.
        /// </summary>
        public string ContinuationPointer { get; set; }

        /// <summary>
        /// MSH.15 - Accept Acknowledgment Type.
        /// <para>Suggested: 0155 Accept/Application Acknowledgment Conditions -&gt; ClearHl7.Codes.V270.CodeAcceptApplicationAcknowledgmentConditions</para>
        /// </summary>
        public string AcceptAcknowledgmentType { get; set; }

        /// <summary>
        /// MSH.16 - Application Acknowledgment Type.
        /// <para>Suggested: 0155 Accept/Application Acknowledgment Conditions -&gt; ClearHl7.Codes.V270.CodeAcceptApplicationAcknowledgmentConditions</para>
        /// </summary>
        public string ApplicationAcknowledgmentType { get; set; }

        /// <summary>
        /// MSH.17 - Country Code.
        /// <para>Suggested: 0399 Country Code -&gt; https://www.iso.org/iso-3166-country-codes.html</para>
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// MSH.18 - Character Set.
        /// <para>Suggested: 0211 Alternate Character Sets -&gt; ClearHl7.Codes.V270.CodeAlternateCharacterSets</para>
        /// </summary>
        public IEnumerable<string> CharacterSet { get; set; }

        /// <summary>
        /// MSH.19 - Principal Language Of Message.
        /// </summary>
        public CodedWithExceptions PrincipalLanguageOfMessage { get; set; }

        /// <summary>
        /// MSH.20 - Alternate Character Set Handling Scheme.
        /// <para>Suggested: 0356 Alternate Character Set Handling Scheme -&gt; ClearHl7.Codes.V270.CodeAlternateCharacterSetHandlingScheme</para>
        /// </summary>
        public string AlternateCharacterSetHandlingScheme { get; set; }

        /// <summary>
        /// MSH.21 - Message Profile Identifier.
        /// </summary>
        public IEnumerable<EntityIdentifier> MessageProfileIdentifier { get; set; }

        /// <summary>
        /// MSH.22 - Sending Responsible Organization.
        /// </summary>
        public ExtendedCompositeNameAndIdNumberForOrganizations SendingResponsibleOrganization { get; set; }

        /// <summary>
        /// MSH.23 - Receiving Responsible Organization.
        /// </summary>
        public ExtendedCompositeNameAndIdNumberForOrganizations ReceivingResponsibleOrganization { get; set; }

        /// <summary>
        /// MSH.24 - Sending Network Address.
        /// </summary>
        public HierarchicDesignator SendingNetworkAddress { get; set; }

        /// <summary>
        /// MSH.25 - Receiving Network Address.
        /// </summary>
        public HierarchicDesignator ReceivingNetworkAddress { get; set; }

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
                if (string.Compare(Id, segments.First(), true, CultureInfo.CurrentCulture) != 0)
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ Configuration.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            //FieldSeparator = ;
            //EncodingCharacters = ;
            SendingApplication = segments.Length > 3 ? TypeHelper.Deserialize<HierarchicDesignator>(segments.ElementAtOrDefault(3), false) : null;
            SendingFacility = segments.Length > 4 ? TypeHelper.Deserialize<HierarchicDesignator>(segments.ElementAtOrDefault(4), false) : null;
            ReceivingApplication = segments.Length > 5 ? TypeHelper.Deserialize<HierarchicDesignator>(segments.ElementAtOrDefault(5), false) : null;
            ReceivingFacility = segments.Length > 6 ? TypeHelper.Deserialize<HierarchicDesignator>(segments.ElementAtOrDefault(6), false) : null;
            DateTimeOfMessage = segments.ElementAtOrDefault(7)?.ToNullableDateTime(Consts.DateTimeFormatPrecisionSecond);
            Security = segments.ElementAtOrDefault(8);
            MessageType = segments.Length > 9 ? TypeHelper.Deserialize<MessageType>(segments.ElementAtOrDefault(9), false) : null;
            MessageControlId = segments.ElementAtOrDefault(10);
            ProcessingId = segments.Length > 11 ? TypeHelper.Deserialize<ProcessingType>(segments.ElementAtOrDefault(11), false) : null;
            VersionId = segments.Length > 12 ? TypeHelper.Deserialize<VersionIdentifier>(segments.ElementAtOrDefault(12), false) : null;
            SequenceNumber = segments.ElementAtOrDefault(13)?.ToNullableDecimal();
            ContinuationPointer = segments.ElementAtOrDefault(14);
            AcceptAcknowledgmentType = segments.ElementAtOrDefault(15);
            ApplicationAcknowledgmentType = segments.ElementAtOrDefault(16);
            CountryCode = segments.ElementAtOrDefault(17);
            CharacterSet = segments.Length > 18 ? segments.ElementAtOrDefault(18).Split(separator) : null;
            PrincipalLanguageOfMessage = segments.Length > 19 ? TypeHelper.Deserialize<CodedWithExceptions>(segments.ElementAtOrDefault(19), false) : null;
            AlternateCharacterSetHandlingScheme = segments.ElementAtOrDefault(20);
            MessageProfileIdentifier = segments.Length > 21 ? segments.ElementAtOrDefault(21).Split(separator).Select(x => TypeHelper.Deserialize<EntityIdentifier>(x, false)) : null;
            SendingResponsibleOrganization = segments.Length > 22 ? TypeHelper.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(segments.ElementAtOrDefault(22), false) : null;
            ReceivingResponsibleOrganization = segments.Length > 23 ? TypeHelper.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(segments.ElementAtOrDefault(23), false) : null;
            SendingNetworkAddress = segments.Length > 24 ? TypeHelper.Deserialize<HierarchicDesignator>(segments.ElementAtOrDefault(24), false) : null;
            ReceivingNetworkAddress = segments.Length > 25 ? TypeHelper.Deserialize<HierarchicDesignator>(segments.ElementAtOrDefault(25), false) : null;
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
                                $"{{0}}{{1}}{ StringHelper.StringFormatSequence(2, 24, Configuration.FieldSeparator) }",
                                Id,
                                FieldSeparator,
                                EncodingCharacters,
                                SendingApplication?.ToDelimitedString(),
                                SendingFacility?.ToDelimitedString(),
                                ReceivingApplication?.ToDelimitedString(),
                                ReceivingFacility?.ToDelimitedString(),
                                DateTimeOfMessage.HasValue ? DateTimeOfMessage.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                Security,
                                MessageType?.ToDelimitedString(),
                                MessageControlId,
                                ProcessingId?.ToDelimitedString(),
                                VersionId?.ToDelimitedString(),
                                SequenceNumber.HasValue ? SequenceNumber.Value.ToString(Consts.NumericFormat, culture) : null,
                                ContinuationPointer,
                                AcceptAcknowledgmentType,
                                ApplicationAcknowledgmentType,
                                CountryCode,
                                CharacterSet != null ? string.Join(Configuration.FieldRepeatSeparator, CharacterSet) : null,
                                PrincipalLanguageOfMessage?.ToDelimitedString(),
                                AlternateCharacterSetHandlingScheme,
                                MessageProfileIdentifier != null ? string.Join(Configuration.FieldRepeatSeparator, MessageProfileIdentifier.Select(x => x.ToDelimitedString())) : null,
                                SendingResponsibleOrganization?.ToDelimitedString(),
                                ReceivingResponsibleOrganization?.ToDelimitedString(),
                                SendingNetworkAddress?.ToDelimitedString(),
                                ReceivingNetworkAddress?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}