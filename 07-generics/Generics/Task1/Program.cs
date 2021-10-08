using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 3, 5, 8, 10, };
            DynamicArray<int> masint = new DynamicArray<int>(a);
            masint.Add(101);
            masint.PrintArray();

            masint.RemoveAt(2);
            masint.PrintArray();

            int[] b = { 3, 5, 8, 10, 11};
            masint.AddRange(b);
            masint.PrintArray();

            masint.Insert(0, 228);
            masint.PrintArray();

            masint.RemoveAt(0);
            masint.PrintArray();

            DynamicArray <double> mas1 = new DynamicArray<double>(5);
            int afaf= mas1.Capacity;
        }

       
    }
    class DynamicArray<T> where T : new()
    {
        private T[] arr;
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
        public  DynamicArray()
        {
            const int BaseCapacity=8;
            arr = new T[BaseCapacity];
            Length = 0;
        }
        public DynamicArray  (int n)
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
                GrowArray(Length+items.Length);
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
        public  void PrintArray()
        {
            for (int i = 0; i < Length; i++)
            {
                Console.Write(arr[i] + " ");

            }
            Console.WriteLine();
        }
    }
}
