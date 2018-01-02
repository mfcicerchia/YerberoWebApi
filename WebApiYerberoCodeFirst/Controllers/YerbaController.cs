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
using WebApiYerberoCodeFirst.Models;

namespace WebApiYerberoCodeFirst.Controllers
{
    public class YerbaController : ApiController
    {
        private YerberoContext db = new YerberoContext();

        // GET: api/Yerba
        public IQueryable<Yerba> Getyerbas()
        {
            return db.yerbas;
        }

        // GET: api/Yerba/5
        [ResponseType(typeof(Yerba))]
        public async Task<IHttpActionResult> GetYerba(int id)
        {
            Yerba yerba = await db.yerbas.FindAsync(id);
            if (yerba == null)
            {
                return NotFound();
            }

            return Ok(yerba);
        }

        // PUT: api/Yerba/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutYerba(int id, Yerba yerba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != yerba.idYerba)
            {
                return BadRequest();
            }

            db.Entry(yerba).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YerbaExists(id))
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

        // POST: api/Yerba
        [ResponseType(typeof(Yerba))]
        public async Task<IHttpActionResult> PostYerba(Yerba yerba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.yerbas.Add(yerba);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = yerba.idYerba }, yerba);
        }

        // DELETE: api/Yerba/5
        [ResponseType(typeof(Yerba))]
        public async Task<IHttpActionResult> DeleteYerba(int id)
        {
            Yerba yerba = await db.yerbas.FindAsync(id);
            if (yerba == null)
            {
                return NotFound();
            }

            db.yerbas.Remove(yerba);
            await db.SaveChangesAsync();

            return Ok(yerba);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool YerbaExists(int id)
        {
            return db.yerbas.Count(e => e.idYerba == id) > 0;
        }
    }
}