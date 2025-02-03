using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdoEmpCrud.WebApi.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [RegularExpression(@"^(?![\s])[a-zA-Z]+(?:\s[a-zA-Z]+)*(?<!['\s])$",
        ErrorMessage = "Invalid input. Use only alphabetic characters with single spaces between words.")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Age must be greater than zero.")]
        public int Age { get; set; }

        [StringLength(20, ErrorMessage = "Enter Role.")]
        public string? Role { get; set; }
    }
}