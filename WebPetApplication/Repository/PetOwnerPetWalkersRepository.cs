using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPetApplication.Models;

namespace WebPetApplication.Repository
{
    public class PetOwnerPetWalkersRepository
    {
        private WebPetApplicationContext db = new WebPetApplicationContext();

        public List<PetOwnerPetWalker> PetOwnerApprovedPetWalker(int petownerId, int petwalkerId)
        {
            var query = from popw in db.PetOwnerPetWalkers
                        where popw.PetOwnerId.Equals(petownerId) && popw.PetWalkerId.Equals(petwalkerId)
                        select popw;
            return query.ToList();
        }
    }
}