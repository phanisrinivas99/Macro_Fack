using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
    }
}
