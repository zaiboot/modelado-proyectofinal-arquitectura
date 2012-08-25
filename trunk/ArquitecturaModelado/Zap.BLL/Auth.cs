using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZAP.Model;
using ZAP.DAL;

namespace Zap.BLL
{
    public class Auth : BaseBLL
    {
        public OperationResult<AuthenticateResult> Authenticate(AuthInformationModel logonInfo)
        {

            OperationResult<AuthenticateResult> operatioResult;

            AuthDAL dalAuth = new AuthDAL();
            operatioResult = dalAuth.AuthUser(logonInfo);
            if (operatioResult.Data.IsLoginFine)
            {
                
                if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                {
                    //No one can access the system on sundays
                    operatioResult.Data.IsLoginFine = false;
                }
            }
            return operatioResult;

        }

    }
}
