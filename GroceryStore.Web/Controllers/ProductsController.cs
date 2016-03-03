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
    public class ProductsController : ApiController
    {
        GroceryStoreDbContext db = new GroceryStoreDbContext();

        public ProductsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Products
        public IQueryable<Product> Get()
        {
            return db.Products;
        }


        public IQueryable<Product> Get(bool onlyActive)
        {
            return db.Products.Where(product => product.Available);
        }

        // GET: api/Products/5
        public IHttpActionResult Get(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        private bool ProductExists(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
                return false;

            return true;
        }
    }
}
