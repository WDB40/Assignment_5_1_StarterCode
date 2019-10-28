using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class Accomplishment
    {
        public int AccomplishmentID { get; set; }
        public int PersonID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public DateTime DateOfAccomplishment { get; set; }
    }
}
