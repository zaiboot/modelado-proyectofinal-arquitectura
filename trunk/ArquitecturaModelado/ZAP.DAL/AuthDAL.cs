using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZAP.Model;
using System.Data.SQLite;
using System.Data;
using System.Data.Common;

namespace ZAP.DAL
{
    public class AuthDAL : BaseDAL
    {
        private DbCommand sql_cmd;
        

        public OperationResult<AuthenticateResult> AuthUser(AuthInformationModel logonInfo)
        {
            OperationResult<AuthenticateResult> operatioResult = new OperationResult<AuthenticateResult>
            {
                IsSuccesed = true,
                Data = new AuthenticateResult()

            };

            string sqlQuery = "SELECT 1 FROM Users WHERE userName = @userName AND password = @password";
            try
            {
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = sqlQuery;
                var p = sql_cmd.CreateParameter();
                p.DbType = DbType.String;
                p.Value = logonInfo.Password;
                p.ParameterName = "password";
                sql_cmd.Parameters.Add(p);

                 p = sql_cmd.CreateParameter();
                p.DbType = DbType.String;
                p.Value = logonInfo.UserName;
                p.ParameterName = "userName";
                sql_cmd.Parameters.Add(p);
                DbDataReader rdr = sql_cmd.ExecuteReader();

                if (rdr.Read())
                {
                    operatioResult.Data.IsLoginFine = true;
                }
                else
                {
                    operatioResult.Data.IsLoginFine = false;
                }

                sql_con.Close();
            }
            //TODO: FINISH THIS
            catch (DbException)
            {
                operatioResult.IsSuccesed = false;
                //TODO: Call the error component.
                operatioResult.ErrorMessage = "Errorsito se  despicho la madre";
                operatioResult.Data = null;

            }
            return operatioResult;
        }
    }
}
