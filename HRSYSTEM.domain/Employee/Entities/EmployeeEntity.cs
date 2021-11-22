namespace HRSYSTEM.domain
{
    /// <summary>
    /// This is the main employee entity
    /// </summary>
    public class EmployeeEntity
    {
        /// <summary>
        /// Employee's primary key
        /// </summary>
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
