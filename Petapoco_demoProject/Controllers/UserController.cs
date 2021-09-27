using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using Petapoco_demoProject.Models;
using PetaPoco;


namespace Petapoco_demoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly Iuser_detail userService;

        public UserController(Iuser_detail userService)
        {
            this.userService = userService;
        }
        [HttpGet("getAUser")]
        public Task<user_detail_view> GetAUser(int id)
        {
            return this.userService.getAUser(id);
        }
        [HttpGet("GetALLUser")]
        public Task<List<user_detail_view>> GetALLUser()
        {
            return this.userService.getUser();
        }
        [HttpPost("Insertuser")]
        public Task<string> Insertusers(user_detail_view users)
        {
            return this.userService.Insertuser(users);
        }
        [HttpDelete("Deleteuser")]
        public Task<string> Deleteusers(int id)
        {
            return this.userService.Deleteuser(id);
        }
        [HttpPut("UpdateUser")]
        public Task<string> Updateusers(int id,String username,string password)
        {
            return this.userService.Updateuser(id,username,password);
        }
    }
}
