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
            List<Mountain> mountains = new List<Mountain>();
            using (StreamReader r = new StreamReader("mountains.json"))
            {
                string json = r.ReadToEnd();
                mountains = Deserialize<Mountain>(json);
            }

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
            switch (operation)
            {
                case 1:
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
                    break;
            }
        }

        /// <summary>
        /// Generic method, using generic T type parameters
        /// JSON deserialization into an object collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        private static bool AddMountain(string name, IEnumerable<Mountain> mountains)
        {
            //check DB if exists
            Console.Write("Is it high mountain? y/n: ");
            string high = Console.Read().ToString();
            Match m = Regex.Match(high, @"y|yes", RegexOptions.IgnoreCase);
            if (m.Success)
            {
                HighMountain mountain = new HighMountain(name);
                //add other params
            }
            else
            {
                Mountain mountain = new Mountain(name);
                //add to list
            }
            //Update DB
            return true;
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
            this.dateclimbed = DateTime.Now;
            this.timetoclimb = TimeSpan.Parse("");
            this.notes = null;
        }
        public string name { get; set; }
        public int altitude { get; set; }
        public Coords coordinates { get; set; }
        public DateTime dateclimbed { get; set; }
        public TimeSpan timetoclimb { get; set; }
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
        I, II, III, IV, V, VI, VII, 
    }
}
