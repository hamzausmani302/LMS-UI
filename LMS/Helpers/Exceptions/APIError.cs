using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Globalization;
using System.Net;

namespace LMS.Helpers.Exceptions
{
  
    public class APIError : Exception
    {
        public APIError(string message) : base(message)
        {


        }

        public APIError(string message, params object[] args)
           : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
