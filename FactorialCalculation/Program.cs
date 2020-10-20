using System;
using System.Timers;

namespace FactorialCalculation
{
    class Program
    {
        private static readonly Timer timer = new Timer(1000);

        private static ulong resultFactorial;
        private static ulong Input;
        private static int i = 0;

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            i++;
            if (i % 2 == 0)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Clear();
            TableConstructor(Input, resultFactorial);
        }

        static ulong Factorial(ulong x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }

        static int MaxLength(ulong x)
        {
            int length = $"{x}".Length;
            return length;
        }

        static void IfFactorialLonger(ulong factorial, string str, string str2, int abs)
        {
            Console.WriteLine(new string(' ', abs / 2) + str);
            Console.WriteLine(str2);
            Console.WriteLine("║" + new string(' ', MaxLength(factorial) + 2) + "║");
            Console.WriteLine("║" + " " + factorial + " " + "║");
            Console.WriteLine("║" + new string(' ', MaxLength(factorial) + 2) + "║");
            Console.WriteLine("╚" + new string('═', MaxLength(factorial) + 2) + "╝");
        }

        static void IfTextLonger(ulong factorial, string str, string str2, int abs)
        {
            Console.WriteLine(str);
            string a = new string(' ', abs / 2);
            Console.WriteLine(a + str2 + new string(' ', abs - abs / 2));
            Console.WriteLine(a + "║" + new string(' ', MaxLength(factorial) + 2) + "║");
            Console.WriteLine(a + "║" + " " + factorial + " " + "║");
            Console.WriteLine(a + "║" + new string(' ', MaxLength(factorial) + 2) + "║");
            Console.WriteLine(a + "╚" + new string('═', MaxLength(factorial) + 2) + "╝");
        }

        static void TableConstructor(ulong number, ulong factorial)
        {
            string str = $"факториал числа {number}";
            string str2 = "╔" + new string('═', MaxLength(factorial) + 2) + "╗";
            int abs = Math.Abs(str.Length - str2.Length);
            if (str.Length > str2.Length)
            {
                IfTextLonger(factorial, str, str2, abs);
            }
            else
            {
                IfFactorialLonger(factorial, str, str2, abs);
            }
        }

        static bool IsInputNumber(string str)
        {
            int num;
            bool isNum = int.TryParse(str, out num);
            if (num < 0) isNum = false;
            return isNum;

        }
        static string IsInputCcorrect()
        {
            Console.WriteLine("введите число:");
            string str;
            bool f = true;
            int count = 0;
            do
            {
                if (count != 0)
                {
                    Console.Clear();
                    Console.WriteLine("некорректный ввод. попробуйте еще раз");
                }
                count++;
                f = IsInputNumber(str = Console.ReadLine());
            }
            while (!f);
            return str;
        }

        static void Main(string[] args)
        {
            string str = IsInputCcorrect();
            Input = ulong.Parse(str);
            resultFactorial = Factorial(Input);
            Console.Clear();
            TableConstructor(Input, resultFactorial);
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
            Console.ReadKey();
            timer.Stop();
            timer.Dispose();
        }
    }
}