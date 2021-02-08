using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileOperations
{
   internal  class TextFileProcessor : IDataProcessor
    {
        public void Process(string inputFilePath, string outputFilePath)
        {
            string line = string.Empty;
           
            using (var streamreader= new StreamReader(inputFilePath))
            using (var streamWriter = new StreamWriter(outputFilePath))
            {
                while (!streamreader.EndOfStream)
                {
                   line= streamreader.ReadLine();
                   line = line.ToUpperInvariant();
                   streamWriter.Write(line);
                }
                streamWriter.Flush();
            }
        }

        public void ProcessByMemoryStream(string output)
        {
            using(MemoryStream memoryStream= new MemoryStream())
            using (var streamWriter= new StreamWriter(memoryStream))
             using(FileStream fStream= File.Open(output,FileMode.Create))
            {
                streamWriter.WriteLine("Line1");
                streamWriter.Write("Line2");
                streamWriter.Flush();
                Console.Write("Stream :");
                memoryStream.WriteTo(fStream);
            }
        }
    }
}
