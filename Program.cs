using System;
using System.Collections.Generic;
using System.Linq;

namespace GetToKnowClass
{
    class Program
    {
        static void Main(string[] args)
        {
            bool askAgain = true;
            //Ordered raw data for students, declaring the cohort dictionary to store Student objects
            List<string> names = new List<string>() { "Ramon", "Antonio", "Joshua", "Nick", "Jeremiah", "Wendi", "Juliana", "Nathaniel", "Tommy", "Grace", "Jeffrey", "Josh", "Stephen" };
            List<string> towns = new List<string>() { "Tigard, OR", "Beverly Hills, MI", "Novi, MI", "Canton, MI", "Crystal, MI", "Detroit, MI", "Denver, CO", "Berkley, MI", "Raleigh, NC", "Mesa, AZ", "Detroit, MI", "Baldwin, MI", "The Moon, ??" };
            List<string> foods = new List<string>() { "Burgers", "Focaccia Barese", "Nalesniki", "Tacos", "Burgers", "Salami", "Tacos", "Steak", "Chicken Curry", "Sweet Potato Fries", "Steak", "Falafel", "Mooncakes" };
            Dictionary<int, Student> cohort = new Dictionary<int, Student>();

            //Initialize Student objects based on the ordered data, store them in cohort
            int i = 0;
            foreach(string name in names)
            {
                Student student = new Student(names[i], towns[i], foods[i]);
                cohort.Add(i, student);
                i++;
            }

            Console.WriteLine("Dictionary created");
            Console.WriteLine("Welcome to the student finder");

            while(askAgain)
            {
                string input;
                input = GetInput("Which student do you want to know about? (Enter a number 1-12 or their name");
                try
                {
                    if()
                }
            }
        }

        public static string GetInput(string display)
        {
            Console.WriteLine(display);
            string input = Console.ReadLine();
            return input;
        }
    }
}
