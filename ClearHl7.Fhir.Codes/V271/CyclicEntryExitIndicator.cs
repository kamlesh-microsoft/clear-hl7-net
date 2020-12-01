namespace ClearHl7.Fhir.Codes.V271
{
    /// <summary>
    /// HL7 Version 2 Table 0505 - Cyclic Entry/Exit Indicator.
    /// </summary>
    /// <remarks>https://www.hl7.org/fhir/v2/0505</remarks>
    public enum CyclicEntryExitIndicator
    {
        /// <summary>
        /// # - The last service request in a cyclic group..
        /// </summary>
        TheLastServiceRequestInCyclicGroup,
        
        /// <summary>
        /// * - The first service request in a cyclic group.
        /// </summary>
        TheFirstServiceRequestInCyclicGroup
    }
}