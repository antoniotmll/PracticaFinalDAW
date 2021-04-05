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
    public class LineapedidoController : ApiController
    {
        private cochesdawEntities7 db = new cochesdawEntities7();
        // GET: api/lineapedido
        public IHttpActionResult GetLists(decimal id)
        {
            List<lineapedido> lineas = new List<lineapedido>();
            lineas = db.Database.SqlQuery<lineapedido>("select * from lineapedido where idPedido like {0}", 
                id).ToList();
            if (lineas.Count == 0)
            {
                return NotFound();
            }
            return Ok (lineas);
        }

        // PUT: api/lineapedido/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLists(decimal id, lineapedido lineapedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lineapedido.id)
            {
                return BadRequest();
            }

            db.Entry(lineapedido).State = EntityState.Modified;

            try
            {
                string sql = String.Format("update lineapedido set idPedido = '{0}', idCoche = '{1}', precioCoche = '{2}' where id like {3}",
                lineapedido.idPedido, lineapedido.idCoche, lineapedido.precioCoche, id);
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

        // POST: api/lineapedido
        [ResponseType(typeof(lineapedido))]
        public IHttpActionResult PostLists(lineapedido lineapedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string sql = String.Format("insert into lineapedido (idPedido, idCoche, precioCoche) values ('{0}', '{1}', '{2}')",
                lineapedido.idPedido, lineapedido.idCoche, lineapedido.precioCoche);
            db.Database.ExecuteSqlCommand(sql);

            //db.lineapedido.Add(lineapedidos);
            //db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = lineapedido.id }, lineapedido);
        }

        // DELETE: api/lineapedido/5
        [ResponseType(typeof(lineapedido))]
        public IHttpActionResult DeleteLists(decimal id)
        {
            lineapedido lineapedidos = db.lineapedidoes.Find(id);
            if (lineapedidos == null)
            {
                return NotFound();
            }

            db.lineapedidoes.Remove(lineapedidos);
            db.SaveChanges();

            return Ok(lineapedidos);
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
            return db.lineapedidoes.Count(e => e.id == id) > 0;
        }
    }
}
