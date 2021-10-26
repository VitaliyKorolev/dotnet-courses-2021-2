namespace Task2
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Office office = new Office();
            Person person1 = new Person("Man");
            Person person2 = new Person("Vital");
            Person person3 = new Person("Bogdan");

            office.Come(person1);
            office.Come(person2);
            office.Come(person3);

            office.Leave(person3);
            office.Leave(person2);
            office.Leave(person1);

            office.Come(person1);


        }
    }
}
