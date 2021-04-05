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
    public class StockController : ApiController
    {
        private cochesdawEntities7 db = new cochesdawEntities7();
        // GET: api/stock
        public IQueryable<stock> GetLists()
        {
            return db.stocks;
        }

        // GET: api/stock/5
        [ResponseType(typeof(stock))]
        public IHttpActionResult GetLists(decimal id)
        {
            List<stock> stock = new List<stock>();
            stock = db.Database.SqlQuery<stock>("select * from stock where idCoche like {0}",
                id).ToList();
            if (stock.Count == 0)
            {
                return NotFound();
            }
            return Ok(stock);
        }

        // PUT: api/stock/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLists(decimal id, stock stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stock.idCoche)
            {
                return BadRequest();
            }

            db.Entry(stock).State = EntityState.Modified;

            try
            {
                string sql = String.Format("update stock set unidades = '{0}' where idCoche like {1}",
                stock.unidades, id);
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

        // POST: api/stock
        [ResponseType(typeof(stock))]
        public IHttpActionResult PostLists(stock stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string sql = String.Format("insert into stock (idCoche, unidades) values ('{0}', '{1}')",
                stock.idCoche, stock.unidades);
            try
            {
                db.Database.ExecuteSqlCommand(sql);
            }
            catch(MySql.Data.MySqlClient.MySqlException e)
            {
                return BadRequest(e.Message);
            }

            //db.stock.Add(stocks);
            //db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = stock.idCoche }, stock);
        }

        // DELETE: api/stock/5
        [ResponseType(typeof(stock))]
        public IHttpActionResult DeleteLists(decimal id)
        {
            stock stocks = db.stocks.Find(id);
            if (stocks == null)
            {
                return NotFound();
            }

            db.stocks.Remove(stocks);
            db.SaveChanges();

            return Ok(stocks);
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
            return db.stocks.Count(e => e.idCoche == id) > 0;
        }
    }
}
