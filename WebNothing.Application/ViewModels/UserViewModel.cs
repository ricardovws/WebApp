using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebNothing.Application.ViewModels
{
    public class UserViewModel : EntityViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string Password { get; set; }

    }
}
