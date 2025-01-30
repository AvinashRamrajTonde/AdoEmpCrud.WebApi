using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoEmpCrud.WebApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
        public string? Designation { get; set; }        
    }
}