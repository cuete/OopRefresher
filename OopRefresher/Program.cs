using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            bool success;
            string name;
            string json = ReadFile("mountains.json");
            List<Mountain> mountains = new List<Mountain>(DeserializeToObject<Mountain>(json));

            switch (operation)
            {
                case (int)Operation.Add:
                    Console.Write("Name of new mountain: ");
                    name = Console.ReadLine();
                    success = AddMountain(name, mountains);
                    break;
                case 2:
                    Console.Write("Name of mountain: ");
                    name = Console.ReadLine();
                    success = EditMountain(name, mountains);
                    break;
                case 3:
                    Console.Write("Name of mountain: ");
                    name = Console.ReadLine();
                    success = DeleteMountain(name, mountains);
                    break;
                case 4:
                    //Excuse to use a non-static method ¯\_(ツ)_/¯ 
                    Program p = new Program();
                    IEnumerable<Mountain> mountainlist = p.GetMountains(mountains);
                    break;
                case 5:
                    Console.Write("Name of mountain: ");
                    string search = Console.ReadLine();
                    Mountain mountain = GetMountain(search, mountains);
                    //Console.WriteLine(JsonConvert.SerializeObject(mountain, Formatting.Indented));
                    break;
                case 6:
                    Console.Write("Exiting program");
                    break;
                default:
                    throw new ArgumentException ($"Invalid argument exception: {operation}");
            }
        }

        private static bool AddMountain(string name, List<Mountain> mountains)
        {
            //check DB if exists

            //Console.Write("Is it high mountain? y/n: ");
            //string high = Console.Read().ToString();
            //Match m = Regex.Match(high, @"y|yes", RegexOptions.IgnoreCase);
            //if (m.Success)
            //{
            //    HighMountain mountain = new HighMountain(name);
            //    //add other params
            //}
            //else
            //{

            Mountain mountain = new Mountain(name);
            mountains.Add(mountain);
            string json = SerializeToJson<Mountain>(mountains);
            UpdateFile(json, "mountains.json");
            //}
            return true;
        }

        /// <summary>
        /// Writes text to a file using streamwriter
        /// </summary>
        /// <param name="text"></param>
        /// <param name="filename"></param>
        public static void UpdateFile(string text, string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.Write(text);
            }
        }

        /// <summary>
        /// Reads text file into string using streamreader
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string ReadFile(string filename)
        {
            string text;
            using (StreamReader r = new StreamReader(filename))
            {
                text = r.ReadToEnd();
            }
            return text;
        }

        /// <summary>
        /// Generic method, passing a generic T type parameter
        /// Serialize an object collection to a JSON string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myobject"></param>
        /// <returns></returns>
        public static string SerializeToJson<T>(List<T> myobject)
        {
            return JsonConvert.SerializeObject(myobject);
        }

        /// <summary>
        /// Generic method, using generic T type parameters
        /// JSON deserialization into an object collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> DeserializeToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        private static bool EditMountain(string name, IEnumerable<Mountain> mountains)
        {
            throw new NotImplementedException();
        }

        private static bool DeleteMountain(string name, IEnumerable<Mountain> mountains)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Mountain> GetMountains(IEnumerable<Mountain> mountains)
        {
            throw new NotImplementedException();
        }

        private static Mountain GetMountain(string name, IEnumerable<Mountain> mountains)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Derived class definition
    /// </summary>
    public class HighMountain : Mountain
    {
        public HighMountain(string name) : base(name)
        {
            this.name = base.name;
            this.yds_class = YDS_Class.Class1;
            this.yds_grade = YDS_Grade.I;
            this.camps = 0;
        }
        public YDS_Class yds_class { get; set; }
        public YDS_Grade yds_grade { get; set; }
        public int camps { get; set; }
    }
    
    /// <summary>
    /// Base class definition
    /// </summary>
    public class Mountain
    {
        //Constructor
        public Mountain(string name)
        {
            this.name = name;
            this.altitude = 0;
            this.coordinates = new Coords(0, 0);
            this.dateclimbed = null;
            this.timetoclimb = null;
            this.notes = null;
        }
        public string name { get; set; }
        public int altitude { get; set; }
        public Coords coordinates { get; set; }
        public DateTime? dateclimbed { get; set; }
        public TimeSpan? timetoclimb { get; set; }
        public string notes { get; set; }
    }
    
    /// <summary>
    /// Struct definition
    /// </summary>
    public struct Coords
    {
        public float lat, lon;
        public Coords(float lat, float lon)
        {
            this.lat = lat;
            this.lon = lon;
        }
    }
    
    /// <summary>
    /// Enumerator definition
    /// </summary>
    public enum YDS_Class : int
    {
        Class1 = 1, Class2= 2, Class3 = 3, Class4 = 4, Class5 = 5
    }
    public enum YDS_Grade
    {
        I, II, III, IV, V, VI, VII
    }
    public enum Operation : int
    {
        Add = 1, Edit = 2, Delete = 3, List = 4, Get = 5
    }
}
