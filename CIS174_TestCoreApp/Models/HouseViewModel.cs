using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class HouseViewModel
    {
        public int Id { get; set; }
        
        public int Bedrooms { get; set; }

        public double SquareFeet { get; set; }

        public DateTime DateBuilt { get; set; }

        public string Flooring { get; set; }

        public HouseViewModel(int Id, int Bedrooms, double SquareFeet, DateTime DateBuilt, string Flooring)
        {
            this.Id = Id;
            this.Bedrooms = Bedrooms;
            this.SquareFeet = SquareFeet;
            this.DateBuilt = DateBuilt;
            this.Flooring = Flooring;
        }
    }
}
