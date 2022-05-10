using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Macro_Fack
{
    public static class Macro
    {
        public static List<History> GetHeaders()
        {
            var connectionString = "Data Source=LAPTOP-OD0O0KPE\\SQLEXPRESS;Initial Catalog=Profile;Integrated Security=true;" ;
            string query = "select * from LockUnlock";
            using (var db = new SqlConnection(connectionString))
                return db.Query<History>(query).AsList();
        }
        public static List<Details> GetDetails()
        {
            var connectionString = "Data Source=LAPTOP-OD0O0KPE\\SQLEXPRESS;Initial Catalog=Profile;Integrated Security=true;";
            string query = "select * from LockUnlockDetails";
            using (var db = new SqlConnection(connectionString))
                return db.Query<Details>(query).AsList();
        }
        public static List<Details> GetDetailsById(int id)
        {
            var connectionString = "Data Source=LAPTOP-OD0O0KPE\\SQLEXPRESS;Initial Catalog=Profile;Integrated Security=true;";
            string query = "select * from LockUnlockDetails where LockUnlock_Id=" + id;
            using (var db = new SqlConnection(connectionString))
                return db.Query<Details>(query).AsList();
        }
        public static string UpdateStatus(int id)
        {
            var details = GetDetailsById(id);
            foreach(var detail in details)
            {
                var columnvalue = detail.LockUnlock_Status == "Lock" ? "UnLock" : detail.LockUnlock_Status;
                var connectionString = "Data Source=LAPTOP-OD0O0KPE\\SQLEXPRESS;Initial Catalog=Profile;Integrated Security=true;";
                string query = "UPDATE LockUnlockDetails SET  LockUnlock_Status ='"+columnvalue+"' WHERE Id ="+detail.Id;
                using (var db = new SqlConnection(connectionString))
                    db.Query<int>(query).AsList();
               
            }
            return "Succes";
        }

        public static string UpdateStatus()
        {
            var details = GetDetails();
            foreach (var detail in details)
            {
                var columnvalue = detail.LockUnlock_Status == "Lock" ? "UnLock" : detail.LockUnlock_Status;
                var connectionString = "Data Source=LAPTOP-OD0O0KPE\\SQLEXPRESS;Initial Catalog=Profile;Integrated Security=true;";
                string query = "UPDATE LockUnlockDetails SET  LockUnlock_Status ='" + columnvalue + "' WHERE Id =" + detail.Id;
                using (var db = new SqlConnection(connectionString))
                    db.Query<int>(query).AsList();

            }
            return "Succes";
        }
        public static async Task<int> CreateHeader(string status, string userName)
        {
            int id = 0;
            var connectionString = "Data Source=LAPTOP-OD0O0KPE\\SQLEXPRESS;Initial Catalog=Profile;Integrated Security=true;";
            using (var db = new SqlConnection(connectionString))
            {
                string insertUserSql = @"INSERT INTO dbo.[LockUnlock](UserName, Lock_Unlock, CreateDate)
                        OUTPUT INSERTED.[Id]
                        VALUES(@Username, @Lock_Unlock, @CreateDate);";

                id =await db.QuerySingleAsync<int>(
                                                insertUserSql,
                                                new
                                                {
                                                    Username = userName,
                                                    Lock_Unlock = status,
                                                    CreateDate = DateTime.Now
                                                });
            }
            return id;
        }
        public static async Task<int> CreateDetails(string status, string ProfileName, string division, int headerId)
        {
            int id = 0;
            var connectionString = "Data Source=LAPTOP-OD0O0KPE\\SQLEXPRESS;Initial Catalog=Profile;Integrated Security=true;";
            using (var db = new SqlConnection(connectionString))
            {
                string insertUserSql = @"INSERT INTO dbo.[LockUnlockDetails](LockUnlock_Id, Division, ProfileName,LockUnlock_Status,CreateDate)
                        OUTPUT INSERTED.[Id]
                        VALUES(@LockUnlock_Id, @Division, @ProfileName,@LockUnlock_Status,@CreateDate);";

                 id =await db.QuerySingleAsync<int>(
                                                insertUserSql,
                                                new
                                                {
                                                    LockUnlock_Id = "lorem ipsum",
                                                    Division = "555-123",
                                                    ProfileName = "lorem ipsum",
                                                    LockUnlock_Status= status,
                                                    CreateDate=DateTime.Now
                                                });
            }
            return id;
        }
    }
}
