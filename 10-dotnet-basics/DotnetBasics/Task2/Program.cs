using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateofbirth = new DateTime(2000, 06, 05);
            DateTime dateofhiring = new DateTime(2010, 03, 15);
            Employee emp = new Employee(dateofbirth, "valeriy", "baranov", "andreevich", "SMM", dateofhiring);

            DateTime dateofbirth1 = new DateTime(2000, 06, 05);
            DateTime dateofhiring1 = new DateTime(2010, 03, 15);
            Employee emp1 = new Employee(dateofbirth1, "valeriy", "baranov", "andreevich", "SMM", dateofhiring1);

            Object o = new Object();

            User user = new User(dateofbirth, "valeriy", "baranov", "andreevich");

            bool b= emp.Equals(user);
            Console.WriteLine(b);
        }
    }
}
