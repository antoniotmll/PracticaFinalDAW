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
    public class UsuarioController : ApiController
    {
        private cochesdawEntities7 db = new cochesdawEntities7();
        // GET: api/usuario
        public IQueryable<usuario> GetLists()
        {
            return db.usuarios;
        }

        // GET: api/usuario/5
        [ResponseType(typeof(usuario))]
        public IHttpActionResult GetLists(decimal id)
        {
            usuario usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        // PUT: api/usuario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLists(decimal id, usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.id)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                string sql = String.Format("update usuario set user = '{0}', passwd = '{1}',  tipoUsuario = '{2}', nombre = '{3}', direccion = '{4}', telefono = '{5}' where id like {6}",
                usuario.user, usuario.passwd, usuario.tipoUsuario, usuario.nombre, usuario.direccion, usuario.telefono, id);
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

        // POST: api/usuario
        [ResponseType(typeof(usuario))]
        public IHttpActionResult PostLists(usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string sql = String.Format("insert into usuario (user, passwd, tipoUsuario, nombre, direccion, telefono) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                usuario.user, usuario.passwd, usuario.tipoUsuario, usuario.nombre, usuario.direccion, usuario.telefono);
            db.Database.ExecuteSqlCommand(sql);

            //db.usuario.Add(usuarios);
            //db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = usuario.id }, usuario);
        }

        // DELETE: api/usuario/5
        [ResponseType(typeof(usuario))]
        public IHttpActionResult DeleteLists(decimal id)
        {
            usuario usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            db.usuarios.Remove(usuarios);
            db.SaveChanges();

            return Ok(usuarios);
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
            return db.usuarios.Count(e => e.id == id) > 0;
        }
    }
}