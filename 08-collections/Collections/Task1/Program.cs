using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
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
            
            while ( collection.Count!=1)
            {
                var a = collection.GetEnumerator();
                a.MoveNext();
                var temp = a.Current;
                collection.Remove(a.Current);
                collection.Add(temp);
                var b = collection.GetEnumerator();
                b.MoveNext();
                collection.Remove(b.Current);
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
