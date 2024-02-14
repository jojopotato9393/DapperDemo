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

            #region Exercise1
            //var departmentRepo = new DepartmentRepo(conn);
            //departmentRepo.InsertDepartment("joes new department");
            //var departments = departmentRepo.GetAllDepartments();
            //foreach (var department in departments)
            //{
            //    Console.WriteLine(department.DepartmentID);
            //    Console.WriteLine(department.Name);
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}
            #endregion

            var productRepo = new DapperProduct(conn);
            var products = productRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine(product.Price);
            }

        }
    }
}
