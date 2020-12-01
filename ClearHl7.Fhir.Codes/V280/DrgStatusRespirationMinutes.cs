namespace ClearHl7.Fhir.Codes.V280
{
    /// <summary>
    /// HL7 Version 2 Table 0757 - DRG Status Respiration Minutes.
    /// </summary>
    /// <remarks>https://www.hl7.org/fhir/v2/0757</remarks>
    public enum DrgStatusRespirationMinutes
    {
        /// <summary>
        /// 0 - Respiration minutes not used for grouping.
        /// </summary>
        RespirationMinutesNotUsedForGrouping,
        
        /// <summary>
        /// 1 - Listed respiration minutes used for grouping.
        /// </summary>
        ListedRespirationMinutesUsedForGrouping,
        
        /// <summary>
        /// 2 - OPS code value used for grouping.
        /// </summary>
        OpsCodeValueUsedForGrouping
    }
}