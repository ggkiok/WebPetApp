using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebPetApplication.Models;
using WebPetApplication.Repository;

namespace WebPetApplication.Controllers
{
    public class PetsController : ApiController
    {
        private WebPetApplicationContext db = new WebPetApplicationContext();

        // GET api/Pets
        public IQueryable<Pet> GetPets()
        {
            return db.Pets;
        }

        // GET api/Pets/PetOwner
        [Route("api/Pets/PetOwner")]
        public IQueryable<PetDTO> GetPetsWithOwnerDetails()
        {
            var pets = from p in db.Pets
                       select new PetDTO()
                       {
                           Id = p.Id,
                           Name = p.Name,
                           DateOfBirth = p.DateOfBirth,
                           PetOwnerId = p.PetOwner.Id,
                           PetOwnerFirstName = p.PetOwner.FirstName,
                           PetOwnerLastName = p.PetOwner.LastName
                       };

            return pets;
        }

        // GET api/Pets/5
        [ResponseType(typeof(Pet))]
        public async Task<IHttpActionResult> GetPet(int id)
        {
            Pet pet = await db.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        }


        [Route("api/Pets/Age/{age:int}")]
        public HttpResponseMessage GetPetsUnderAThisAge(int age)
        {
            PetsRepository oPetsRepository = new PetsRepository();
            var pets = oPetsRepository.GetPetsUnderAThisAge(age);
            if (pets.Count == 0)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, pets);
                return response;
            }

        }

        // PUT api/Pets/5
        public async Task<IHttpActionResult> PutPet(int id, Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pet.Id)
            {
                return BadRequest();
            }

            if (pet.PetOwnerId == 0)
            {
                return BadRequest();
            }

            db.Entry(pet).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Pets
        [ResponseType(typeof(Pet))]
        public async Task<IHttpActionResult> PostPet(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pets.Add(pet);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pet.Id }, pet);
        }

        // DELETE api/Pets/5
        [ResponseType(typeof(Pet))]
        public async Task<IHttpActionResult> DeletePet(int id)
        {
            Pet pet = await db.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            db.Pets.Remove(pet);
            await db.SaveChangesAsync();

            return Ok(pet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetExists(int id)
        {
            return db.Pets.Count(e => e.Id == id) > 0;
        }
    }
}