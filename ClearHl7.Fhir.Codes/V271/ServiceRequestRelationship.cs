namespace ClearHl7.Fhir.Codes.V271
{
    /// <summary>
    /// HL7 Version 2 Table 0506 - Service Request Relationship.
    /// </summary>
    /// <remarks>https://www.hl7.org/fhir/v2/0506</remarks>
    public enum ServiceRequestRelationship
    {
        /// <summary>
        /// C - Compound.
        /// </summary>
        Compound,
        
        /// <summary>
        /// E - Exclusive.
        /// </summary>
        Exclusive,
        
        /// <summary>
        /// N - Nurse prerogative.
        /// </summary>
        NursePrerogative,
        
        /// <summary>
        /// S - Simultaneous.
        /// </summary>
        Simultaneous,
        
        /// <summary>
        /// T - Tapering.
        /// </summary>
        Tapering
    }
}