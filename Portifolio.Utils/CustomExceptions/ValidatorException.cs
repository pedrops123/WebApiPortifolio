using System;
using System.Collections.Generic;

namespace Portifolio.Utils.CustomExceptions
{
    public class ValidatorException : Exception
    {
        public ValidatorException()
        { }

        private static string message { get; set; }

        public ValidatorException(List<string> errors):base()
        {
            errors.ForEach(r => message += message + String.Format("{0}", r));
        }

        public override string Message => message;

        public override string StackTrace => null;

    }
}
