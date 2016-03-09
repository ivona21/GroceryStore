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
              

        public IQueryable<CategoriesDTO> GetCategoriesByProductId(int productId)
        {
           
            var connectedCategories = db.Relationships.Where(r => r.ProductId == productId).Select(r => r.Category).Where(c => c.Active);
            var disconnectedCategories = db.Categories.Where(c => c.Active).Except(connectedCategories);

            var dtoCatConn = connectedCategories.Select(c => new CategoriesDTO
            {
                Id = c.Id,
                CategoryName = c.Name,
                Connected = true
            });

            var dtoCatDiscon = disconnectedCategories.Select(c => new CategoriesDTO
            {
                Id = c.Id,
                CategoryName = c.Name,
                Connected = false
            });

            return dtoCatConn.Concat(dtoCatDiscon);          
        }

        [ResponseType(typeof(Relationship))]
        public IHttpActionResult Post(Relationship relationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var rel = db.Relationships.FirstOrDefault(r => r.ProductId == relationship.ProductId && r.CategoryId == relationship.CategoryId);
            if (rel != null)
            {
                return BadRequest();
            }

            db.Relationships.Add(relationship);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { productId = relationship.ProductId, categoryId = relationship.CategoryId }, relationship);
        }

        
        public IHttpActionResult Delete(int productId, int categoryId)
        {
            Relationship relationship = db.Relationships.FirstOrDefault(r => r.ProductId == productId && r.CategoryId == categoryId);
            if (relationship == null)
            {
                return NotFound();
            }

            db.Relationships.Remove(relationship);
            db.SaveChanges();

            return Ok(relationship);
        }

    }
}
