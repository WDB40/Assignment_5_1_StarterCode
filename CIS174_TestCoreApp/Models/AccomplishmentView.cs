using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class AccomplishmentView
    {
        public int AccomplishmentID { get; set; }
        public int PersonID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfAccomplishment { get; set; }
    }
}
