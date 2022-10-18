using System.Text.Json.Serialization;

namespace Practica_CRUD.Class
{
    public class User
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string FLastName { get; set; }
        public string SName { get; set; }
        public string SLastName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string ID_CARD { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public ICollection<RolUser> RolUser { get; set; }
    }
}
