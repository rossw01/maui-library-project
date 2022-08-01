using SQLite;

namespace LibraryProject.Models
{
    [Table("users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        [Unique]
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}