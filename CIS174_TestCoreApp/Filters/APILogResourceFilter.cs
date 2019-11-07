using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Filters
{
    public class APILogResourceFilter : IResourceFilter
    {

        private readonly IConfiguration _config;
        private bool isEnabled;

        public APILogResourceFilter(IConfiguration config)
        {
            _config = config;
            Boolean.TryParse(_config["APILogging"], out isEnabled);
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            if (isEnabled)
            {
                Debug.WriteLine("Person API Controller Action Method Has Completed.");
            }
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {

            if (isEnabled)
            {
                Debug.WriteLine("Person API Controller Action Method Has Started.");
                context.HttpContext.TraceIdentifier = Guid.NewGuid().ToString();
            }
        }
    }

    public class APILogResourceAttribute : TypeFilterAttribute
    {
        public APILogResourceAttribute() : base(typeof(APILogResourceFilter)) { }
    }
}
