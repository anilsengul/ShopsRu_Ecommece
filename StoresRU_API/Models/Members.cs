namespace StoresRU_API.Models
{
    public class Members
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool  isEmployee { get; set; }
        public bool isMember { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string Password { get; set; }
    }
}
