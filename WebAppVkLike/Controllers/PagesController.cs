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
using WebAppVkLike.EFClasses;
using WebAppVkLike.Models;

namespace WebAppVkLike.Controllers
{
    public class PagesController : ApiController
    {
        private LikeContext _db = new LikeContext();

        // GET: api/Pages
        public IQueryable<Page> GetPages()        {
            return _db.Pages;
        }

        // GET: api/Pages/5
        [ResponseType(typeof(Page))]
        public IHttpActionResult GetPage(int id)
        {
            Page page = _db.Pages.Find(id);
            if (page == null)
            {
                return NotFound();
            }

            return Ok(page);
        }

        // PUT: api/Pages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPage(int id, Page page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != page.Id)
            {
                return BadRequest();
            }

            _db.Entry(page).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageExists(id))
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

        // POST: api/Pages
        [ResponseType(typeof(Page))]
        public IHttpActionResult PostPage(Page page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Pages.Add(page);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = page.Id }, page);
        }

        // DELETE: api/Pages/5
        [ResponseType(typeof(Page))]
        public IHttpActionResult DeletePage(int id)
        {
            Page page = _db.Pages.Find(id);
            if (page == null)
            {
                return NotFound();
            }

            _db.Pages.Remove(page);
            _db.SaveChanges();

            return Ok(page);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PageExists(int id)
        {
            return _db.Pages.Count(e => e.Id == id) > 0;
        }
    }
}