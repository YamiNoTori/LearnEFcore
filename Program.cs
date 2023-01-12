using System;
using EFcoreLearn_0.View.Controllers;
using EFcoreLearn_0.View.Models;
using Microsoft.Extensions.Configuration;


namespace EFcoreLearn_0.View
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start!");
            DbController dbController = new(GetConfig().GetConnectionString("DbConnectString"));
            
            // GOTO нужно получить лист из ролей, и уже потом при создании присваивать
            // нужное значение свойству Person.Role
            
            Person dima = new ()
            {
                Name = "Dima",
                Age = 23,
                //Role = new PersonRole() {Name = "Admin"}
            };
            dbController.AddNewPerson(new List<Person>() {dima});

            Console.WriteLine("End. Please, click any button!");
            Console.ReadKey();
        }


        public static IConfigurationRoot GetConfig()
        {
            return (new ConfigurationBuilder()).SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
        }
    }
}