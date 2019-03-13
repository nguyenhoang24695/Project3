using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NgoProjectk3.DataContext
{
    public class NgoProjectk3Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public NgoProjectk3Context() : base("name=NgoProjectk3Context")
        {
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<NgoProjectk3Context>(null);
        //    base.OnModelCreating(modelBuilder);
        //}

        public System.Data.Entity.DbSet<NgoProjectk3.Models.Account> Accounts { get; set; }
        public System.Data.Entity.DbSet<NgoProjectk3.Models.Category> Categories { get; set; }
        public System.Data.Entity.DbSet<NgoProjectk3.Models.DonateProgram> DonatePrograms { get; set; }
        public System.Data.Entity.DbSet<NgoProjectk3.Models.Donation> Donations { get; set; }
        public System.Data.Entity.DbSet<NgoProjectk3.Models.Credential> Credentials { get; set; }
        public System.Data.Entity.DbSet<NgoProjectk3.Models.Interested> Interesteds { get; set; }
    }
}
