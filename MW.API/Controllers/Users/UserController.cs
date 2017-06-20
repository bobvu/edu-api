using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MW.API.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using MW.DataAccess.Contexts;
using MW.Domains.Users;
using MW.API.Helpers;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MW.API.Controllers.Users
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly MwSqlContext _appDbContext;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserController(UserManager<User> userManager, IMapper mapper, MwSqlContext appDbContext,
            ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
            _logger = loggerFactory.CreateLogger<UserController>();
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<User>(model);
            var result = await _userManager.CreateAsync(userIdentity, model.Password);
            Errors.AddErrorsToModelState(result, ModelState);

            string json = JsonConvert.SerializeObject(Errors.AddErrorsToModelState(result, ModelState), Formatting.Indented);

            if (!result.Succeeded) {
                //_logger.LogInformation("Something went wrong with Creating a new account with username: " + model.Email + " password: " + model.Password);
                _logger.LogInformation("Can't create new account with username: " + model.Email + " password: " + model.Password+" Errors " + json);
                return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            }
            else
            {
                _logger.LogInformation("User created a new account with username: " + model.Email + " password: " + model.Password);
            } 

            //await _appDbContext.Users.AddAsync(new User { UserName=userIdentity.Email});
            //await _appDbContext.SaveChangesAsync();
            
            return new OkObjectResult("User created");
        }
    }
}
