﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V231.Types;

namespace ClearHl7.V231.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment TXA - Transcription Document Header.
    /// </summary>
    public class TxaSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "TXA";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// TXA.1 - Set ID- TXA.
        /// </summary>
        public uint? SetIdTxa { get; set; }

        /// <summary>
        /// TXA.2 - Document Type.
        /// <para>Suggested: 0270 Document Type -&gt; ClearHl7.Codes.V231.CodeDocumentType</para>
        /// </summary>
        public string DocumentType { get; set; }

        /// <summary>
        /// TXA.3 - Document Content Presentation.
        /// <para>Suggested: 0191 Type Of Referenced Data -&gt; ClearHl7.Codes.V231.CodeTypeOfReferencedData</para>
        /// </summary>
        public string DocumentContentPresentation { get; set; }

        /// <summary>
        /// TXA.4 - Activity Date/Time.
        /// </summary>
        public DateTime? ActivityDateTime { get; set; }

        /// <summary>
        /// TXA.5 - Primary Activity Provider Code/Name.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> PrimaryActivityProviderCodeName { get; set; }

        /// <summary>
        /// TXA.6 - Origination Date/Time.
        /// </summary>
        public DateTime? OriginationDateTime { get; set; }

        /// <summary>
        /// TXA.7 - Transcription Date/Time.
        /// </summary>
        public DateTime? TranscriptionDateTime { get; set; }

        /// <summary>
        /// TXA.8 - Edit Date/Time.
        /// </summary>
        public IEnumerable<DateTime> EditDateTime { get; set; }

        /// <summary>
        /// TXA.9 - Originator Code/Name.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> OriginatorCodeName { get; set; }

        /// <summary>
        /// TXA.10 - Assigned Document Authenticator.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> AssignedDocumentAuthenticator { get; set; }

        /// <summary>
        /// TXA.11 - Transcriptionist Code/Name.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> TranscriptionistCodeName { get; set; }

        /// <summary>
        /// TXA.12 - Unique Document Number.
        /// </summary>
        public EntityIdentifier UniqueDocumentNumber { get; set; }

        /// <summary>
        /// TXA.13 - Parent Document Number.
        /// </summary>
        public EntityIdentifier ParentDocumentNumber { get; set; }

        /// <summary>
        /// TXA.14 - Placer Order Number.
        /// </summary>
        public IEnumerable<EntityIdentifier> PlacerOrderNumber { get; set; }

        /// <summary>
        /// TXA.15 - Filler Order Number.
        /// </summary>
        public EntityIdentifier FillerOrderNumber { get; set; }

        /// <summary>
        /// TXA.16 - Unique Document File Name.
        /// </summary>
        public string UniqueDocumentFileName { get; set; }

        /// <summary>
        /// TXA.17 - Document Completion Status.
        /// <para>Suggested: 0271 Document Completion Status -&gt; ClearHl7.Codes.V231.CodeDocumentCompletionStatus</para>
        /// </summary>
        public string DocumentCompletionStatus { get; set; }

        /// <summary>
        /// TXA.18 - Document Confidentiality Status.
        /// <para>Suggested: 0272 Document Confidentiality Status -&gt; ClearHl7.Codes.V231.CodeDocumentConfidentialityStatus</para>
        /// </summary>
        public string DocumentConfidentialityStatus { get; set; }

        /// <summary>
        /// TXA.19 - Document Availability Status.
        /// <para>Suggested: 0273 Document Availability Status -&gt; ClearHl7.Codes.V231.CodeDocumentAvailabilityStatus</para>
        /// </summary>
        public string DocumentAvailabilityStatus { get; set; }

        /// <summary>
        /// TXA.20 - Document Storage Status.
        /// <para>Suggested: 0275 Document Storage Status -&gt; ClearHl7.Codes.V231.CodeDocumentStorageStatus</para>
        /// </summary>
        public string DocumentStorageStatus { get; set; }

        /// <summary>
        /// TXA.21 - Document Change Reason.
        /// </summary>
        public string DocumentChangeReason { get; set; }

        /// <summary>
        /// TXA.22 - Authentication Person, Time Stamp (set).
        /// </summary>
        public IEnumerable<PerformingPersonTimeStamp> AuthenticationPersonTimeStampSet { get; set; }

        /// <summary>
        /// TXA.23 - Distributed Copies (Code and Name of Recipient(s) ).
        /// </summary>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> DistributedCopiesCodeAndNameOfRecipients { get; set; }

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

            SetIdTxa = segments.ElementAtOrDefault(1)?.ToNullableUInt();
            DocumentType = segments.ElementAtOrDefault(2);
            DocumentContentPresentation = segments.ElementAtOrDefault(3);
            ActivityDateTime = segments.ElementAtOrDefault(4)?.ToNullableDateTime();
            PrimaryActivityProviderCodeName = segments.Length > 5 ? segments.ElementAtOrDefault(5).Split(separator).Select(x => TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(x, false)) : null;
            OriginationDateTime = segments.ElementAtOrDefault(6)?.ToNullableDateTime();
            TranscriptionDateTime = segments.ElementAtOrDefault(7)?.ToNullableDateTime();
            EditDateTime = segments.Length > 8 ? segments.ElementAtOrDefault(8).Split(separator).Select(x => x.ToDateTime()) : null;
            OriginatorCodeName = segments.Length > 9 ? segments.ElementAtOrDefault(9).Split(separator).Select(x => TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(x, false)) : null;
            AssignedDocumentAuthenticator = segments.Length > 10 ? segments.ElementAtOrDefault(10).Split(separator).Select(x => TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(x, false)) : null;
            TranscriptionistCodeName = segments.Length > 11 ? segments.ElementAtOrDefault(11).Split(separator).Select(x => TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(x, false)) : null;
            UniqueDocumentNumber = segments.Length > 12 ? TypeHelper.Deserialize<EntityIdentifier>(segments.ElementAtOrDefault(12), false) : null;
            ParentDocumentNumber = segments.Length > 13 ? TypeHelper.Deserialize<EntityIdentifier>(segments.ElementAtOrDefault(13), false) : null;
            PlacerOrderNumber = segments.Length > 14 ? segments.ElementAtOrDefault(14).Split(separator).Select(x => TypeHelper.Deserialize<EntityIdentifier>(x, false)) : null;
            FillerOrderNumber = segments.Length > 15 ? TypeHelper.Deserialize<EntityIdentifier>(segments.ElementAtOrDefault(15), false) : null;
            UniqueDocumentFileName = segments.ElementAtOrDefault(16);
            DocumentCompletionStatus = segments.ElementAtOrDefault(17);
            DocumentConfidentialityStatus = segments.ElementAtOrDefault(18);
            DocumentAvailabilityStatus = segments.ElementAtOrDefault(19);
            DocumentStorageStatus = segments.ElementAtOrDefault(20);
            DocumentChangeReason = segments.ElementAtOrDefault(21);
            AuthenticationPersonTimeStampSet = segments.Length > 22 ? segments.ElementAtOrDefault(22).Split(separator).Select(x => TypeHelper.Deserialize<PerformingPersonTimeStamp>(x, false)) : null;
            DistributedCopiesCodeAndNameOfRecipients = segments.Length > 23 ? segments.ElementAtOrDefault(23).Split(separator).Select(x => TypeHelper.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(x, false)) : null;
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
                                StringHelper.StringFormatSequence(0, 24, Configuration.FieldSeparator),
                                Id,
                                SetIdTxa.HasValue ? SetIdTxa.Value.ToString(culture) : null,
                                DocumentType,
                                DocumentContentPresentation,
                                ActivityDateTime.HasValue ? ActivityDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                PrimaryActivityProviderCodeName != null ? string.Join(Configuration.FieldRepeatSeparator, PrimaryActivityProviderCodeName.Select(x => x.ToDelimitedString())) : null,
                                OriginationDateTime.HasValue ? OriginationDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                TranscriptionDateTime.HasValue ? TranscriptionDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                EditDateTime != null ? string.Join(Configuration.FieldRepeatSeparator, EditDateTime.Select(x => x.ToString(Consts.DateTimeFormatPrecisionSecond, culture))) : null,
                                OriginatorCodeName != null ? string.Join(Configuration.FieldRepeatSeparator, OriginatorCodeName.Select(x => x.ToDelimitedString())) : null,
                                AssignedDocumentAuthenticator != null ? string.Join(Configuration.FieldRepeatSeparator, AssignedDocumentAuthenticator.Select(x => x.ToDelimitedString())) : null,
                                TranscriptionistCodeName != null ? string.Join(Configuration.FieldRepeatSeparator, TranscriptionistCodeName.Select(x => x.ToDelimitedString())) : null,
                                UniqueDocumentNumber?.ToDelimitedString(),
                                ParentDocumentNumber?.ToDelimitedString(),
                                PlacerOrderNumber != null ? string.Join(Configuration.FieldRepeatSeparator, PlacerOrderNumber.Select(x => x.ToDelimitedString())) : null,
                                FillerOrderNumber?.ToDelimitedString(),
                                UniqueDocumentFileName,
                                DocumentCompletionStatus,
                                DocumentConfidentialityStatus,
                                DocumentAvailabilityStatus,
                                DocumentStorageStatus,
                                DocumentChangeReason,
                                AuthenticationPersonTimeStampSet != null ? string.Join(Configuration.FieldRepeatSeparator, AuthenticationPersonTimeStampSet.Select(x => x.ToDelimitedString())) : null,
                                DistributedCopiesCodeAndNameOfRecipients != null ? string.Join(Configuration.FieldRepeatSeparator, DistributedCopiesCodeAndNameOfRecipients.Select(x => x.ToDelimitedString())) : null
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}