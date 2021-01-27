using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebNothing.Data.Extensions;
using WebNothing.Data.Mappings;
using WebNothing.Domain.Entities;

namespace WebNothing.Data.Context
{
    public class WebNothingContext : DbContext
    {
        public WebNothingContext(DbContextOptions<WebNothingContext> option) : base (option)
        {

        }

        #region DBSets
        public DbSet<User> Users { get; set; } 
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }
    }
}
