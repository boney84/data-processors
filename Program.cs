using System;

namespace FileOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"C:\Users\boney\source\repos\Excercise files\input_data.txt";
            string outputFilePath = @"C:\Users\boney\source\repos\DataFiles\test.txt";
            TextFileProcessor processor = new TextFileProcessor();
            processor.ProcessByMemoryStream(outputFilePath);
            //BinaryFileProcessor processor = new BinaryFileProcessor();
            //processor.ProcessByBinaryStream(inputFilePath, outputFilePath);
            Console.ReadLine();
        }
    }
}
