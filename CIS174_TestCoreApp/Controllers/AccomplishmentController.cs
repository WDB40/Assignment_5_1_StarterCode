using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models;
using CIS174_TestCoreApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    public class AccomplishmentController : Controller
    {

        PersonAccomplishmentDBHelper _helper;

        public AccomplishmentController(PersonAccomplishmentDBHelper helper)
        {
            _helper = helper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(PersonAccomplishmentCommand input)
        {

            if (!ModelState.IsValid)
            {
                return View("Index", input);
            }
            else
            {
                Person person = MapPerson(input);
                person = _helper.CreatePerson(person);

                return RedirectToAction("AllPersons");
            }
        }

        public ViewResult AllPersons()
        {
            return View(_helper.GetAllPersons());
        }

        public ViewResult Details(int id)
        {
            return View(_helper.GetPerson(id));
        }

        [HttpGet]
        public ViewResult EditPerson(int id)
        {
            return View(_helper.GetPerson(id));
        }

        [HttpPost]
        public IActionResult EditPerson(PersonAccomplishmentCommand input)
        {

            if (!ModelState.IsValid)
            {
                return View("EditPerson", input);
            }
            else
            {
                Person newPerson = MapPerson(input);
                newPerson.PersonID = input.PersonID;
                _helper.UpdatePerson(newPerson);

                return RedirectToAction("AllPersons");
            }
        }

        public RedirectToActionResult DeletePerson(int id)
        {
            _helper.DeletePerson(id);
            return RedirectToAction("AllPersons");
        }

        public Person MapPerson(PersonAccomplishmentCommand input)
        {
            Person person = new Person
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Birthdate = input.Birthdate,
                City = input.City,
                State = input.State,
                Accomplishments = input.Accomplishments?.Select(accomplishment =>
                    new Accomplishment
                    {
                        Name = accomplishment.Name,
                        DateOfAccomplishment = accomplishment.DateOfAccomplishment
                    }).ToHashSet()
            };

            return person;
        }
    }
}