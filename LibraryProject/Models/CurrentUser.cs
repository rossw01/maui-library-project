using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Models
{
    [Table("currentUser")]
    public class CurrentUser
    {
        [PrimaryKey, Unique] // doesnt auto incrememnt, should replace previous user
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
