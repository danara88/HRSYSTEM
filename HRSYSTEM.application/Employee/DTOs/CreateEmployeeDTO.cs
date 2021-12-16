using HRSYSTEM.domain;

namespace HRSYSTEM.application
{
    /// <summary>
    /// This is the DTO for Employee Entity to create a new one
    /// </summary>
    public class CreateEmployeeDTO
    {
        /// <summary>
        /// Employee's firstname
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Employee's lastname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Employee's middlename
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Employee's job
        /// </summary>
        public int JobCatalogID { get; set; }

        // <summary>
        /// Employee's work email
        /// </summary>
        public string WorkEmail { get; set; }

        /// <summary>
        /// Employee's telephone
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Employee's status Ex. 2 = Active, 1 = Inactive
        /// </summary>
        public StatusEmployeeEnum Status { get; set; }
    }
}
