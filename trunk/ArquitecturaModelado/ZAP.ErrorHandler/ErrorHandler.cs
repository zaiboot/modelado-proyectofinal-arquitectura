using System;
using ZAP.Model;
using System.Configuration;
using System.Text;
using System.IO;
using System.Security;

namespace ZAP.ErrorHandler
{
    /// <summary>
    /// Class that handles an error on the application
    /// </summary>
    public class ErrorHandler
    {
        /// <summary>
        /// File path for the error file path.
        /// </summary>
        private string errorFilePath;

        public ErrorHandler()
        {
            errorFilePath = ConfigurationManager.AppSettings["ErrorLogPath"] ?? @"C:\Temp\error.txt";

            if (errorFilePath.Length > 508)
            {
                throw new System.ApplicationException("The specified file " + errorFilePath + " is not valid. Please review the name");
            }
            if (!System.IO.File.Exists(errorFilePath))
            {
                try
                {
                    System.IO.File.Create(errorFilePath).Close();
                }
                catch (UnauthorizedAccessException ex)
                {
                    throw new System.ApplicationException("Cannot access" + errorFilePath + ". Please review permissions", ex);
                }
                catch (NotSupportedException ex)
                {
                    throw new System.ApplicationException("Unexpeceted error by creating the file: " + errorFilePath, ex);
                }
                catch (DirectoryNotFoundException ex)
                {
                    throw new System.ApplicationException("The specified directory, for the file: " + errorFilePath + " is not valid.", ex);
                }
                catch (IOException ex)
                {
                    throw new System.ApplicationException("Unexpeceted error by creating the file: " + errorFilePath, ex);
                }


            }
        }

        /// <summary>
        /// Logs the error for an application
        /// </summary>
        /// <param name="exceptionToHandle"></param>
        public OperationResult<T> HandleError<T>(Exception exceptionToHandle) where T : BaseModel
        {
            OperationResult<T> errorResult = new OperationResult<T>
            {
                IsSuccesed = false,
                Data = null,
                Id = Guid.NewGuid()
            };

            //TODO: React according to the error.
            errorResult.ErrorMessage = "We just discovered an error. Don't panic we are working on it right now, please give us some time to fix it.";
            //TODO: Log the error.
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendFormat("{0} - {1} - \n{2} ", errorResult.Id, DateTime.Now, exceptionToHandle.ToString());
            //TODO: Email the error. Esteban will do this.
            StreamWriter writerLogger = null;

            try
            {
                writerLogger = new StreamWriter(errorFilePath);

            }
            catch (SecurityException ex)
            {

                throw new System.ApplicationException("Cannot access" + errorFilePath + ". Please review permissions", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new System.ApplicationException("Cannot access" + errorFilePath + ". Please review permissions", ex);
            }
            catch (NotSupportedException ex)
            {
                throw new System.ApplicationException("Unexpeceted error by creating the file: " + errorFilePath, ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new System.ApplicationException("The specified directory, for the file: " + errorFilePath + " is not valid.", ex);
            }
            catch (IOException ex)
            {
                throw new System.ApplicationException("Unexpeceted error by creating the file: " + errorFilePath, ex);
            }

            try
            {
                writerLogger.WriteLine(strBuilder.ToString());
            }
            catch (IOException ex)
            {
                throw new System.ApplicationException("Unexpeceted error by creating the file: " + errorFilePath, ex);
            }

            catch (ObjectDisposedException ex)
            {
                throw new System.ApplicationException("Unexpeceted error by creating the file: " + errorFilePath, ex);
            }
            writerLogger.Flush();
            writerLogger.Close();

            return errorResult;
        }
    }
}
