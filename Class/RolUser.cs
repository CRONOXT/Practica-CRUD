using System.Text.Json.Serialization;

namespace Practica_CRUD.Class
{
    public class RolUser
    {
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int RolId { get; set; }
        [JsonIgnore]
        public Rol Rol { get; set; }
    }
}
