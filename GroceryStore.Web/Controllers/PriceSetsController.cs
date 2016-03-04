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
    public class PriceSetsController : ApiController
    {
        GroceryStoreDbContext db = new GroceryStoreDbContext();

        public PriceSetsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/PriceSets
        public IQueryable<PriceSet> Get()
        {
            return db.PriceSets;
        }

        public IQueryable<PriceSet> GetByProductId(int productId)
        {
            return db.PriceSets.Where(ps => ps.ProductId == productId);
        }
               

        // GET: api/PriceSets/5
        public IHttpActionResult Get(int id)
        {
            PriceSet priceSet = db.PriceSets.Find(id);
            if (priceSet == null)
            {
                return NotFound();
            }

            return Ok(priceSet);
        }

        // POST: api/PriceSets
        [ResponseType(typeof(PriceSet))]
        public IHttpActionResult Post(PriceSet priceSet, int productId)
        {           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            priceSet.ProductId = productId;

            ProductsController ctrl = new ProductsController();
            ctrl.ChangeProductAveragePrice(productId, priceSet.Price, true);

            db.PriceSets.Add(priceSet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = priceSet.Id }, priceSet);
        }       

        // DELETE: api/PriceSets/5
        [ResponseType(typeof(PriceSet))]
        public IHttpActionResult Delete(int id)
        {
            PriceSet priceSet = db.PriceSets.Find(id);
            if (priceSet == null)
            {
                return NotFound();
            }

            //Change product average price
            ProductsController ctrl = new ProductsController();
            ctrl.ChangeProductAveragePrice(priceSet.ProductId, priceSet.Price, false);           

            db.PriceSets.Remove(priceSet);
            db.SaveChanges();

            return Ok(priceSet);
        }

        private bool priceSetExists(int id)
        {
            PriceSet priceSet = db.PriceSets.Find(id);
            if (priceSet == null)
                return false;

            return true;
        }
    }
}
