using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileOperations
{
    public class BinaryFileProcessor : IDataProcessor
    {
      
       public void Process(string inputFilePath, string outputFilePath)
        {
            using(FileStream input= File.Open(inputFilePath, FileMode.Open, FileAccess.Read))
            using(FileStream output= File.Create(outputFilePath))
            {
                try
                {
                    const int endOfStream = -1;
                    int largestByte = 0;
                    int currentByte = input.ReadByte();
                    while (currentByte != endOfStream)
                    {
                        output.WriteByte((byte)currentByte);
                        if (largestByte < currentByte)
                        {
                            largestByte = currentByte;
                        }
                        currentByte = input.ReadByte();
                    }
                    output.WriteByte((byte)largestByte);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
              
            }
        }

        public void ProcessByBinaryStream(string inputFilePath, string outputFilePath)
        {
            using (FileStream input = File.Open(inputFilePath, FileMode.Open, FileAccess.Read))
            using(BinaryReader inputBinReader= new BinaryReader(input))
            using (FileStream output = File.Create(outputFilePath))
            using(BinaryWriter outputBinaryWriter= new BinaryWriter(output))
            {
                try
                {
                    int largestByte = 0;
                    int currentByte = inputBinReader.ReadByte();
                    while (inputBinReader.BaseStream.Position < inputBinReader.BaseStream.Length)
                    {
                        outputBinaryWriter.Write((byte)currentByte);
                        if (largestByte < currentByte)
                        {
                            largestByte = currentByte;
                        }
                        currentByte = inputBinReader.ReadByte();
                    }
                    outputBinaryWriter.Write((byte)largestByte);
                    Console.WriteLine("processed binary file");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
