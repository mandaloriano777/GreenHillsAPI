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
using GreenHillsAPI.Models;

namespace GreenHillsAPI.Controllers.API
{
    public class SensoresController : ApiController
    {
        private BancoDadosAPI db = new BancoDadosAPI();

        // GET: api/Sensores
        public IQueryable<tbsensores> Gettbsensores()
        {
            return db.tbsensores;
        }

        // GET: api/Sensores/5
        [ResponseType(typeof(tbsensores))]
        public IHttpActionResult Gettbsensores(int id)
        {
            tbsensores tbsensores = db.tbsensores.Find(id);
            if (tbsensores == null)
            {
                return NotFound();
            }

            return Ok(tbsensores);
        }

        // PUT: api/Sensores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbsensores(int id, tbsensores tbsensores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbsensores.id)
            {
                return BadRequest();
            }

            db.Entry(tbsensores).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbsensoresExists(id))
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

        // POST: api/Sensores
        [ResponseType(typeof(tbsensores))]
        public IHttpActionResult Posttbsensores(tbsensores tbsensores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbsensores.Add(tbsensores);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbsensores.id }, tbsensores);
        }

        // DELETE: api/Sensores/5
        [ResponseType(typeof(tbsensores))]
        public IHttpActionResult Deletetbsensores(int id)
        {
            tbsensores tbsensores = db.tbsensores.Find(id);
            if (tbsensores == null)
            {
                return NotFound();
            }

            db.tbsensores.Remove(tbsensores);
            db.SaveChanges();

            return Ok(tbsensores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbsensoresExists(int id)
        {
            return db.tbsensores.Count(e => e.id == id) > 0;
        }
    }
}