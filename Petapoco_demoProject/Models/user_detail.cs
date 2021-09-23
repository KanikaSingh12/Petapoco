
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petapoco_demoProject.Models
{
    public class user_detail
    {
        [Column("user_id")]
        public int user_id { get; set; }

        [Column("user_name")]
        public string user_name { get; set; }

        [Column("password")]
        public string password { get; set; }
    }
}
