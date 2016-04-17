using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebPetApplication.Models
{
    public class WebPetApplicationContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebPetApplicationContext() : base("name=WebPetApplicationContext")
        {
            // New code:
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<WebPetApplication.Models.Pet> Pets { get; set; }

        public System.Data.Entity.DbSet<WebPetApplication.Models.PetOwner> PetOwners { get; set; }

        public System.Data.Entity.DbSet<WebPetApplication.Models.PetWalker> PetWalkers { get; set; }

        public System.Data.Entity.DbSet<WebPetApplication.Models.PetOwnerPetWalker> PetOwnerPetWalkers { get; set; }
    
    }
}
