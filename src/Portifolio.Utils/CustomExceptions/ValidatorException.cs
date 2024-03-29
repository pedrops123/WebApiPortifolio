﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Portifolio.Utils.CustomExceptions
{
    public class ValidatorException : Exception
    {
        private string _messageFromList { get; set; }

        public override string Message
        {
            get
            {
                return _messageFromList;
            }
        }

        public override string StackTrace
        {
            get
            {
                return Assembly.GetExecutingAssembly().Location;
            }
        }

        public ValidatorException()
        { }

        public ValidatorException(List<FluentValidation.Results.ValidationFailure> ListMessage)
        {
            ListMessage.ForEach(r => _messageFromList += String.Format("* {0}. <br/>", r.ErrorMessage));
        }

        public ValidatorException(string message, Exception exception) : base(message, exception)
        { }

        public ValidatorException(string message) : base(message)
        { }

    }
}
