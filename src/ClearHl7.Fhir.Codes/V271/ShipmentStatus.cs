namespace ClearHl7.Fhir.Codes.V271
{
    /// <summary>
    /// HL7 Version 2 Table 0905 - Shipment Status.
    /// </summary>
    /// <remarks>https://www.hl7.org/fhir/v2/0905</remarks>
    public enum ShipmentStatus
    {
        /// <summary>
        /// INV - Inventoried.
        /// </summary>
        Inventoried,
        
        /// <summary>
        /// ONH - On Hold.
        /// </summary>
        OnHold,
        
        /// <summary>
        /// PRC - Processing.
        /// </summary>
        Processing,
        
        /// <summary>
        /// REJ - Rejected.
        /// </summary>
        Rejected,
        
        /// <summary>
        /// TRN - In Transit.
        /// </summary>
        InTransit,
        
        /// <summary>
        /// TTL - Triaged to Lab.
        /// </summary>
        TriagedToLab
    }
}