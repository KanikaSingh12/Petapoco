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
        public async Task <List<user_detail_view>> getUser()
        {
            List<user_detail_view> parts = new List<user_detail_view>();
            var payouts = await this.database.FetchAsync<Models.user_detail>("SELECT * FROM public.user_detail", parts);
            List<user_detail_view> part = new List<user_detail_view>();
            for (int i = 0; i < payouts.Count; i++)
            {
                user_detail_view  obj1= new user_detail_view();
                obj1.user_id = payouts[i].user_id;
                obj1.user_name = payouts[i].user_name;
                obj1.password = payouts[i].password;

                part.Add(obj1);
            }

            return part;
              
        }

        public async Task<user_detail_view> getAUser(int id)
        {
            List<user_detail_view> parts = new List<user_detail_view>();
            var payouts = await this.database.FetchAsync<Models.user_detail>("SELECT * FROM public.user_detail where user_id='"+id+"'", parts);
            return new user_detail_view {
                user_id = payouts[0].user_id,
            password = payouts[0].password,
            user_name = payouts[0].user_name
            };

        }
        public async Task<string> Insertuser(user_detail_view users)
        {
            user_detail u = new user_detail();
            u.user_id = users.user_id;
            u.user_name = users.user_name;
            u.password = users.password;

            await this.database.InsertAsync(u);
            return "success";
        }
        
        public async Task<string> Deleteuser(int id)
        {
            user_detail u = new user_detail();
            
            u.user_id = id;
            u.user_name = "";
            u.password = "";


            await this.database.DeleteAsync("user_detail", "user_id", u);
                
            return "success";
        }
        
            public async Task<string> Updateuser(int id,string username,string password)
        {
            user_detail u = new user_detail();

            u.user_id = id;
            u.user_name = username;
            u.password = password;


            await this.database.UpdateAsync("user_detail", "user_id",u); 
                

            return "success";
        }
    }
}
