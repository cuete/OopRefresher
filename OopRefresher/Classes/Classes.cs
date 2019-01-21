using System;
using System.Collections.Generic;
using OopRefresher.Interfaces;
using OopRefresher.Helpers;

namespace OopRefresher.Classes
{
    public class SmallMountain : IItem<SmallMountain>
    {
        public SmallMountain(string name)
        {
            this.name = name;
            this.altitude = 0;
            this.coordinates = new Coords(0, 0);
            this.dateclimbed = null;
            this.timetoclimb = null;
            this.notes = null;
        }
        public SmallMountain() { }
        public string name { get; set; }
        public int altitude { get; set; }
        public Coords coordinates { get; set; }
        public DateTime? dateclimbed { get; set; }
        public TimeSpan? timetoclimb { get; set; }
        public string notes { get; set; }

        public void AddItem(List<SmallMountain> mountains, SmallMountain mountain)
        {
            mountains.Add(mountain);
            string json = GenericMethods.SerializeToJson(mountains);
            GenericMethods.UpdateFile(json, "mountains.json");
        }

        public void EditItem(List<SmallMountain> mountains, string name)
        {
            //Implement edit logic
        }

        public void DeleteItem(List<SmallMountain> mountains, string name)
        {
            //Implement delete logic
        }

        public SmallMountain GetItem(List<SmallMountain> mountains, string name)
        {
            SmallMountain mountain = new SmallMountain(name);
            //Implement search logic
            return mountain;
        }

        public void ListItems(List<SmallMountain> mountains)
        {
            //Implement show logic
        }
    }

    /// <summary>
    /// Update this to use IMountain interface
    /// </summary>
    //public class HighMountain : Mountain
    //{
    //    public HighMountain(string name) : base(name)
    //    {
    //        this.name = base.name;
    //        this.yds_class = YDS_Class.Class1;
    //        this.yds_grade = YDS_Grade.I;
    //        this.camps = 0;
    //    }
    //    public YDS_Class yds_class { get; set; }
    //    public YDS_Grade yds_grade { get; set; }
    //    public int camps { get; set; }
    //}

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
        Class1 = 1, Class2 = 2, Class3 = 3, Class4 = 4, Class5 = 5
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
