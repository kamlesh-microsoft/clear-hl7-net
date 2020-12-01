namespace ClearHl7.Fhir.Codes.V251
{
    /// <summary>
    /// HL7 Version 2 Table 0536 - Certificate Status.
    /// </summary>
    /// <remarks>https://www.hl7.org/fhir/v2/0536</remarks>
    public enum CertificateStatus
    {
        /// <summary>
        /// E - Expired.
        /// </summary>
        Expired,
        
        /// <summary>
        /// I - Inactive.
        /// </summary>
        Inactive,
        
        /// <summary>
        /// P - Provisional.
        /// </summary>
        Provisional,
        
        /// <summary>
        /// R - Revoked.
        /// </summary>
        Revoked,
        
        /// <summary>
        /// V - Active/Valid.
        /// </summary>
        ActiveValid
    }
}