using System;
using System.Collections;
using System.Collections.Generic;
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 3, 5, 8, 10, };
            DynamicArray<int> masint = new DynamicArray<int>(a);
         
            List<int> b = new List<int> { 2, 5, 6, 7 };
            DynamicArray<int> masint1 = new DynamicArray<int>(b);

            foreach (var el in masint)
            {
                Console.WriteLine(el);
            }
            foreach (var el in masint1)
            {
                Console.WriteLine(el);
            }
        }
        class DynamicArray<T> : IEnumerable<T> 
            where T : new()
        {
            private T[] arr;
            private int currentindex = -1;
            public bool   MoveNext()
            {
                if (currentindex < Length-1)
                {
                    currentindex++;
                    return true;
                }
                
                return false;
            }
            public void Reset()
            {
                currentindex = -1;
            }

            public T Current
            {
                get 
                { 
                    if(currentindex==-1 || currentindex >= Length){ throw new InvalidOperationException(); }
                    return arr[currentindex]; 
                }
            }
            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < Length; i++)
                {
                    yield return arr[i];
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return  GetEnumerator();
            }
            public DynamicArray(IEnumerable<T> collection)
            {
                var ie = collection.GetEnumerator();
                int i = 0;
                int count = 0;
                while (ie.MoveNext())
                {
                    count++;
                }
                ie.Reset();
                arr = new T[count];
                while (ie.MoveNext())
                {
                    arr[i] = ie.Current;
                    i++;
                }
                Length = count;
            }

            public int Capacity
            {
                get { return arr.Length; }
            }
            public T this[int index]
            {
                get
                {
                    if (index < Length)
                    {
                        return arr[index];
                    }

                    throw new IndexOutOfRangeException();
                }
                set
                {
                    if (index < Length)
                    {
                        arr[index] = value;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
            }
            public int Length   //// количество элементов в массиве 
            {
                get;
                private set;
            }
            public DynamicArray()
            {
                const int BaseCapacity = 8;
                arr = new T[BaseCapacity];
                Length = 0;
            }
            public DynamicArray(int n)
            {
                if (n < 0)
                {
                    throw new ArgumentException("Длина должна быть положительна");
                }

                arr = new T[n];
                Length = 0;
            }
            public DynamicArray(T[] array)
            {
                arr = (T[])array.Clone();
                Length = array.Length;
            }

            public void Add(T item)
            {
                if (Capacity == Length)
                {
                    GrowArray(Capacity * 2);
                }
                arr[Length++] = item;
            }
            public void AddRange(T[] items)
            {
                if (Capacity < Length + items.Length)
                {
                    GrowArray(Length + items.Length);
                }
                items.CopyTo(arr, Length);
                Length = Length + items.Length;
            }
            public void Insert(int index, T item)
            {
                if (index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                if (Capacity == Length)
                {
                    GrowArray(Capacity * 2);
                }
                Array.Copy(arr, index, arr, index + 1, Length - index);
                arr[index] = item;
                Length++;
            }
            public bool RemoveAt(int index)
            {
                if (index >= Length)
                {
                    return false;
                }

                int shiftStart = index + 1;
                if (shiftStart < Length)
                {
                    Array.Copy(arr, shiftStart, arr, index, Length - shiftStart);
                }

                Length--;
                return true;
            }
            private void GrowArray(int newLength)
            {
                T[] newArray = new T[newLength];
                arr.CopyTo(newArray, 0);
                arr = newArray;
            }
            public void PrintArray()
            {
                for (int i = 0; i < Length; i++)
                {
                    Console.Write(arr[i] + " ");

                }
                Console.WriteLine();
            }

           
        }
    }
}
