using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace ZAP.DAL
{
    public abstract class BaseDAL
    {
        protected SQLiteConnection sql_con = new SQLiteConnection();
        public BaseDAL()
        {

            sql_con.ConnectionString = @"Data Source=c:\database\ArqDemo.SQLite;Version=3;Compress=True;";
//            string sqlQuery = "CREATE TABLE IF NOT EXISTS [Users](" +
//"[ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
//"[UserName] NVARCHAR(100) NULL," +
//"[Password] NVARCHAR(100) NULL" +
//");" +
//"   INSERT INTO [Users] ( [UserName], [Password]) VALUES ('Esteban', '123');";
//            sql_con.Open();
//            var sql_cmd = sql_con.CreateCommand();
//            sql_cmd.CommandText = sqlQuery;
//            sql_cmd.ExecuteNonQuery();
//            sql_con.Close();
        }
    }
}
