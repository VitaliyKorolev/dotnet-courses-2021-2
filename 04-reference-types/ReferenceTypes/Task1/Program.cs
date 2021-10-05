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
            Console.WriteLine($"Возраст: {user1.Age}  Имя: {user1.Name}  Фамилия: {user1.LastName}  Отчество: {user1.Patronymic} ");
        }
        class User
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
    }
}
