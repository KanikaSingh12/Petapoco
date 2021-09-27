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
        
        private readonly Iuser_detail payoutService;

        public UserController(Iuser_detail payoutService)
        {
            this.payoutService = payoutService;
        }
        
        [HttpGet("GetUser")]
        public Task<user_detail_view> getUser(int id)
        {

            return this.payoutService.getAUser(id);
        }
        [HttpGet("GetAllUser")]
        public Task <List<user_detail_view>> GetPayoutsOverview()
        {

            return this.payoutService.getUser();
        }
        [HttpPost("Insertuser")]
        public Task<string> Insertusers(user_detail_view users)
        {
            return this.payoutService.Insertuser(users);
        }
        [HttpDelete("Deleteuser")]
        public Task<string> Deleteusers(int id)
        {
            return this.payoutService.Deleteuser(id);
        }
        [HttpPut("UpdateUser")]
        public Task<string> Updateusers(int id,String username,string password)
        {
            return this.payoutService.Updateuser(id,username,password);
        }
    }
}
