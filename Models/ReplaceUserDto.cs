namespace MY_API.Models
{
    public class ReplaceUserDto
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public required long Phone_no { get; set; }
    }
}
