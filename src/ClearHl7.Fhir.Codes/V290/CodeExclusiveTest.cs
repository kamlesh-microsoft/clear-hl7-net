﻿namespace ClearHl7.Fhir.Codes.V290
{
    /// <summary>
    /// HL7 Version 2 Table 0919 - Exclusive Test.
    /// </summary>
    /// <remarks>https://www.hl7.org/fhir/v2/0919</remarks>
    public enum CodeExclusiveTest
    {
        /// <summary>
        /// D - In some cases, this test should be only exclusively with like tests (examples are cyto or pathology).
        /// </summary>
        TestShouldBeOnlyExclusivelyWithLikeTests,
        
        /// <summary>
        /// N - This test can be included with any number of other tests.
        /// </summary>
        TestCanBeIncludedWithAnyOtherTests,
        
        /// <summary>
        /// Y - This test should be exclusive.
        /// </summary>
        TestShouldBeExclusive
    }
}