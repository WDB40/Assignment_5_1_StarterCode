using CIS174_TestCoreApp.Models;
using CIS174_TestCoreApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Filters
{
    public class UpdatePersonFilter : IActionFilter
    {

        PersonAccomplishmentDBHelper _dBHelper;
        private readonly ILogger _log;

        public UpdatePersonFilter(PersonAccomplishmentDBHelper dBHelper, ILogger<UpdatePersonFilter> log)
        {
            _dBHelper = dBHelper;
            _log = log;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Intentionally left blank.
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Person person = (Person)context.ActionArguments["person"];

            PersonAccomplishmentCommand oldPerson = _dBHelper.GetPerson(person.PersonID);

            if(oldPerson == null)
            {
                _log.LogWarning("The following Person ID was not found: {personID}", person.PersonID);
                context.Result = new BadRequestObjectResult("Person not found.");

            }
            else if(!person.FirstName.Equals(oldPerson.FirstName) || !person.LastName.Equals(oldPerson.LastName))
            {
                _log.LogWarning("A user attempted to updated the following name: {lastName}, {firstName}", person.LastName, person.FirstName);
                context.Result = new BadRequestObjectResult("Cannot update a person's name.");
            }

        }
    }

    public class UpdatePersonAttribute : TypeFilterAttribute
    {
        public UpdatePersonAttribute() : base(typeof(UpdatePersonFilter)) { }
    }
}
