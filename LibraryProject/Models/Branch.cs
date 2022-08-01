using SQLite;

namespace LibraryProject.Models
{
    [Table("branches")]
    public class Branch
    {
        [PrimaryKey, AutoIncrement,Unique]
        public int ID { get; set; }
        [Unique]
        public string BranchName { get; set; }
        public byte[] ImageData { get; set; } = null;
    }
}
