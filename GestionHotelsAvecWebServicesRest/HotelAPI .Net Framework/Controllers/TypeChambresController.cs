﻿using System;
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
using GestionHotelsAvecWebServicesRest.Models;
using HotelAPI.Net_Framework.Data;

namespace HotelAPI.Net_Framework.Controllers
{
    public class TypeChambresController : ApiController
    {
        private HotelAPINet_FrameworkContext db = new HotelAPINet_FrameworkContext();

        // GET: api/TypeChambres
        public IQueryable<TypeChambre> GetTypeChambres()
        {
            return db.TypeChambres;
        }

        // GET: api/TypeChambres/5
        [ResponseType(typeof(TypeChambre))]
        public async Task<IHttpActionResult> GetTypeChambre(int id)
        {
            TypeChambre typeChambre = await db.TypeChambres.FindAsync(id);
            if (typeChambre == null)
            {
                return NotFound();
            }

            return Ok(typeChambre);
        }

        // PUT: api/TypeChambres/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTypeChambre(int id, TypeChambre typeChambre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeChambre.TypeChambreId)
            {
                return BadRequest();
            }

            db.Entry(typeChambre).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeChambreExists(id))
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

        // POST: api/TypeChambres
        [ResponseType(typeof(TypeChambre))]
        public async Task<IHttpActionResult> PostTypeChambre(TypeChambre typeChambre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeChambres.Add(typeChambre);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = typeChambre.TypeChambreId }, typeChambre);
        }

        // DELETE: api/TypeChambres/5
        [ResponseType(typeof(TypeChambre))]
        public async Task<IHttpActionResult> DeleteTypeChambre(int id)
        {
            TypeChambre typeChambre = await db.TypeChambres.FindAsync(id);
            if (typeChambre == null)
            {
                return NotFound();
            }

            db.TypeChambres.Remove(typeChambre);
            await db.SaveChangesAsync();

            return Ok(typeChambre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeChambreExists(int id)
        {
            return db.TypeChambres.Count(e => e.TypeChambreId == id) > 0;
        }
    }
}