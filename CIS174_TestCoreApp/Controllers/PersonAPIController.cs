using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Filters;
using CIS174_TestCoreApp.Models;
using CIS174_TestCoreApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    [Route("api/person")]
    [ApiController]
    [ValidateModel]
    [APILogResource]
    public class PersonAPIController : ControllerBase
    {
        private PersonAccomplishmentDBHelper _dbHelper;

        public PersonAPIController(PersonAccomplishmentDBHelper personAccomplishmentDBHelper)
        {
            _dbHelper = personAccomplishmentDBHelper;
        }

        [HttpPost("CreatePerson")]
        public IActionResult CreatePerson([FromBody] Person person)
        {

            Person created = _dbHelper.CreatePerson(person);
            return RedirectToAction("GetAllPersons");
        }

        [HttpGet("GetPerson/{id}")]
        public IActionResult GetPerson([FromRoute] int id)
        {

            PersonAccomplishmentCommand person = _dbHelper.GetPerson(id);

            if(person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpGet("GetAllPersons")]
        public IActionResult GetAllPersons()
        {
            ISet<PersonAccomplishmentCommand> persons = _dbHelper.GetAllPersons();

            return Ok(persons);
        }

        [UpdatePerson]
        [HttpPost("UpdatePerson")]
        public IActionResult UpdatePerson([FromBody] Person person)
        {

            _dbHelper.UpdatePerson(person);

            return Ok(person);
        }

        [HttpPost("DeletePerson/{id}")]
        public IActionResult DeletePerson([FromRoute] int id)
        {

            _dbHelper.DeletePerson(id);

            return RedirectToAction("GetAllPersons");
        }

        [HttpGet("error")]
        public IActionResult ThrowError()
        {
            throw new Exception();
        }
    }
}