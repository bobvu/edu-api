using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MW.DataAccess.Contexts;
using MW.Domains.Test;
using Newtonsoft.Json;
using MW.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using MW.Domains.Users;
using AutoMapper;
using MW.API.Models.AccountViewModels;

namespace MW.API.Controllers.Test
{
    [Produces("application/json")]
    [Route("api/Items")]
    public class ItemsController : Controller
    {
        private readonly ILogger _logger;
        private readonly MwSqlContext _dbContext;
        private readonly IMapper _mapper;
        public ItemsController(
            MwSqlContext context,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _dbContext = context;
            _logger = loggerFactory.CreateLogger<ItemsController>();
            _mapper = mapper;
        }

        // GET: api/Items
        [HttpGet]
        public IEnumerable<Item> GetAll()
        {
            var items = _dbContext.Items.ToList();
            foreach (Item item in items)
            {
                var comments = _dbContext.Comments.Where(c => c.ItemId == item.ItemId).ToList();
                item.Comments = comments;
            }
            return items;
        }

        // GET: api/Items/5
        [HttpGet("{id}", Name = "GetItem")]
        public Item Get(long id)
        {
            var item = _dbContext.Items.FirstOrDefault(c => c.ItemId == id);
            var comments = _dbContext.Comments.Where(c => c.ItemId == id).ToList();
            item.Comments = comments;
            return item;
        }

        // GET: api/Items/5
        [HttpGet]
        [Route("GetMentionables", Name = "GetMentionables")]
        public List<User> Get()
        {
            var users = _dbContext.Users.ToList();
            List<RegisterViewModel> mentionables = new List<RegisterViewModel>();
            foreach (User user in users)
            {
                //var userIdentity = _mapper.Map<RegisterViewModel>(user);
                //mentionables.Add(userIdentity);
            }
            
            return users;
        }

        // POST: api/Items
        [HttpPost]
        [Route("AddItem", Name = "AddItem")]
        public IActionResult Post([FromBody]Item model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _dbContext.Items.Add(model);
                _dbContext.SaveChanges();
                return new OkObjectResult("Item created");
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Can't create new Item " + ex.Message);
                return new BadRequestObjectResult(ex);
            }

        }

        // POST: api/Items/AddComments
        [HttpPost]
        [Route("AddComment", Name = "AddCommentToItem")]
        public IActionResult AddCommentToItem([FromBody]Comment model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _dbContext.Items.FirstOrDefault(i => i.ItemId == model.ItemId);
            if (item != null)
            {
                try
                {
                    _dbContext.Comments.Add(model);
                    _dbContext.SaveChanges();
                    var comments = _dbContext.Comments.Where(c => c.ItemId == item.ItemId).ToList();
                    item.Comments = comments;

                    return CreatedAtRoute("GetItem", new { id = item.ItemId }, item);
                }
                catch (Exception ex)
                {
                    return new BadRequestObjectResult("Failed " + ex.Message);
                }
            }
            return new BadRequestObjectResult("Item doesn't exist");
        }


        // PUT: api/Items/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var item = _dbContext.Items.FirstOrDefault(i => i.ItemId == id);
            if (item != null)
            {
                _dbContext.Items.Remove(item);
                _dbContext.SaveChanges();
                return new OkObjectResult("Item deleted");
            }
            else
            {
                return new OkObjectResult("Item doens't exist");

            }
        }
    }
}
