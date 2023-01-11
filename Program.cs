using System;
using EFcoreLearn_0.View.Controllers;
using EFcoreLearn_0.View.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace EFcoreLearn_0.View
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start!");
            DbController dbController = new(GetConfig().GetConnectionString("DbConnectString"));
            List<PersonRole> list = dbController.GetAllPersonRole();



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