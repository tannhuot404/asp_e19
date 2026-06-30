namespace api_demo_e19.DTO
{
    public class UserResponseDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Token { get; set; } = string.Empty;
    }
}
