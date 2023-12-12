using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab6to8;
namespace ConsoleApp1
{
    public class Third<T>
    {
        private MyStack<T> _firstStack;
        private MyStack<T> _secondStack;

        public Third(MyStack<T> firstStack, MyStack<T> secondStack)
        {
            _firstStack = firstStack;
            _secondStack = secondStack;
        }

        public MyCyclingQueue<T> GetSolution()
        {
            MyCyclingQueue<T> result 
                = new MyCyclingQueue<T>(_firstStack.Count + _secondStack.Count);
            MyStack<T> temp = new MyStack<T>(_firstStack.Count + _secondStack.Count);
            while (!_secondStack.IsEmpty())
            {
                temp.Push(_secondStack.Pop());
            }
            while (!_firstStack.IsEmpty())
            {
                temp.Push(_firstStack.Pop());
            }
            while(!temp.IsEmpty())
            {
                result.Enqueue(temp.Pop());
            }
            return result;
        }
    }

    public class Second
    {
        private string s, w;
        public Second(string s, string w)
        {
            this.s = s;
            this.w = w;
        }
        /// <summary>
        /// Наибольшая общая подстрока
        /// </summary>
        /// <returns></returns>
        public string GetResult()
        {
            if (s.Length > w.Length)
            {
                string temp = w;
                w = s;
                s = temp;
            }
            string x = "";
            int lastSub = 0;
            int len = 1;
            for(int i = 0; i < s.Length; i++)
            {
                string subStr = s.Substring(lastSub, len);
                int[] findRes = KMP(w, subStr);
                if (findRes.Length == 1 && findRes[0] == -1)
                {
                    lastSub = i;
                    len = 1;
                    i--;
                    continue;
                }
                len++;
                if (subStr.Length >= x.Length)
                    x = subStr;
            }

            return x;
        }

        /// <summary>
        /// Префикс функция для алгоритма КМП
        /// </summary>
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
                    {
                        j = result[j - 1];
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Осуществляет поиск подстроки с помощью алгоритма КМП
        /// </summary>
        /// <param name="srcStr">Строка, в которой осуществляется поиск</param>
        /// <param name="targetStr">Искомая строка</param>
        /// <returns>Индексы встречи подстроки в данной строке
        /// либо -1 в случае если подстроки нет в данной строке</returns>
        public static int[] KMP(string srcStr, string targetStr)
        {
            int[] P = PrefixFunction(targetStr);
            List<int> result = new List<int>();
            int n = srcStr.Length;
            int m = targetStr.Length;

            int i = 0;
            int j = 0;

            // лилилосьлилилилась
            //           лилила
            // [0, 0, 1, 2, 3]
            while (i < n)
            {
                if (srcStr[i] == targetStr[j])
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
                    if (j > 0)
                    {
                        j = P[j - 1];
                    }
                    else
                    {
                        i += 1;
                    }
                }
            }
            if (result.Count == 0)
                result.Add(-1);
            return result.ToArray();
        }
    }
}
