using System;

namespace Task2
{
    partial class Program
    {
        class Person
        {
            public string Name { get; private set; }
            public Person(string name)
            {
                Name = name;
            }
            public void Greet(object sender, OfficeEventArgs args)
            {
                if(args.Time.Hour<=12)
                   Console.WriteLine($"Доброе утро,{args.Name}!, - сказал {this.Name}");

                if (args.Time.Hour >= 17)
                    Console.WriteLine($"Добрый вечер,{args.Name}!, - сказал {this.Name}");

                if (args.Time.Hour < 17 && args.Time.Hour > 12)
                    Console.WriteLine($"Доброе день,{args.Name}!, - сказал {this.Name}");
            }
            public void Goodbye(object sender, OfficeEventArgs args)
            {
                Console.WriteLine($"До свидания,{args.Name}!, - сказал {this.Name}");
            }

        }
    }
}
