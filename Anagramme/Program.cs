using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anagramme
{
    class Program
    {
        static List<String>[] words = new List<String>[1000];
        static void Main(string[] args)
        {
            loadWords();
            Console.Write("Search Anagramm for ?:");
            String word = Console.ReadLine();

            if (words[word.Length] == null)
            {
                Console.WriteLine("No Anagramms in Libary");
            }
            else
            {
                foreach (String s in words[word.Length])
                {
                    if (canBeAnagramm(word.ToLower(), s.ToLower()))
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            Console.ReadKey();
        }

        public static Boolean canBeAnagramm(String s1, String s2)
        {
            var aSet = new HashSet<char>(s1);
            var bSet = new HashSet<char>(s2);
            return aSet.SetEquals(s2);
        }

        public static void loadWords()
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\..\german.dic");

            foreach (string line in lines)
            {
                if (words[line.Length] == null)
                    words[line.Length] = new List<String>();

                words[line.Length].Add(line);
            }
        }
    }
}