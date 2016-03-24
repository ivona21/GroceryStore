using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using GroceryStore.Data;
using GroceryStore.Model;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;

namespace GroceryStore.Web.Controllers
{
    public class CategoriesController : ApiController
    {
        GroceryStoreDbContext db = new GroceryStoreDbContext();

        public CategoriesController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Categories
        public IQueryable<Category> Get()
        {
            return db.Categories;
        }

        public IQueryable<Category> Get(bool onlyActive)
        {
            return db.Categories.Where(category => category.Active);
        }

        // GET: api/Categories/5
        public IHttpActionResult Get(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public IHttpActionResult Post(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.Id)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoryExists(id))
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

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult Delete(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }     
            
                  

            db.Categories.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        private bool categoryExists(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
                return false;

            return true;
        }
    }
}
