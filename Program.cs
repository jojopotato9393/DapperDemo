using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.IO;
           
           

namespace DapperDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //^^^^MUST HAVE USING DIRECTIVES^^^^

            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var departmentRepo = new DepartmentRepo(conn);
            departmentRepo.InsertDepartment("joes new department");
            var departments = departmentRepo.GetAllDepartments();
            foreach (var department in departments)
            {
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
