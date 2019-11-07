using CIS174_TestCoreApp.Models;
using CIS174_TestCoreApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Filters
{
    public class UpdatePersonFilter : IActionFilter
    {

        PersonAccomplishmentDBHelper _dBHelper;

        public UpdatePersonFilter(PersonAccomplishmentDBHelper dBHelper)
        {
            _dBHelper = dBHelper;
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
                context.Result = new BadRequestObjectResult("Person not found.");

            }
            else if(!person.FirstName.Equals(oldPerson.FirstName) || !person.LastName.Equals(oldPerson.LastName))
            {
                context.Result = new BadRequestObjectResult("Cannot update a person's name.");
            }

        }
    }

    public class UpdatePersonAttribute : TypeFilterAttribute
    {
        public UpdatePersonAttribute() : base(typeof(UpdatePersonFilter)) { }
    }
}
