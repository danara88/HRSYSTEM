namespace HRSYSTEM.domain
{
    /// <summary>
    /// This is the main Role Entity
    /// </summary>
    public class RoleEntity
    {
        /// <summary>
        /// Main primary key
        /// </summary>
        public int RoleID { get; set; }

        /// <summary>
        /// This is the name of the role
        /// </summary>
        public string Name { get; set; }

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
