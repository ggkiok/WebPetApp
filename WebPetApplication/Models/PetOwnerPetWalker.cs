using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPetApplication.Models
{
    public class PetOwnerPetWalker
    {
        public int Id { get; set; }
        // Foreign Keys
        public int PetOwnerId { get; set; }
        public PetOwner PetOwner { get; set; }

        public int PetWalkerId { get; set; }
        public PetWalker PetWalker { get; set; }
    }
}