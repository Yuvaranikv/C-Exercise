using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlay
{
    internal class SportsPlayer
    {
        public string Name { get; set; }
        public string Sport { get; set; }
        public int YearsExperience { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        // Constructor
        public SportsPlayer(string name, string sport, int yearsExperience, int age, string position)
        {
            Name = name;
            Sport = sport;
            YearsExperience = yearsExperience;
            Age = age;
            Position = position;
        }


        public void PrintPlayerInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Sport: {Sport}");
            Console.WriteLine($"Years of Experience: {YearsExperience}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Position: {Position}");
            Console.WriteLine();
        }

        

    }
}
