﻿using System.Collections.Generic;
using System.Linq;
using ClearHl7.Fhir.Helpers;
using ClearHl7.Fhir.V230.Types;

namespace ClearHl7.Fhir.V230.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment ARQ - Appointment Request.
    /// </summary>
    public class ArqSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "ARQ";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// ARQ.1 - Placer Appointment ID.
        /// </summary>
        public EntityIdentifier PlacerAppointmentId { get; set; }

        /// <summary>
        /// ARQ.2 -  Filler Appointment ID.
        /// </summary>
        public EntityIdentifier FillerAppointmentId { get; set; }

        /// <summary>
        /// ARQ.3 - Occurrence Number.
        /// </summary>
        public decimal? OccurrenceNumber { get; set; }

        /// <summary>
        /// ARQ.4 - Placer Group Number.
        /// </summary>
        public EntityIdentifier PlacerGroupNumber { get; set; }

        /// <summary>
        /// ARQ.5 - Schedule ID.
        /// </summary>
        public CodedElement ScheduleId { get; set; }

        /// <summary>
        /// ARQ.6 - Request Event Reason.
        /// </summary>
        public CodedElement RequestEventReason { get; set; }

        /// <summary>
        /// ARQ.7 - Appointment Reason.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0276</remarks>
        public CodedElement AppointmentReason { get; set; }

        /// <summary>
        /// ARQ.8 - Appointment Type.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0277</remarks>
        public CodedElement AppointmentType { get; set; }

        /// <summary>
        /// ARQ.9 - Appointment Duration.
        /// </summary>
        public decimal? AppointmentDuration { get; set; }

        /// <summary>
        /// ARQ.10 - Appointment Duration Units.
        /// </summary>
        public CodedElement AppointmentDurationUnits { get; set; }

        /// <summary>
        /// ARQ.11 - Requested Start Date/Time Range.
        /// </summary>
        public IEnumerable<DateTimeRange> RequestedStartDateTimeRange { get; set; }

        /// <summary>
        /// ARQ.12 - Priority-ARQ.
        /// </summary>
        public string PriorityArq { get; set; }

        /// <summary>
        /// ARQ.13 - Repeating Interval.
        /// </summary>
        public RepeatInterval RepeatingInterval { get; set; }

        /// <summary>
        /// ARQ.14 - Repeating Interval Duration.
        /// </summary>
        public string RepeatingIntervalDuration { get; set; }

        /// <summary>
        /// ARQ.15 - Placer Contact Person.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons PlacerContactPerson { get; set; }

        /// <summary>
        /// ARQ.16 - Placer Contact Phone Number.
        /// </summary>
        public IEnumerable<ExtendedTelecommunicationNumber> PlacerContactPhoneNumber { get; set; }

        /// <summary>
        /// ARQ.17 - Placer Contact Address.
        /// </summary>
        public ExtendedAddress PlacerContactAddress { get; set; }

        /// <summary>
        /// ARQ.18 - Placer Contact Location.
        /// </summary>
        public PersonLocation PlacerContactLocation { get; set; }

        /// <summary>
        /// ARQ.19 - Entered By Person.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons EnteredByPerson { get; set; }

        /// <summary>
        /// ARQ.20 - Entered By Phone Number.
        /// </summary>
        public IEnumerable<ExtendedTelecommunicationNumber> EnteredByPhoneNumber { get; set; }

        /// <summary>
        /// ARQ.21 - Entered By Location.
        /// </summary>
        public PersonLocation EnteredByLocation { get; set; }

        /// <summary>
        /// ARQ.22 - Parent Placer Appointment ID.
        /// </summary>
        public EntityIdentifier ParentPlacerAppointmentId { get; set; }

        /// <summary>
        /// ARQ.23 - Parent Filler Appointment ID.
        /// </summary>
        public EntityIdentifier ParentFillerAppointmentId { get; set; }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 24, Configuration.FieldSeparator),
                                Id,
                                PlacerAppointmentId?.ToDelimitedString(),
                                FillerAppointmentId?.ToDelimitedString(),
                                OccurrenceNumber.HasValue ? OccurrenceNumber.Value.ToString(Consts.NumericFormat, culture) : null,
                                PlacerGroupNumber?.ToDelimitedString(),
                                ScheduleId?.ToDelimitedString(),
                                RequestEventReason?.ToDelimitedString(),
                                AppointmentReason?.ToDelimitedString(),
                                AppointmentType?.ToDelimitedString(),
                                AppointmentDuration.HasValue ? AppointmentDuration.Value.ToString(Consts.NumericFormat, culture) : null,
                                AppointmentDurationUnits?.ToDelimitedString(),
                                RequestedStartDateTimeRange != null ? string.Join(Configuration.FieldRepeatSeparator, RequestedStartDateTimeRange.Select(x => x.ToDelimitedString())) : null,
                                PriorityArq,
                                RepeatingInterval?.ToDelimitedString(),
                                RepeatingIntervalDuration,
                                PlacerContactPerson?.ToDelimitedString(),
                                PlacerContactPhoneNumber != null ? string.Join(Configuration.FieldRepeatSeparator, PlacerContactPhoneNumber.Select(x => x.ToDelimitedString())) : null,
                                PlacerContactAddress?.ToDelimitedString(),
                                PlacerContactLocation?.ToDelimitedString(),
                                EnteredByPerson?.ToDelimitedString(),
                                EnteredByPhoneNumber != null ? string.Join(Configuration.FieldRepeatSeparator, EnteredByPhoneNumber.Select(x => x.ToDelimitedString())) : null,
                                EnteredByLocation?.ToDelimitedString(),
                                ParentPlacerAppointmentId?.ToDelimitedString(),
                                ParentFillerAppointmentId?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator);
        }
    }
}