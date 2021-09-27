
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petapoco_demoProject.Models
{
    public class user_detail_view
    {
        public user_detail_view()
        { 
        }
        
        public int user_id { get; set; }

       
        public string user_name { get; set; }

       
        public string password { get; set; }
    }
}
