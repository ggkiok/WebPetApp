using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebPetApplication.Models;

namespace WebPetApplication.Repository
{
    public class PetsRepository
    {
        private WebPetApplicationContext db = new WebPetApplicationContext();
        public List<Pet> GetPetsByPetOwnerId(int petownerId)
        {
            var query = from pets in db.Pets
                        where pets.PetOwnerId.Equals(petownerId)
                        select pets;
            return query.ToList();
        }

        public List<Pet> GetPetsUnderAThisAge(int iage)
        {
            var query = from pets in db.Pets
                        where DbFunctions.DiffYears(pets.DateOfBirth, DateTime.Now) < iage
                        select pets;
            return query.ToList();
        }
    }
}