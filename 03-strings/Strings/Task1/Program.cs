using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текстовую строку");
            string text =Console.ReadLine();
            string text1= RemovePunctuation(text);
            Console.WriteLine(text1);
            Console.WriteLine(Counter(text1));

        }
        static string RemovePunctuation(string text)
        {


            for (int i = 0; i < text.Length; i++)
            {
                
                if (char.IsPunctuation(text[i]))
                {
                     text = text.Replace(text[i], ' '); 
                }

            }
            return text;

        }
        static double Counter(string text)
        {
            int letters = 0;
            for (int i = 0; i < text.Length; i++)
            {
               
               if (char.IsLetter(text[i]))
               {
                  letters++;
               }
              
            }
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int word = words.Length;
            return (double)letters / word;

        }


    }
}
