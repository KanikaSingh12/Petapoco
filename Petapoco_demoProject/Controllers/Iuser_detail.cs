using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Petapoco_demoProject.Models;
namespace Petapoco_demoProject.Controllers
{
    public interface Iuser_detail
    {
        Task<List<user_detail_view>> getUser();

        Task<user_detail_view> getAUser(int id);
        Task<string> Insertuser(user_detail_view user);
        Task<string> Updateuser(int id ,string username,string password );
        Task<string> Deleteuser(int id);


    }
}
