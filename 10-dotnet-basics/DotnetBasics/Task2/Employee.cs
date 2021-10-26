using System;

namespace Task2
{
    class Employee : User, IEquatable<Employee>
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

        public bool Equals(Employee emp)
        {
            return this.Age == emp.Age &&
                this.Name == emp.Name &&
                this.LastName == emp.LastName &&
                this.Patronymic == emp.Patronymic &&
                this.Title == emp.Title &&
                this.Experience == emp.Experience;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (this.GetType() != obj.GetType()) return false;
            return Equals((Employee)obj);
        }
    }
}
