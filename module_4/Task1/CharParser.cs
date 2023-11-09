using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    internal class CharParser
    {
        public static void printFirstChar(string line)
        {
            try
            {
                Console.WriteLine($"First char of your input was '{line[0]}'");
            }
            catch (Exception e)
            {
                Console.WriteLine("The string is null or empty");
                Console.WriteLine(e.Message);
            }
        }
    }
}
