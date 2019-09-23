using System;
using System.ComponentModel.DataAnnotations;

namespace Clean.Infrastructure.Dtos
{
    public class QualDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Type { get; set; }
        public double Grade { get; set; }

        [Required]
        public DateTime? Date { get; set; }
        public int StaffId { get; set; }
    }
}