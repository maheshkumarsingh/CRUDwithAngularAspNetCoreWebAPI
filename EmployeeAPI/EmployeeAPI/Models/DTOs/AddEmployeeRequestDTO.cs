using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models.DTOs
{
    public class AddEmployeeRequestDTO
    {
        [Required]
        public string? EmployeeName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public string? Department { get; set; }
        [Required]
        public string? Designation { get; set; }
        [Required]
        public double? BasicSalary { get; set; }
    }
}
