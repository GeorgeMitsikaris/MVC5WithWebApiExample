using MVC5WithWebApiExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC5WithWebApiExample.Controllers.WebApi
{
    [RoutePrefix("itemtypes")]
    public class ItemTypesController : ApiController
    {
        ItemTypeDBContext _db = new ItemTypeDBContext();

        // GET: api/ItemTypes
        [Route("")]
        public IEnumerable<ItemType> Get()
        {
            var itemTypes = _db.ItemTypes.ToList();
            return itemTypes;
        }

        // GET: api/ItemTypes/5
        [Route("search")]
        public ItemType Get(string search)
        {
            var itemTypeName = _db.ItemTypes.FirstOrDefault(i => i.Name.Contains(search));
            return itemTypeName;
        }

        // POST: api/ItemTypes
        [Route("")]
        public void Post([FromBody]ItemType itemType)
        {
            if (itemType == null)
                throw new NullReferenceException("You must enter a value");
            else
            {
                _db.ItemTypes.Add(itemType);
                _db.SaveChanges();
            }
        }

        // PUT: api/ItemTypes/5
        [Route()]
        public void Put(int id, [FromBody]ItemType itemType)
        {
        }

        // DELETE: api/ItemTypes/5
        public void Delete(int id)
        {
        }
    }
}
