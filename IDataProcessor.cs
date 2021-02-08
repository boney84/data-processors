using System;
using System.Collections.Generic;
using System.Text;

namespace FileOperations
{
   public interface IDataProcessor
    {
        void Process(string inputFilePath, string outputFilePath);
    }
}
