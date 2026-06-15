using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    class Student
    {
        public string name {  get; set; }
        public List<int> Grades { get; set; }

        public Student(string name, List<int> grades)
        {
            Name = name;
            Grades = grades;
        }

        public double GetAverage()
        {
            if (Grades.Count == 0) return 0;
            double sum = 0;
            foreach (int grade in Grades) 
            { 
                sum += grade; 
            } 
            return sum / Grades.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }