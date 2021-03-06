﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebNothing.Data.Validators.ErrorMessage
{
    public class ErrorMessage
    {
        public List<ErrorMessage> Errors { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }

        public ErrorMessage()
        {

        }
        public ErrorMessage(string name, string message)
        {
            Name = name;
            Message = message;
        }
    }
}
