using System;
using System.Collections.Generic;

namespace Task2
{
    partial class Program
    {
        class Office
        {
            private HashSet<Person> employeesList = new HashSet<Person>();

           
            public event EventHandler<OfficeEventArgs> PersonCame;

            public event EventHandler<OfficeEventArgs> PersonLeft;
            public void Come(Person person)
            {
                if (employeesList.Contains(person) ) { throw new Exception("В данный момент в офисе уже есть этот работник"); }
                OfficeEventArgs args = new OfficeEventArgs(person.Name, DateTime.Now);
                Console.WriteLine($"На работу пришел {person.Name}");

                employeesList.Add(person);
                
                PersonCame?.Invoke(this, args);
                PersonCame += person.Greet;
                PersonLeft += person.Goodbye;
            }
            public void Leave(Person person)
            {
                if (!employeesList.Contains(person)) { throw new Exception("В данный момент в офисе нет такого работника"); }

                OfficeEventArgs args = new OfficeEventArgs(person.Name, DateTime.Now);
                Console.WriteLine($" {person.Name} ушел домой");
                employeesList.Remove(person);

                PersonLeft -= person.Goodbye;
                PersonCame -= person.Greet;
                PersonLeft?.Invoke(this, args);
                
                
            }
        }
    }
}
