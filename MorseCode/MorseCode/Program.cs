using System;
using System.Collections.Generic;
using System.Linq;
namespace MorseCode
{
    class Program
    {
        static Dictionary<char, string> morseCodeConverter = new Dictionary<char, string>()
            {
                {'a', ".-" },
                {'b', "-..." },
                {'c', "-.-." },
                {'d', "-.." },
                {'e', "." },
                {'f', "..-." },
                {'g', "--." },
                {'h', "...." },
                {'i', ".." },
                {'j', ".---" },
                {'k', "-.-" },
                {'l', ".-.." },
                {'m', "--" },
                {'n', "-." },
                {'o', "---" },
                {'p', ".--." },
                {'q', "--.-" },
                {'r', ".-." },
                {'s', "..." },
                {'t', "-" },
                {'u', "..-" },
                {'v', "...-" },
                {'w', ".--" },
                {'x', "-..-" },
                {'y', "-.--" },
                {'z', "--.." },
                {'1', ".----" },
                {'2', "..---" },
                {'3', "...--" },
                {'4', "....-" },
                {'5', "....." },
                {'6', "-...." },
                {'7', "--..." },
                {'8', "---.." },
                {'9', "----." },
                {'0', "-----" }

            };


        static void Main(string[] args)
        {

            Console.WriteLine("The encoded message \n\n" + Encode("Images may be subject to copyright"));
            Console.WriteLine("The decoded message \n\n" + Decode("- .... .. ... / .. ... / -- --- .-. ... . / -.-. --- -.. ."));

            Console.ReadLine();

        }

        static string Decode(string morseCode)
        {
            morseCode += " ";
            string decoded = string.Empty;

            for (int x = 0; x < morseCode.Length; x++)
            {
                //Console.WriteLine("x");
                int i = x;
                bool exitWhile= false;
                while (morseCode[i] != ' ' && morseCode[i] != '/' && !exitWhile)
                {
                    if (i + 1 >= morseCode.Length)
                    {
                        exitWhile = true;
                        i--;
                    }
                    i++;
                }
                string tempString = string.Empty;
                while (x < i)
                {
                    tempString += morseCode[x++];
                }

                for (int y = 0; y < morseCodeConverter.Count; y++)
                {
                    if (morseCodeConverter.ElementAt(y).Value == tempString)
                    {
                        decoded += morseCodeConverter.ElementAt(y).Key;

                    }
                }
                if (morseCode[x] == '/')
                {
                    decoded += " ";
                }
            }


            return decoded;
        }
        static string Encode(string plainText)
        {
            plainText = plainText.ToLower();
            

            string decoded = string.Empty;
            foreach (char letter in plainText)
            {
                try
                {

                    decoded += morseCodeConverter[letter] + " ";
                }
                catch (Exception e)
                {
                    decoded += " / ";
                    
                }
            }
            return decoded;

        }
    }
}
