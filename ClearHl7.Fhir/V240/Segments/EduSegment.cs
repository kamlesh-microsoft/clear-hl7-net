﻿using System;
using ClearHl7.Fhir.V240.Types;

namespace ClearHl7.Fhir.V240.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment EDU - Educational Detail.
    /// </summary>
    public class EduSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "EDU";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// EDU.1 - Set ID - EDU.
        /// </summary>
        public uint? SetIdEdu { get; set; }

        /// <summary>
        /// EDU.2 - Academic Degree.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0360</remarks>
        public string AcademicDegree { get; set; }

        /// <summary>
        /// EDU.3 - Academic Degree Program Date Range.
        /// </summary>
        public DateTimeRange AcademicDegreeProgramDateRange { get; set; }

        /// <summary>
        /// EDU.4 - Academic Degree Program Participation Date Range.
        /// </summary>
        public DateTimeRange AcademicDegreeProgramParticipationDateRange { get; set; }

        /// <summary>
        /// EDU.5 - Academic Degree Granted Date.
        /// </summary>
        public DateTime? AcademicDegreeGrantedDate { get; set; }

        /// <summary>
        /// EDU.6 - School.
        /// </summary>
        public ExtendedCompositeNameAndIdNumberForOrganizations School { get; set; }

        /// <summary>
        /// EDU.7 - School Type Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0402</remarks>
        public CodedElement SchoolTypeCode { get; set; }

        /// <summary>
        /// EDU.8 - School Address.
        /// </summary>
        public ExtendedAddress SchoolAddress { get; set; }

        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                "{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}",
                                Id,
                                SetIdEdu.HasValue ? SetIdEdu.Value.ToString(culture) : null,
                                AcademicDegree,
                                AcademicDegreeProgramDateRange?.ToDelimitedString(),
                                AcademicDegreeProgramParticipationDateRange?.ToDelimitedString(),
                                AcademicDegreeGrantedDate.HasValue ? AcademicDegreeGrantedDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                School?.ToDelimitedString(),
                                SchoolTypeCode?.ToDelimitedString(),
                                SchoolAddress?.ToDelimitedString()
                                ).TrimEnd('|');
        }
    }
}