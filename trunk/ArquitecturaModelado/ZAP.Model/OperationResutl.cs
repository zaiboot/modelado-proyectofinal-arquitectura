using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZAP.Model
{
    /// <summary>
    /// To set a standart for all the layers for handling errors.
    /// </summary>
    public class OperationResult<T> where  T : BaseModel 
    {
        /// <summary>
        /// Define if the request was successfull.
        /// </summary>
        public bool IsSuccesed;
        public string ErrorMessage;
        public T Data { get; set; }
 
    }
}
