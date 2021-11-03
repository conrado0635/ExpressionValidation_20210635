using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
/*Created by Conrado R Cabuyadao  id#20210635*/
namespace ExpressionValidation
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" === Welcome to Expression Validation Program ===  Created by Conrado Cabuyadao");
            Console.ResetColor();
            Stack<char> character = new Stack<char>();
            string openCharacter;
            string closeCharacter;
          

            Console.Write("Enter your expression: ");
            string inputExp = Console.ReadLine();

            openCharacter = GetOpenChar();
            Console.WriteLine();
            closeCharacter = GetCloseChar();

            char[] expression = inputExp.ToCharArray();
            char openChar = openCharacter.ToCharArray()[0];
            char closeChar = closeCharacter.ToCharArray()[0];
            int open = 0;
            int close = 0;
         
            for (var i = 0; i < expression.Length; i++)
                {
                    if (expression[i] == openChar)
                    {
                        character.Push(expression[i]);
                        open++;
                    }
                    if ((expression[i] == closeChar) & (character.Count > 0))
                    {
                        /*Console.WriteLine(character.Count);*/
                        character.Pop();
                        close++;
                    }
                }
          /*      Console.WriteLine("open:" + open);
                Console.WriteLine("close:" + close);
                Console.WriteLine("character:" + character.Count);*/
                if ((open == close) && (open != 0) & (close != 0))
                {
                    Console.WriteLine($"Expression: {inputExp} is valid!");
                }
                else
                {
                    Console.WriteLine($"Expression:{((inputExp != null) ? inputExp : "Empty")} is invalid");
                }
        }
        private static string GetOpenChar()
        {
            var openRegex = new Regex(@"[{(<[]");  
            string openCharacter;
            do
            {
                Console.Write("Enter Opening character to validate ex:'{','[','(','<' <Not Empty>: ");
                openCharacter = Console.ReadLine().Trim();
                
            } while (!openRegex.IsMatch(openCharacter));
            return openCharacter;
        }
        private static string GetCloseChar()
        {
           
            var closeRegex = new Regex(@"[})>\]]");
            string closeCharacter;
            do
            {
                Console.Write($"Enter Closing character to validate ex:'}}',']',')','>' <Not Empty>: ");
                closeCharacter = Console.ReadLine().Trim();
            } while (!closeRegex.IsMatch(closeCharacter));

            return closeCharacter;
        }
    }
}
