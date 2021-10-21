using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

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
        public static Dictionary<string, int> CountWords(string s)
        {
            s = s.ToLower();
            Regex regex = new Regex(@"[^a-zA-Z]", RegexOptions.IgnoreCase);
            Dictionary<string, int> words = new Dictionary<string, int>();
            string result = regex.Replace(s, " ");
            string[] resultwords = result.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var groupwords = from p in resultwords
                             group p by p ;
            

            foreach (var gr in groupwords)
            {
                words.Add(gr.Key, gr.Count());
            }
            return words;
        }
    }
}
