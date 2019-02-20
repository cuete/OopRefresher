using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OopRefresher.Classes;
using OopRefresher.Interfaces;
using OopRefresher.Helpers;

namespace OopRefresher
{
    class Program
    {
        /// <summary>
        /// Main method, runs on execution
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option:\n" +
                "1.Add a mountain\n" +
                "2.Edit a mountain\n" +
                "3.Delete a mountain\n" +
                "4.List mountains\n" +
                "5.Get mountain by name\n" +
                "6.Exit\n");
            int operation = Int32.Parse(Console.ReadLine());
            string name;

            string json = GenericMethods.ReadFile("mountains.json");
            List<SmallMountain> s_mountains = GenericMethods.DeserializeToObject<SmallMountain>(json);
            SmallMountain mountain = new SmallMountain();

            switch (operation)
            {
                case (int)Operation.Add:
                    Console.Write("Name of new mountain: ");
                    mountain.name = Console.ReadLine();
                    mountain.AddItem(s_mountains, mountain);
                    break;
                case 2:
                    Console.Write("Name of mountain: ");
                    name = Console.ReadLine();
                    mountain.EditItem(s_mountains, name);
                    break;
                case 3:
                    Console.Write("Name of mountain: ");
                    name = Console.ReadLine();
                    mountain.DeleteItem(s_mountains, name);
                    break;
                case 4:
                    mountain.ListItems(s_mountains);
                    break;
                case 5:
                    Console.Write("Name of mountain: ");
                    string search = Console.ReadLine();
                    mountain.GetItem(s_mountains, search);
                    break;
                case 6:
                    Console.Write("Exiting program");
                    break;
                default:
                    throw new ArgumentException($"Invalid argument exception: {operation}");
            }
            Console.ReadKey();
        }
    }
}
