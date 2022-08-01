using SQLite;
using LibraryProject.Models;

namespace LibraryProject.Repository
{
    public class DataReader
    {
        string _dbPath;
        private SQLiteConnection conn;
        public DataReader(string dbPath)
        {
            _dbPath = dbPath;
        }
        private void Init()
        {
            if (conn != null) return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<User>();
            conn.CreateTable<Branch>();
            conn.CreateTable<CurrentUser>();
        }

        public void AddNewUser(string username, string password, bool isAdmin)      // Users table operation
        {
            Init(); // connects to db if not connected already
            conn.Insert(new User { Username = username, Password = password, IsAdmin = isAdmin });
        }

        public List<User> GetUsers()                                  // Users table operation
        {
            Init();
            return conn.Table<User>().ToList();
        }

         public void ClearDatabase()
        {
            Init();
            conn.DeleteAll<User>();
        } // TODO : Remove from finished project

        public void ReplaceCurrentUser(string username)
        {
            Init();
            conn.InsertOrReplace(new CurrentUser { Id = 1, Username = username });
        }// Workaround, couldn't find a good way of passing current user through pages

        public User GetCurrentUser()
        {
            Init();
            string username = conn.Table<CurrentUser>().ToList()[0].Username; 
            return conn.Query<User>("select * from users where Username = ?", username)[0];
        } // Workaround, couldn't find a good way of passing current user through pages

        public void AddNewBranch(string branchName, byte[] branchImageData)
        {
            Init();
            conn.Insert(new Branch { BranchName = branchName, ImageData = branchImageData});
        }

        public List<Branch> GetBranches()
        {
            Init();
            return conn.Table<Branch>().ToList();
        }

        public void DeleteBranch(int ID)
        {
            Init();
            conn.Delete<Branch>(ID);
        }
    }
}
