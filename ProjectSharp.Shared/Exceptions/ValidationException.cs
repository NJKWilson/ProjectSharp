using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjectSharp.WebUi.ProjectSharp.Shared.Exceptions
{
    public class ValidationException : Exception
    {
        public Dictionary<string, List<string>> ErrorList = new();

        public ValidationException(Dictionary<string, List<string>> errorList) : base()
        {
            ErrorList = errorList;
        }

        public ValidationException(string message) : base(message) { }

        public ValidationException(string message, params object[] args) 
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}