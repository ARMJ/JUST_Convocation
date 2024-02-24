using Convocation.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Convocation.DAL
{
    public class ConvocationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ConvocationDBContext() : base("ConvocationDBContext")
        {

        }

        public static ConvocationDBContext Create()
        {
            return new ConvocationDBContext();
        }

        public System.Data.Entity.DbSet<Convocation.Models.ApplicationUser> ApplicationUsers { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}