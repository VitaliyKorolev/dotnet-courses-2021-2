using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int> { 1, 2, 3, 4};
            LinkedList<string> list2 = new LinkedList<string>();
            list2.AddLast("Vanya");
            list2.AddLast("Bogdan");
            list2.AddLast("Valeriy");


            RemoveEachSecondItem(list1);
            Print(list1);
         
            RemoveEachSecondItem(list2);
            Print(list2);
        }
        static void RemoveEachSecondItem <T> ( ICollection<T> collection)  
        {
            while (collection.Count != 1)
            {
                List<T> delete = new List<T>();
                var a = collection.GetEnumerator();
                int count = 0;
                while (a.MoveNext())
                {
                    count++;
                    
                    if (count % 2 == 0)
                    {
                        delete.Add(a.Current);
                    }
                }
                foreach(T del in delete)
                {
                    collection.Remove(del);
                }

            }
            
        }
        static void Print<T>(ICollection<T> collection)
        {
            foreach(T el in collection)
            {
                Console.WriteLine(el);
            }
        }
    }
}
