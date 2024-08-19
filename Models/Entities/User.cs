namespace MY_API.Models.Entities
{
    public class User
    {
        public  int ID { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public required long Phone_no { get; set; }
    }
}
