using System;
using System.IO;

namespace date_named_folders
{
    class Program
    {
        //In case you prefer another naming for your folders based on the date, 
        //change this constant accordingly.
        private const string Format = "yyyyMMdd";

        static void Main(string[] args)
        {

            if (args.Length == 2) 
            {

                string[] fileNames = Directory.GetFiles(args[0], args[1]);

                // Display all files.
                Console.WriteLine("--- Files: ---");
                for (int i = 0; i < fileNames.Length; i++)
                {
                    string name = fileNames[i];
                    DateTime creationTime = File.GetCreationTime(name);
                    string folderName = Path.Combine(args[0], creationTime.ToString(Format));
                    
                    if (!Directory.Exists(folderName)) 
                    {
                        //Create the folder
                        Console.WriteLine($"Creating folder {folderName}");
                        Directory.CreateDirectory(folderName);
                    }
                    
                    //Move the file
                    Console.WriteLine($"Moving file {name} to folder {folderName}");
                    File.Move(name,Path.Combine(folderName,Path.GetFileName(name)));
                }
            } 
            else 
            {
                Console.WriteLine("Usage: dotnet run <path to folder> <file selector>");
            }

        }
    }
}
