using dataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dataAccess.Interfaces
{
    public interface IEmployee
    {
        Task AddEmployee(Employee data);
        Task<List<Employee>> GetEmployee();
        Task<Employee> GetEmployeeById(int id);
        Task EditEmployee(Employee data);
        Task DeleteEmployee(int id);
        Task<bool> EmployeeLogin(Login data);



    }
}
