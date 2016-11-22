using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jogging.Model.Models;


namespace JoggingDB.DataLayer
{
    class JoggingContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().Property(t => t.Username).HasMaxLength(20);
            modelBuilder.Entity<Session>().HasKey(t => t.Id);
            modelBuilder.Entity<User>().HasKey(t => t.Id);
            modelBuilder.Entity<User>().Property(t => t.Password).IsRequired();

            base.OnModelCreating(modelBuilder);

        }
    }
}
