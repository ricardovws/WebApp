﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using WebNothing.Domain.Entities;

namespace WebNothing.Data.Validators.ErrorMessage
{
    public class ErrorMessageBuilder
    {
        public ErrorMessage ErrorMessage { get; set; }
        public UserValidator Validator { get; set; }
        public ValidationResult Results { get; set; }

        public ErrorMessageBuilder()
        {
            ErrorMessage = new ErrorMessage();
            Validator = new UserValidator();
            Results = null;
        }

        public ErrorMessage IsItOk(User user, string confirmPassword)
        {
            if (user.Password != confirmPassword)
                ErrorMessage.Errors.Add("Both passwords must match!");

            Results = Validator.Validate(user);

            if (Results.IsValid == false)
            {
                foreach (ValidationFailure failure in Results.Errors)
                {
                    ErrorMessage.Errors.Insert(0, $"{failure.ErrorMessage}");
                }
            }

            return ErrorMessage;
        }
    }
}
