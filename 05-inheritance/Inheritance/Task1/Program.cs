using System;
using MyLibrary;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateofbirth = new DateTime(2000, 06, 05);
            DateTime dateofhiring = new DateTime(2010, 03, 15);
            Employee emp= new Employee(dateofbirth, "valeriy", "baranov", "andreevich", "SMM", dateofhiring);
            Console.WriteLine($"Имя: {emp.Name} Фамилия: {emp.LastName} Отчество: {emp.Patronymic} Возраст: {emp.Age} Стаж: {emp.Experience} Должность: {emp.Title}");
           
        }
    }
    class Employee : MyLibrary.User
    {
        private DateTime dateofhiring; 
       
        public int Experience  // вычисление здесь
        {
            get 
            {
                DateTime today = DateTime.Today;
                int experience = today.Year - dateofhiring.Year;
                if (today.Month < dateofhiring.Month || (today.Month == dateofhiring.Month && today.Day < dateofhiring.Day)) experience--;
                return experience;
            }
        }
        public string Title { get; }
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
            this.dateofhiring = dateofhiring;
            this.Title = title;
        }
    }
}
