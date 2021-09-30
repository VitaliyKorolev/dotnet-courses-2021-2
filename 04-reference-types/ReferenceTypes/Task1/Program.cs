using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime datenow = DateTime.Today;
            DateTime date1 = new DateTime(1999, 05, 06);
          
            User user1 = new User(date1, "vitaliy", "korolev", "igorevich");
            Console.WriteLine(user1.Age);
        }
        class User
        {
            private string name;
            private string lastname;
            private string patronymic;
            public DateTime dateofbirth;
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
            
            public User(DateTime date, string name, string lastname, string patronymic)
            {
                if (date.Year > 2020 || date.Year < 1900) { throw new Exception("Недопустимая дата рождения"); }
                this.dateofbirth = date;
                this.name = name;
                this.lastname = lastname;
                this.patronymic = patronymic;
                age = DateTime.Now.Year - date.Year;
                if (DateTime.Now.Month < date.Month || (DateTime.Now.Month == date.Month && DateTime.Now.Day < date.Day)) age--;
            }


        }
    }
}
