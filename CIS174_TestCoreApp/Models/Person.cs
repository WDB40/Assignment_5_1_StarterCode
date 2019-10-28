using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class Person
    {
        public int PersonID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(25)]
        public string State { get; set; }
        public ICollection<Accomplishment> Accomplishments { get; set; }

        public bool IsDeleted { get; set; }
    }
}
