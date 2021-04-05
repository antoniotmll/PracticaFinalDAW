using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PracticaFinal.Models;

namespace PracticaFinal.Controllers
{
    public class CocheController : ApiController
    {
        private cochesdawEntities7 db = new cochesdawEntities7();
        // GET: api/coche
        public IQueryable<coche> GetLists()
        {
            return db.coches;
        }

        // GET: api/coche/5
        [ResponseType(typeof(coche))]
        public IHttpActionResult GetLists(decimal id)
        {
            coche coches = db.coches.Find(id);
            if (coches == null)
            {
                return NotFound();
            }

            return Ok(coches);
        }

        // PUT: api/coche/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLists(decimal id, coche coche)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coche.id)
            {
                return BadRequest();
            }

            db.Entry(coche).State = EntityState.Modified;

            try
            {
                string sql = String.Format("update coche set nombre = '{0}', descripcion = '{1}', marca = '{2}', modelo = '{3}', motor = '{4}', anyo = '{5}', precio = {6}, img = '{7}' where id like {8}",
                coche.nombre, coche.descripcion, coche.marca, coche.modelo, coche.motor, coche.anyo, coche.precio, coche.img, id);
                db.Database.ExecuteSqlCommand(sql);
                //db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/coche
        [ResponseType(typeof(coche))]
        public IHttpActionResult PostLists(coche coche)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string sql = String.Format("insert into coche (nombre, descripcion, marca, modelo, motor, anyo, precio, img) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, '{7}')",
                coche.nombre, coche.descripcion, coche.marca, coche.modelo, coche.motor, coche.anyo, coche.precio, coche.img);
            db.Database.ExecuteSqlCommand(sql);

            //db.coche.Add(coches);
            //db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = coche.id }, coche);
        }

        // DELETE: api/coche/5
        [ResponseType(typeof(coche))]
        public IHttpActionResult DeleteLists(decimal id)
        {
            coche coches = db.coches.Find(id);
            if (coches == null)
            {
                return NotFound();
            }

            db.coches.Remove(coches);
            db.SaveChanges();

            return Ok(coches);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListsExists(decimal id)
        {
            return db.coches.Count(e => e.id == id) > 0;
        }
    }
}