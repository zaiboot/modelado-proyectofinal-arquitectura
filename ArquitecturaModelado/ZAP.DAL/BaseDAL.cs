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
            sql_con.ConnectionString = "Data Source=DemoT.db;Version=3;New=False;Compress=True;";
        }
    }
}
