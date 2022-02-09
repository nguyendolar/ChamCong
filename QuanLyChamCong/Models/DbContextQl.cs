using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;

namespace QuanLyChamCong.Models
{
    public class DbContextQl : DbContext
    {
        public DbContextQl() : base("DBConnectionString")
        {

        }

        public DbSet<User> users { get; set; }

        public DbSet<Role> roles { get; set; }

        public DbSet<Review> reviews { get; set; }

        public DbSet<CheckIn> checkIns { get; set; }

        public DbSet<Salary> salarys { get; set; }

        public DbSet<SupplementalLeave> supplementalLeaves { get; set;}

        public DbSet<Type> types { get; set; }  

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.PropertyName + ": " + x.ErrorMessage));
                throw new DbEntityValidationException(errorMessages);
            }
        }
    }
}