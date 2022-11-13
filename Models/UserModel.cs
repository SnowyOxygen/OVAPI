namespace OVAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Currency { get; set; }
        public bool Admin { get; set; }
        public bool Active { get; set; }
    }
}
