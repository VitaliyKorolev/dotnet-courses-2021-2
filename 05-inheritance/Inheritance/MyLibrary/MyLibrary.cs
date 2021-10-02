using System;

namespace MyLibrary
{
    public class MyLibrary
    {
        private string name;
        private string lastname;
        private string patronymic;
        private DateTime dateofbirth;
        private int age;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public string LastName
        {
            get { return lastname; }
            private set { lastname = value; }
        }
        public string Patronymic
        {
            get { return patronymic; }
            private set { patronymic = value; }
        }
        public int Age
        {
            get { return age; }
        }

        public MyLibrary(DateTime date, string name, string lastname, string patronymic)
        {
            if (date.Year > 2020 || date.Year < 1900) { throw new Exception("Недопустимая дата рождения"); }
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Неверное имя пользователя");
            }
            if (String.IsNullOrEmpty(lastname))
            {
                throw new ArgumentException("Неверная фамилия пользователя");
            }
            if (String.IsNullOrEmpty(patronymic))
            {
                throw new ArgumentException("Неверное отчество пользователя");
            }
            this.dateofbirth = date;
            Name = name;
            LastName = lastname;
            Patronymic = patronymic;
            age = DateTime.Now.Year - date.Year;
            if (DateTime.Now.Month < date.Month || (DateTime.Now.Month == date.Month && DateTime.Now.Day < date.Day)) age--;
        }
    }

    public class Round
    {
        public int Radius { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public double Circumference { get; }
        public double Area { get; }

        public Round(int r, int x, int y)
        {
            if (r <= 0) { throw new Exception("Недопустимый радиус окружности"); }
            Radius = r;
            X = x;
            Y = y;
            Circumference = 2 * Math.PI * r;
            Area = Math.PI * r * r;
        }
    }
}
