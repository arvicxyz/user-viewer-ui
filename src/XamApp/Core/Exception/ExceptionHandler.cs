using System;
using System.Diagnostics;

namespace XamApp.Core
{
    public static class ExceptionHandler
    {
        /// <summary>
        /// Catch unhandled exceptions. You can use -Visual Studio App Center- service to send your errors.
        /// https://appcenter.ms/
        /// </summary>
        /// <param name="exception"></param>
        public static void LogException(Exception exception)
        {
            try
            {
                if (exception == null)
                {
                    return;
                }
                var exceptionMessage = exception.ToString();
                Debug.WriteLine(exceptionMessage, "* Unhandled Exception *");
                // Send errors here
            }
            catch
            {
                // Just suppress any error logging exceptions
            }
        }
    }
}
