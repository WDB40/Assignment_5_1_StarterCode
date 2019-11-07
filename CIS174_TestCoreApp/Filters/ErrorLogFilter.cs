using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Filters
{
    public class ErrorLogFilter : IExceptionFilter
    {
        private ErrorLogDbContext _dbContext;

        public ErrorLogFilter(ErrorLogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnException(ExceptionContext context)
        {

            Debug.WriteLine("---------------Exception Encountered---------------");
            ErrorLog error = new ErrorLog();
            error.ResponseId = context.HttpContext.TraceIdentifier.ToString();
            error.ErrorDateTime = DateTime.UtcNow;
            error.StatusCode = context.HttpContext.Response.StatusCode.ToString();
            error.ExceptionMessage = context.Exception.Message.ToString();
            error.StrackTrace = context.Exception.StackTrace.ToString();

            _dbContext.Add(error);
            _dbContext.SaveChanges();

            Debug.WriteLine("---------------Exception Logged---------------");

            context.ExceptionHandled = true;
            context.Result = new ObjectResult(error);
        }
    }
}
