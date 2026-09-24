using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dataAccess.Models
{
   public  class AppDb:DbContext
    {
        //AppDb acts as a bridge between C# code and SQL Server.
        //DbContext is provided by Entity Framework Core.
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {
        }
        /*This constructor receives database configuration settings 
         from Program.cs and passes them to the base DbContext class. 
         The base DbContext uses these settings to 
         establish a connection with SQL Server and manage database operations.*/

        public DbSet<Employee> Employees { get; set; }
    }
}
