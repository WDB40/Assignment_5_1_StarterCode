using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CIS174_TestCoreApp.Models
{
    public class CreatePersonViewModel
    {
        [Display(Name = "First Name")]
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(25)]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        [Range(1, 120)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Confirm Email")]
        [Required]
        [Compare(nameof(Email), ErrorMessage = "Email address must match.")]
        public string ConfirmEmail { get; set; }

        [Url]
        [MinLength(7)]
        public string Website { get; set; }

        //I tried both of these, but they were still editable on the page.
        //I'm guessing that it technically isn't editable on the server side, so UI can still mess with it, but the new value doesn't get passed?
        //[ReadOnly(true)]
        [Editable(false)]
        public string School { get; set; }
    }
}
