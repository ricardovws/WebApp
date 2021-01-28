using System;
using System.Collections.Generic;
using System.Text;

namespace WebNothing.Domain.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
