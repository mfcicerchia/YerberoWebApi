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
    public class EmpleadoController : ApiController
    {
        private YerberoContext db = new YerberoContext();

        // GET: api/Empleado
        public IQueryable<Empleado> Getempleados()
        {
            return db.empleados;
        }

        // GET: api/Empleado/5
        [ResponseType(typeof(Empleado))]
        public async Task<IHttpActionResult> GetEmpleado(int id)
        {
            Empleado empleado = await db.empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(empleado);
        }

        // PUT: api/Empleado/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleado.idEmpleado)
            {
                return BadRequest();
            }

            db.Entry(empleado).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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

        // POST: api/Empleado
        [ResponseType(typeof(Empleado))]
        public async Task<IHttpActionResult> PostEmpleado(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.empleados.Add(empleado);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = empleado.idEmpleado }, empleado);
        }

        // DELETE: api/Empleado/5
        [ResponseType(typeof(Empleado))]
        public async Task<IHttpActionResult> DeleteEmpleado(int id)
        {
            Empleado empleado = await db.empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            db.empleados.Remove(empleado);
            await db.SaveChangesAsync();

            return Ok(empleado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadoExists(int id)
        {
            return db.empleados.Count(e => e.idEmpleado == id) > 0;
        }
    }
}