using System;
using MyLibrary;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateofbirth = new DateTime(1999, 06, 05);
            DateTime dateofhiring = new DateTime(2020, 03, 15);
            Employee emp= new Employee(dateofbirth, "valeriy", "baranov", "andreevich", "SMM", dateofhiring);
            Console.WriteLine($"Имя: {emp.Name} Фамилия: {emp.LastName} Отчество: {emp.Patronymic} Возраст: {emp.Age} Стаж: {emp.Experience} Должность: {emp.Title}");
        }
    }
    class Employee : MyLibrary.MyLibrary
    {
        private int experience;
        private string title;
        public int Experience
        {
            get { return experience; }
        }
        public string Title
        {
            get { return title; }
            private set { title = value; }
        }
        public Employee(DateTime date, string name, string lastname, string patronymic, string title, DateTime dateofhiring) : base(date, name, lastname, patronymic)
        {
            if (String.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Неверная должность");
            }
            if (dateofhiring.CompareTo(DateTime.Now) > 0 || (dateofhiring.CompareTo(date) < 0))  // дата найма раньше даты рождения или в позже сегодняшней даты
            {
                throw new ArgumentException("Неверная дата найма");
            }
            Title = title;
            experience = DateTime.Now.Year - dateofhiring.Year;
            if (DateTime.Now.Month < dateofhiring.Month || (DateTime.Now.Month == dateofhiring.Month && DateTime.Now.Day < dateofhiring.Day)) experience--;
        }
    }
}
