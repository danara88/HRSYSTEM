namespace HRSYSTEM.application
{
    public class JobCatalogDTO
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
    }
}
