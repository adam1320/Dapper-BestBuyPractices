
using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace BestBuyPractices
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Configuration
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            #endregion

            IDbConnection connection = new MySqlConnection(connString);
            var repo = new DapperProductRepository(connection);

            //repo.CreateProduct("RC car", 199.99, 1);

            //repo.UpdateProductName(940, "Traxxas RC Truck");

            var products = repo.GetAllProducts();

            foreach (var item in products)
            { Console.WriteLine($"{item.CategoryID}, {item.Name}, {item.Price}"); }
           /* DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Hello user, herre are the current departments:");
            Console.Write("Please press enter");
            Console.ReadLine();
            var depos = repo.GetAllDepartments();
            Print(depos);
           
            Console.WriteLine("Do you want to add a department?");
            string userResponse = Console.ReadLine();
            if (userResponse.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of your new department?");
                userResponse = Console.ReadLine();
                repo.InsertDepartment(userResponse);
               Print(repo.GetAllDepartments());
            }
            Console.WriteLine("Have a great day!");
           */

          

        }
        /*private static void Print(IEnumerable<Department> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"ID: {depo.DepartmentID} Name: {depo.Name}");
            }
        }*/

    }
}
