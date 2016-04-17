using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebPetApplication.Models;
using WebPetApplication.Repository;

namespace WebPetApplication.Controllers
{
    public class PetsOwnerController : ApiController
    {
        private WebPetApplicationContext db = new WebPetApplicationContext();

        // GET api/PetsOwner
        public IQueryable<PetOwner> GetPetOwners()
        {
            return db.PetOwners;
        }

        // GET api/PetsOwner/5
        [ResponseType(typeof(PetOwner))]
        public async Task<IHttpActionResult> GetPetOwner(int id)
        {
            PetOwner petowner = await db.PetOwners.FindAsync(id);
            if (petowner == null)
            {
                return NotFound();
            }

            return Ok(petowner);
        }

        [Route("api/PetsOwner/{petownerId}/Pets")]
        public HttpResponseMessage GetPetsByOwnerId(int petownerId)
        {
            PetsRepository oPetsRepository = new PetsRepository();
            var pets = oPetsRepository.GetPetsByPetOwnerId(petownerId);
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

        [Route("api/PetsOwner/{petownerId}/Approves/{petwalkerId}")]
        [HttpGet]
        public HttpResponseMessage IsPetOwnerApprovesPetWalker(int petownerId, int petwalkerId)
        {
            PetOwnerPetWalkersRepository oPetOwnerPetWalkersRepository = new PetOwnerPetWalkersRepository();
            var petwalker = oPetOwnerPetWalkersRepository.PetOwnerApprovedPetWalker(petownerId, petwalkerId);
            if (petwalker.Count == 0)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, false);
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, true);
                return response;
            }

        }

        // PUT api/PetsOwner/5
        public async Task<IHttpActionResult> PutPetOwner(int id, PetOwner petowner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petowner.Id)
            {
                return BadRequest();
            }

            db.Entry(petowner).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetOwnerExists(id))
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

        // POST api/PetsOwner
        [ResponseType(typeof(PetOwner))]
        public async Task<IHttpActionResult> PostPetOwner(PetOwner petowner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetOwners.Add(petowner);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = petowner.Id }, petowner);
        }

        // DELETE api/PetsOwner/5
        [ResponseType(typeof(PetOwner))]
        public async Task<IHttpActionResult> DeletePetOwner(int id)
        {
            PetOwner petowner = await db.PetOwners.FindAsync(id);
            if (petowner == null)
            {
                return NotFound();
            }

            db.PetOwners.Remove(petowner);
            await db.SaveChangesAsync();

            return Ok(petowner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetOwnerExists(int id)
        {
            return db.PetOwners.Count(e => e.Id == id) > 0;
        }
    }
}