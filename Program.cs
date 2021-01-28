using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

//For one of the build specifications for the lab, I'm not sure where I would've incorporated catches for IndexOutOFRangeException and FormatException, as
//the methods I used do not throw exceptions of those types (as far as I can tell)
namespace GetToKnowClass
{
    class Program
    {
        static void Main(string[] args)
        {
            bool findStudent = true;
            bool findInfo = true;
            Random r = new Random();
            //Ordered raw data for students, declaring the cohort dictionary to store Student objects
            List<string> names = new List<string>() { "Ramon", "Antonio", "Joshua", "Nick", "Jeremiah", "Wendi", "Juliana", "Nathaniel", "Tommy", "Grace", "Jeffrey", "Josh", "Stephen" };
            List<string> towns = new List<string>() { "Tigard, OR", "Beverly Hills, MI", "Novi, MI", "Canton, MI", "Crystal, MI", "Detroit, MI", "Denver, CO", "Berkley, MI", "Raleigh, NC", "Mesa, AZ", "Detroit, MI", "Baldwin, MI", "The Moon, ??" };
            List<string> foods = new List<string>() { "Burgers", "Focaccia Barese", "Nalesniki", "Tacos", "Burgers", "Salami", "Tacos", "Steak", "Chicken Curry", "Sweet Potato Fries", "Steak", "Falafel", "Mooncakes" };
            List<string> colors = new List<string>() { "Red", "Blue", "Green", "Yellow", "Orange", "Pink", "Purple", "Black", };
            Dictionary<int, Student> cohort = new Dictionary<int, Student>();
            Student foundStudent = null;

            //Initialize Student objects based on the ordered data, store them in cohort
            int i = 0;
            foreach(string name in names)
            {
                int color = r.Next(colors.Count);
                Student student = new Student(i + 1, names[i], towns[i], foods[i], colors[color]);
                cohort.Add(i, student);
                i++;
            }

            Console.WriteLine("Dictionary created");
            Console.WriteLine("Welcome to the student finder");

            while(true)
            {
                //Attempts to find a Student using GetStudent. Will loop until it finds a student
                while (findStudent)
                {
                    string input;
                    try
                    {
                        input = GetInput("Which student do you want to know about? (Enter a number 1-13 or their first name)").Trim();
                        foundStudent = GetStudent(cohort, input);
                        findStudent = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }

                    Console.WriteLine("Student found!");
                }

                //Attempts to find valid info using GetInput. Will loop until it gets valid input to display info
                while (findInfo)
                {
                    string input2;
                    try
                    {
                        input2 = GetInput($"What would you like to know about {foundStudent.Name}? (Enter \"Hometown\", \"Favorite food\", or \"Favorite Color\")").Trim();
                        GetInfo(foundStudent, input2);
                        findInfo = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Information not found");
                        Console.WriteLine(e.Message);
                    }
                }

                //Asks user if they want to look for more students
                string input3 = GetInput("Would you like to search for another student? (y/n)").Trim();
                if (input3 == "n")
                {
                    break;
                }
                else
                {
                    findInfo = true;
                    findStudent = true;
                }
            }
        }

        //Gets input from the user, taking in the string you want to display
        public static string GetInput(string display)
        {
            Console.WriteLine(display);
            string input = Console.ReadLine();
            return input;
        }

        //Gets a Student out of the cohort dictionary, comparing data from each Student against the input string. Will throw an exception if a student is not found
        public static Student GetStudent(Dictionary<int, Student> classmates, string input)
        {
            Student foundStudent = null;
            if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
            {
                foreach (KeyValuePair<int, Student> student in classmates)
                {
                    if (student.Value.Name.ToLower().Equals(input.ToLower()))
                    {
                        foundStudent = classmates[student.Value.StudentNumber - 1];
                    }
                    else if (int.TryParse(input, out int i))
                    {
                        if (i - 1 >= 0 || i - 1 <= 12)
                        foundStudent = classmates[i - 1];
                    }
                }

                if(foundStudent == null)
                {
                    throw new Exception("Student not found. Please try again.");
                }
                return foundStudent;
            }
            else
            {
                throw new Exception("Input cannot be blank. Please try again.");
            }
        }

        //Gets information about a Student, comparing the input string to a number of valid answers
        public static void GetInfo(Student student, string input)
        {
            if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
            {
                if (input.ToLower().Equals("hometown"))
                {
                    Console.WriteLine($"{student.Name}'s hometown is {student.Hometown}");
                }
                else if (input.ToLower().Equals("favorite food"))
                {
                    Console.WriteLine($"{student.Name}'s favorite food is {student.FavoriteFood}");
                }
                else if (input.ToLower().Equals("favorite color"))
                {
                    Console.WriteLine($"{student.Name}'s favorite color is {student.FavoriteColor}");
                }
                else
                {
                    throw new Exception("Invalid input. Please enter one of the options");
                }
            }
        }
    }
}
