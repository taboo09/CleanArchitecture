using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clean.Infrastructure.Dtos
{
    public class StaffDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Forename { get; set; }

        [Required]
        [StringLength(255)]
        public string Surname { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }
        public string JobTitle { get; set; }

        [Range(0.00, 999999.00,
            ErrorMessage = "Salary must be less than 1 mil")]
        public decimal AnnualSalary { get; set; }
        public int HomeId { get; set; }
        public ICollection<QualDto> Qualifications { get; set; }
    }
}