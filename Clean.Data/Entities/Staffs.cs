using System;
using System.Collections.Generic;

namespace Clean.Data.Entities
{
    public partial class Staffs
    {
        public Staffs()
        {
            Qualifications = new HashSet<Qualifications>();
        }

        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JobTitle { get; set; }
        public decimal AnnualSalary { get; set; }
        public int HomeId { get; set; }

        public Homes Home { get; set; }
        public ICollection<Qualifications> Qualifications { get; set; }
    }
}
