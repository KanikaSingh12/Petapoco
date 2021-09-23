using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Petapoco_demoProject.Models

{
    public class BaseService
    {
        public readonly IDatabase database;
        public BaseService(IDatabase database)
        {
            this.database = database;
        
        }


    }
}
