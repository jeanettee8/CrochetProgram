namespace CrochetProgram
{
    public class Method
    {
        public void GeneratePattern(int rowAmount, string stitchType, string yarnColor)
        {
            string finishedPattern = ($"Color: {yarnColor}\nStitch type: {stitchType}\nAmount of rows: {rowAmount}\n\n");
            Console.WriteLine(finishedPattern);
            string filePath = "pattern.txt";
            File.AppendAllText(filePath, finishedPattern);
        }

    }
}