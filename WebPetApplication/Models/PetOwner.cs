using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using Newtonsoft.Json;

namespace WebPetApplication.Models
{
    public class PetOwner
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        public ICollection<Pet> Pets { get; set; }
        public ICollection<PetOwnerPetWalker> PetOwnerPetWalkers { get; set; }
    }
}