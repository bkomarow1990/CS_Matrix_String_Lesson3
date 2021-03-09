using System;
using System.Linq;
using System.Text;

namespace HW_task2
{
    class Program
    {
        static void deleteSymbolsInString(ref string str, params char[] symbols) {
            foreach (var item in symbols)
            {
                str = str.Replace(item.ToString(),String.Empty);
            }
        }
        static string Multiply(string source, int multiplier)
        {
            StringBuilder sb = new StringBuilder(multiplier * source.Length);
            for (int i = 0; i < multiplier; i++)
            {
                sb.Append(source);
            }

            return sb.ToString();
        }

        static void showStats(string str) {
            char[] symbols = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'j', 'k', 'l','h', 'm', 'n', 's', 'p', 'r', 't', 'q', 'z' };
            int count = 0;
            foreach (var item in symbols)
            {
                count = str.Count( c => c.Equals(item));
                if (count != 0 )
                {
                    Console.WriteLine($"{item} [{count}] {Multiply("*", count)} ");
                }
            }
        }
        static void Main(string[] args)
        {
            string str = "nfpisifn232k44445555sfno23233pews";
            deleteSymbolsInString(ref str,'2','3','5');
            Console.WriteLine($"str: {str}");
            showStats("I don’t know whether to delete this or rewrite it");
        }
    }
}
