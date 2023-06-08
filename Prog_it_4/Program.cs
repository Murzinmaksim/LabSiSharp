using System;

namespace Prog_it_4
{

    // Класс 1-го уровня
    class HigherEducationInstitution
    {
        public string Name { get; set; }
        public int EnrolledStudents { get; set; }
        public int Graduates { get; set; }

        public double CalculateQuality()
        {
            return (double)Graduates / EnrolledStudents;
        }

        public void DisplayInformation()
        {
            Console.WriteLine("Higher Education Institution: " + Name);
            Console.WriteLine("Enrolled Students: " + EnrolledStudents);
            Console.WriteLine("Graduates: " + Graduates);
            Console.WriteLine("Quality: " + CalculateQuality());
        }
    }

    // Класс 2-го уровня (потомок)
    class Specialization : HigherEducationInstitution
    {
        public double PercentageEmployment { get; set; }

        public new double CalculateQuality()
        {
            return PercentageEmployment * base.CalculateQuality();
        }

        public new void DisplayInformation()
        {
            base.DisplayInformation();
            Console.WriteLine("Percentage employment: " + PercentageEmployment);
            Console.WriteLine("QualityP: " + CalculateQuality());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание объекта класса 1-го уровня
            HigherEducationInstitution university = new HigherEducationInstitution
            {
                Name = "University 1",
                EnrolledStudents = 1400,
                Graduates = 800
            };

            // Вывод информации о классе 1-го уровня
            Console.WriteLine("Class 1:");
            university.DisplayInformation();
            Console.WriteLine();

            // Создание объекта класса 2-го уровня
            Specialization specialization = new Specialization
            {
                Name = "University 2",
                EnrolledStudents = 500,
                Graduates = 400,
                PercentageEmployment = 0.85
            };

            // Вывод информации о классе 2-го уровня
            Console.WriteLine("Class 2:");
            specialization.DisplayInformation();

         

            Console.ReadLine();
        }
    }
}
