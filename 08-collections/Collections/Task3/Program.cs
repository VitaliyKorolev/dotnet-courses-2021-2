using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Hello/ my. name is,  Name????787585 name is";
            var words = CountWords(s);
            foreach(var el in words)
            {
                Console.WriteLine(el);
            }
        }
        public static Dictionary<string, int>  CountWords(string s)
        {
            s= s.ToLower();
            Regex regex = new Regex(@"[^a-zA-Z]", RegexOptions.IgnoreCase);
            var set = new HashSet<string>();
           /// string[] resultwords1 = Regex.Split(s , "[^a-zA-Z]" );
            
            Dictionary<string, int> words = new Dictionary<string, int>();
            string result = regex.Replace(s, " ");
            string[] resultwords = result.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in resultwords)
            {
                set.Add(word);
               
            }
            foreach (string word in set)
            {
                int count = 0;
                foreach (string word1 in resultwords)
                {
                    if (word == word1) count++;
                }
                words.Add( word, count);
            }
            return words;

        }
    }
}
