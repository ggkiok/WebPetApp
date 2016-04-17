using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPetApplication.Models
{
    public class PetInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}