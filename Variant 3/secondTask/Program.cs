using System.Text;

namespace exam
{
    class Program
    {
        public static void Main(string[] args)
        {
            string str = "astgassl";
            Dictionary<string, int> dic = Str.Find2(str);
            foreach(var d in dic )
                Console.WriteLine(d.ToString());
        }
    }
    public static class Str
    {
        public static Dictionary<string, int> Find2(string s)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 1; i < s.Length; i++)
            {
                string str = s.Substring(i - 1, 2);
                if (dic.ContainsKey(str))
                    dic[str]++;
                else if(dic.ContainsKey(Str.Revers(str)))
                    dic[Str.Revers(str)]++;
                else
                    dic.Add(str, 1);
            }
            return dic;
        }
        public static string Revers(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            return s[1].ToString() + s[0].ToString();
        }
    }
}