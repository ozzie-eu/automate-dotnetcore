using System;
using System.IO.Compression;

namespace compress_folder_zip
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
                Console.WriteLine("Usage: dotnet run <path to folder> <zip archive name>");
            else 
            {
                string originPath = args[0];
                string zipName = args[1];
                
                ZipFile.CreateFromDirectory(originPath, zipName);
            }
        }
    }
}
