using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clean.Data.Dtos
{
    public class HomeDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }
        public ICollection<StaffDto> Staffs { get; set; }
    }
}