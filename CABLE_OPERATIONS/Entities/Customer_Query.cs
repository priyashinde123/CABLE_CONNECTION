using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CABLE_OPERATIONS.Entities
{
    public  class Customer_Query
    {  
      public  int id;
      public  int customer_id;
      public  int agent_id;
      public  string query;
      public  int query_statusid;
     public   DateTime created_date;
     public   DateTime resolved_date;
     public   string resolved_by;
    }
}
