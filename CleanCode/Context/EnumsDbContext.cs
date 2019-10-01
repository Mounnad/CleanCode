using CleanCode.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class EnumsDbContext : DbContext
    {
        public EnumsDbContext() : base("name=EnumsDb")
        {
        }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>()
               .Property(s => s.Id)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<User>()
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
