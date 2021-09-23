using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Petapoco_demoProject.Controllers;
using PetaPoco;

namespace Petapoco_demoProject.Models
{
    public class user_service : BaseService, Iuser_detail
    {
        public user_service(IDatabase database) : base(database)
        {
            
        }
        public async Task <user_detail_view> getUser()
        {
            List<user_detail_view> parts = new List<user_detail_view>();
            var payouts = await this.database.FetchAsync<Models.user_detail>("SELECT * FROM public.user_detail", parts);

            
            return new user_detail_view
            {
                user_id = payouts[0].user_id,
                user_name = payouts[0].user_name,
                password = payouts[0].password,

            };
        }

    }
}
