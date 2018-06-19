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
    public class LikesController : ApiController
    {
        private LikeContext _db = new LikeContext();

        // GET: api/Likes
        public IQueryable<Like> GetLikes()
        {
            return _db.Likes;
        }

        // GET: api/Likes/5
        [ResponseType(typeof(Like))]
        public IHttpActionResult GetLike(int id)
        {
            Like like = _db.Likes.Find(id);
            if (like == null)
            {
                return NotFound();
            }

            return Ok(like);
        }

        // PUT: api/Likes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLike(int id, Like like)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != like.Id)
            {
                return BadRequest();
            }

            _db.Entry(like).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikeExists(id))
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

        // POST: api/Likes
        [ResponseType(typeof(Like))]
        public IHttpActionResult PostLike(Like like)
        { 

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Likes.Add(like);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = like.Id }, like);
        }

        // DELETE: api/Likes/5
        [ResponseType(typeof(Like))]
        public IHttpActionResult DeleteLike(int id)
        {
            Like like = _db.Likes.Find(id);
            if (like == null)
            {
                return NotFound();
            }

            _db.Likes.Remove(like);
            _db.SaveChanges();

            return Ok(like);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LikeExists(int id)
        {
            return _db.Likes.Count(e => e.Id == id) > 0;
        }
    }
}