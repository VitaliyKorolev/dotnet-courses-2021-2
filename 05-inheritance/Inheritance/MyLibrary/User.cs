using System;

namespace MyLibrary
{
    public class  User
    {

        private DateTime dateofbirth;
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Patronymic { get; private set; }
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - dateofbirth.Year;
                if (today.Month < dateofbirth.Month || (today.Month == dateofbirth.Month && today.Day < dateofbirth.Day)) age--;
                return age;
            }
        }
        public User(DateTime date, string name, string lastname, string patronymic)
        {
            if (date.Year > 2020 || date.Year < 1900) { throw new Exception("Недопустимая дата рождения"); }
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Неверное имя пользователя");

            if (String.IsNullOrEmpty(lastname))
                throw new ArgumentException("Неверная фамилия пользователя");

            if (String.IsNullOrEmpty(patronymic))
                throw new ArgumentException("Неверное отчество пользователя");

            dateofbirth = date;
            Name = name;
            LastName = lastname;
            Patronymic = patronymic;
        }
    }

    public class Round
    {
        public int Radius { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public virtual double Circumference
        {
            get { return 2 * Math.PI * Radius; }
        }
        public virtual double Area 
        { 
            get { return Math.PI * Radius * Radius; } 
        }

        public Round(int r, int x, int y)
        {
            if (r <= 0) { throw new Exception("Недопустимый радиус окружности"); }
            Radius = r;
            X = x;
            Y = y;
        }
    }
}
