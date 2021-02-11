using System;
using System.Collections.Generic;
using System.Text;
using WebNothing.Domain.Models;

namespace WebNothing.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
