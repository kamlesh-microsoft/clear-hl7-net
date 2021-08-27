﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.V251.Types;

namespace ClearHl7.V251.Segments
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
        /// <para>Suggested: 0287 Problem/Goal Action Code -&gt; ClearHl7.Codes.V251.CodeProblemGoalActionCode</para>
        /// </summary>
        public string ActionCode { get; set; }

        /// <summary>
        /// PRB.2 - Action Date/Time.
        /// </summary>
        public DateTime? ActionDateTime { get; set; }

        /// <summary>
        /// PRB.3 - Problem ID.
        /// </summary>
        public CodedElement ProblemId { get; set; }

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
        public CodedElement ProblemClassification { get; set; }

        /// <summary>
        /// PRB.11 - Problem Management Discipline.
        /// </summary>
        public IEnumerable<CodedElement> ProblemManagementDiscipline { get; set; }

        /// <summary>
        /// PRB.12 - Problem Persistence.
        /// </summary>
        public CodedElement ProblemPersistence { get; set; }

        /// <summary>
        /// PRB.13 - Problem Confirmation Status.
        /// </summary>
        public CodedElement ProblemConfirmationStatus { get; set; }

        /// <summary>
        /// PRB.14 - Problem Life Cycle Status.
        /// </summary>
        public CodedElement ProblemLifeCycleStatus { get; set; }

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
        public CodedElement ProblemRanking { get; set; }

        /// <summary>
        /// PRB.19 - Certainty of Problem.
        /// </summary>
        public CodedElement CertaintyOfProblem { get; set; }

        /// <summary>
        /// PRB.20 - Probability of Problem (0-1).
        /// </summary>
        public decimal? ProbabilityOfProblem01 { get; set; }

        /// <summary>
        /// PRB.21 - Individual Awareness of Problem.
        /// </summary>
        public CodedElement IndividualAwarenessOfProblem { get; set; }

        /// <summary>
        /// PRB.22 - Problem Prognosis.
        /// </summary>
        public CodedElement ProblemPrognosis { get; set; }

        /// <summary>
        /// PRB.23 - Individual Awareness of Prognosis.
        /// </summary>
        public CodedElement IndividualAwarenessOfPrognosis { get; set; }

        /// <summary>
        /// PRB.24 - Family/Significant Other Awareness of Problem/Prognosis.
        /// </summary>
        public string FamilySignificantOtherAwarenessOfProblemPrognosis { get; set; }

        /// <summary>
        /// PRB.25 - Security/Sensitivity.
        /// </summary>
        public CodedElement SecuritySensitivity { get; set; }

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

            ActionCode = segments.Length > 1 && segments[1].Length > 0 ? segments[1] : null;
            ActionDateTime = segments.Length > 2 && segments[2].Length > 0 ? segments[2].ToNullableDateTime() : null;
            ProblemId = segments.Length > 3 && segments[3].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[3], false) : null;
            ProblemInstanceId = segments.Length > 4 && segments[4].Length > 0 ? TypeHelper.Deserialize<EntityIdentifier>(segments[4], false) : null;
            EpisodeOfCareId = segments.Length > 5 && segments[5].Length > 0 ? TypeHelper.Deserialize<EntityIdentifier>(segments[5], false) : null;
            ProblemListPriority = segments.Length > 6 && segments[6].Length > 0 ? segments[6].ToNullableDecimal() : null;
            ProblemEstablishedDateTime = segments.Length > 7 && segments[7].Length > 0 ? segments[7].ToNullableDateTime() : null;
            AnticipatedProblemResolutionDateTime = segments.Length > 8 && segments[8].Length > 0 ? segments[8].ToNullableDateTime() : null;
            ActualProblemResolutionDateTime = segments.Length > 9 && segments[9].Length > 0 ? segments[9].ToNullableDateTime() : null;
            ProblemClassification = segments.Length > 10 && segments[10].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[10], false) : null;
            ProblemManagementDiscipline = segments.Length > 11 && segments[11].Length > 0 ? segments[11].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeHelper.Deserialize<CodedElement>(x, false)) : null;
            ProblemPersistence = segments.Length > 12 && segments[12].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[12], false) : null;
            ProblemConfirmationStatus = segments.Length > 13 && segments[13].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[13], false) : null;
            ProblemLifeCycleStatus = segments.Length > 14 && segments[14].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[14], false) : null;
            ProblemLifeCycleStatusDateTime = segments.Length > 15 && segments[15].Length > 0 ? segments[15].ToNullableDateTime() : null;
            ProblemDateOfOnset = segments.Length > 16 && segments[16].Length > 0 ? segments[16].ToNullableDateTime() : null;
            ProblemOnsetText = segments.Length > 17 && segments[17].Length > 0 ? segments[17] : null;
            ProblemRanking = segments.Length > 18 && segments[18].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[18], false) : null;
            CertaintyOfProblem = segments.Length > 19 && segments[19].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[19], false) : null;
            ProbabilityOfProblem01 = segments.Length > 20 && segments[20].Length > 0 ? segments[20].ToNullableDecimal() : null;
            IndividualAwarenessOfProblem = segments.Length > 21 && segments[21].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[21], false) : null;
            ProblemPrognosis = segments.Length > 22 && segments[22].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[22], false) : null;
            IndividualAwarenessOfPrognosis = segments.Length > 23 && segments[23].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[23], false) : null;
            FamilySignificantOtherAwarenessOfProblemPrognosis = segments.Length > 24 && segments[24].Length > 0 ? segments[24] : null;
            SecuritySensitivity = segments.Length > 25 && segments[25].Length > 0 ? TypeHelper.Deserialize<CodedElement>(segments[25], false) : null;
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
                                StringHelper.StringFormatSequence(0, 26, Configuration.FieldSeparator),
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
                                ProblemManagementDiscipline != null ? string.Join(Configuration.FieldRepeatSeparator, ProblemManagementDiscipline.Select(x => x.ToDelimitedString())) : null,
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
                                SecuritySensitivity?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}