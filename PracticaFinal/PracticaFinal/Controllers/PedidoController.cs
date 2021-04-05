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
    public class PedidoController : ApiController
    {
        private cochesdawEntities7 db = new cochesdawEntities7();
        // GET: api/pedido
        public IQueryable<pedido> GetLists()
        {
            return db.pedidoes;
        }

        // GET: api/pedido/5
        [ResponseType(typeof(pedido))]
        public IHttpActionResult GetLists(decimal id)
        {
            List<pedido> pedidos = new List<pedido>();
            pedidos = db.Database.SqlQuery<pedido>("select * from pedido where idCliente like {0}",
                id).ToList();
            if (pedidos.Count == 0)
            {
                return NotFound();
            }
            return Ok(pedidos);
        }

        // PUT: api/pedido/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLists(decimal id, pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedido.id)
            {
                return BadRequest();
            }

            db.Entry(pedido).State = EntityState.Modified;

            try
            {
                string sql = String.Format("update pedido set idCliente = '{0}', precioTotal = '{1}' where id like {2}",
                pedido.idCliente, pedido.precioTotal, id);
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

        // POST: api/pedido
        [ResponseType(typeof(pedido))]
        public IHttpActionResult PostLists(pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string sql = String.Format("insert into pedido (idCliente, precioTotal) values ('{0}', '{1}')",
                pedido.idCliente, pedido.precioTotal);
            db.Database.ExecuteSqlCommand(sql);

            //db.pedido.Add(pedidos);
            //db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = pedido.id }, pedido);
        }

        // DELETE: api/pedido/5
        [ResponseType(typeof(pedido))]
        public IHttpActionResult DeleteLists(decimal id)
        {
            pedido pedidos = db.pedidoes.Find(id);
            if (pedidos == null)
            {
                return NotFound();
            }

            db.pedidoes.Remove(pedidos);
            db.SaveChanges();

            return Ok(pedidos);
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
            return db.pedidoes.Count(e => e.id == id) > 0;
        }
    }
}
