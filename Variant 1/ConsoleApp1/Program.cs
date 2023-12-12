using System;

namespace ConsoleApp1
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string s = "abab"; //Console.ReadLine();
            
            Dictionary<string, int> combs = new Dictionary<string, int>();
            combs[""] = 1;

            for (int depth = 1; depth <= s.Length; depth++)
            {
                Combinations(0, s.Length - depth, 0, depth, "", s, combs);
            }
            
            


            Console.WriteLine($"Способов: {combs.Keys.Count + 1}");
            foreach(var st in combs.Keys)
            {
                Console.WriteLine(st);
            }
        }
        static void AddToDictionary(Dictionary<string, int> dict, string key)
        {
            if (dict.ContainsKey(key))
            {
                dict[key]++;
            }
            else
            {
                dict[key] = 1;
            }
        }
        static void Combinations(int start, int end, int depth, int maxDepth, string current, string s, Dictionary<string, int> combinations)
        {
            for (int i = start; i <= end; i++)
            {
                if (depth == maxDepth)
                {
                    if (IsPalindrome(current))
                    {
                        AddToDictionary(combinations, current);
                    }
                        
                    return;
                }
                else
                {
                    var p = current + s[i];
                    Combinations(i + 1, end + 1, depth + 1, maxDepth, p, s, combinations);
                }
            }
        }


        static bool IsPalindrome(string s)
        {
            for(int i = 0; i< s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}