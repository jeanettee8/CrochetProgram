namespace CrochetProgram
{
    public class HelperMethods
    {
        public void GeneratePattern(int rowAmount, string stitchType, string yarnColor)
        {
            string finishedPattern = ($"Color: {yarnColor}\nStitch type: {stitchType}\nAmount of rows: {rowAmount}\n\n");
            Console.WriteLine(finishedPattern);
            string filePath = "pattern.txt";
            File.AppendAllText(filePath, finishedPattern);
        }

        public void ColorText(string redTxt)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(redTxt);
            Console.ResetColor();
        }

    }
}