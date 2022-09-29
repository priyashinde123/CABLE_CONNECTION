using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CABLE_OPERATIONS.Entities
{
    public class Customer
    {
     public   int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
       public string contact { get; set; }
        public string address { get; set; }
        public int  package_id { get; set; }
      public int status_id { get; set; }
        public DateTime connection_date { get; set; }
        public int  gid { get; set; }
       public int  city_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
    }
}
