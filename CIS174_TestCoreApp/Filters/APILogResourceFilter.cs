using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _log;

        public APILogResourceFilter(IConfiguration config, ILogger<APILogResourceFilter> log)
        {
            _config = config;
            _log = log;
            Boolean.TryParse(_config["APILogging"], out isEnabled);
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            if (isEnabled)
            {
                _log.LogInformation("Person API Controller Action Method Has Completed.");
            }
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {

            if (isEnabled)
            {
                _log.LogInformation("Person API Controller Action Method Has Started.");
                context.HttpContext.TraceIdentifier = Guid.NewGuid().ToString();
            }
        }
    }

    public class APILogResourceAttribute : TypeFilterAttribute
    {
        public APILogResourceAttribute() : base(typeof(APILogResourceFilter)) { }
    }
}
