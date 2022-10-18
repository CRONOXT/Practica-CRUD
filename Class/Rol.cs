using System.Text.Json.Serialization;

namespace Practica_CRUD.Class
{
    public class Rol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<RolUser> RolUser { get; set; }

    }
}
