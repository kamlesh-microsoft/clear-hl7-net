using System;
using System.Collections.Generic;
using System.Linq;
using ClearHl7.Fhir.V282.Types;

namespace ClearHl7.Fhir.V282.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment PRB - Problem Details.
    /// </summary>
    public class PrbSegment : ISegment
    {
        /// <summary>
        /// Gets the ID for the Segment.  This property is read-only.
        /// </summary>
        public string Id { get; } = "PRB";
        
        /// <summary>
        /// Gets or sets the rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.
        /// </summary>
        public int Ordinal { get; set; }

        /// <summary>
        /// PRB.1 - Action Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0206</remarks>
        public string ActionCode { get; set; }

        /// <summary>
        /// PRB.2 - Action Date/Time.
        /// </summary>
        public DateTime? ActionDateTime { get; set; }

        /// <summary>
        /// PRB.3 - Problem ID.
        /// </summary>
        public CodedWithExceptions ProblemId { get; set; }

        /// <summary>
        /// PRB.4 - Problem Instance ID.
        /// </summary>
        public EntityIdentifier ProblemInstanceId { get; set; }

        /// <summary>
        /// PRB.5 - Episode of Care ID.
        /// </summary>
        public EntityIdentifier EpisodeOfCareId { get; set; }

        /// <summary>
        /// PRB.6 - Problem List Priority.
        /// </summary>
        public decimal? ProblemListPriority { get; set; }

        /// <summary>
        /// PRB.7 - Problem Established Date/Time.
        /// </summary>
        public DateTime? ProblemEstablishedDateTime { get; set; }

        /// <summary>
        /// PRB.8 - Anticipated Problem Resolution Date/Time.
        /// </summary>
        public DateTime? AnticipatedProblemResolutionDateTime { get; set; }

        /// <summary>
        /// PRB.9 - Actual Problem Resolution Date/Time.
        /// </summary>
        public DateTime? ActualProblemResolutionDateTime { get; set; }

        /// <summary>
        /// PRB.10 - Problem Classification.
        /// </summary>
        public CodedWithExceptions ProblemClassification { get; set; }

        /// <summary>
        /// PRB.11 - Problem Management Discipline.
        /// </summary>
        public IEnumerable<CodedWithExceptions> ProblemManagementDiscipline { get; set; }

        /// <summary>
        /// PRB.12 - Problem Persistence.
        /// </summary>
        public CodedWithExceptions ProblemPersistence { get; set; }

        /// <summary>
        /// PRB.13 - Problem Confirmation Status.
        /// </summary>
        public CodedWithExceptions ProblemConfirmationStatus { get; set; }

        /// <summary>
        /// PRB.14 - Problem Life Cycle Status.
        /// </summary>
        public CodedWithExceptions ProblemLifeCycleStatus { get; set; }

        /// <summary>
        /// PRB.15 - Problem Life Cycle Status Date/Time.
        /// </summary>
        public DateTime? ProblemLifeCycleStatusDateTime { get; set; }

        /// <summary>
        /// PRB.16 - Problem Date of Onset.
        /// </summary>
        public DateTime? ProblemDateOfOnset { get; set; }

        /// <summary>
        /// PRB.17 - Problem Onset Text.
        /// </summary>
        public string ProblemOnsetText { get; set; }

        /// <summary>
        /// PRB.18 - Problem Ranking.
        /// </summary>
        public CodedWithExceptions ProblemRanking { get; set; }

        /// <summary>
        /// PRB.19 - Certainty of Problem.
        /// </summary>
        public CodedWithExceptions CertaintyOfProblem { get; set; }

        /// <summary>
        /// PRB.20 - Probability of Problem (0-1).
        /// </summary>
        public decimal? ProbabilityOfProblem01 { get; set; }

        /// <summary>
        /// PRB.21 - Individual Awareness of Problem.
        /// </summary>
        public CodedWithExceptions IndividualAwarenessOfProblem { get; set; }

        /// <summary>
        /// PRB.22 - Problem Prognosis.
        /// </summary>
        public CodedWithExceptions ProblemPrognosis { get; set; }

        /// <summary>
        /// PRB.23 - Individual Awareness of Prognosis.
        /// </summary>
        public CodedWithExceptions IndividualAwarenessOfPrognosis { get; set; }

        /// <summary>
        /// PRB.24 - Family/Significant Other Awareness of Problem/Prognosis.
        /// </summary>
        public string FamilySignificantOtherAwarenessOfProblemPrognosis { get; set; }

        /// <summary>
        /// PRB.25 - Security/Sensitivity.
        /// </summary>
        public CodedWithExceptions SecuritySensitivity { get; set; }

        /// <summary>
        /// PRB.26 - Problem Severity.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0836</remarks>
        public CodedWithExceptions ProblemSeverity { get; set; }

        /// <summary>
        /// PRB.27 - Problem Perspective.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0838</remarks>
        public CodedWithExceptions ProblemPerspective { get; set; }

        /// <summary>
        /// PRB.28 - Mood Code.
        /// </summary>
        /// <remarks>https://www.hl7.org/fhir/v2/0725</remarks>
        public CodedWithNoExceptions MoodCode { get; set; }
        
        /// <summary>
        /// Returns a delimited string representation of this instance.
        /// </summary>
        /// <returns>A string.</returns>
        public string ToDelimitedString()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                "{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}",
                                Id,
                                ActionCode,
                                ActionDateTime.HasValue ? ActionDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ProblemId?.ToDelimitedString(),
                                ProblemInstanceId?.ToDelimitedString(),
                                EpisodeOfCareId?.ToDelimitedString(),
                                ProblemListPriority.HasValue ? ProblemListPriority.Value.ToString(Consts.NumericFormat, culture) : null,
                                ProblemEstablishedDateTime.HasValue ? ProblemEstablishedDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                AnticipatedProblemResolutionDateTime.HasValue ? AnticipatedProblemResolutionDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ActualProblemResolutionDateTime.HasValue ? ActualProblemResolutionDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ProblemClassification?.ToDelimitedString(),
                                ProblemManagementDiscipline != null ? string.Join("~", ProblemManagementDiscipline.Select(x => x.ToDelimitedString())) : null,
                                ProblemPersistence?.ToDelimitedString(),
                                ProblemConfirmationStatus?.ToDelimitedString(),
                                ProblemLifeCycleStatus?.ToDelimitedString(),
                                ProblemLifeCycleStatusDateTime.HasValue ? ProblemLifeCycleStatusDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ProblemDateOfOnset.HasValue ? ProblemDateOfOnset.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ProblemOnsetText,
                                ProblemRanking?.ToDelimitedString(),
                                CertaintyOfProblem?.ToDelimitedString(),
                                ProbabilityOfProblem01.HasValue ? ProbabilityOfProblem01.Value.ToString(Consts.NumericFormat, culture) : null,
                                IndividualAwarenessOfProblem?.ToDelimitedString(),
                                ProblemPrognosis?.ToDelimitedString(),
                                IndividualAwarenessOfPrognosis?.ToDelimitedString(),
                                FamilySignificantOtherAwarenessOfProblemPrognosis,
                                SecuritySensitivity?.ToDelimitedString(),
                                ProblemSeverity?.ToDelimitedString(),
                                ProblemPerspective?.ToDelimitedString(),
                                MoodCode?.ToDelimitedString()
                                ).TrimEnd('|');
        }
    }
}