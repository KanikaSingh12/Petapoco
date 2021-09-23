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
        Task <user_detail_view> getUser();
    }
}
