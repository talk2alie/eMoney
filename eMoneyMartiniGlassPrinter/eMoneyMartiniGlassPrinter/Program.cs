using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMoneyMartiniGlassPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            var w = new Stopwatch();
            w.Start();
            PrintGlassRecursive(70);
            w.Stop();
            Console.WriteLine(w.ElapsedMilliseconds + " milliseconds");
                      
            Console.Read();
        }


        static void PrintGlassRecursive(int handleHeight)
        {
            int characterCount, width;
            characterCount = width = handleHeight + (handleHeight - 1);
            var output = new StringBuilder();

            PrintGlassRecursive(characterCount, width, handleHeight, new string('0', characterCount), output);
        }


        static void PrintGlassRecursive(int characterCount, int width, int handleHeight, string input, StringBuilder output)
        {
            if (characterCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(characterCount), "size must be greater than 0");
            }

            if (String.IsNullOrEmpty(input.ToString()))
            {
                throw new ArgumentOutOfRangeException(nameof(input), "input must have content");
            }

            if (characterCount > width)
            {
                throw new ArgumentException("characters cannot exceed the width of the glass", nameof(input));
            }

            const int STEP = 2;
            int leftPadding = characterCount + (width - characterCount) / STEP;
            output.AppendLine(input.PadLeft(leftPadding).PadRight(width));
            if (characterCount == 1)
            {
                Console.Write(output.ToString());
                int iteration = 0;
                while (iteration < handleHeight)
                {
                    Console.WriteLine("|".PadLeft(leftPadding).PadRight(width));
                    iteration++;
                }
                Console.WriteLine(new string('=', width));
                return;
            }
            characterCount -= STEP;
            PrintGlassRecursive(characterCount, width, handleHeight, new string('0', characterCount), output);
        }


        static void PrintGlass(int size)
        {
            int characterCount, width;
            characterCount = width = size + (size - 1);
            var output = new StringBuilder();

            const int STEP = 2;
            int leftPadding;
            while (characterCount >= 1)
            {
                leftPadding = GetLeftPadding(characterCount, width, STEP);
                Console.WriteLine(new string('0', characterCount).PadLeft(leftPadding).PadRight(width));
                characterCount -= STEP;
            }

            int iteration = 0;
            characterCount = 1;
            leftPadding = GetLeftPadding(characterCount, width, STEP);
            while (iteration < size)
            {
                Console.WriteLine("|".PadLeft(leftPadding).PadRight(width));
                iteration++;
            }
            Console.WriteLine(new string('=', width));
        }


        private static int GetLeftPadding(int characterCount, int width, int STEP)
        {
            return characterCount + (width - characterCount) / STEP;
        }
    }
}