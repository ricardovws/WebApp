using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebNothing.Domain.Entities;

namespace WebNothing.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(
                    new User { Id = 1, Name = "User Default", Email = "user@user.com", DateCreated = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Hour), IsDeleted = false, DateUpdated = null }
                );

            return builder;
        }
    }
}
