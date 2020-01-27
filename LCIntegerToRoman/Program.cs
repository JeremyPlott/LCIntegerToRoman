using System;
using System.Collections.Generic;
using System.Linq;

namespace LCIntegerToRoman
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> numeralDict = new Dictionary<int, string>()
            {
                {1, "I"}, {4, "IV"}, {5, "V"}, {9, "IX"},
                {10, "X" }, {40, "XL"}, {50, "L"}, {90, "XC"},
                {100, "C"}, {400, "CD"}, {500, "D"}, {900, "CM"},
                { 1000, "M"}
            };

            Console.WriteLine(IntToRoman(3));


            string IntToRoman(int num)
            {
                string convertedNumber = string.Empty;

                int digitPosition = 1;

                while (num > 0)
                {
                    int digit = num % 10;

                    try
                    {
                        convertedNumber = numeralDict[digit * digitPosition] + convertedNumber;
                    }
                    catch
                    {
                            convertedNumber = AddDigit(digit, digitPosition, convertedNumber);                        
                    }

                    num = num / 10;
                    digitPosition = digitPosition * 10;
                }

                return convertedNumber;
            }

            string AddDigit(int digit, int digitPosition, string currentConversion)
            {
                var numOfRepeats = digit;

                if (digit > 5)
                {
                    numOfRepeats = digit - 5;
                    currentConversion = numeralDict[digitPosition * 5] + AddToCurrent(digitPosition, numOfRepeats, currentConversion);
                } 
                else
                {
                    currentConversion = AddToCurrent(digitPosition, numOfRepeats, currentConversion); 
                }

                return currentConversion;


                string AddToCurrent(int digitPosition, int numOfRepeats, string currentConversion)
                {
                    return string.Concat(Enumerable.Repeat(numeralDict[digitPosition], numOfRepeats)) + currentConversion;
                }
            }
        }
    }
}
