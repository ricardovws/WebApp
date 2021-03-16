using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WebNothing.Domain.Entities;

namespace WebNothing.Data.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
        }
    }
}
