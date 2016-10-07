using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        int[] array = { 5, 3, 0, 1, 2, 3, 0, 0 };
        int[] tweedearray = {-5, 2, 5, 4, -7, -2, 9, 4};

        static void Main(string[] args)
        {
            Program program = new Program();
            int a = program.FirstPosition("alphabet", 't');
            int b = program.CountZeros(program.array);
            int[] c = program.Add(program.array, program.tweedearray);
            Console.WriteLine(a);
            Console.WriteLine(b);
            string text = string.Join(", ", c);
            Console.WriteLine(text);
            Console.ReadKey();
        }

        public int CountZeros(int[] array)
        {
            int sum = 0;
            foreach(int a in array)
            {
                if (a == 0) sum++;
            }
            return sum;
        }

        public int[] Add(int[] array1, int[] array2)
        {
            int[] result = new int[array1.Length];
            for (int i = 0; i < array1.Length; i++)
            {
                result[i] = array1[i] + array2[i];
            }
            return result;
        }

        public int FirstPosition(string s, char c)
        {
            if (s.Contains(c))
                return s.IndexOf(c);
            else
                return -1;
        }
    }
}
