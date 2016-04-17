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

namespace WebPetApplication.Controllers
{
    public class PetOwnerPetWalkerController : ApiController
    {
        private WebPetApplicationContext db = new WebPetApplicationContext();

        // GET api/PetOwnerPetWalker
        public IQueryable<PetOwnerPetWalker> GetPetOwnerPetWalkers()
        {
            return db.PetOwnerPetWalkers;
        }

        // GET api/PetOwnerPetWalker/5
        [ResponseType(typeof(PetOwnerPetWalker))]
        public async Task<IHttpActionResult> GetPetOwnerPetWalker(int id)
        {
            PetOwnerPetWalker petownerpetwalker = await db.PetOwnerPetWalkers.FindAsync(id);
            if (petownerpetwalker == null)
            {
                return NotFound();
            }

            return Ok(petownerpetwalker);
        }

        // PUT api/PetOwnerPetWalker/5
        public async Task<IHttpActionResult> PutPetOwnerPetWalker(int id, PetOwnerPetWalker petownerpetwalker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petownerpetwalker.Id)
            {
                return BadRequest();
            }

            db.Entry(petownerpetwalker).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetOwnerPetWalkerExists(id))
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

        // POST api/PetOwnerPetWalker
        [ResponseType(typeof(PetOwnerPetWalker))]
        public async Task<IHttpActionResult> PostPetOwnerPetWalker(PetOwnerPetWalker petownerpetwalker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetOwnerPetWalkers.Add(petownerpetwalker);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = petownerpetwalker.Id }, petownerpetwalker);
        }

        // DELETE api/PetOwnerPetWalker/5
        [ResponseType(typeof(PetOwnerPetWalker))]
        public async Task<IHttpActionResult> DeletePetOwnerPetWalker(int id)
        {
            PetOwnerPetWalker petownerpetwalker = await db.PetOwnerPetWalkers.FindAsync(id);
            if (petownerpetwalker == null)
            {
                return NotFound();
            }

            db.PetOwnerPetWalkers.Remove(petownerpetwalker);
            await db.SaveChangesAsync();

            return Ok(petownerpetwalker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetOwnerPetWalkerExists(int id)
        {
            return db.PetOwnerPetWalkers.Count(e => e.Id == id) > 0;
        }
    }
}