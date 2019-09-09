using System;
using System.Collections.Generic;

namespace Clean.Data.Entities
{
    public partial class Homes
    {
        public Homes()
        {
            Staffs = new HashSet<Staffs>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }

        public ICollection<Staffs> Staffs { get; set; }
    }
}
