namespace HRSYSTEM.domain
{
    /// <summary>
    /// User's main entity
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// Main primary key
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// The user's first name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The user's surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// The user's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The user's username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The user's role reference
        /// </summary>
        public int RoleID { get; set; }

        /// <summary>
        /// The user's password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The user's status (enbaled/disabled)
        /// </summary>
        public bool Status { get; set; }

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
