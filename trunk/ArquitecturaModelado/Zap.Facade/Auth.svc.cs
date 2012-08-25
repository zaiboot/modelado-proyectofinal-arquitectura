using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ZAP.Model;

namespace Zap.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Auth" in code, svc and config file together.
    public class Auth : IAuth
    {
        #region IAuth Members

        public OperationResult<AuthenticateResult> Authenticate(AuthInformationModel logonInfo)
        {
            BLL.Auth authBll = new BLL.Auth();
            if (logonInfo == null)
                  throw new ArgumentNullException("logonInfo cannot be null");
            
            OperationResult<AuthenticateResult> operatioResult;
            operatioResult = authBll.Authenticate(logonInfo);
            return operatioResult;
        }

        #endregion
    }
}
