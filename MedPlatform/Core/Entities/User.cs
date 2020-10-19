using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
