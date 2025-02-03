using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoEmpCrud.WebApi.Models;

namespace AdoEmpCrud.WebApi.Data.Core
{
    public interface IEmployeeRepository
    {
        // Method Signature
        // 1. Access Modifier 2. Return Type
        //3. Method Name 4. Parameter List
        // Interface only has Only  Method Declaration.

        public List<Employee> GetEmployees();
        public Employee GetEmpById(int Id);
        public bool AddEmployee(Employee employee);
        public bool UpdateEmployee(int Id, Employee employee);
        public bool DeleteEmployee(int Id);
    }
}