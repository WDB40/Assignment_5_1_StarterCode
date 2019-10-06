using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View(new SignUpModel());
        }

        public IActionResult CreatePerson(SignUpModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}