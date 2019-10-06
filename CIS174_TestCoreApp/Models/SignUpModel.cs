using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class SignUpModel
    {

        [Required]
        [Display(Name = "First Name")]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(25)]
        [MinLength(2)]
        public string LastName { get; set; }

        [Range(1,120)]
        public int Age { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2018")]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords must match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Country { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(value:"USA", text:"USA"),
            new SelectListItem(value:"Mexico", text:"Mexico"),
            new SelectListItem(value:"Canada", text:"Canada")
        };
    }
}
