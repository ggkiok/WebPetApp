using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebPetApplication.Models
{
    public class PetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PetOwnerId { get; set; }
        public string PetOwnerFirstName { get; set; }
        public string PetOwnerLastName { get; set; }
    }
}