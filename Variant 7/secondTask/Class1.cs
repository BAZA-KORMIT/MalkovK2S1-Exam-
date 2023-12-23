using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ZachetString
{
    public class StringQues
    {
        public static string ReplaceGroups(string text)
        {
            string startPattern = "##";
            string endPattern = "##";
            string replacePattern = "<$1>";
            return Regex.Replace(text, $"{startPattern}(.*?){endPattern}", replacePattern);
        }
        /// <summary>
        /// Метод позволяющий узнатть сколько значений нужно пропустить чтобы продолжить поиск
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static int[] PrefixFunction(string s)
        {
            int[] result = new int[s.Length];
            int i = 1;
            int j = 0;
            while (i < s.Length)
            {
                if (s[j] == s[i])
                {
                    result[i] = j + 1;
                    i += 1;
                    j += 1;
                }
                else
                {
                    if (j == 0)
                    {
                        result[i] = 0;
                        i += 1;
                    }
                    else
                        j = result[j - 1];
                }
            }
            return result;
        }
        /// <summary>
        /// Алгоритм Кнута-Морриса-Пратта
        /// </summary>
        /// <param name="s1">Подстрока</param>
        /// <param name="s">исходная строка</param>
        /// <returns></returns>
        public static int[] KMP(string s1, string s)
        {
            int[] P = PrefixFunction(s);
            //s1 - строка в которой , s - подстрока
            List<int> result = new List<int>();
            int n = s1.Length;
            int m = s.Length;

            int i = 0;
            int j = 0;

            while (i < n)
            {
                if (s1[i] == s[j])
                {
                    i += 1;
                    j += 1;
                    if (j == m)
                    {
                        result.Add(i - j);
                        j -= 1;
                    }
                }
                else
                {
                    if (j > 0) { j = P[j - 1]; }
                    else { i += 1; }
                }
            }
            if (result.Count == 0)
                result.Add(-1);
            return result.ToArray();
        }
    }

}
