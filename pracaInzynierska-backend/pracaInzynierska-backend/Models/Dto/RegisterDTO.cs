namespace pracaInzynierska_backend.Models.Dto
{
    public class RegisterDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
    }
}
