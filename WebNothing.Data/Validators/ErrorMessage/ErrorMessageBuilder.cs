using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using WebNothing.Domain.Entities;

namespace WebNothing.Data.Validators.ErrorMessage
{
    public class ErrorMessageBuilder
    {
        public List<ErrorMessage> ErrorMessage { get; set; }
        public UserValidator Validator { get; set; }
        public ValidationResult Results { get; set; }

        public ErrorMessageBuilder()
        {
            ErrorMessage = new List<ErrorMessage>();
            Validator = new UserValidator();
            Results = null;
        }

        public List<ErrorMessage> IsItOk(User user, string confirmPassword, bool ignorePasswordUpdate = false)
        {
            Results = Validator.Validate(user);

            if (Results.IsValid == false)
            {
                foreach (ValidationFailure failure in Results.Errors)
                {
                    if (!(ignorePasswordUpdate && failure.PropertyName == "Password"))
                    {
                        //ErrorMessage.Add($"{failure.ErrorMessage}");
                        ErrorMessage.Add(new ErrorMessage(failure.PropertyName, failure.ErrorMessage));
                    }
                }
            }

            if (user.Password != confirmPassword)
                ErrorMessage.Add(new ErrorMessage("ConfirmPassword", "Both passwords must match!"));

            return ErrorMessage;
        }
    }
}
