using MVC5WithWebApiExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC5WithWebApiExample.Controllers.WebApi
{
    [RoutePrefix("ItemTypes")]
    public class ItemTypesController : ApiController
    {
        ItemTypeDBContext _db = new ItemTypeDBContext();

        // GET: ItemTypes
        [Route("")]
        public IEnumerable<ItemType> Get()
        {
            var itemTypes = _db.ItemTypes.ToList();
            return itemTypes;
        }

        //Get: ItemTypes/1
        [Route("findById")]
        public ItemType GetItem(int id)
        {
            var itemType = _db.ItemTypes.Find(id);
            return itemType;
        }

        // GET: ItemTypes/abc
        [Route("searchByName")]
        public List<ItemType> Get(string search)
        {
            var itemTypeName = _db.ItemTypes.Where(i => i.Name.Contains(search)).ToList();
            return itemTypeName;
        }

        // GET: ItemTypes/5
        [Route("searchByCode")]
        public List<ItemType> Get(int search)
        {
            var itemTypeName = _db.ItemTypes.Where(i => i.Code.ToString().Contains(search.ToString())).ToList();
            return itemTypeName;
        }

        // POST: ItemTypes
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

        // PUT: ItemTypes/5
        [Route("{id:int}")]
        public void Put(int id, [FromBody]ItemType itemType)
        {
            var itemTypeFromDb = _db.ItemTypes.FirstOrDefault(i => i.Id.Equals(id));
            itemTypeFromDb.Code = itemType.Code;
            itemTypeFromDb.Name = itemType.Name;
            _db.SaveChanges();
        }

        // DELETE: ItemTypes/5
        [Route("{id:int}")]
        public void Delete(int id)
        {
            var itemType = _db.ItemTypes.FirstOrDefault(i => i.Id.Equals(id));
            _db.ItemTypes.Remove(itemType);
            _db.SaveChanges();
        }
    }
}
