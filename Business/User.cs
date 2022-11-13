namespace OVAPI.Business
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Currency { get; set; }
        public bool Admin { get; set; }
        public bool Active { get; set; }
    }
}
