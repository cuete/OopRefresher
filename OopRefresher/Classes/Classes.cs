using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OopRefresher.Classes
{    
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