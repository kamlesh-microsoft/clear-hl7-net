namespace ClearHl7.Fhir.Codes.V220
{
    /// <summary>
    /// HL7 Version 2 Table 0127 - Allergen Type.
    /// </summary>
    /// <remarks>https://www.hl7.org/fhir/v2/0127</remarks>
    public enum AllergenType
    {
        /// <summary>
        /// DA - Drug allergy.
        /// </summary>
        DrugAllergy,
        
        /// <summary>
        /// FA - Food allergy.
        /// </summary>
        FoodAllergy,
        
        /// <summary>
        /// MA - Miscellaneous allergy.
        /// </summary>
        MiscellaneousAllergy,
        
        /// <summary>
        /// MC - Miscellaneous contraindication.
        /// </summary>
        MiscellaneousContraindication
    }
}