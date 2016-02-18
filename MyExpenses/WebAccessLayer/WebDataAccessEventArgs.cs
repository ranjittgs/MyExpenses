using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.WebAccessLayer
{
   public class WebDataAccessEventArgs : EventArgs 
    {
       public WebAccessStatus WebAccessStatus { set; get; }
       public string Data { set; get; }

       public object PayLoad { set; get; }
       public WebDataAccessEventArgs(WebAccessStatus status,string data,object payLoad)
       {
           this.WebAccessStatus = status;
           this.Data = data;
           this.PayLoad = payLoad;
       }


    }
}
