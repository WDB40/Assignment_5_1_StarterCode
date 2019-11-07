using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class ErrorLog
    {
        public int ErrorLogID { get; set; }
        public string ResponseId { get; set; }
        public DateTime ErrorDateTime { get; set; }
        public string StatusCode { get; set; }
        public string ExceptionMessage { get; set; }
        public string StrackTrace { get; set; }
    }
}
