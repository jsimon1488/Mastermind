using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace Mastermind
{
    public class Menu
    {
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                string answer = GenerateRandomNumber();
                Console.WriteLine("Welcome to Mastermind. Press 'q' to quit or enter to continue.");
                if (Console.ReadLine() == "q")
                {
                    break;
                }
                int counter = 1;
                // Loops no more than 10 times
                while (true)
                {
                    // Checks that this is not the 11th try
                    if (counter == 11)
                    {
                        Console.WriteLine("You lose!");
                        Pause();
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine($"You have 10 tries to guess the 4 digit combination. Each digit will be between 1 and 6, inclusive. This is guess #{counter}.");
                    
                    // Checks that the input is in valid form
                    string input = GetInput();

                    // Returns a response with a "+" for a correct digit,
                    // "-" for a correct digit out of place, and a " " for an incorrect digit
                    string response = CheckAnswer(input, answer);
                    Console.WriteLine(response);
                    if (response == "++++")
                    {
                        Console.WriteLine("Congratulations!");
                        Pause();
                        break;
                    }
                    Pause();
                    counter++;
                }
            }
        }

        public void Pause()
        {
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        public string GetInput()
        {
            while (true)
            {
                Console.WriteLine("Please enter the 4 digit combination.");
                string input = Console.ReadLine();
                if (CheckForValidNumber(input))
                {
                    return input;
                }
                Console.WriteLine("Please enter a valid combination.");
            }
        }

        public bool CheckForValidNumber(string input)
        {
            if (input.Length != 4)
            {
                //Console.WriteLine("Please enter 4 digits only");
                //Console.ReadLine();
                return false;
            }
            for (int i = 0; i < 4; i++)
            {
                string digitToCheck = Convert.ToString(input[i]);
                if (!int.TryParse(digitToCheck, out int digit))
                {
                    //Console.WriteLine("Please enter integer values only.");
                    //Console.ReadLine();
                    return false;
                }
                if (digit < 1 || digit > 6)
                {
                    //Console.WriteLine("Please enter digits between 1 and 6 inclusive.");
                    //Console.ReadLine();
                    return false;
                }
            }
            return true;
        }

        public string GenerateRandomNumber()
        {
            string answer = "";
            for (int i = 0; i < 4; i++)
            {
                Random random = new Random();
                answer += Convert.ToString(random.Next(1, 6));
            }
            return answer;
        }
        public string CheckAnswer(string input, string answer)
        {
            string response = "";
            for (int i = 0; i < 4; i++)
            {
                if (input[i] == answer[i])
                {
                    response += "+";
                }
                else if (answer.Contains(input[i]))
                {
                    response += "-";
                }
                else
                {
                    response += " ";
                }
            }
            return response;
        }
    }
}
