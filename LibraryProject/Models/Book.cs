using SQLite;

namespace LibraryProject.Models
{
    [Table("Books")]
    public class Book
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public int BranchID { get; set; }
        [Unique]
        public string ISBN { get; set; }

    }
}
