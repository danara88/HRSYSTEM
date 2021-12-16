namespace HRSYSTEM.domain
{
    /// <summary>
    /// This is the main JobCatalog Entity
    /// </summary>
    public class JobCatalogEntity
    {
        /// <summary>
        /// JobCatalog primary key
        /// </summary>
        public int JobCatalogID { get; set; }

        /// <summary>
        /// Job title
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Job main function
        /// </summary>
        public string JobFunction { get; set; }

        /// <summary>
        /// Job sub function
        /// </summary>
        public string JobSubFunction { get; set; }
        /// <summary>
        /// When the record was created
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        // <summary>
        /// When the record was updated
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
