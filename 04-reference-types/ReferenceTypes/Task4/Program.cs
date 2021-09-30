using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString s= new MyString("jhfgggf");
            MyString s1 = new MyString();
            char[] a = { 'a', 'b', 'c', 'd' };
            MyString s2 = new MyString(a);
            string s3 = s2.MyToString();
            Console.WriteLine(s3);
            Console.WriteLine(s.MyToString());
            MyString billy = new MyString("jh");
            s= s - billy;
        }

        class MyString
        {
            public char[] str;
            public  MyString()
            {
                str = new char[1];
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
            public string MyToString()
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
               string res= s1.MyToString() + s2.MyToString();

                MyString sumstr = new MyString(res); 
                return sumstr;
            }
            public static bool operator ==(MyString s1, MyString s2)
            {
               return s1.str == s2.str;
            }
            public static bool operator !=(MyString s1, MyString s2)
            {
                return s1.str != s2.str;
            }
            public static MyString operator -(MyString s1, MyString s2)
            {
                string s3 = s1.MyToString();
                string s4 = s2.MyToString();
                s3.Replace(s4, "");
                MyString minstr = new MyString(s3.Replace(s4, ""));
                return minstr;
            }

        }
    }
}
