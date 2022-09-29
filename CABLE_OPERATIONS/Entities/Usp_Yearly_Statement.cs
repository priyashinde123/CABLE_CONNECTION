using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CABLE_OPERATIONS.Entities
{
    public class Usp_Yearly_Statement
    {
      public  int monthid { get; set; }

      public  string month { get; set; }
     
      public  int? year { get; set; }

      public  string month_ { get; set; }
      public DateTime? payment_date { get; set; }

      public  int? paid_amount { get; set; }
    }
}
