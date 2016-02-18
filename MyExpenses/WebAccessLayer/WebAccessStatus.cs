using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyExpenses.WebAccessLayer
{
    public class WebAccessStatus
    {
        public int StatusCode { set; get; }
        public string StatusText { set; get; }

        public WebAccessStatus(int StatusCode, string StatusText)
        {
            this.StatusCode = StatusCode;
            this.StatusText = StatusText;
        }


        
    }
}
