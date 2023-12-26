using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите первое предложение:");
        string s1 = Console.ReadLine();
        Console.WriteLine("Введите второе предложение:");
        string s2= Console.ReadLine();
        FindLongWord(s1, s2);
    }

    static void FindLongWord(string? s1, string? s2)
    {
        //{ ' ', ',', '.', ';', ':', '!', '?' } - возможные знаки разделяющие слова

        string[] w1 = s1.Split(new[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string[] w2 = s2.Split(new[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string[] w3 = FindCommonWords(w1, w2);
        LongestWord(w3);
    }

    static string[] FindCommonWords(string[] w1, string[] w2)
    {
        List<string> sen1 = w1.ToList<string>();
        List<string> sen2 = w2.ToList<string>();
        
        int len1 = w1.Length; int len2 = w2.Length;
        int len; int count = 0;
        if (len1 > len2)
            len = len1;
        else
            len = len2;
        List<string> w3 = new List<string>();
        for (int i = 0; i < len;i++)
        {
            if (w1.Contains(w2[i]))
            {
                w3.Add( w2[i]);
                count++;
            }
        }
        return w3.ToArray();
    }

    static void LongestWord(string[] w3)
    {
        string longest = w3[0];
        for (int i = 1; i < w3.Length; i++)
        {
            if (w3[i].Length > longest.Length)
                longest = w3[i];
        }
        Console.WriteLine(longest);
    }
}
