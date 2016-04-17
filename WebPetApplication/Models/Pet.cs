using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebPetApplication.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        // Foreign Keys
        public int PetOwnerId { get; set; }
        public PetOwner PetOwner{ get; set; }
    }
}