namespace ClearHl7.Fhir.Codes.V271
{
    /// <summary>
    /// HL7 Version 2 Table 0465 - Name/Address Representation.
    /// </summary>
    /// <remarks>https://www.hl7.org/fhir/v2/0465</remarks>
    public enum NameAddressRepresentation
    {
        /// <summary>
        /// A - Alphabetic (i.e., Default or some single-byte).
        /// </summary>
        Alphabetic,
        
        /// <summary>
        /// I - Ideographic (i.e., Kanji).
        /// </summary>
        Ideographic,
        
        /// <summary>
        /// P - Phonetic (i.e., ASCII, Katakana, Hiragana, etc.).
        /// </summary>
        Phonetic
    }
}