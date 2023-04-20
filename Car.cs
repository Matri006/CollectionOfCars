using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using SQLitePCL;
using SQLite;


namespace Cars_Collection
{
    
    class Car
    {
        public int Id { get; set;}
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string Country { get; set; }
        public Car()
        {
        }
        public Car(string mark, string model, int year, string type, string color, string country)
        {
         
            Mark = mark;
            Model = model;
            Year = year;
            Type = type;
            Color = color;
            Country = country;
        }
         public Car(int id, string mark, string model, int year, string type, string color, string country)
        {
            Id = id;
            Mark = mark;
            Model = model;
            Year = year;
            Type = type;
            Color = color;
            Country = country;
        }
    }
}

