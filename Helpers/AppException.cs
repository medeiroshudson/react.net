using System;
using System.Globalization;

namespace react.net.Helpers
{
    public class AppException : Exception
    {
        // custom class for deal with custom exceptions (e.g validation issues)
        // that can be caught and handled within the application
        // thanks to Jason Watmore
        // https://jasonwatmore.com/post/2019/10/14/aspnet-core-3-simple-api-for-authentication-registration-and-user-management

        public AppException() : base() { }

        public AppException(string message) : base(message) { }

        public AppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args)) {}
    }
}