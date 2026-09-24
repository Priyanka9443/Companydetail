using dataAccess.Interfaces;
using dataAccess.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace dataAccess.BusinessLogic
{
   public class EmployeeBl:IEmployee
    {
        public readonly AppDb _db;
        public EmployeeBl(AppDb db)
        {
            _db = db;
        }

        public async Task AddEmployee(Employee data)
        {
            await _db.Employees.AddAsync(data);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetEmployee()
        {
            return await _db.Employees.AsNoTracking().ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var res = await _db.Employees.FirstOrDefaultAsync(x => x.id == id);
            if (res == null)
            {
                throw new Exception("Employee not found");
            }
            return res;
        }

        public async Task EditEmployee(Employee data)
        {
            var res=await _db.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.id == data.id);
            var result = new dataAccess.Models.Employee
            {
                id = res.id,
                name = data.name,
                email = data.email,
                password = data.password


            };
            _db.Employees.Update(result);
            await _db.SaveChangesAsync();


        }

        public async Task DeleteEmployee(int id)
        {
            var res = await _db.Employees.FindAsync(id);
            if (res != null)
            {
                _db.Employees.Remove(res);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> EmployeeLogin(Login data)
        {
            var res = await _db.Employees.AnyAsync(x => x.email == data.email && x.password == data.password);
            return res;
        }       
    }   
}
