using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // TODO: Implement the task here.
            string input = string.Empty;

            while (true)
            { 
                Console.WriteLine("Please enter some line or input 'exit' to exit");
                input = Console.ReadLine();

                if ("exit".Equals(input, StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }

                CharParser.printFirstChar(input);
            }
        }
    }
}