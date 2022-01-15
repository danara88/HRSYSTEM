namespace HRSYSTEM.application
{
    /// <summary>
    /// Response from the Login user
    /// </summary>
    public class AuthResponseDTO
    {
        public string AccessToken { get; set; }
        public UserDTO User { get; set; }
    }
}
