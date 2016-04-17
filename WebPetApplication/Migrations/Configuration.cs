using System.Net.Mail;

namespace WebPetApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebPetApplication.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebPetApplication.Models.WebPetApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebPetApplication.Models.WebPetApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.PetOwners.AddOrUpdate(x => x.Id,
                new PetOwner() { Id = 1, FirstName = "George", LastName = "Harper", Email = "g.harp@Petlover.com" },
                new PetOwner() { Id = 2, FirstName = "Thomas", LastName = "Cisse", Email = "t.cis@Petlover.com" },
                new PetOwner() { Id = 3, FirstName = "Evripidis", LastName = "Griezman", Email = "e.gri@Petlover.com" }
                );
            
            context.Pets.AddOrUpdate(x => x.Id,
                new Pet() { Id = 1, Name = "Charlie", DateOfBirth = new DateTime(2010,01,10),PetOwnerId  = 1},
                new Pet() { Id = 2, Name = "Djibril", DateOfBirth = new DateTime(2012, 02, 02),PetOwnerId = 2},
                new Pet() { Id = 3, Name = "Spitha", DateOfBirth = new DateTime(2005, 08, 09),PetOwnerId = 3}
                );

            context.PetWalkers.AddOrUpdate(x => x.Id,
               new PetWalker() { Id = 1, FirstName = "Panagiota", LastName = "Mountz", Email = "p.mou@Petlover.com", PhoneNumber = "698989898" },
               new PetWalker() { Id = 2, FirstName = "Olga", LastName = "Vas", Email = "o.vas@Petlover.com" , PhoneNumber = ""},
               new PetWalker() { Id = 3, FirstName = "Panagiotis", LastName = "Akrep", Email = "p.akr@Petlover.com" , PhoneNumber = "2121212121" }
               );

            context.PetOwnerPetWalkers.AddOrUpdate(x => x.Id,
             new PetOwnerPetWalker() { Id = 1, PetOwnerId = 1, PetWalkerId = 2 },
             new PetOwnerPetWalker() { Id = 2, PetOwnerId = 1, PetWalkerId = 1 },
             new PetOwnerPetWalker() { Id = 3, PetOwnerId = 2, PetWalkerId = 1 }
             );
            
        }
    }
}
