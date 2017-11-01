﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MobileCloudExercicio01.Models;
using MobileCloudExercicio01.Models.Contexto;

namespace MobileCloudExercicio01.WebAPI
{
    public class ModeloController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Modelo
        public IQueryable<Modelo> GetModeloes()
        {
            return db.Modeloes;
        }

        // GET: api/Modelo/5
        [ResponseType(typeof(Modelo))]
        public IHttpActionResult GetModelo(int id)
        {
            Modelo modelo = db.Modeloes.Find(id);
            if (modelo == null)
            {
                return NotFound();
            }

            return Ok(modelo);
        }

        // PUT: api/Modelo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModelo(int id, Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelo.ID)
            {
                return BadRequest();
            }

            db.Entry(modelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(id))
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

        // POST: api/Modelo
        [ResponseType(typeof(Modelo))]
        public IHttpActionResult PostModelo(Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Modeloes.Add(modelo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = modelo.ID }, modelo);
        }

        // DELETE: api/Modelo/5
        [ResponseType(typeof(Modelo))]
        public IHttpActionResult DeleteModelo(int id)
        {
            Modelo modelo = db.Modeloes.Find(id);
            if (modelo == null)
            {
                return NotFound();
            }

            db.Modeloes.Remove(modelo);
            db.SaveChanges();

            return Ok(modelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModeloExists(int id)
        {
            return db.Modeloes.Count(e => e.ID == id) > 0;
        }
    }
}