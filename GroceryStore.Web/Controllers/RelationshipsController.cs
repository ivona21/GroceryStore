using GroceryStore.Data;
using GroceryStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace GroceryStore.Web.Controllers
{
    public class RelationshipsController : ApiController
    {

        GroceryStoreDbContext db = new GroceryStoreDbContext();

        public IQueryable<Relationship> GetByProductId(int productId)
        {
            return db.Relationships.Where(r => r.ProductId == productId);
        }

        [ResponseType(typeof(Relationship))]
        public IHttpActionResult Post(Relationship relationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }           

            db.Relationships.Add(relationship);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { productId = relationship.ProductId, categoryId = relationship.CategoryId }, relationship);
        }

    }
}
