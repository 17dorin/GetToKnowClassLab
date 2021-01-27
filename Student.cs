using System;
using System.Collections.Generic;
using System.Text;

namespace GetToKnowClass
{
    public class Student
    {
        public string Name { get; set; }
        public string Hometown { get; set; }
        public string FavoriteFood { get; set; }
        public string FavoriteColor { get; set; }

        public Student(string name, string town, string food)
        {
            Name = name;
            Hometown = town;
            FavoriteFood = food;
        }
    }
}
