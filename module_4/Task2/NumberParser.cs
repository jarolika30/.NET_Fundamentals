using System;
using System.Linq;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null) throw new ArgumentNullException("Argument can not be null!");

            string numericString = string.Empty;
            long parsedValue = 0;

            var stringToConvert = stringValue.Trim();
            var charArray = stringToConvert.ToCharArray();
            int multiplier = 1;

            if (string.IsNullOrWhiteSpace(stringValue)) throw new FormatException($"Unable to parse '{stringValue}'");

            if (charArray[0] == '-' || charArray[0] == '+')
            {
                multiplier = charArray[0] == '-' ? -1 : 1;
                charArray = charArray.Skip(1).ToArray();
            }

            if (charArray.All(i => char.IsDigit(i)))
            {
                var numbers = charArray.Select(i => (long)(i - '0'));
                parsedValue = numbers.Aggregate((result, x) => result * 10 + x) * multiplier;

                if (parsedValue < int.MinValue || parsedValue > int.MaxValue) throw new OverflowException("Value is out of range!");

                return (int)parsedValue;
            }

            throw new FormatException();
        }
    }
}