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
        public bool Authenticate(AuthInformationModel logonInfo)
        {
            bool returnValue = false;
            AuthDAL dalAuth = new AuthDAL();
            returnValue = dalAuth.AuthUser(logonInfo);
            //validate date and times
            
            return returnValue;

        }

    }
}
