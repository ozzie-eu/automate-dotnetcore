using System;
using System.IO;

namespace flatten_folder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2) 
            {

                string[] fileNames = Directory.GetFiles(args[0], args[1]);

                // Display all files.
                Console.WriteLine("--- Files: ---");
                foreach (string file in Directory.EnumerateFiles(args[0], args[1],SearchOption.AllDirectories))
                {                    
                    //Mind if the file exists to not overwrite different files with the same name
                    string newName = Path.GetFileName(file);
                    int i=1;
                    while(File.Exists(Path.Combine(args[0],newName))) 
                    {
                        newName = i.ToString() + Path.GetFileName(file); 
                        i++;
                    }

                    //Move the file
                    Console.WriteLine($"Moving file {file} to folder {args[0]}");
                    File.Move(file,Path.Combine(args[0],newName));
                }
            } 
            else 
            {
                Console.WriteLine("Usage: dotnet run <path to folder> <file selector>");
            }
        }
    }
}
