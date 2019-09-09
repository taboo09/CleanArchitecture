using System;
using System.Collections.Generic;

namespace Clean.Data.Entities
{
    public partial class Qualifications
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Grade { get; set; }
        public DateTime Date { get; set; }
        public int StaffId { get; set; }

        public Staffs Staff { get; set; }
    }
}
