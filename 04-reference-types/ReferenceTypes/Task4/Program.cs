using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString s= new MyString("jhfgggjh");
            MyString s1 = new MyString();
            char[] a = { 'a', 'b', 'c', 'd' };
            MyString s2 = new MyString(a);
            string s3 = s2.ToString();
            Console.WriteLine(s3);
            Console.WriteLine(s.ToString());
            MyString billy = new MyString("jh");
            s= s - billy;
            s[1] = 'l';
            Console.WriteLine(s.ToString());
            s = s + s2;
            s1 = new MyString("abcd");
           
           
            Console.WriteLine(s.ToString());
            Console.WriteLine(s1== s2);

        }

        class MyString
        {
            private char[] str;
            public char this[int i]
            {
                get { return Str[i]; }
                set { Str[i] = value; }
            }
            public char[] Str
            {
                get { return str; }
            }
            public  MyString()
            {
                str = new char[0];
            }
            public MyString(string s)
            {
                str = new char[s.ToCharArray().Length];
                str = s.ToCharArray();
            }
            public MyString(char[] arr)
            {
                str = new char[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    str[i] = arr[i];
                }
            }
            public override string  ToString()
            {
                
                string res = string.Empty;
                for (int i = 0; i < str.Length; i++)
                {
                    res= res+ str[i].ToString() ;
                }
                return res;
            }
            public static MyString operator +(MyString s1, MyString s2)
            {
               string res= s1.ToString() + s2.ToString();
               int a = s1.Str.Length;
                
                MyString sumstr = new MyString(res); 
                return sumstr;
            }
            public static bool operator ==(MyString s1, MyString s2)
            {
                
               return (!ReferenceEquals(null, s2)&&!ReferenceEquals(s1, null)) && s1.Str.ToString() == s2.Str.ToString();
            }
            public static bool operator !=(MyString s1, MyString s2)
            {
                return !(s1 == s2);
            }
            public static MyString operator -(MyString s1, MyString s2)
            {
                string s3 = s1.ToString();
                string s4 = s2.ToString();
                
                MyString minstr = new MyString(s3.Remove(s3.IndexOf(s4),s4.Length));
                return minstr;
            }

        }
    }
}
