using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace CrochetProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Crochet Program!");
            Console.WriteLine();
            Console.WriteLine("Would you like to delete the old pattern.txt file?");
            string? deleteTxtFileInput = Console.ReadLine();
            string[] yesInput = { "yes", "yup", "ja", "jepp", "ok"};
            if (yesInput.Contains(deleteTxtFileInput, StringComparer.InvariantCultureIgnoreCase))
            {
                File.Delete("pattern.txt");
                Console.WriteLine("pattern.txt file successfully deleted!");
                Console.WriteLine();
            }

            var colorText = new HelperMethods();

            Console.Write("Please input the different ");
            colorText.ColorText("colors");
            Console.WriteLine(" you're choosing from.");
            Console.WriteLine("Press enter again when you're done!");

            List<string> colors = new List<string>();

            bool enteringYarnColor = true;
            while (enteringYarnColor)
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
                Console.Write("No ");
                colorText.ColorText("colors");
                Console.WriteLine(" entered");
                return;
            }
        
            Console.Write("Please input the different ");
            colorText.ColorText("stitches");
            Console.WriteLine(" you're choosing from.");
            Console.WriteLine("Press enter again when you're done!");

            List<string> stitches = new List<string>();


            bool enteringStitchType = true;
            while (enteringStitchType) 
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
                colorText.ColorText("stitches");
                Console.WriteLine(" entered");
                return;
            }


            Console.Write("Please input the ");
            colorText.ColorText("minimum amount of rows");
            Console.WriteLine(" for your color");
            int minRows;
            while (!int.TryParse(Console.ReadLine(), out minRows))
            {
                Console.WriteLine("Please input a valid number.");
            }

            Console.Write("Please input the ");
            colorText.ColorText("maximum amount of rows");
            Console.WriteLine(" for your color");
            int maxRows;
            while (!int.TryParse(Console.ReadLine(), out maxRows))
            {
                Console.WriteLine("Please input a valid number.");
            }

            var generatePattern = new HelperMethods();
            Console.WriteLine("How many times would you like to generate?");
            Console.WriteLine("(For example, if you want to make a pattern for your next 5 colors)");
            int generateTimes;
            while (!int.TryParse(Console.ReadLine(), out generateTimes))
            {
                Console.WriteLine("Please input a valid number.");
            }
            
            Random rnd = new Random();

            Console.WriteLine("Here is your costum pattern!");
            for (int i = 0; i < generateTimes; i++)
            {
                string yarnColor = colors[rnd.Next(colors.Count)];
                string stitchType = stitches[rnd.Next(stitches.Count)];
                int rowAmount = rnd.Next(minRows, (maxRows + 1));
                generatePattern.GeneratePattern(rowAmount, stitchType, yarnColor);
                Console.WriteLine();
            }
            Console.WriteLine("You can now find your updated pattern in the pattern.txt file.");
        }

    }
}