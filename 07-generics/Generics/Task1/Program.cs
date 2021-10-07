using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 3, 5, 8, 10, };
            DynamicArray<int> masint = new DynamicArray<int>(a);
   
            masint.RemoveAt(2);
            int adfh=  masint[2];
            double[] b = { 3, 5, 8, 10, };
            DynamicArray<double> mas1 = new DynamicArray<double>(5);
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
            arr = new T[8];
            for(int i=0; i< 8; i++ )
            {
                arr[i] = default(T);
            }
            Length = 0;
        }
        public DynamicArray  (int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Длина должна быть положительна");
            }

            arr = new T[n];
            Length = n;
        }
        public DynamicArray(T[] a)
        {
            arr=a;
            
            Length = a.Length;

        }
       
        public void Add(T item)
        {
            if (arr.Length == Length)
            {
                int newLength = arr.Length * 2;
                T[] newArray = new T[newLength];
                arr.CopyTo(newArray, 0);
                arr = newArray;
            }
            arr[Length++] = item;
        }
        public void AddRange(T[] items)
        {
            if (arr.Length < Length + items.Length)
            {
                int newLength = Length+items.Length;
                T[] newArray = new T[newLength];
                arr.CopyTo(newArray, 0);
                arr = newArray;
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

            if (arr.Length == Length)
            {
                int newLength = arr.Length * 2;
                T[] newArray = new T[newLength];
                arr.CopyTo(newArray, 0);
                arr = newArray;
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



    }
}
