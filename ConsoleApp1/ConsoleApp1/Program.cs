using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace StudentManagementSystem
{
    public class Student
    {
        private string name;
        private List<int> grades;

        public Student(string studentName, List<int> studentGrades)
        {
            name = studentName;
            grades = studentGrades;
        }

        public string GetStudentName()
        {
            return name;
        }

        public void SetStudentname(string studentName)
        {
            name = studentName;
        }

        public List<int> GetGrades()
        {
            return grades;
        }

        public void AddGrade(int grade)
        {
            grades.Add(grade);
        }

        public double GetAverage()
        {
            if (grades.Count == 0)
                return 0;

            double sum = 0;

            foreach (int grade in grades)
            {
                sum += grade;
            }

            return sum / grades.Count;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Grades: {string.Join(", ", grades)}");
            Console.WriteLine($"Average: {GetAverage():F2}");
        }
    }

    public class StudentManager

    {
        private List<Student> students;

        public StudentManager()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public bool HasStudents()
        {
            return students.Count > 0;
        }

        public double ComputeClassAvg()
        {
            if (students.Count == 0) return 0;

            double totalAvg = 0;
            foreach (Student student in students)
            {
                totalAvg += student.GetAverage();
            }

            return totalAvg / students.Count;
        }

        public (Student topStudent, int highestGrade) FindHighestGrade()
        {
            if (students.Count == 0) return (null, -1);

            Student topStudent = null;
            int highestGrade = -1;

            foreach (Student student in students)
            {
                foreach (int grade in student.GetGrades())
                {
                    if (grade > highestGrade)
                    {
                        highestGrade = grade;
                        topStudent = student;
                    }
                }
            }

            return (topStudent, highestGrade);
        }

        public void DisplayAllStudents()
        {
            if (!HasStudents())
            {
                Console.WriteLine("No Students in the System!");
                return;
            }

            Console.WriteLine("======= ALL STUDENTS =======");
            foreach (Student student in students)
            {
                student.DisplayInfo();
                Console.WriteLine();
            }
        }
    }
    public class UI
    {
        private StudentManager _manager;
        public UI(StudentManager manager)
        {
            _manager = manager;
        }
        public void DisplayMenu()
        {
            Console.WriteLine("===== STUDENT SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Compute Average Grade");
            Console.WriteLine("4. Find Highest Grade");
            Console.WriteLine("5. Exit");
            Console.WriteLine("==========================");
            Console.Write("Choose an option: ");
        }

        public int GetMenuChoice()

        {

            string input = Console.ReadLine();

            try
            {
                return int.Parse(input);
            }

            catch

            {
                return 0;
            }

        }

        public void HandleAddStudent()

        {

            Console.WriteLine();

            Console.Write("Enter student name: ");

            string name = Console.ReadLine();

            List<int> grades = new List<int>();

            Console.Write("Enter grade 1: ");
            int grade1 = int.Parse(Console.ReadLine());
            grades.Add(grade1);

            Console.Write("Enter grade 2: ");
            int grade2 = int.Parse(Console.ReadLine());
            grades.Add(grade2);

            Console.Write("Enter grade 3: ");
            int grade3 = int.Parse(Console.ReadLine());
            grades.Add(grade3);

            Student student = new Student(name, grades);
            _manager.AddStudent(student);

            Console.WriteLine("Student added successfully!\n");

        }

        public void HandleViewAllStudents()

        {
            Console.WriteLine();
            _manager.DisplayAllStudents();

        }

        public void HandleComputeAvgGrades()

        {

            Console.WriteLine();

            if (!_manager.HasStudents())
            {
                Console.WriteLine("No student in the system.\n");
                return;
            }

            double classAverage = _manager.ComputeClassAvg();

            Console.WriteLine("===== CLASS AVERAGE =====");
            Console.WriteLine($"Overall Average Grade: {classAverage:F2}\n");

        }

        public void HandleFindHighestGrade()

        {

            Console.WriteLine();

            if (!_manager.HasStudents())

            {
                Console.WriteLine("No student in the system.\n");
                return;
            }

            (Student topStudent, int highestGrade) result = _manager.FindHighestGrade();


            Console.WriteLine("===== HIGHEST GRADE =====");

            Console.WriteLine($"Top Student: {result.topStudent.GetStudentName()}");

            Console.WriteLine($"Highest Grade: {result.highestGrade}\n");

        }
    }


    class Program
    {
        static void Main(string[] args)

        {
            StudentManager manager = new StudentManager();
            UI ui = new UI(manager);

            bool running = true;

            while (running)

            {
                ui.DisplayMenu();
                int choice = ui.GetMenuChoice();
                if (choice == 1)
                {
                    ui.HandleAddStudent();
                }
                else if (choice == 2)
                {
                    ui.HandleViewAllStudents();
                }
                else if (choice == 3)
                {
                    ui.HandleComputeAvgGrades();
                }
                else if (choice == 4)
                {
                    ui.HandleFindHighestGrade();
                }
                else if (choice == 5)
                {
                    running = false;
                    Console.WriteLine("Exiting Program...");
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid Choice. Choose 1-5 only.\n");
                }

            }

        }
    }

}

