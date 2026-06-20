    

class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
namespace StudentManagementSystem
{
    class Student
    {
        private string name;
        private List<int> grades;

        public Student(string studentName, List<int> studentGrades)
        {
            name = studentName;
            grades = studentGrades;
        }

        public string GetName()
        {
            return name;
        }

        public List<int> GetGrades() 
        {
            return grades;
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

}