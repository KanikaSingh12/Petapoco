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
        [HttpGet("overview")]
        public Task<user_detail_view> GetPayoutsOverview()
        {
            return this.payoutService.getUser();
        }
    }
}
