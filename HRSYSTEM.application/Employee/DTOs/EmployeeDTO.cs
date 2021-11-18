namespace HRSYSTEM.application
{
    /// <summary>
    /// This is the DTO for one employee
    /// </summary>
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }

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
        /// Employee's age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Employee's status Ex. 2 = Active, 1 = Inactive
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// When the record was created
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// When the record was updated
        /// </summary>
        public DateTime UpdatedOn { get; set; }

    }
}
