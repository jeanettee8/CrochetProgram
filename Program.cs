using System.Collections.Generic;
using System.Xml.Schema;

/*ive made a small crochet program, and want to receive hints on what i can improve, but not the answer, so i can learn without having the answer given to me. Only hints and tips on how i could improve and make the code better, for readability or for the user. first is my program.cs:    */

namespace CrochetProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Crochet Program!");
            Console.WriteLine();
            Thread.Sleep(800);
            Console.WriteLine("If not your first time, would you like to empty the old pattern.txt file?");
            string? deleteTxtFileInput = Console.ReadLine();
            string[] yesInput = { "yes", "yup", "ja", "jepp", "ok"};
            if (yesInput.Contains(deleteTxtFileInput, StringComparer.InvariantCultureIgnoreCase))
            {
                File.Delete("pattern.txt");
                Console.WriteLine("pattern.txt file successfully deleted!");
                Console.WriteLine();
            }

            Console.Write("Please input the different ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("colors");
            Console.ResetColor();
            Console.WriteLine(" you're choosing from.");
            Console.WriteLine();
            Console.WriteLine("Press enter again when you're done!");

            List<string> colors = new List<string>();

            bool enteringYarnColor;
            while (enteringYarnColor = true) 
            {
                string? colorInput = Console.ReadLine();
                if (string.IsNullOrEmpty(colorInput)) 
                {
                    break;
                }
                colors.Add(colorInput);
            }

            if (colors.Count == 0)
            {
                Console.WriteLine("No colors entered!");
                return;
            }
        
            Random rnd = new Random();
            string yarnColor = colors[rnd.Next(colors.Count)];

            Console.Write("Please input the different ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("stitches");
            Console.ResetColor();
            Console.WriteLine(" you're choosing from.");
            Console.WriteLine();
            Console.WriteLine("Press enter again when you're done!");

            List<string> stitches = new List<string>();

            bool enteringStitchType;
            while (enteringStitchType = true) 
            {
                string? stitchInput = Console.ReadLine();
                if (string.IsNullOrEmpty(stitchInput)) 
                {
                    break;
                }
                stitches.Add(stitchInput);
            }

            if (stitches.Count == 0)
            {
                Console.Write("No ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("stitches");
                Console.ResetColor();
                Console.WriteLine(" entered");
                return;
            }

            string stitchType = stitches[rnd.Next(stitches.Count)];

            Console.Write("Please input the maximum ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("amount of rows");
            Console.ResetColor();
            Console.WriteLine(" for your color");
            int maxRows;
            while (!int.TryParse(Console.ReadLine(), out maxRows))
            {
                Console.WriteLine("Please input a valid number.");
            }
            int rowAmount = rnd.Next(1, (maxRows + 1));

            var generatePattern = new Method();
            Console.WriteLine("How many times would you like to generate?");
            Thread.Sleep(500);
            Console.WriteLine("(For example, if you want to make a pattern for your next 5 colors)");
            int generateTimes;
            while (!int.TryParse(Console.ReadLine(), out generateTimes))
            {
                Console.WriteLine("Please input a valid number.");
            }
            Console.WriteLine("Here is your costum pattern!");
            for (int i = 0; i < generateTimes; i++)
            {
                int rowAmountTwo = rnd.Next(1, (maxRows + 1));
                string stitchTypeTwo = stitches[rnd.Next(stitches.Count)];
                string yarnColorTwo = colors[rnd.Next(colors.Count)];
                generatePattern.GeneratePattern(rowAmountTwo, stitchTypeTwo, yarnColorTwo);
                Console.WriteLine();
            }
            Console.WriteLine("You can now find your updated pattern in the pattern.txt file.");
        }

    }
}