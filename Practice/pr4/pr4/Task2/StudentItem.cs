using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr4.Task2
{
    public class StudentItem
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double AverageScore { get; set; }


        public StudentItem(string name, int age, double averageScore)
        {
            Name = name;
            Age = age;
            AverageScore = averageScore;
        }
    }
}
